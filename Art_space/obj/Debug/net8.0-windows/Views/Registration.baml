   M S B A M L   `   `   `  ����D  @Art_space, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:Art_space.ViewsArt_space.Views  5      "    Art_space.Views.Registration   5      Z VDevExpress.Mvvm.UI, Version=23.2.0.0, Culture=neutral, PublicKeyToken=382ad28f6ae31f30W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      /localclr-namespace:Art_space.Views     5        N� Title$  Registration��5	      .��5      � ���#E2E2E2 � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��2* �6   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $��3* �6   �� 5      $
��0.5* �6   .+�5   
   �� $9��3Регистрация аккаунта в ArtSpace��6   $��38(�6;   $
��Bold"�6I   $��0��6[   $��0��6h   $��3��6x   $��Center=�6�   $��Center=�6�   �� 5   
    �� Orientation$ Vertical=�6   $��Center=�6,   $��Center=�6I   $��1��6d   $��1��6q   .+�5      �� $ 
Horizontal=�6   $��5q�62   .+�5      �� $%��Введите фамилию: ��6   $	��130��65   $��Center=�6A   $��Center=�6^   $��14(�6y   �� 5      $	��150��6   $��25��6&   ��62   �� *SurnameUser+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�5      �� 5      $ 
Horizontal=�6   $��5q�62   .+�5       �� $��Введите имя: ��6   $	��130��61   $��Center=�6=   $��Center=�6Z   $��14(�6u   �� 5!      $	��150��6   $��25��6&   ��62   �� *
NameUser+$ TwoWay=�$ PropertyChanged=�5"      �� 5$      $ 
Horizontal=�6   $��5q�62   .+�5%      �� $!��Введите почту: ��6   $	��130��63   $��Center=�6?   $��Center=�6\   $��14(�6w   �� 5&      $	��150��6   $��25��6&   ��62   �� *	LoginUser+$ TwoWay=�$ PropertyChanged=�5'      �� 5)      $ 
Horizontal=�6   $��5q�62   .+�5*      �� $#��Введите пароль: ��6   $	��130��64   $��Center=�6@   $��Center=�6]   $��14(�6x   �� 5+      -   5         ��Name$ 
tbPassword��5+      $	��150��6.   $��25��6:   $y�	Collapsed=�6F   G� 5,      -   5         G�Name$ 
pbPassword��5,       G� PasswordChar$ *��62   $	��150��6C   $��25��6O   6[   d� 5-      -   5        	 d�Name$	 toggleShowPassword��5-      $
��👁��6;   ��6H   Z� ��6_   Z� 6u   5.      �� 50      $ 
Horizontal=�6   $��15q�62   $��Center=�6>   .+�51      �� -   5        
 ��Name$
 bExit��51      $��Отмена��6(   $��35��69   $��65��6E      
GrayButton#��[  6P   $��5q�6t   6   �� 52      -   5        $
 bEnter��52      $*��$Зарегистрироваться��6)   $��35��6F   $	��130��6R   #��[  6^   $��5q�6�   ��6�   �� *RegistrationWnd+53      54      55      56      