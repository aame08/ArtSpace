   M S B A M L   `   `   `  ����D  @Art_space, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:Art_space.ViewsArt_space.Views  5      !    Art_space.Views.AllExhibits   5      Z VDevExpress.Mvvm.UI, Version=23.2.0.0, Culture=neutral, PublicKeyToken=382ad28f6ae31f30W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      /localclr-namespace:Art_space.Views     5        N� Title$  AllExhibits��5	      .��5      � ���#E2E2E2 � ColumnDefinitions 5   
   �� 5      $��5 �6   �� 5      $��* �6   �� 5      $��5 �6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��2* �6   .+�5   
   �� $2��,Управление экспонатами.��6   $��0��63   $��1��6@   $��18(�6P   $
��Bold"�6^   $��Center=�6p   $��Center=�6�   $��
0, 5, 0, 5q�6�   �� 5   
   $��Добавление��6      
GrayButton#��[  6&   $��30��6J   $��1��6W   $��1��6d   $��
0, 5, 0, 5q�6t   $��Center=�6�   $
��Left=�6�   $	��115��6�   ��6�   �� *OpenAddExhibitWnd+�� 5   
    �� Orientation$ 
Horizontal=�6   $��1��6.   $��1��6;   $��
0, 5, 0, 5q�6K   $��Center=�6_   $��Right=�6z   .+�5      �� $ 
Horizontal=�6   $��3q�62   .+�5      �� $��
0, 0, 0, 1q�6   
���   �$	��150��6J    �� TextWrapping$ NoWrap=�6V   ��6l   �� *Search+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=��� 5      $
��🔍��6   $��17��6&   5      �� 5       -   5         ��Name$ cbFilter��5       $	��150��6)   $��3q�65   ��6@   �� *	Filters+ �� SelectedItem 6`   �� *SelectedFilter+$ TwoWay=�$ PropertyChanged=�5!      &   System.Windows.Controls.DataGrid  5#   
   $��2��6   $��1��6    ��60   �� *
Exhibits+ 6Q   �� *SelectedExhibit+	   Columns	 5$      0  *System.Windows.Controls.DataGridTextColumn  5%      ,  &System.Windows.Controls.DataGridColumn
   Header$
 ID��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$
 0.5* 6O   1  +System.Windows.Controls.DataGridBoundColumn   Binding 61   �� *	IdExhibit+6O     5&      $
 Название��6%   $
 1.5* 6W    67   �� *NameExhibit+6W     5'      $
 Год создания��6%   $
 1.5* 6\    6;   �� *YearCreation+6\     5(      $#
 Страна создания��6%   $ 2* 6b    6>   �� *CountryCreation+6b     5)      $
 
Эпоха��6%   $
 1.5* 6`    64   �� *IdEraNavigation.NameEra+6`     5*      $
 Жанр��6%   $
 1.5* 6c    63   �� *IdGenreNavigation.NameGenre+6c     5+      $
 Вид искусства��6%   $
 1.5* 6k    6<   �� *IdArtFormNavigation.NameAF+6k   4  .System.Windows.Controls.DataGridTemplateColumn  5,      $
 Действие��6)   $ * 6;      CellTemplate 5-      �� 5.      .R�5/      �� $��Изменить��6%   $��20��68   #��[  6D   ��6h   �� * DataContext.OpenEditExhibitWnd+ �� RelativeSource ��  �� AncestorType"  50      52      54      55      56      