   M S B A M L   `   `   `  ����F  BSalesWPFApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:SalesWPFAppSalesWPFApp  5   	       SalesWPFApp.OrderDetail   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:SalesWPFApp     5   	     � Title$  OrderDetail��5   	   $	��300��6   $	��650��6*    � WindowStartupLocation$ CenterScreen=�5	   	   .��5
      �� $��10q�6   .+�5   
   �  � ColumnDefinitions 5      �� 5      $��* �6#   �� 5      $��* �6#    � RowDefinitions 5      �� 5      $��* �6    �� 5      $��* �6    �� 5      $��* �6    .+�5      �� $��0��6    �� Orientation$ 
Horizontal=�6)   $��5q�6B   .+�5      �� $	��ID:��6   $	��100��6&   �� 5      -   5         ��Name$ txtId��5       �� 
IsReadOnly$
 True��6)   $	��200��6;   ��6G   ��  �� Path$ OrderId� �� Mode$ OneWay=�	 � DataContext	 6r   �� 
 �� ElementName$
 lvOrders��$ SelectedItem�5      �� 5      $��1��6   $ 
Horizontal=�6)   $��5q�6B   .+�5      �� $��	Customer:��6   $	��100��6,   �� 5      -   5        $ txtCustomer��5      $
 True��6/   $	��200��6A   ��6M   �� $ MemberId�$ OneWay=�	 6y   �� $
 lvOrders��$ SelectedItem�5      �� 5       $��0��6   $��1��6)   $ 
Horizontal=�66   $��5q�6O   .+�5!      �� $��Order Date:��6   $	��100��6.   �� 5"      -   5        $ txtOrderDate��5"      $
 True��60   $	��200��6B   ��6N   �� $ 	OrderDate�$ OneWay=�	 6{   �� $
 lvOrders��$ SelectedItem�5#      �� 5%      $��1��6   $��1��6)   $ 
Horizontal=�66   $��5q�6O   .+�5&      �� $��Required Date:��6   $	��100��61   �� 5'      -   5        $ txtRequiredDate��5'      $
 True��63   $	��200��6E   ��6Q   �� $ RequiredDate�$ OneWay=�	 6�   �� $
 lvOrders��$ SelectedItem�5(      �� 5*      $��0��6   $��2��6)   $ 
Horizontal=�66   $��5q�6O   .+�5+      �� $��Shipped Date:��6   $	��100��60   �� 5,      -   5        $ txtShippedDate��5,      $
 True��62   $	��200��6D   ��6P   �� $ ShippedDate�$ OneWay=�	 6   �� $
 lvOrders��$ SelectedItem�5-      �� 5/      $��1��6   $��2��6)   $ 
Horizontal=�66   $��5q�6O   .+�50      �� $��Freight:��6   $	��100��6+   �� 51      -   5        $ 
txtFreight��51      $
 True��6.   $	��200��6@   ��6L   �� $ Freight�$ OneWay=�	 6w   �� $
 lvOrders��$ SelectedItem�52      53      &   System.Windows.Controls.DataGrid  54   
   -   5          Name$ dgOrderDetails��54         AutoGenerateColumns$ False��6+   $��10q�6G   $	��130��6S      Columns 55      0  *System.Windows.Controls.DataGridTextColumn  56      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$	 100 6O   1  +System.Windows.Controls.DataGridBoundColumn   Binding 61   �� *	ProductId+6O     57      $
 Name��6%   $	 200 6S    63   �� *ProductName+6S     58      $ Price��6%   $	 100 6h    64   �� *	UnitPrice+ �� StringFormat$ {0:C}��6h     59      $ Quantity��6%   $	 100 6T    67   �� *
Quantity+6T     5:      $ Discount��6%   $	 100 6j    67   �� *
Discount+$ {0:P}��6j   5<      5=      5>      