   M S B A M L   `   `   `  ����F  BPhilosopher, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:PhilosopherPhilosopher  5   	       Philosopher.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:Philosopher     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   .��5	      �  � RowDefinitions 5
   
   �� 5      6   �� 5      6   .+�5   
   �� $��Philosopher GAME��6   $��0��6,   $��50(�69   $��Center=�6G   $��Center=�6d   
�������6�   �� 5   
   $��0��6   $��Center=�6"    �� Orientation$ Vertical=�6?   .+�5      �� $��	Spaghetti��6   $��16(�6(   $��	ExtraBold"�66   $��Center=�6M   6l   � 5      -   5         �Name$ pbSpaghetti��5      $��20��6/   $	��300��6;    � Minimum$ 0Q�6G    � Maximum$	 100Q�6S   
��� � �6v   5      �� 5   
   -   5         ��Name$ StartButton��5      $��0��6   $��Start��63   $��50��6C   $��20��6N   $��Right=�6Z   $��Bottom=�6v   $��0 0 20 0q�6�   6�   �� 5   
   $��1��6   $ Vertical=�6"   $
��Left=�69   $��20 0 0 0q�6T   .+�5      �� -   5         ��Name$ lblPhilosopher1��5      $��Philosopher #1��6-   $��	ExtraBold"�6F   
����� �6q   � 5      -   5        $ pbPhilosopher1��5      $��20��62   $	��300��6>   $��0 0 0 10q�6J   $
��Left=�6\   $ 0Q�6w   $	 100Q�6�   
����� �6�   �� 5      -   5        $ lblPhilosopher2��5      $��Philosopher #2��6-   $��	ExtraBold"�6F   
���  ��6p   � 5      -   5        $ pbPhilosopher2��5      $��20��62   $	��300��6>   $��0 0 0 10q�6J   $
��Left=�6\   $ 0Q�6w   $	 100Q�6�   
���  ��6�   5      �� 5   
   $��1��6   $ Vertical=�6"   $��Right=�69   $��0 0 20 0q�6U   .+�5      �� -   5        $ lblPhilosopher3��5      $��Philosopher #3��6-   $��	ExtraBold"�6F   
�������6v   � 5      -   5        $ pbPhilosopher3��5      $��20��62   $	��300��6>   $��0 0 0 10q�6J   $
��Left=�6\   $ 0Q�6w   $	 100Q�6�   
�������6�   �� 5      -	   5        $ lblPhilosopher4��5      $��Philosopher #4��6-   $��	ExtraBold"�6F   
��� ���6w   � 5      -
   5        $ pbPhilosopher4��5      $��20��62   $	��300��6>   $��0 0 0 10q�6J   $
��Left=�6\   $ 0Q�6w   $	 100Q�6�   
��� ���6�   5       �� 5!   
   $��1��6   $ Vertical=�6"   $��Bottom=�69   $��Center=�6T   .+�5"      �� -   5        $ lblPhilosopher5��5"      $��Philosopher #5��6-   $��	ExtraBold"�6F   
��� �|�6v   � 5#      -   5        $ pbPhilosopher5��5#      $��20��62   $	��300��6>   $��0 0 0 20q�6J   $
��Left=�6\   $ 0Q�6w   $	 100Q�6�   
��� �|�6�   5$      5%      5&      