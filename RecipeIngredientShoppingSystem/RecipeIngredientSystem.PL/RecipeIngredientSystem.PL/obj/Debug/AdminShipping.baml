   M S B A M L   `   `   `  ����T  PRecipeIngredientSystem.PL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:RecipeIngredientSystem.PLRecipeIngredientSystem.PL  5   	   -    'RecipeIngredientSystem.PL.AdminShipping   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   9local'clr-namespace:RecipeIngredientSystem.PL     5   	     � Title$  AdminShipping��5   	   $	��700��6   $
��1300��6,   .��5	      � .+�5
   
   �� $
��Left=�6   $	��660��6+   $	��Top=�68   $
��1454��6P   $��jeff-sheldon-264920.jpg��6]    J� Opacity$	 0.3Q�6~   $��0,0,-160.4,0q�6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ datagrid��5      $
��Left=�6%   $	��352��6@   $��688,112,0,0q�6M   $	��Top=�6b   $	��521��6z   6�   �� 5   
   $��Shipping Number ��6   $
��Left=�6+   $��
52,153,0,0q�6F   $	��Top=�6Z   $��40��6r   $	��183��6~   $��20(�6�   $
��Bold"�6�   �� 5   
   $��Order Id��6   $
��Left=�6#   $��
52,225,0,0q�6>   $	��Top=�6R   $��40��6j   $	��130��6v   $��20(�6�    J� RenderTransformOrigin$ 0.672,0.914&�6�   $
��Bold"�6�   �� 5   
   $��Expected Delivery Date ��6   $
��Left=�62   $��
52,307,0,0q�6M   $	��Top=�6a   $��40��6y   $	��183��6�   $��20(�6�   $
��Bold"�6�   �� 5   
   -   5         ��Name$ shipnum��5      $
��Left=�6#   $��40��6>   $��269,153,0,0q�6J    �� TextWrapping$
 Wrap=�6_   $	��Top=�6s   $	��250��6�   $��22(�6�   ���	#FFEEE1CF6�   �� 5   
   -   5        $ shiporderid��5      $
��Left=�6'   $��40��6B   $��269,225,0,0q�6N   $
 Wrap=�6c   $	��Top=�6w   $	��250��6�   $��22(�6�   ���	#FFEEE1CF �� 
IsReadOnly . 6�   �� 5   
   -   5        $��UPDATE��5      $
��Left=�6"   $��182,380,0,0q�6=   $	��Top=�6R   $	��141��6j   $��51��6v   $��22(�6�   $
��Bold"�6�   6�   �� 5   
   -   5        $
��LIST��5      $
��Left=�6    $��882,529,0,0q�6;   $	��Top=�6P   $	��150��6h   $��47��6t   $��22(�6�   $ 1.587,0.813&�6�   $
��Bold"�6�   6�   �� 5   
   $��SHIPPING DETAILS��6   $
��Left=�6+   $��
345,41,0,0q�6F   $	��Top=�6Z   $��66��6r   $	��392��6~   $��42(�6�   $
��Bold"�6�   $ 0.693,0.833&�6�   �� 5   
   -   5         ��Name$ backbtn��5      $
��Back��6"   $
��Left=�61   $	��122��6L   $��14(�6X   $
��Bold"�6|   $��0,0,0,632.4q�6�   $��30��6�   $��Bottom=�6�   �� 5   
   -   5        $ 	logoutbtn��5      $��LOGOUT��6$   $
��Left=�65   $��1198,10,0,0q�6P   $	��Top=�6e   $��86��6}   $��47��6�   $��18(�6�   $
��Bold"�6�   �� 5   
   -   5        $ txtusername1��5       �� TextAlignment$ Right=�6(   $
��Left=�6>   $��30��6Y   $��	505,0,0,0q�6e   $
 Wrap=�6x   $	��Top=�6�   $	��221��6�   $��20(�6�   $��0q�6�   $ 0.5,0.5&�6�   $y�Hidden=�6  (  "System.Windows.Controls.DatePicker  5   
   -	   5        	  Name$	 expdate��5      $
��Left=�6&   $��269,307,0,0q�6A   $	��Top=�6V   $��40��6n   $	��250��6z   �� 5   
   -
   5        $ txtusername��5      $
��Left=�6'   $��42��6B   $��
938,10,0,0q�6N   $
 Wrap=�6b   $	��Top=�6v   $	��235��6�   $��20(�6�   $
��Bold"�6�   5      5      