   M S B A M L   `   `   `  ���� K  GOperatorOverseer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:OperatorOverseerOperatorOverseer  !    OperatorOverseer.MainWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     0localclr-namespace:OperatorOverseer       � Title$  Operator Overseer��$	��700��$	��950��.���� .@��� $��Operator�����#87CEEB.���  � RowDefinitions �� $��40 ��� $��* �.+��� $��0�� �� Orientation$ 
Horizontal=�.+��� -   $��Create��$��10q�$	��150��
����������#FF6B6B&   System.Windows.Controls.DataGrid  -     Name$ dataGrid��$��1��   CanUserSortColumns .    SelectionMode$ Single=�   AutoGenerateColumns .  $��
10,10,10,0q�$
��Auto��$
��Auto��   CanUserAddRows .     CanUserDeleteRows .  	   
IsReadOnly	 . "
   VerticalScrollBarVisibility$

 Auto=�$   HorizontalScrollBarVisibility$
 Auto=�   CanUserResizeColumns .    	CellStyle ��  �� 
TargetType*  $System.Windows.Controls.DataGridCell"   �� Triggers P�  P� Property �@ 
IsSelected P� Value . . ���  �� Property � �� �� Value �#87CEEB��  � ��
 �   ���  � �� �#87CEEB   ColumnHeaderStyle �� =  7System.Windows.Controls.Primitives.DataGridColumnHeader"   �� BasedOn# [B .���  � ��$ Center=���  � ��$ 	0.5,0,0,0q���  � ��
 �������  � ��$ 22����  � ��   HeaderBrush# [  ��  � ��
 �   ���  �@J�SnapsToDevicePixels . ��  � ��$ 5����  � ��$ 0q�   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ Number��   Width5  /System.Windows.Controls.DataGridLengthConverter$ 80 1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *Number+  $
 Name��$	 100  �� *Name+  $ 	Last Name��$	 100  �� *
LastName+  $ Device��$	 100  �� *Device+  $ Permissions��$
 Auto  �� *Permissions+4  .System.Windows.Controls.DataGridTemplateColumn  $
 Edit��$ 60    CellTemplate �� .R��� -   $
��Edit��
����������#FF6B6B
 � Tag �� *Number+  $ Remove��$ 80  �� .R��� -   $��Remove��
����������#FF6B6B �� *Number+�� $��Permissions�����#87CEEB.���  �� $��40 ��� $��* �.+��� $��0��$ 
Horizontal=�.+��� -   $��_addPermissionTextbox��$��25��$	��200��$��5q��� -   $	��Add��$��10q�$	��150��
����������#FF6B6B�� -   $��_permissionsStackPanel��$
��Left=�$��1��