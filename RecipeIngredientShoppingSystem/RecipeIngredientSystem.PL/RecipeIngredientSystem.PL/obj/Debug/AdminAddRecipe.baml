   M S B A M L   `   `   `  ����T  PRecipeIngredientSystem.PL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:RecipeIngredientSystem.PLRecipeIngredientSystem.PL  5   	   .    (RecipeIngredientSystem.PL.AdminAddRecipe   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   9local'clr-namespace:RecipeIngredientSystem.PL     5   	     � Title$  AdminAddRecipe��5   	   $	��700��6    $
��1300��6-   .��5	      � .+�5
   
   �� $
��Left=�6   $	��721��6+   $	��Top=�68   $
��1467��6P   $��jeff-sheldon-264920.jpg��6]    J� Opacity$	 0.3Q�6~   $��0,0,-173.4,-50.6q�6�   �� 5   
   -   5         ��Name$ lblRecipeId��5      $��Recipe ID :��6%   $��20(�6;   $
��Left=�6I   $��	27,86,0,0q�6d   $	��Top=�6w   $��40��6�   $	��152��6�   $ 2Q�6�   $
��Bold"�6�   �� 5   
   -   5        $ lblRecipeName��5      $��Recipe Name : ��6'   $��20(�6@   $
��Left=�6N   $��
27,168,0,0q�6i   $	��Top=�6}   $	��152��6�   $��40��6�   $
��Bold"�6�   �� 5   
   -   5        $ lblRecipeDescription��5      $��Recipe Description :��6.   $��20(�6M   $
��Left=�6[   $��
27,255,0,0q�6v   $	��Top=�6�    J� RenderTransformOrigin$ -0.281,-0.617&�6�   $	��211��6�   $��40��6�   $
��Bold"�6�   �� 5   
   -   5         ��Name$ txtrecipeId��5      $
��Left=�6F   $��23��6a   $��
281,86,0,0q�6m    �� TextWrapping$
 Wrap=�6�   $	��Top=�6�   $	��399��6�   $	��350��6�   $��40��6�   $��20(�6�   �� 5   
   -   5        $ txtrecipename��5      $
��Left=�6)   $��23��6D   $��281,168,0,0q�6P   $
 Wrap=�6e   $	��Top=�6y   $	��399��6�   $	��350��6�   $��40��6�   $��20(�6�   �� 5   
   -   5        $ txtrecipedescription��5      $
��Left=�60   $	��175��6K   $��281,255,0,0q�6X   $
 Wrap=�6m   $	��Top=�6�   $	��399��6�   $��20(�6�   �� 5   
   -   5         ��Name$ btnaddrecipe��5      $
��Add ��6'   $��22(�66   $
��Bold"�6D   $
��Left=�6W   $��
22,480,0,0q�6r   $	��Top=�6�   $	��140��6�   $��30��6�   �� 5   
   -   5        $ 	btnupdate��5      $��Update��6$   $��22(�65   $
��Bold"�6C   $
��Left=�6V   $��30��6q   $��195,480,0,0q�6}   $	��Top=�6�   $	��140��6�   $ 
0.767,1.16&�6�   �� 5   
   -	   5        $ 	btndelete��5      $��Delete��6$   $��22(�65   $
��Bold"�6C   $
��Left=�6U   $��30��6p   $��368,480,0,0q�6|   $	��Top=�6�   $	��140��6�   6�   �� 5   
   -
   5        $ 	btnsearch��5      $��Search��6$   $��22(�65   $
��Bold"�6C   $
��Left=�6U   $��30��6p   $��
27,545,0,0q�6|   $	��Top=�6�   $	��140��6�   6�   �� 5   
   -   5        $ btnclear��5      $��Clear��6#   $��22(�63   $
��Bold"�6A   $
��Left=�6S   $��30��6n   $��195,545,0,0q�6z   $	��Top=�6�   $	��140��6�   6�   �� 5   
   -   5        $ btnlist��5      $
��List��6#   $��22(�62   $
��Bold"�6@   $
��Left=�6R   $��30��6m   $��368,545,0,0q�6y   $	��Top=�6�   $	��140��6�   6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ dgrecipedetails��5      $
��Left=�6,   $	��402��6G   $��798,111,0,0q�6T   $	��Top=�6i   $	��395��6�   �� 5   
   -   5        $ backbtn��5      $
��Back��6"   $
��Left=�61   $��Bottom=�6L   $	��122��6g   $��14(�6s   $��0,0,0,630.4q�6�   $��30��6�   $
��Bold"�6�   �� 5   
   -   5        $ 	logoutbtn��5      $��LOGOUT��6$   $
��Left=�65   $��1198,10,0,0q�6P   $	��Top=�6e   $��86��6}   $��47��6�   $
��Bold"�6�   $��18(�6�   �� 5   
   -   5        $ txtusername1��5       �� TextAlignment$ Right=�6(   $
��Left=�6>   $��42��6Y   $��
945,15,0,0q�6e   $
 Wrap=�6y   $	��Top=�6�   $	��235��6�   $��20(�6�   $��0q�6�   $ 0.5,0.5&�6�   	 �� 
IsReadOnly	 . $
��Bold"�6  �� 5   
   $$��Enter the Recipe Id to Search:��6   $
��Left=�69   $��	27,49,0,0q�6T   $	��Top=�6g   $	��248��6   $��16(�6�   $
��Bold"�6�   5      5      