   M S B A M L   `   `   `  ����D  @Art_space, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:Art_space	Art_space  5   	       Art_space.MainWindow   5   	   Z VDevExpress.Mvvm.UI, Version=23.2.0.0, Culture=neutral, PublicKeyToken=382ad28f6ae31f30W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:Art_space     5   	     � Title$  ARTSPACE��5   	   $	��650��6   $
��1000��6'    � WindowStartupLocation$ CenterScreen=�64    � Icon$ 	/icon.png��6Y   $	��650��6j   $
��1000��6z   .��5	      � ���#E2E2E2 � ColumnDefinitions 5
   
   �� 5      $��* �6   �� 5      $��3* �6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��3* �6   .+�5   
   �� ���#DD5030$��0��6&   $��0��63   $��2��6C   �� 5   
   ���#E2E2E2$��1��6&   $��0��63   $��2��6C   �� 5   
    �� Orientation$ Vertical=�6   $
��Left=�6,   $��Center=�6G   $��3q�6b   $��0��6m   $��0��6z   $��2��6�   .+�5      �� $��ARTSPACE��6   $��Italic$�6(   $��38(�6;   $
��Bold"�6I   �� 5      $0��*Лучшее решение для вас.��6   $
��Wrap=�67   5      �� 5   
   $ Vertical=�6   $��Center=�6,   $��Center=�6I   $��1��6d   $��0��6q   .+�5      �� -   5         ��Name$ bEnter��5      $"��Войти в аккаунт��6%      
GrayButton#��[  6?   $��5q�6c   $��35��6n   $	��150��6z   6�   �� 5      -   5        $ bRegistration��5      $*��$Зарегистрироваться��6,   #��[  6I   $��5q�6m   $��35��6x   $	��150��6�   6�   5      � 5    
   $��0��6   $��1��6   $��Center=�6,   $��Center=�6G    5!      �� 5"      $
��Auto �6    �� 5#      $��* �6    .+�5&      �� $C��=Самые просматриваемые экспонаты:��6   $
��Wrap=�6@   $��Medium"�6T   $��0��6h   $��Center=�6u   $��Center=�6�   �� 5(      -   5         ��Name$ lvTop��5(      $��Disabled=�6L   $��1��6�   ��6&   �� *UCTopExhibits+��5)      �� 5*      .R�5+      � 5,      5.      5/      � 51   
   $��1��6   $��1��6    52      �� 53      $
��Auto �6    �� 54      $��* �6    .+�57      �� ���#909090$��0��6*    �� CornerRadius$ 
0, 0, 0, 5��67   �� 58      $ 
Horizontal=�6   $��0��62   $��Center=�6?   $
��Left=�6Z   $��5q�6u   .+�59      �� $ 
Horizontal=�6   $��3q�66   .+�5:      �� $��
0, 0, 0, 1q�6   
���   �$	��150��6N   	 �� TextWrapping$	 NoWrap=�6Z   ��6p   �� *Search+
 �� Mode$
 TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=��� 5;      $
��🔍��6    $��17��6*   5<      �� 5=      -   5         ��Name$ cbFilter��5=      $	��150��6-   $��3q�69   ��6D   �� *	Filters+ �� SelectedItem 6d   �� *SelectedFilter+5>      �� 5@      -   5        $ 
lvExhibits��5@      $��Disabled=�6N   $��Stretch=�6�   $��Stretch=�6�   $��1��6�   ��6+   �� *
UCExhibits+��5A      �� 5B      .R�5C      � 5D      5F      5G       � 5I   
   -   5          �Name$ frameForEveryone��5I        � NavigationUIVisibility$ Hidden=�6*   $��1��6J   $��1��6W    � 5J   
   -   5        $ frameForAccount��5J      $ Hidden=�6)   $��1��6I   $��0��6V    � 5K   
   -   5        $( "frameToAuthorizationOrRegistration��5K      $ Hidden=�6<   $��1��6\   $��0��6i   $��2��6y   5L      5M      