   M S B A M L   `   `   `  ����D  @Art_space, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:Art_space.ViewsArt_space.Views  5           Art_space.Views.AllReviews   5      Z VDevExpress.Mvvm.UI, Version=23.2.0.0, Culture=neutral, PublicKeyToken=382ad28f6ae31f30W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      /localclr-namespace:Art_space.Views     5        N� Title$  
AllReviews��5	      .��5      � ���#E2E2E2 � ColumnDefinitions 5   
   �� 5      $��5 �6   �� 5      $��* �6   �� 5      $��5 �6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��2* �6   .+�5   
   �� $j��dУправление отзывами, на которые были оставлены жалобы.��6   $��0��6R   $��1��6_   $��18(�6o   $
��Bold"�6}   $��Center=�6�   $��Center=�6�   $��
0, 5, 0, 5q�6�   &   System.Windows.Controls.DataGrid  5   
   $��1��6   $��1��6    ��60   �� *	Reviews+ �� SelectedItem 6P   �� *SelectedReview+   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$
 0.5* 6N   1  +System.Windows.Controls.DataGridBoundColumn   Binding 61   �� *
IdReview+6N     5      $) #Название экспоната��6%   $
 1.5* 6u    6A   �� *!IdExhibitNavigation.NameExhibit+6u     5      $ Пользователь��6%   $
 1.5* 6f    6;   �� *IdUserNavigation.Login+6f   4  .System.Windows.Controls.DataGridTemplateColumn  5      $ Текст отзыва��6)   $ 2* 6?      CellTemplate 5      �� 5      .R�5       �� $
��Wrap=�6D   ��6(   �� *
TextReview+6D   5!      5#        5$      $ Действие��6)   $ 2* 6;    5%      �� 5&      .R�5'      �� 	 �� Orientation$	 Vertical=�6)   $��Center=�6@   $��Center=�6]   .+�5(   "   �� $��Вернуть��6)   $��20��6;   $��70��6G      
GrayButton#��[  6R   $��
0, 3, 0, 3q�6v   ��6�   �� *DataContext.ReturnReviewWnd+
 �� RelativeSource
 ��  �� AncestorType"  �� 5)   "   $��Удалить��6)   $��20��6;   $��70��6G   #��[  6R   $��
0, 3, 0, 3q�6v   ��6�   �� *DataContext.DeleteReviewWnd+
 �� "  5*      5+      5-      5/      50      51      