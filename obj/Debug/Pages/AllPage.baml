   M S B A M L   `   `   `  ����C  ?Agamotto, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:Agamotto.PagesAgamotto.Pages  5          Agamotto.Pages.AllPage   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .localclr-namespace:Agamotto.Pages     5        N� Title$  AllPage��5	      .��5      �  � ColumnDefinitions 5   
   �� 5      $	��22* �6   �� 5      $
��655* �6   �� 5      $	��23* �6    � RowDefinitions 5   
   �� 5      $��0* �6   �� 5      �� 5      $	��0.8 �6   �� 5      $	��0.5 �6   .+�5   
   o� $	��Top=�6   $��3��6'   $��23��6;   $
��Bold"�6G   $��0,5,0,0q�6Y   $��2��6j   ��5      �� 5       �� EndPoint$ 0.5,1&�6&    �� 
StartPoint$ 0.5,0&�67   .��5      �  � Color$ Black��6#    � Offset$ 1Q�61   � 5      $ 	#FFDEDE00��6#   $ 0.412Q�65   5      ��5      �� 5      .@�5!      m� -   5        $��Главная��5!      $��14(�6(   66   m� 5"      $��
Выход��6   $��14(�6&   5#      �� 5$   
   -   5         ��Name$ title��5$      $��Товары��6   $��1��60   $��107,28,35,354q�6@   ���	#FFDEDE00$��Center=�6n   $
��Bold"�6�   $��48(�6�   $��2��6�   &   System.Windows.Controls.DataGrid  5%   
   -   5          Name$ prodGrid��5%      	   AutoGenerateColumns	 .  $��1��6A   $
��Left=�5&      $��
0,100,0,10q�6.   $��1��5'      $
��Auto��6    
   Columns
 5(      0  *System.Windows.Controls.DataGridTextColumn  5*      ,  &System.Windows.Controls.DataGridColumn   Header$ Наименование��6>      Width5  /System.Windows.Controls.DataGridLengthConverter$ 2* 6T   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   �� *Name+6T     5+      $ Категория��6B   $ 2* 6U    6%   �� *
Category+6U     5,      $ Цена��6?   $
 1.3* 6M    6%   �� *Price+6M     5-      $  Производитель��6C   $
 1.5* 6Z    6%   �� *	BrandName+6Z     5.      $- 'Количество изменений��6H   $
 1.3* 6f    6%   �� *CountOfChanges+6f     5/      $+ %Последнее изменение��6>   $ 2* 6[    6%   �� *Date+6[    � ContextMenu 52      �� 53      .@�54      m� -   5        $��Просмотр��54      6F   m� 55      $��Удалить��6   62   m� 56      $��Изменить��6   63   57      59      �� 5:   
   -   5        $��
Назад��5:      $
��Left=�6!   $��0,53,0,0q�6<   $	��Top=�6N   $��80��6f   ���	#FFDEDE00$��32��6�   $��16(�6�   $
��Bold"�6�   $��1��6�   $��2��6�   ��5;      �� 5<      5>      5C      5D      