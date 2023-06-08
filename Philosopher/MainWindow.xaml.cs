using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Philosopher
{
    public partial class MainWindow : Window
    {
        private const int MaxEatCount = 3; // Количество раз, которое философ должен поесть
        private Semaphore forkSemaphore = new Semaphore(2, 2);
        private int eatCount = 0; // Счетчик съеденной пасты
        private int spaghettiPercent = 100; // Процент пасты

        // Создаем объекты для представления вилок
        private readonly Fork fork1 = new Fork();
        private readonly Fork fork2 = new Fork();
        private readonly Fork fork3 = new Fork();
        private readonly Fork fork4 = new Fork();
        private readonly Fork fork5 = new Fork();

        public MainWindow()
        {
            InitializeComponent();
            InitializeProgressBars();
            StartButton.Click += StartButton_Click;
        }

        private void InitializeProgressBars()
        {
            pbSpaghetti.Value = spaghettiPercent;
            pbPhilosopher1.Value = 0;
            pbPhilosopher2.Value = 0;
            pbPhilosopher3.Value = 0;
            pbPhilosopher4.Value = 0;
            pbPhilosopher5.Value = 0;
        }

        private async void StartButton_Click(object sender, RoutedEventArgs e)
        {
            StartButton.IsEnabled = false; // Блокируем кнопку, чтобы ее нельзя было нажать повторно

            // Создаем задачу для каждого философа
            Task[] philosopherTasks =
            {
                Task.Run(() => PhilosopherLogic(pbPhilosopher1, "Philosopher #1", "Aqua")),
                Task.Run(() => PhilosopherLogic(pbPhilosopher2, "Philosopher #2", "Red")),
                Task.Run(() => PhilosopherLogic(pbPhilosopher3, "Philosopher #3", "BurlyWood")),
                Task.Run(() => PhilosopherLogic(pbPhilosopher4, "Philosopher #4", "DarkOrange")),
                Task.Run(() => PhilosopherLogic(pbPhilosopher5, "Philosopher #5", "LawnGreen"))
            };

            // Ожидаем завершения всех задач
            await Task.WhenAll(philosopherTasks);

            StartButton.IsEnabled = true; // Разблокируем кнопку после окончания работы философов
        }


        private void PhilosopherLogic(ProgressBar progressBar, string philosopherName, string color)
        {
            while (spaghettiPercent > 0)
            {
                Think(philosopherName);

                // Взять левую вилку
                forkSemaphore.WaitOne();

                // Проверить доступность правой вилки
                if (forkSemaphore.WaitOne(0))
                {
                    Eat(philosopherName, progressBar);

                    // Освободить вилки
                    forkSemaphore.Release();
                    forkSemaphore.Release();
                }
                else
                {
                    // Освободить левую вилку, если правая недоступна
                    forkSemaphore.Release();
                }
            }
        }

        private void Eat(string philosopherName, ProgressBar progressBar)
        {
            // Обновляем UI в главном потоке
            Application.Current.Dispatcher.Invoke(() =>
            {
                UpdateStatus(philosopherName, "Eating");
                progressBar.Value = eatCount * 100 / MaxEatCount;
                pbSpaghetti.Value = spaghettiPercent;
            });

            // Имитируем прием пищи
            Thread.Sleep(new Random().Next(1000, 2001));

            // Уменьшаем количество оставшейся пасты
            lock (this)
            {
                spaghettiPercent -= new Random().Next(5, 11); // Убавляем случайное количество пасты (5-10%)
                if (spaghettiPercent < 0)
                    spaghettiPercent = 0;
            }

            eatCount++;
        }

        private void Think(string philosopherName)
        {
            // Обновляем UI в главном потоке
            Application.Current.Dispatcher.Invoke(() =>
            {
                UpdateStatus(philosopherName, "Thinking");
            });

            // Имитируем размышления философа
            Thread.Sleep(new Random().Next(1000, 2001));
        }

        

        private void UpdateStatus(string philosopherName, string status)
        {
            switch (philosopherName)
            {
                case "Philosopher #1":
                    lblPhilosopher1.Content = $"{philosopherName}: {status}";
                    break;
                case "Philosopher #2":
                    lblPhilosopher2.Content = $"{philosopherName}: {status}";
                    break;
                case "Philosopher #3":
                    lblPhilosopher3.Content = $"{philosopherName}: {status}";
                    break;
                case "Philosopher #4":
                    lblPhilosopher4.Content = $"{philosopherName}: {status}";
                    break;
                case "Philosopher #5":
                    lblPhilosopher5.Content = $"{philosopherName}: {status}";
                    break;
            }
        }
    }

    // Класс для представления вилки
    public class Fork
    {
        private readonly object lockObject = new object();
        private bool isAvailable = true;

        public void Acquire()
        {
            lock (lockObject)
            {
                while (!isAvailable)
                {
                    Monitor.Wait(lockObject);
                }
                isAvailable = false;
            }
        }

        public bool TryAcquire()
        {
            lock (lockObject)
            {
                if (isAvailable)
                {
                    isAvailable = false;
                    return true;
                }
                return false;
            }
        }

        public void Release()
        {
            lock (lockObject)
            {
                isAvailable = true;
                Monitor.PulseAll(lockObject);
            }
        }
    }
}
