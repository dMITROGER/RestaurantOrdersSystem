   M S B A M L   `   `   `  ����H  DRestopayStaff, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:RestopayStaffRestopayStaff  5          RestopayStaff.ManagerPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -localclr-namespace:RestopayStaff     5        N� Title$  ManagerPage��5	      .��5      � ���	#FFBDC6DA.+�5   
   �� $��MANAGER PAGE��6   $
��Left=�6'   $��	10,10,0,0q�6B   $	��Top=�6U   $
��Bold"�6m   $��Showcard Gothic)�6   $��14(�6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$
 grid��5   *   ���	#FFBDC6DA$
��Left=�69   $	��364��6T   $��0,76,0,0q�6a   $	��Top=�6s   $	��800��6�      AutoGenerateColumns .     Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Order #��6%      
IsReadOnly .    Width5  /System.Windows.Controls.DataGridLengthConverter$ 60 6h   1  +System.Windows.Controls.DataGridBoundColumn   Binding 66   �� *OrderNumber+6h     5      $
 Date��6%    . $	 170 6b    63   �� *
DateTime+6b     5      $
 Name��6%    . $	 170 6^    63   �� *Name+6^     5      $ Quantity��6%   $ 70 6T    67   �� *
Quantity+6T     5      $ Table #��6%    . $ 60 6h    66   �� *TableNumber+6h     5      $ 
CookStatus��6%    . $ 80 6k    69   �� *CookStatus_+6k     5      $ BartenderStatus��6%    . $ 80 6u    6>   �� *BartenderStatus_+6u   4  .System.Windows.Controls.DataGridTemplateColumn  5      $ Change Status��6)   $ * 6@      CellTemplate 5      �� 5      .R�5      �� -   5        .��5   7   
COMPLETE6A   5      5      5      �� 5!   
   -   5        $��Update��5!      $
��Left=�6"   $��
623,12,0,0q�6=   $	��Top=�6Q   $	��167��6i   $��14(�6�   ���	#FFA9DF3C6�   �� 5"   
   -   5        $
��Exit��5"      $
��Left=�6    $��
147,12,0,0q�6;   $	��Top=�6O   $��75��6g   $��14(�6�   ���	#FFF24A366�   �� 5#   
   -   5        	 ��Name$	 ArchidedOrders��5#      $��Archided Orders��6)   $
��Left=�6C   $��
363,12,0,0q�6^   $	��Top=�6r   $	��154��6�   $��14(�6�   ���	#FFE87F7F6�   �� 5$   
   -   5        $
��Menu��5$      $
��Left=�6    $��
254,12,0,0q�6;   $	��Top=�6O   $��75��6g   $��14(�6�   ���	#FFE6F0946�   �� 5%   
   $��Active orders��6   $
��Left=�6(   $��
345,40,0,0q�6C   $	��Top=�6W   
 J� RenderTransformOrigin$
 0.692,-0.152&�6o   $
��Bold"�6�   $��16(�6�   5&      5'      