   M S B A M L   `   `   `  ����T  PRecipeIngredientSystem.PL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:RecipeIngredientSystem.PLRecipeIngredientSystem.PL  5   	   ,    &RecipeIngredientSystem.PL.SelectRecipe   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   9local'clr-namespace:RecipeIngredientSystem.PL     5   	     � Title$  SelectRecipe��5   	   $	��700��6   $
��1300��6+   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $	��26* �6   �� 5      $��1267* �6   .+�5   
   �� $
��Left=�6   $	��670��6+   $��0,0,-136.4,0q�68   $	��Top=�6N   $
��1430��6f   $��jeff-sheldon-264920.jpg��6s    J� Opacity$	 0.3Q�6�   $��2��6�   �� 5   
   -   5         ��Name$ cmbbox��5      $
��Left=�6#   $��37.6,225,0,0q�6>   $	��Top=�6T   $	��300��6l   $��40��6�   $��1��6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$
 grid��5         CanUserAddRows .  $
��Left=�68   $	��327��6S   $��501.6,180,0,0q�6`   $	��Top=�6w   $	��622��6�   $��1��6�      Columns 5      4  .System.Windows.Controls.DataGridTemplateColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ VIEW INGREDIENTS��6)      CellTemplate 5      �� 5      .R�5      �� 	 ��Name$	 btnshow��6%   -   5        $��14(�5   6   $
��View��6D   6S   5      5      5#      �� 5$   
   -   5        
 ��Name$
 txtusername��5$      $
��Left=�6'   $��42��6B   $��916.6,15,0,0q�6N    �� TextWrapping$
 Wrap=�6d   $	��Top=�6x   $	��235��6�   $��20(�6�   $��0q�6�    J� RenderTransformOrigin$ 0.5,0.5&�6�   $��1��6�    �� TextAlignment$ Center=�6�   $
��Bold"�6   �� 
IsReadOnly . 6  �� 5%   
   $��Select Recipe��6   $
��Left=�6(   $��37.6,180,0,0q�6C   $	��Top=�6Y   $��40��6q   $	��170��6}   $��18(�6�   $
��Bold"�6�   $��1��6�   �� 5&   
   -   5        $��LOGOUT��5&      $
��Left=�6"   $��1171.6,10,0,0q�6=   $	��Top=�6T   $��86��6l   $��47��6w   $��2q�6�   $��1��6�   $��20(�6�   $
��Bold"�6�   �� 5'   
   -   5        $	 backbtn��5'      $
��Back��6"   $
��Left=�61   $	��Top=�6L   $	��122��6d   $��14(�6p   $��2��6�   $��30��6�   $
��Bold"�6�   �� 5(   
   -   5        $	 cartbtn��5(      $
��CART��6"   $
��Left=�61   $��37.6,96,0,0q�6L   $	��Top=�6a   $	��150��6y   $��58��6�   $��20(�6�   $
��Bold"�6�   $��1��6�   $ 0.612,0.333&�6�   5*      5+      