   M S B A M L   `   `   `  ����C  ?Restopay, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:RestopayRestopay  5          Restopay.CartPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      (localclr-namespace:Restopay     5        N� Title$  CartPage��5	      .��5      � ���	#FFBDC6DA$��
0,0,0,-155q�6"   .+�5   
   �� $
��CART��6   $
��Bold"�6   $��Showcard Gothic)�61   $��18(�6N   $
��Left=�6\   $��
359,10,0,0q�6w   $	��Top=�6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ gridBill��5   *   ���	#FFBDC6DA$
��Left=�6=   $	��268��6X   $��
186,41,0,0q�6e   $	��Top=�6y   $	��408��6�   $��14(�6�      AutoGenerateColumns .     Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$
 Name��6%      
IsReadOnly .    Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6^   1  +System.Windows.Controls.DataGridBoundColumn   Binding 63   �� *Name+6^     5      $ 	Price,CAD��6%    . $ 80 6d    68   �� *Price+6d     5      $ Quantity��6%   $ 70 6T    67   �� *
Quantity+6T     5      $ Subtotal,CAD��6%    . $	 100 6h    6;   �� *Amount+6h   4  .System.Windows.Controls.DataGridTemplateColumn  5         CellTemplate 5      �� 5      .R�5      �� -   5        .��5   7   X6:   5      5      5      �� 5   
   -   5        $
��Back��5      $
��Left=�6    $��186,392,0,0q�6;   $	��Top=�6P   $��75��6h   6s   �� 5   
   -   5        $��
Remove all��5      $
��Left=�6&   $��186,340,0,0q�6A   $	��Top=�6V   $��75��6n   6y   �� 5   
   -   5        $��paymentMethod��5   %   	 �� SelectedIndex$	 0��6   $
��Left=�6;   $��373,426,0,0q�6V   $	��Top=�6k   $	��120��6�   @�5       �� 5!      .��6   PayPal6'   �� 5"      .��6   Credit/Debit Card62   5$      �� 5%   
   $��Payment method :��6   $
��Left=�6+   $��264,423,0,0q�6F   $	��Top=�6[   �� 5&   
   -   5        $	��Pay��5&      $	��Pay��6   $
��Left=�6*   $��519,426,0,0q�6E   $	��Top=�6Z   $��75��6r   6}   �� 5'   
   -   5        
 ��Name$
 txAmount��5'       �� TextAlignment$ Right=�6z   $
��Left=�6�   $��522,336,0,0q�6�   $
��Wrap=�6�   $	��Top=�6�   $��70��6�   ���	#FFA8F07F$��14(�6  ��6&   ��  �� Path$ subtotal� �� Mode$ OneWay=� �� UpdateSourceTrigger$ PropertyChanged=�6  �� 5(   
   -   5        $
 txTax��5(      $ Right=�6k   $
��Left=�6�   $��522,357,0,0q�6�   $
��Wrap=�6�   $	��Top=�6�   $��70��6�   ���	#FFA8F07F$��14(�6�   ��6#   �� *Tax+$ OneWay=�$ PropertyChanged=�6�   �� 5)   
   -	   5        $
 txTotal��5)      $ Right=�6o   $
��Left=�6�   $��522,378,0,0q�6�   $
��Wrap=�6�   $	��Top=�6�   $��70��6�   ���	#FFA8F07F$
��Bold"�6  $��14(�6  ��6%   �� *Total+$ OneWay=�$ PropertyChanged=�6  �� 5*   
   $��	Subtotal:��6   $
��Left=�6$   $��459,333,0,0q�6?   $	��Top=�6T   �� 5+   
   $
��Tax:��6   $
��Left=�6   $��459,353,0,0q�6:   $	��Top=�6O   �� 5,   
   $��Total:��6   $
��Left=�6!   $��459,374,0,0q�6<   $	��Top=�6Q   $
��Bold"�6i   5.      5/      