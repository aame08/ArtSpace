   M S B A M L   `   `   `  ����D  @Art_space, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:Art_space.ViewsArt_space.Views  5      '    !Art_space.Views.ManagingFavorites   5      Z VDevExpress.Mvvm.UI, Version=23.2.0.0, Culture=neutral, PublicKeyToken=382ad28f6ae31f30W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      /localclr-namespace:Art_space.Views     5        N� Title$  ManagingFavorites��5	      .��5      � ���#E2E2E2 � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��3* �6    � ColumnDefinitions 5   
   �� 5      $��5 �6   �� 5      $��3* �6   �� 5      $��5 �6   .+�5   
   �� $+��%Избранные экспонаты��6   $��28(�6/   $
��Bold"�6=   $��0��6O   $��0��6\   $��3��6l   $��Center=�6�   $��Center=�6�   $��
0, 5, 0, 5q�6�   �� 5   
    �� Orientation$ 
Horizontal=�6   $��1��6.   $��1��6;   $��Right=�6K   $��Center=�6g   .+�5      �� $"��Сортировать по:��6   $��14(�6/   $��
0, 5, 5, 5q�6=   $��17��6Q   �� 5      $��20��6f   $	��150��6r   $��
0, 5, 5, 5q�6~   ��6   �� *Sorts+ �� SelectedItem 65   �� *SelectedSortForFavorite+6~   5      �� 5   
   $��Disabled=�6   $��Stretch=�6I   $��2��6g   $��1��6t   $��Stretch=�6�   $��
0, 5, 0, 5q�6�   ��6�   �� *	Favorites+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=� 6  �� *SelectedFavorite+��5      �� 5       .R�5!      �� $ Vertical=�6!   5"      ��5$      �� 5%      .R�5&      �� ���#242424$��1q�63    �� CornerRadius$ 3��6G   ._�5'      �  5(      �� 5)   "   $��* �63   �� 5*   "   $��* �63    5,      �� 5-   "   $
��Auto �60   �� 5.   "   $
��Auto �60   �� 5/   "   $
��Auto �60   �� 50   "   $
��Auto �60   .+�53      �� $��1q�6%   
���   �$ 5��6M   $��
5, 5, 5, 5q�6^    �� Padding$ 0q�6r   $��0��6~   $��0��6�   $��4��6�   $	��250��6�   $	��250��6�   ._�54   "   �� $	��250��6h   $	��250��6u   ��6(   �� *.,IdExhibitNavigation.Images[0].DisplayedImage+6u   55      �� 57      $��12(�6(   $��0��66   $��1��6C   $��
0, 5, 5, 5q�6S   $
��Wrap=�6g   �� 58   "   $$�Дата добавления:��6&    �� 59   "   �6&   �� *DateAddition+5:      �� 5<      $��1(�6W   $��3��6d   $��1��6q   ��6(   �� *IdExhibitNavigation.IdExhibit+6q   �� 5=      $��18(�6Y   $
��Bold"�6g   $��1��6y   $��1��6�   $
��Wrap=�6�   $��
0, 5, 5, 5q�6�   ��6(   �� *!IdExhibitNavigation.NameExhibit+6�   �� 5?      $.��(Удалить из Избранного��6%      
GrayButton#��[  6E   $��30��6i   $��2��6u   $��1��6�   $
��Left=�6�   $��Center=�6�   ��6�   �� *DataContext.RemoveFavoriteWnd+	 �� RelativeSource	 �� 
 �� AncestorType"
 ��5@      5A      5B      5D      5E      5F      