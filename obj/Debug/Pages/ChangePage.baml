   M S B A M L   `   `   `  ����C  ?Agamotto, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:Agamotto.PagesAgamotto.Pages  5          Agamotto.Pages.ChangePage   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .localclr-namespace:Agamotto.Pages     5        N� Title$  
ChangePage��5	      .��5      �  � ColumnDefinitions 5   
   �� 5      $	��22* �6   �� 5      $
��655* �6   �� 5      $	��23* �6    � RowDefinitions 5   
   �� 5      $��0* �6   �� 5      �� 5      $	��0.8 �6   �� 5      $	��0.5 �6   .+�5   
   o� $	��Top=�6   $��3��6'   $��23��6;   $
��Bold"�6G   $��0,5,0,0q�6Y   $��2��6j   ��5      �� 5       �� EndPoint$ 0.5,1&�6&    �� 
StartPoint$ 0.5,0&�67   .��5      �  � Color$ Black��6#    � Offset$ 1Q�61   � 5      $ 	#FFDEDE00��6#   $ 0.412Q�65   5      ��5      �� 5      .@�5!      m� -   5        $��Главная��5!      $��14(�6(   66   m� 5"      $��
Выход��6   $��14(�6&   5#      �� 5$   
   -   5         ��Name$ title��5$      $��Изменения��6   $��1��63   $��197,28,225,354q�6C   ���	#FFDEDE00$��Center=�6r   $
��Bold"�6�   $��48(�6�   $��2��6�   &   System.Windows.Controls.DataGrid  5%   
   -   5          Name$ 
changeGrid��5%      	   AutoGenerateColumns	 .  $��1��6C   $
��Left=�5&      $��
0,100,0,10q�6.   $��1��5'      $
��Auto��6    
   Columns
 5(      0  *System.Windows.Controls.DataGridTextColumn  5*      ,  &System.Windows.Controls.DataGridColumn   Header$ 
Товар��6B      Width5  /System.Windows.Controls.DataGridLengthConverter$ 2* 6Q   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   �� *
prodName+6Q     5+      $ Дата��6>   $ 2* 6L    6%   �� *date+6L     5,      $ Цена до��6E   $
 1.3* 6V    6%   �� *PriceBefore+6V     5-      $ Повышение��6B   $
 1.5* 6U    6%   �� *
Increase+6U     5.      $ 
Сумма��6=   $
 1.3* 6L    6%   �� *Sum+6L   52      �� 53   
   -   5        $��
Назад��53      $
��Left=�6!   $��0,53,0,0q�6<   $	��Top=�6N   $��80��6f   ���	#FFDEDE00$��32��6�   $��16(�6�   $
��Bold"�6�   $��1��6�   $��2��6�   ��54      �� 55      57      58      59      