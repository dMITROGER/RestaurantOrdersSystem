   M S B A M L   `   `   `  ����H  DRestopayStaff, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:RestopayStaffRestopayStaff  5          RestopayStaff.DBAdminPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -localclr-namespace:RestopayStaff     5        N� Title$  DBAdminPage��5	      .��5      � ���	#FFBDC6DA.+�5   
   �� $��DBA PAGE��6   $
��Left=�6#   $��	10,10,0,0q�6>   $	��Top=�6Q   $
��Bold"�6i   $��Showcard Gothic)�6{   $��14(�6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$
 grid��5   *   ���	#FFBDC6DA$
��Left=�69   $	��345��6T   $��0,72,0,0q�6a   $	��Top=�6s   $	��800��6�   $��16(�6�      AutoGenerateColumns .     Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$
 Name��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6M   1  +System.Windows.Controls.DataGridBoundColumn   Binding 63   �� *Name+6M     5      $ Price��6%   $	 100 6N    64   �� *Price+6N   4  .System.Windows.Controls.DataGridTemplateColumn  5      $ Actions��6)   $	 151 6:      CellTemplate 5      �� 5      .R�5      ��  �� Orientation$ 
Horizontal=�6)   .+�5   "   �� -   5        .��5   =   Delete6E   �� 5   "   -   5        .��5   =   Update6E   �� 5   "   -   5        .��5   =   Insert6E   5      5      5      5       �� 5"   
   -   5        $
��Exit��5"      $
��Left=�6    $��
120,10,0,0q�6;   $	��Top=�6O   $��75��6g   $��16(�6�   ���	#FFF24A366�   �� 5#   
   -   5        	 ��Name$	 menuCategory��5#      $
��Left=�6)   $��
365,42,0,0q�6D   $	��Top=�6X   $	��120��6p   
 �� SelectedIndex$
 0��6|   $��16(�6�   @�5$      �� 5%      .��6   	Beverages6*   �� 5&      .��6   
Appetizers6+   �� 5'      .��6   MainCourses6,   �� 5(      .��6   
Desserts6)   5+      �� 5,   
   $��Menu category :��6   $
��Left=�6*   $��
230,38,0,0q�6E   $	��Top=�6Y   $��16(�6q   �� 5-   
   -   5        $
��Show��5-      $
��Left=�6    $��
513,44,0,0q�6;   $	��Top=�6O   $��75��6g   $��16(�6�   5/      50      