   M S B A M L   `   `   `  ����H  DRestopayStaff, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:RestopayStaffRestopayStaff  5          RestopayStaff.WaiterPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -localclr-namespace:RestopayStaff     5        N� Title$  
WaiterPage��5	      .��5      � ���	#FFBDC6DA.+�5   
   �� $��WAITER PAGE��6   $
��Left=�6&   $��	10,10,0,0q�6A   $	��Top=�6T   $
��Bold"�6l   $��Showcard Gothic)�6~   $��14(�6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$
 grid��5   *   ���	#FFBDC6DA$
��Left=�69   $	��364��6T   $��0,58,0,0q�6a   $	��Top=�6s   $	��800��6�   $��14(�6�      AutoGenerateColumns .     Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Order#��6%      
IsReadOnly .    Width5  /System.Windows.Controls.DataGridLengthConverter$ 60 6g   1  +System.Windows.Controls.DataGridBoundColumn   Binding 65   �� *OrderNumber+6g     5      $
 Date��6%    . $	 165 6b    63   �� *
DateTime+6b     5      $
 Name��6%    . $	 170 6^    63   �� *Name+6^     5      $ Quantity��6%   $ 55 6T    67   �� *
Quantity+6T     5      $ Table#��6%    . $ 55 6g    65   �� *TableNumber+6g     5      $ Amount��6%    . $ 70 6b    65   �� *Amount+6b     5      $ Status��6%    . $ 90 6i    65   �� *WaiterStatus_+6i   4  .System.Windows.Controls.DataGridTemplateColumn  5      $ Change Status��6)   $ * 6@      CellTemplate 5      �� 5      .R�5      �� -   5        .��5   7   	COMPLETED6B   5      5      5!      �� 5#   
   -   5        $��Update��5#      $
��Left=�6"   $��
623,12,0,0q�6=   $	��Top=�6Q   $	��167��6i   $��14(�6�   ���	#FFA9DF3C6�   �� 5$   
   -   5        $
��Exit��5$      $
��Left=�6    $��
158,12,0,0q�6;   $	��Top=�6O   $��75��6g   $��14(�6�   ���	#FFF24A366�   �� 5%   
   -   5        $
��Menu��5%      $
��Left=�6    $��
273,12,0,0q�6;   $	��Top=�6O   $��75��6g   $��14(�6�   ���	#FFE6F0946�   5'      5(      