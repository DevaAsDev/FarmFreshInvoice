   M S B A M L   `   `   `  ���� K  GFarmFreshInvoice, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:FarmFreshInvoice.SubViewsFarmFreshInvoice.SubViews  )    #FarmFreshInvoice.SubViews.Wholesale   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     9local'clr-namespace:FarmFreshInvoice.SubViews       � Title$  Wholesale Bill��$	��650��$
��1000�� � Icon$ /src/log.png�� � 
ResizeMode$ NoResize=�.���  � RowDefinitions �� $��50 ��� $	��100 ��� �� $	��200 �.+�� $��50��$��Center=� � ColumnDefinitions �� �� �� �� �� �� .+��� $��
Bill No : ��$��	20 20 0 0q�$��30��$
��auto��$	��Top=�$
��Left=�
���   ��� -    ��Name$ BillId��$��0q�$��	60 20 0 0q�$��30��$
��auto��$	��Top=�$
��Left=�
���   ��� $��1��$��Bill Time : ��$��0 20 0 0q�$��30��$
��auto��$	��Top=�$
��Left=�
���   ��� -   $ BillTime��$��1��$��0q�$��	60 20 0 0q�$��20��$
��auto��$	��Top=�$
��Left=�
���   ��� $��2��$��Bill Date : ��$��0,20,0,0q�$��30��$
��auto��$	��Top=�$
��Left=�
���   ��� -   $ BillDate��$��2��$��0q�$��	60,20,0,0q�$��30��$
��auto��$	��Top=�$
��Left=�
���   �� $��1��$	��100��$��Center=�.+���  �� Orientation$ 
Horizontal=�.+��� $ 
Horizontal=�$��30��.+��� $��Name of the particular :��$��20 5 0 0q��� -   $ names��$
|�True��$��5q�$	��150��� -   $��suggestionsPopup��$��Bottom=� � 	StaysOpen$ False��$��False�� � PlacementTarget �� 	 �� ElementName$	 names��.���� -   $��suggestedNames��$	��150��$
��auto���� $ 
Horizontal=�$��30��.+��� $��Price :��$��5q��� -   $ prices��$��5q�$��80���� $ 
Horizontal=�$��30��.+��� $��Quantity(kg) :��$��5q��� -   $ 	quantitys��$��5q�$��80���� $ 
Horizontal=�$��30��.+��� $��Amount :��$��5q��� -	   $ amounts��$��5q�$��80���� $ 
Horizontal=�$��30��.+��� -
   
 ��Name$
 
cancel_btn��$��Cancel��$��80��$��20��$��20 0 0 0q��� -   $
 add_btn��$	��Add��$��80��$��20��$��20 0 0 0q�� $��2��.+�&   System.Windows.Controls.DataGrid  -     Name$ dataGrid��$��10q�   AutoGenerateColumns$ False��   
IsReadOnly$
 True��   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$	 355    Header$ Product Name��1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *ProductName+  $	 200 $ Price�� �� *Price+  $	 200 $ Quantity(kg)�� �� *
Quantity+  $	 200 $ Amount�� �� *Amount+� $��3��.+��� $	��500��$
��Left=�.+��� $ 
Horizontal=�$��0 20 0 0q�.+��� $��Payment Method : ��$��10 0 0 0q�$��Center=�	� -   $��radioButton1��$
��Cash�� d� 	IsChecked$
 TrueY� 	� 	GroupName$ myRadioGroup��$��Center=�$��5 0 5 0q�	� -   $��radioButton2��$	��UPI��$ myRadioGroup��$��Center=�$��5 0 5 0q�	� -   $��radioButton3��$��	Pay Later��$ myRadioGroup��$��Center=�$��5 0 0 0q��� $ Vertical=�.+��� $ 
Horizontal=�$��	10 10 0 0q�.+��� $��Customer Name :���� -   $ customer_name��$	��180��$��5 0 0 0q��� $ 
Horizontal=�$��	10 10 0 0q�.+��� $��Mobile No :���� -   $ 
mobile_num��$	��210��$��5 0 0 0q��� $ 
Horizontal=�$��	10 10 0 0q�.+��� $��	Remarks :���� -   $ remark��$	��220��$��5 0 0 0q��� $	��300��$��Right=�$ Vertical=�.+��� $ 
Horizontal=�$��Right=�$
��auto��.+��� $��Total :��$��5q�$
��Bold"��� -    ��Name$ total��$��5q�$��80���� $ 
Horizontal=�$��Right=�$
��auto��.+��� $��
Discount :��$��5q�$
��Bold"��� -   $ discount��$��5q�$��80���� $ 
Horizontal=�$��Right=�$
��auto��.+��� $��
Subtotal :��$��5q�$
��Bold"��� -   $ subtotal��$��5q�$��80���� $ 
Horizontal=�$��Right=�$
��auto��.+��� $��Final Amount :��$��5q�$
��Bold"��� -   $ final_amount��$��5q�$��80���� $ 
Horizontal=�$��Right=�$��0 20 0 0q�.+��� -   $
��Save��$��80��$��0 0 5 0q��� -   $��Print��$��80��$��0 0 5 0q��� -   $
��Exit��$��80��$��0 0 10 0q�