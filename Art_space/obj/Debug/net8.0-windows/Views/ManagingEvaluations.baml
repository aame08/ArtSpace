   M S B A M L   `   `   `  ����D  @Art_space, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:Art_space.ViewsArt_space.Views  5      )    #Art_space.Views.ManagingEvaluations   5      Z VDevExpress.Mvvm.UI, Version=23.2.0.0, Culture=neutral, PublicKeyToken=382ad28f6ae31f30W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      /localclr-namespace:Art_space.Views     5        N� Title$  ManagingEvaluations��5	      .��5      � ���#E2E2E2 � ColumnDefinitions 5   
   �� 5      $��5 �6   �� 5      $��3* �6   �� 5      $��5 �6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��3* �6   .+�5   
   �� $)��#Оставленные оценки��6   $��28(�6.   $
��Bold"�6<   $��0��6N   $��0��6[   $��3��6k   $��Center=�6   $��Center=�6�   $��
0, 5, 0, 5q�6�   �� 5   
   $��Disabled=�6   $��Stretch=�6I   $��1��6g   $��1��6t   $��Stretch=�6�   $��
0, 5, 0, 5q�6�   ��6�   �� *Evaluations+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=� �� SelectedItem 6  �� *EvaluationForEdit+$ TwoWay=���5      �� 5      .R�5      ��  �� Orientation$ Vertical=�6!   5      ��5      �� 5      .R�5       �� ���#242424$��1q�63    �� CornerRadius$ 3��6G   ._�5!      �  5"      �� 5#   "   $��* �63   �� 5$   "   $��* �63    5&      �� 5'   "   $
��Auto �60   �� 5(   "   $
��Auto �60   �� 5)   "   $
��Auto �60   .+�5,      �� $��1q�6%   
���   �$ 5��6M   $��
5, 5, 5, 5q�6^    �� Padding$ 0q�6r   $��0��6~   $��0��6�   $��3��6�   $	��250��6�   $	��250��6�   ._�5-   "   �� $	��250��6h   $	��250��6u   ��6(   �� *.,IdExhibitNavigation.Images[0].DisplayedImage+6u   5.      �� 50      $��18(�6(   $
��Bold"�66   $��0��6H   $��1��6U   $
��Wrap=�6e   $��
0, 5, 5, 5q�6y   $
��Left=�6�   $��Center=�6�   �� 51   "   �6&   �� *!IdExhibitNavigation.NameExhibit+ �� 52   "   $��1(�6U   
������ �6&   �� *IdExhibitNavigation.IdExhibit+6b   53      �� 55      $��1��57   '   $��1��64   $��30��6E   $	��200��6R   $
��Left=�6^   $��Center=�6y   ��55   '   �� *DataContext.ScoreEvaluations+	 �� RelativeSource	 �� 
 �� AncestorType"
 �� �� SelectedIndex 56   '   �� *Score+$ PropertyChanged=�57   y   �� 59      $#��Изменить оценку��6%      
GrayButton#��[  6?   $��30��6c   $��2��6o   $��1��6|   $
��Left=�6�   $��Center=�6�   ��5:   %   �� *DataContext.EditEvalutionWnd+	 �� "
 ��5;      5<      5=      5?      5@      5A      