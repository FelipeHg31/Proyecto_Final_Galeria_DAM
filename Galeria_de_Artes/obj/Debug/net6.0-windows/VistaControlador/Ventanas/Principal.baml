   M S B A M L   `   `   `  ����B  >BARTOPI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullg8clr-namespace:Galeria_de_Artes.VistaControlador.Ventanas*Galeria_de_Artes.VistaControlador.Ventanas  5      o<clr-namespace:Galeria_de_Artes.VistaControlador.User_control.Galeria_de_Artes.VistaControlador.User_control  5      :    4Galeria_de_Artes.VistaControlador.Ventanas.Principal   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Jlocal8clr-namespace:Galeria_de_Artes.VistaControlador.Ventanas     5      Kuc<clr-namespace:Galeria_de_Artes.VistaControlador.User_control     5      -   5          N�Name$  Prins��5       N� Title$ 	Principal��5
       � 	Resources 5       	  salir  galeria�� 5   
   %:   &	        &	      �� 5      6   �� 5      6   5       J� InputBindings 5      �� 5   
   
 �� Key$	 Esc��6    �� Command# [  6   �� 5   
   $	 Tab��6   # [ 6    J� CommandBindings 5      )  #System.Windows.Input.CommandBinding  5   
   -   5           Command# [  5      6:     5   
   -   5        # [ 5      6<   .��5      � .+�5    
   �� $!��/Resources/Fondo_Botero.jpg��6   $
��Fill=�65   o� 5"   
   -   5         o�Name$ menus��5"      $��23��6   $	��Top=�6@   $��Center=�6X   ��6*   Z� .@�5$      �� -   5        	 ��Name$	 
Mi_Galeria��5$      $��Galeria��6)   $	��Top=�6;   $��Center=�6S   $��80��6p     Btn#��[ 6�   �� 5%      -   5        $	 Pregunta��5%      $��?��6'   $	��Top=�63   $
��Left=�6K   $��20��6f   $��25��6q   #��[ 6�   m� 5'      -   5        
 m�Name$
 Admin��5'      $��Administrar��6&    m� StaysOpenOnClick$
 True��6;   
���   �
�������.@�5(      @   :Galeria_de_Artes.VistaControlador.User_control.administrar  -   5          Name$ adminn��5(   !   5)      5+      �� 5-   
   -	   5        $	 
BotonPelis��5-      $	��230��6&   $	��160��62   $��400,215,0,0q�6?    � ToolTip$ 	Peliculas��6�   ��6U   Z� .��5.      �� -
   5         ��Name$ 	Peliculas��5.      $��/Resources/CineGif1.gif��6'   $	��250��6H   $	��200��6T   5/      �� 51   
   -   5        $	 BotonLibros��51      $	��250��6'   $	��160��63   $��0,200,400,0q�6@   $ Libros��6�   ��6�   Z� .��52      �� -   5        $ Libros��52      $��/Resources/libros.png��6$   $	��275��6C   $	��150��6O   53      �� 55   
   -   5        $	 BotonMusica��55      $	��250��6'   $	��150��63   $��400,0,0,140q�6@   ���	#FFF7EDED$ Musica��6�   .��56      �� -   5        $ Musica��56      $��/Resources/Musica.png��6$   $	��200��6C   $	��150��6O   $��UniformToFill=�6\   57      �� 59   
   -   5        $	 BotonPinturas��59      $	��250��6)   $	��160��65   $��0,-120,400,30q�6B   $ Pinturas��6�   ��6�   Z� .��5:      �� -   5        $ Pinturas��5:      $��/Resources/PinturaGif.gif��6&   $	��260��6I   $	��150��6U   5;      �� 5=   
   -   5        $	 Cerrar��5=      $��Cerrar sesion��6!   $��Center=�69   $��Bottom=�6V   $��0,0,0,0q�6q   #��[ 6�   �� 5>   
   -   5         ��Name$ us��5>      $	��100��6!   $��20��6-   $��Center=�69   $��Bottom=�6V   $��0,0,0,35q�6q    �� TextAlignment$ Center=�6�   
�������6�   5@      5A      