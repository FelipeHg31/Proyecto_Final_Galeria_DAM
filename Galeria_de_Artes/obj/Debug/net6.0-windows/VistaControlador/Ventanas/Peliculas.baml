   M S B A M L   `   `   `  ����B  >BARTOPI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullg8clr-namespace:Galeria_de_Artes.VistaControlador.Ventanas*Galeria_de_Artes.VistaControlador.Ventanas  5      :    4Galeria_de_Artes.VistaControlador.Ventanas.Peliculas   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Jlocal8clr-namespace:Galeria_de_Artes.VistaControlador.Ventanas     5        N� Title$  	Peliculas��5	      .��5      � .+�5   
   �� $��/Resources/cine.jpg��6   $��UniformToFill=�6-   �� 5   
   $��Titulo��6    �� TextAlignment$ Center=�6"   $��0,0,300,350q�69      txt#��[  6O   �� 5   
   $��Genero��6   $ Center=�6"   $��100,-200,0,150q�69   #��[  6R   �� 5   
   $��Actor y director��6   $ Center=�6,   $��40��6C   $	��250��6O   
�������$��35(�6r   $��45,0,150,130q�6�   #��[  6�   �� 5   
   $��Opinión��6   $��250,0,-270,40q�6#   #��[  6:   �� 5   
   $��Palabra clave��6   $	��200��6*   $ Center=�66   $��-200,0,250,-120q�6M   #��[  6f   �� 5   
   -   5         ��Name$ titulos��5      $	��200��6$   $��35��60   $��-150,0,150,230q�6<   6t   �� 5   
   -   5        $ Genero��5      $	��200��6#   $��35��6/   $��120,0,0,230q�6;   6P   �� 5   
   -   5        $ Director��5      $	��200��6%   $��35��61   $��	120,0,0,0q�6=   �� 5   
   -   5        $ Actores��5      $	��200��6%   $��35��61   $��-150,0,150,0q�6=   �� 5   
   -   5         ��Name$ opinion��5      $	��200��6#   $	��130��6/   $��250,80,-300,-40q�6<    �� TextWrapping$ WrapWithOverflow=�6U   �� 5   
   -   5        $ 	pal_calve��5      $	��300��6%   $��35��61   $��-200,120,250,-100q�6=   $ WrapWithOverflow=�6X   �� 5   
   -   5         ��Name$
 Peli��5      $	��150��6   $	��150��6+   $��250,0,-300,250q�68   6m   �� 5   
   -   5         ��Name$ gusta��5      $��Me gusta��6    $	��140��63   $��40��6?   $��-300,200,250,-150q�6K   $��25(�6g     Btn#��[ 6�   �� 5    
   -	   5        $ No_Gusta��5       $��No me gusta��6#   $	��150��6:   $��40��6F   $��300,200,-250,-150q�6R   $��25(�6m   #��[ 6�   �� 5!   
   -
   5        $
 Busq��5!      $��Nueva Busqueda��6   $	��190��68   $��40��6D   $��200,200,5,-150q�6P   $��25(�6i   #��[ 6�   �� 5"   
   -   5        $	 opi��5"      $��Guardar��6   $	��190��60   $��40��6<   $��-200,200,5,-150q�6H   $��25(�6b   #��[ 6�   �� 5#   
   -   5        $ Busqueda��5#      $��Buscar por palabras��6#   $	��220��6A   $��50��6M   $��0,220,-100,0q�6Y   $��25(�6p   #��[ 6�   5%      5&      