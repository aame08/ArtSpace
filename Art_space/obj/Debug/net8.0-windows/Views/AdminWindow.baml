   M S B A M L   `   `   `  ����D  @Art_space, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:Art_space.ViewsArt_space.Views  5   	   !    Art_space.Views.AdminWindow   5   	   Z VDevExpress.Mvvm.UI, Version=23.2.0.0, Culture=neutral, PublicKeyToken=382ad28f6ae31f30W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:Art_space.Views     5   	     � Title$  ARTSPACE��5   	   $	��650��6   $
��1000��6'    � WindowStartupLocation$ CenterScreen=�64    � Icon$ 	/icon.png��6Y   $	��650��6j   $
��1000��6z   .��5	      � ���#E2E2E2 � ColumnDefinitions 5
   
   �� 5      $��* �6   �� 5      $��3* �6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��3* �6   .+�5   
   �� ���#DD5030$��0��6&   $��0��63   $��2��6C   �� 5   
   $��ARTSPACE��6   $��Italic$�6$   $��38(�67   $
��Bold"�6E   $
��Left=�6W   $��Center=�6r   $��
5, 5, 0, 5q�6�   $��0��6�   $��0��6�   $��2��6�   �� 5   
   $(��"Администрирование��6   $��Oblique$�6-   $��36(�6A   $��Center=�6O   $��Center=�6l   $��0��6�   $��1��6�   $��
0, 5, 0, 5q�6�   �� 5   
    �� Orientation$ Vertical=�6   $��Center=�6,   $��Center=�6I   $��1��6d   $��0��6q   .+�5      �� $��Экспонаты��6      
GrayButton#��[  6)   $��5q�6M    � Cursor$
 Hand��6X   $��35��6f   $	��150��6r   ��6~   �� *ViewExhibitsWnd+�� 5      $-��'Отзывы пользователей��6   #��[  64   $��5q�6X   $
 Hand��6c   $��35��6q   $	��150��6}   ��6�   �� *ViewReviewsWnd+�� 5      $��
Выйти��6   #��[  6%   $��5q�6I   $
 Hand��6T   $��35��6b   $	��150��6n   ��6z   �� *	LogoutWnd+5       � 5   
   -   5          �Name$ frameForEveryone��5        � NavigationUIVisibility$ Hidden=�6*   $��1��6J   $��1��6W   5      5      