   M S B A M L   `   `   `  ����F  BSalesWPFApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:SalesWPFAppSalesWPFApp  5          SalesWPFApp.ManageProduct   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      +localclr-namespace:SalesWPFApp     5      .��5	      � .+�5
   
   �� $��10q�6   .+�5      �   � ColumnDefinitions  5      �� 5      $��* �6'   �� 5      $��* �6'    � RowDefinitions 5      �� 5      $��* �6$   �� 5      $��* �6$   �� 5      $��* �6$   �� 5      $��* �6$   .+�5      �� $��0��6    �� Orientation$ 
Horizontal=�6-   $��5q�6F   .+�5      �� $	��ID:��6   $	��100��6*   �� 5      -   5         ��Name$ txtId��5      $	��200��6-   ��69   ��  �� Path$ 	ProductId� �� Mode$ OneWay=� � DataContext 6f   ��  �� ElementName$ 
lvProducts��$ SelectedItem�5      �� 5      $��1��6   $ 
Horizontal=�6-   $��5q�6F   .+�5      �� $��CategoryId:��6   $	��100��62   �� 5       -   5        $ txtCategoryId��5       $	��200��65   ��6A   �� $ 
CategoryId�$ OneWay=� 6o   �� $ 
lvProducts��$ SelectedItem�5!      �� 5$      $��0��6   $��1��6-   $ 
Horizontal=�6:   $��5q�6S   .+�5%      �� $��Product Name:��6   $	��100��64   �� 5&      -   5        $ txtProductName��5&      $	��200��66   ��6B   �� $ ProductName�$ OneWay=� 6q   �� $ 
lvProducts��$ SelectedItem�5'      �� 5)      $��1��6   $��1��6-   $ 
Horizontal=�6:   $��5q�6S   .+�5*      �� $��Weight:��6   $	��100��6.   �� 5+      -   5        $ 	txtWeight��5+      $	��200��61   ��6=   �� $ Weight�$ OneWay=� 6g   �� $ 
lvProducts��$ SelectedItem�5,      �� 5/      $��0��6   $��2��6-   $ 
Horizontal=�6:   $��5q�6S   .+�50      �� $��Unit Price:��6   $	��100��62   �� 51      -   5        $ txtUnitPrice��51      $	��200��64   ��6@   �� $ 	UnitPrice�$ OneWay=� 6m   �� $ 
lvProducts��$ SelectedItem�52      �� 54      $��1��6   $��2��6-   $ 
Horizontal=�6:   $��5q�6S   .+�55      �� $��Unit In Stock:��6   $	��100��65   �� 56      -   5        $ txtUnitsInStock��56      $	��200��67   ��6C   �� $ UnitsInStock�$ OneWay=� 6s   �� $ 
lvProducts��$ SelectedItem�57      �� 59      $��3��6   $ 
Horizontal=�6*   $��Center=�6C   $��10q�6`   .+�5:      �� -   5         ��Name$ LoadData��5:      $
��Load��6/   $��75��6>   $��5q�6I   6T   �� 5;      -   5        $	 Add��5;      $	��Add��6*   $��75��68   $��5q�6C   6N   �� 5<      -	   5        $ Update��5<      $��Update��6-   $��75��6>   $��5q�6I   6U   �� 5=      -
   5        $ Delete��5=      $��Delete��6-   $��75��6>   $��5q�6I   6T   5>      �� 5@      $��1��6   $��3��6-   $ 
Horizontal=�6:   $��5q�6S   .+�5A      �� -   5        $ 	btnSearch��5A      $��Search��60   $��92��6A   $��5q�6L   6W   �� 5B      -   5        $ 	txtSearch��5B      $	��200��61   5C      5D      �� 5G      -   5        	 ��Name$	 
lvProducts��5G      $	��200��6+   $	��700��68   $��10q�6D   
 �� View
 5H      �� 5I      .P�5J      �� $��ID��6)    �� Width$	 100��65    �� DisplayMemberBinding 6A   �� $ 	ProductId��� 5K      $��Category ID��6)   $	 150��6>    6J   �� $ 
CategoryId��� 5L      $��Product Name��6)   $	 150��6?    6K   �� $ ProductName��� 5M      $��Weight��6)   $	 100��69    6E   �� $ Weight��� 5N      $��
Unit Price��6)   $	 100��6=    6I   �� $ 	UnitPrice��� 5O      $��Unit In Stock��6)   $	 100��6@    6L   �� $ UnitsInStock�5P      5R      5S      5T      5U      