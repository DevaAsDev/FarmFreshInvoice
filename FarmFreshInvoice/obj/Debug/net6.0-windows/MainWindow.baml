   M S B A M L   `   `   `  ����K  GFarmFreshInvoice, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:FarmFreshInvoiceFarmFreshInvoice  5   	   !    FarmFreshInvoice.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:FarmFreshInvoice     5   	   -   5          � Title$  FarmFreshInvoice��5   	   $	��650��6"   $
��1000��6/    � Icon$ /src/log.png��6<    � 
ResizeMode$ NoResize=�5	   	    � WindowStyle$
 None=�5   	    � AllowsTransparency$
 True��5   	   
������  � 	Resources 5         RoundedWindowStyle �� 
TargetType �� Property �� Value	 �� 
TargetType
 �� CornerRadius��%�   &	        �� 5   
   " �6+   .�5      ��  � �� 5      �� 5      "	 �6&   .R�5      �� $
 20��6!   
�������._�5      �� 5      5      5      5      5      ��5       �� 5!   
    �� ResourceKey$ RoundedWindowStyle��6   .��5%      � .+�5(   
   �� $��/src/log.png��6   $��20��6&   $��20��61   $	��Top=�6>   $
��Left=�6V   $��	20 10 0 0q�6q   �� 5)   
   $��FarmFreshInvoice��6   
���   �$	��Top=�6?   $
��Left=�6W   $��	50 10 0 0q�6r   � 5+   
   -   5         �Name$ 	actionBar��5+      
������ $��20��6^   $��	60 0 60 0q�6j   $	��Top=�6}   6�   �� 5-   
   $��20��6   $��20��6   $��Right=�6(   $	��Top=�6D   $
 10��6\   $��1q�6n   
�������
���  ��$��	0,10,10,0q�6�    J� Effect 5.      3  -System.Windows.Media.Effects.DropShadowEffect  5/         ShadowDepth$ 4Q�6#      
BlurRadius$ 5Q�63      	Direction$	 270Q�6B      Color$ 	#FFD8D4D4��6R   ._�51      � -   5        $
 exit��51      
������ .+�52      �� $��X��6   $��Center=�6%   $��Center=�6@   53      54      �� 56   
   -   5         ��Name$ scoll1��56      $��0 20 0 0q�6'   $��Hidden=�69   $��Hidden=�6`   .��57      � $
��auto��6   .+�5:      �� $	��100��6   $	��250��6&   $
��Left=�62   $	��Top=�6M   $
 10��6e   $��1q�6w   
�������
�������$��	40,62,0,0q�6�    5;        5<      $ 4Q�6+   $ 5Q�6;   $	 270Q�6J   $ 	#FFD8D4D4��6Z   ._�5>      � -   5        $ retail��5>      
������ .+�5?      �� $��New Bill(Retail)��6$   $��Center=�6<   $��Center=�6W   5@      5A      �� 5C      $	��100��6   $	��250��6&   $
��Left=�62   $	��Top=�6M   $
 10��6e   $��1q�6w   
�������
�������$��
385,62,0,0q�6�    5D        5E      $ 4Q�6+   $ 5Q�6;   $	 270Q�6J   $ 	#FFD8D4D4��6Z   ._�5G      � -   5        $ 	wholesale��5G      
������ .+�5H      �� $��New Bill(Wholesale)��6$   $��Center=�6?   $��Center=�6Z   5I      5J      �� 5L      $	��100��6   $	��250��6&   $
��Left=�62   $	��Top=�6M   $
 10��6e   $��1q�6w   
�������
�������$��
710,62,0,0q�6�    5M        5N      $ 4Q�6+   $ 5Q�6;   $	 270Q�6J   $ 	#FFD8D4D4��6Z   ._�5P      � 
������ .+�5Q      �� $��Expenditure��6$   $��Center=�67   $��Center=�6R   5R      5S      �� 5U      $	��100��6   $	��250��6&   $
��Left=�62   $	��Top=�6M   $
 10��6e   $��1q�6w   
�������
�������$��385,207,0,0q�6�    5V        5W      $ 4Q�6+   $ 5Q�6;   $	 270Q�6J   $ 	#FFD8D4D4��6Z   ._�5Y      � -   5        $ purchase��5Y      
������ .+�5Z      �� $��Purchase Report��6$   $��Center=�6;   $��Center=�6V   5[      5\      � 5^      5`      5b      5e      5h      5l      