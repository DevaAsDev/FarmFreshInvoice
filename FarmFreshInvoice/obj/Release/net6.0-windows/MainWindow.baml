   M S B A M L   `   `   `  ���� K  GFarmFreshInvoice, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:FarmFreshInvoiceFarmFreshInvoice  !    FarmFreshInvoice.MainWindow   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     0localclr-namespace:FarmFreshInvoice     -     � Title$  FarmFreshInvoice��$	��650��$
��1000�� � Icon$ /src/log.png�� � 
ResizeMode$ NoResize=� � WindowStyle$
 None=� � AllowsTransparency$
 True��
������  � 	Resources    RoundedWindowStyle �� 
TargetType �� Property �� Value	 �� 
TargetType
 �� CornerRadius��%V   &	        �� " �.���  � �� �� "	 �.R��� $
 20��
�������._��� ����  �� ResourceKey$ RoundedWindowStyle��.��� .+��� $��/src/log.png��$��20��$��20��$	��Top=�$
��Left=�$��	20 10 0 0q��� $��FarmFreshInvoice��
���   �$	��Top=�$
��Left=�$��	50 10 0 0q�� -    �Name$ 	actionBar��
������ $��20��$��	60 0 60 0q�$	��Top=��� $��20��$��20��$��Right=�$	��Top=�$
 10��$��1q�
�������
���  ��$��	0,10,10,0q� J� Effect 3  -System.Windows.Media.Effects.DropShadowEffect     ShadowDepth$ 4Q�   
BlurRadius$ 5Q�   	Direction$	 270Q�   Color$ 	#FFD8D4D4��._�� -   $
 exit��
������ .+��� $��X��$��Center=�$��Center=��� -    ��Name$ scoll1��$��0 20 0 0q�$��Hidden=�$��Hidden=�.��� $
��auto��.+��� $	��100��$	��250��$
��Left=�$	��Top=�$
 10��$��1q�
�������
�������$��	40,62,0,0q�   $ 4Q�$ 5Q�$	 270Q�$ 	#FFD8D4D4��._�� -   $ retail��
������ .+��� $��New Bill(Retail)��$��Center=�$��Center=��� $	��100��$	��250��$
��Left=�$	��Top=�$
 10��$��1q�
�������
�������$��
385,62,0,0q�   $ 4Q�$ 5Q�$	 270Q�$ 	#FFD8D4D4��._�� -   $ 	wholesale��
������ .+��� $��New Bill(Wholesale)��$��Center=�$��Center=��� $	��100��$	��250��$
��Left=�$	��Top=�$
 10��$��1q�
�������
�������$��
710,62,0,0q�   $ 4Q�$ 5Q�$	 270Q�$ 	#FFD8D4D4��._�� 
������ .+��� $��Expenditure��$��Center=�$��Center=��� $	��100��$	��250��$
��Left=�$	��Top=�$
 10��$��1q�
�������
�������$��385,207,0,0q�   $ 4Q�$ 5Q�$	 270Q�$ 	#FFD8D4D4��._�� -   $ purchase��
������ .+��� $��Purchase Report��$��Center=�$��Center=�� 