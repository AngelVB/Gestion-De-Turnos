   M S B A M L   `   `   `  ����  	Siguiente    Siguiente.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5        � Title$  Login��5      $	��200��6   $	��400��6     � SizeToContent$ WidthAndHeight=�6,    � WindowStartupLocation$ CenterScreen=�6K   $	��400��6p   $	��200��6   $	��400��6�   $	��200��6�   .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5	      $��* �6   �� 5
      $
��Auto �6    � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5   
   �� -   5        $��LabelNombre��5   -   $��0��6   $��0��6    $��20,20,10,10q�6@   $	��Top=�6U   $��23��6m   $
��Auto��6y   $��Stretch=�6�   .��6�   NumColegiado6�   �� 5   
   -   5        $��LabelPassword��5   /   $��0��6   $��1��6!   $��20,10,10,10q�6D   $	��Top=�6Y   $��23��6q   .��6}   
Password6�   �� 5   
   -   5        $��TBNumColegiado��5   �   $��1��6   $��0��6"   $��10,20,20,10q�6/   $��3��6D   $
��Auto��6X   $��Stretch=�6f    �� 	MaxLength$ 10��6�    �� MaxLines$ 1��6�   G� 5   
   -   5        $��
TBPassword��5   ]   $��1��6   $��1��6'   $��10,10,20,10q�64   $��3��6I    G� 	MaxLength$ 20��6o   �� 5   
   -   5        $��Button1��5   w   $��2��6   $��3��6!   $��
10,10,6,20q�6.   $��75��6B   $��23��6M   $��Stretch=�6Y   .��6�   
Cancelar6�   �� 5   
   -   5        $��Button2��5   Y   $��3��6   $��3��6!   $��
6,10,20,20q�6.   $��75��6B   $��23��6M   .��6h   Login6o   5      5      