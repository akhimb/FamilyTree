   M S B A M L   `   `   `  ����  FamilyTreeCreation$    FamilyTreeCreation.AddRelation   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	     � Title$  Add / Update Relation��5   	   $	��360��5   	   $	��500��5	   	    � WindowStartupLocation$ CenterScreen=�5
   	    � 
ResizeMode$ NoResize=�5   	    � WindowStyle$ 
ToolWindow=�5   	   .��5      � $��20q�6    � RowDefinitions 5   
   �� 5      $��50 �6   �� 5      $��50 �6   �� 5      $��50 �6   �� 5      $��50 �6   �� 5      $��20 �6   �� 5      $��60 �6   �� 5      $��30 �6    � ColumnDefinitions 5   
   �� 5      $	��150 �6   �� 5      .+�5   
   �� $��0��6   $��2��6$   $��20(�68   $	��Top=�6F   $��Center=�6^   ADD / UPDATE RELATION6�   �� 5   
   $��1��6   $��20(�6!   $
��Left=�6/   
Source :6U   �� 5   
   -   5         ��Name$ SourceComboBox��5      $��1��5      $��1��5      $��20(�5       $
��Left=�5!      $	��200��6-   $��5q�69   �� 5#   
   $��2��6   $��20(�5$      $
��Left=�5%      
Relation :6;   �� 5&   
   -   5        $ RelationComboBox��5&      $��2��5'      $��1��5(      $��20(�5)      $
��Left=�5*      $	��200��5+      $��5q�5,      �� 5-   
   $��3��6   $��20(�5.      $
��Left=�5/      
Target :69   �� 50   
   -   5        $ TargetComboBox��50      $��3��51      $��1��52      $��20(�53      $
��Left=�54      $	��200��55      $��5q�56      ]� 59   
   $��Center=�6   $��0��61   $��2��6B   $��5��6V   .+�5:      �� -   5         ��Name$ 
SaveButton��5:      $	��150��6*   $��20(�5;      $��0 0 20 0q�5=      $��50��5>      .��6!   Save6'   �� 5?      -   5        $	��150��5?      $��20(�6!   $��50��5@      .��5A   *   Close61   5B      5E      5F      