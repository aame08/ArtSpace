   M S B A M L   `   `   `  ����D  @Art_space, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:Art_space.ViewsArt_space.Views  5      %    Art_space.Views.ManagingReviews   5      Z VDevExpress.Mvvm.UI, Version=23.2.0.0, Culture=neutral, PublicKeyToken=382ad28f6ae31f30W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      /localclr-namespace:Art_space.Views     5        N� Title$  ManagingReviews��5	      .��5      � ���#E2E2E2 � ColumnDefinitions 5   
   �� 5      $��5 �6   �� 5      $��3* �6   �� 5      $��5 �6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��3* �6   .+�5   
   �� $)��#Оставленные отзывы��6   $��28(�6.   $
��Bold"�6<   $��0��6N   $��0��6[   $��3��6k   $��Center=�6   $��Center=�6�   $��
0, 5, 0, 5q�6�   �� 5   
    �� Orientation$ 
Horizontal=�6   $��1��6.   $��1��6;   $��Right=�6K   $��Center=�6g   .+�5      �� $"��Сортировать по:��6   $��14(�6/   $��
0, 5, 5, 5q�6=   $��17��6Q   �� 5      $��20��6e   $	��150��6q   $��
0, 5, 5, 5q�6}   ��6   �� *Sorts+ �� SelectedItem 65   �� *SelectedSortForReviews+6}   5      �� 5   
   $��Disabled=�6�   $��Stretch=�6�   $��2��6�   $��1��6�   $��Stretch=�6�   $��
0, 5, 0, 5q�6#  ��6   �� *	Reviews+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=� 6e   �� *SelectedReview+��5      �� 5       .R�5!      �� $ Vertical=�6!   5"      ��5$      �� 5%      .R�5&      �� ���#242424$��1q�63    �� CornerRadius$ 3��6G   ._�5'      �  5(      �� 5)   "   $
��Auto �63   �� 5*   "   $��2* �63    5,      �� 5-   "   $
��Auto �60   �� 5.   "   $��* �60   �� 5/   "   $��2* �60   �� 50   "   $��* �60   .+�53      �� $��1q�6%   
���   �$ 5��6M   $��
5, 5, 5, 5q�6^    �� Padding$ 0q�6r   $��0��6~   $��0��6�   $��4��6�   $	��200��6�   $	��200��6�   ._�54   "   �� $	��200��6h   $	��200��6u   ��6(   �� *.,IdExhibitNavigation.Images[0].DisplayedImage+6u   55      �� 57      $��12(�6(   $��0��66   $��1��6C   $��
0, 5, 5, 5q�6S   �� 58   "   $$�Дата добавления:��6&    �� 59   "   �6&   �� *
DateReview+5:      �� 5<      $��16(�6(   $
��Bold"�66   $��1��6H   $��1��6U   $
��Left=�6e   $��Center=�6�   $
��Wrap=�6�   $��
0, 5, 5, 5q�6�   �� 5=   "   �6&   �� *!IdExhibitNavigation.NameExhibit+ �� 5>   "   $��1(�6@   
������ �6&   �� *
IdReview+6M    �� 5?   "   $��1(�6U   
������ �6&   �� *IdExhibitNavigation.IdExhibit+6b   5@      �� 5B      $��2��6g   $��1��6t   $��Stretch=�6�   	 �� TextWrapping$
	 Wrap=�6�   $��
0, 5, 5, 5q�6�   ��6&   �� *
TextReview+$ PropertyChanged=�6�   �� 5D      $ Vertical=�6)   $��3��6@   $��1��6M   $��
0, 5, 5, 5q�6]   $��Center=�6q   $��Center=�6�   .+�5E   "   �� $+��%Сохранить изменения��6)      
GrayButton#��[  6G   $��
0, 0, 0, 5q�6k   $��25��6   ��6�   �� *DataContext.EditReviewWnd+
 �� RelativeSource
 ��  �� AncestorType" ���� 5F   "   $+��%Удалить комментарий��6)   #��[  6G   $��25��6k   ��6w   �� *DataContext.DeleteReviewWnd+
 �� " ��5G      5H      5I      5J      5L      5M      5N      