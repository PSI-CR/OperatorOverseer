   M S B A M L   `   `   `  ����K  GOperatorOverseer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:OperatorOverseerOperatorOverseer  5   	   !    OperatorOverseer.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:OperatorOverseer     5   	   -   5          � Title$  Operator Overseer��5   	   $	��700��6#   $	��950��60   .��5	      �� .@�5
   
   �� $��Operator��6   ���#87CEEB.��5      �  � RowDefinitions 5      �� 5      $��40 �6$   62   �� 5      $��* �6$   61   .+�5      �� $��0��6    �� Orientation$ 
Horizontal=�6*   .+�5      �� -   5        $��Create��5      $��10q�6.   $	��150��6:   
����������#FF6B6B6�   5      &   System.Windows.Controls.DataGrid  5      -   5          Name$ dataGrid��5   (   $��1��6      CanUserSortColumns .    SelectionMode$ Single=�6T      AutoGenerateColumns .  $��
10,10,10,0q�6�   $
��Auto��6�   $
��Auto��6�      CanUserAddRows .     CanUserDeleteRows .  	   
IsReadOnly	 . "
   VerticalScrollBarVisibility$

 Auto=�6  $   HorizontalScrollBarVisibility$
 Auto=�6=     CanUserResizeColumns .    	CellStyle 5      �� 5       �� 
TargetType*  $System.Windows.Controls.DataGridCell"  6     �� Triggers 5      P� 5   "    P� Property �@ 
IsSelected P� Value . . �5   &   ��  �� Property � �� �� Value �#87CEEB6C   �� 5   &    � ��
 �   �6C   �� 5   &    � �� �#87CEEB6V   5   #   5         ColumnHeaderStyle 5      �� 5       =  7System.Windows.Controls.Primitives.DataGridColumnHeader"  6     �� BasedOn# [B 6B   .�5!      ��  � ��$ Center=�6K   �� 5"       � ��$ 	0.5,0,0,0q�6@   6T   �� 5#       � ��
 �����6<   �� 5$       � ��$ 22��6:   6G   �� 5%       � ��   HeaderBrush# [  6;   �� 5&       � ��
 �   �6;   �� 5'       �@J�SnapsToDevicePixels . 6D   �� 5(       � ��$ 5��69   �� 5)       � ��$ 0q�67   5*         Columns 5,      0  *System.Windows.Controls.DataGridTextColumn  5-      ,  &System.Windows.Controls.DataGridColumn   Header$ Number��6-      Width5  /System.Windows.Controls.DataGridLengthConverter$ 80 6X   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6=   �� *Number+6X     5.      $
 Name��6-   $	 100 6T    6;   �� *Name+6T     5/      $ 	Last Name��6-   $	 100 6]    6@   �� *
LastName+6]     50      $ Device��6-   $	 100 6X    6=   �� *Device+6X     51      $ Permissions��6-   $
 Auto 6b    6B   �� *Permissions+6b   4  .System.Windows.Controls.DataGridTemplateColumn  52      $
 Edit��61   $ 60 6?      CellTemplate 53      �� 54   "   .R�55   &   �� -   5        $
��Edit��55   -   
����������#FF6B6B
 � Tag 6U   �� *Number+6   56   #   58        59      $ Remove��61   $ 80 6A    5:      �� 5;   "   .R�5<   &   �� -   5        $��Remove��5<   -   
����������#FF6B6B 6Y   �� *Number+6�   5=   #   5?      5A      5B      5C      �� 5D   
   $��Permissions��6   ���#87CEEB.��5E      �  5F      �� 5G      $��40 �6$   62   �� 5H      $��* �6$   61   .+�5J      �� $��0��6   $ 
Horizontal=�6*   .+�5K      �� -   5        $��_addPermissionTextbox��5K      $��25��6;   $	��200��6G   $��5q�6S   6`   �� 5L      -   5        $	��Add��5L      $��10q�6+   $	��150��67   
����������#FF6B6B6�   5M      �� 5N      -   5        $��_permissionsStackPanel��5N   E   $
��Left=�6   $��1��68   5P      5V      5W      5X      5Y      