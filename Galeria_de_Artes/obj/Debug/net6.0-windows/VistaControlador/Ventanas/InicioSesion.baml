   M S B A M L   `   `   `  ����B  >BARTOPI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullg8clr-namespace:Galeria_de_Artes.VistaControlador.Ventanas*Galeria_de_Artes.VistaControlador.Ventanas  5      =    7Galeria_de_Artes.VistaControlador.Ventanas.InicioSesion   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Jlocal8clr-namespace:Galeria_de_Artes.VistaControlador.Ventanas     5      -   5          N�Name$  Sesiones��5       N� Title$ InicioSesion��5	       � 	Resources 5       	  nuevo  Comp�� 5   
   %:   &	        &	      �� 5      6   �� 5      6   5       J� InputBindings 5      �� 5   
   
 �� Key$	 Esc��6    �� Command# [  6   �� 5   
   $	 Tab��6   # [ 6    J� CommandBindings 5      )  #System.Windows.Input.CommandBinding  5   
   -   5           Command# [  5      6:     5   
   -   5        # [ 5      69   .��5      � .+�5   
   �� $ ��/Resources/fondoSesion.jpg��6   $
��Fill=�64   �� 5    
   $��Usuario��6   $��center=�6#   $��Center=�6@    �� TextAlignment$ Center=�6[   $��
0,0,200,50q�6r     txt#��[ 6�   �� 5!   
   -   5        	 ��Name$
	 usua��5!      
���   �$��25��63   $	��125��6?   $��Center=�6K   $��Center=�6h   $��
0,50,200,0q�6�   $��20(�6�   �� 5"   
   $��Contraseña��6   $	��160��6&   $��Center=�62   $��Center=�6O   $��
200,0,0,50q�6k   $ Center=�6   #��[ 6�   G� 5#   
   -   5        
 G�Name$

 Cont��5#      $��25��6$   $	��125��60   $��Center=�6<   $��Center=�6Y   $��
200,50,0,0q�6u   $��Normal"�6�   �� 5$   
   -   5         ��Name$ 	Comprobar��5$      $��	Comprobar��6$   $��Center=�69   $��Center=�6V   $��	0,150,0,0q�6r     	BtnSesion#��[ 6�    � ToolTip$ Tecla rapida Tab��6�   �� 5%   
   -   5        $ Nuevo��5%      $��Nuevo usuario��6    $��25��68   $	��125��6D   $��Center=�6P   $��Center=�6m   $��	0,220,0,0q�6�     Btn#��[ 6�   $ Tecla rapida Esc��6�   5'      5(      