   M S B A M L   `   `   `  ����>  :PS4, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:PS4PS4  5   	       PS4.MainWindow   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   #localclr-namespace:PS4     5   	     � Title$  
MainWindow��5   	    � SizeToContent$ WidthAndHeight=�6   .��5	      �  � RowDefinitions 5
   
   �� 5      $
��AUTO �6   �� 5      $
��AUTO �6   .+�5   
   �� $��0��6   $?��9Generator liczb pseudolosowych bazujący na metodzie LFSR��6    $��5q�6b   $��5q�6m   .��5      �� .+�5      ]� $
��True��6   .+�5      �� $��Powtórzenia ��6   $��5q�63   $��5q�6>   �� 5      -   5        $��seedLFSR��5   G   $��150px��6   $��5q�60   $��5q�6;   $	��...��6W   5      ]� 5      $
��True��6   .+�5      �� $��Wielomian   ��6   $��
5, 5, 7, 5q�63   $��5q�6G   �� 5      -   5        $��tapsLFSR��5   I   $��150.5px��6   $��5q�62   $��5q�6=   $	��...��6Y   5      �� 5       �� Orientation$ 
Horizontal=�6   $��Right=�66   .+�5      �� -   5        $��generate��5   b   $��Generuj��6   $��Right=�6/   $��5q�6K   $��5q�6W   6r   5      ]� 5      $
��True��6   .+�5      �� $��Wygenerowana liczba��6   $��
5, 5, 7, 5q�6:   $��5q�6N   �� 5      -   5        $��	generated��5   [   $��150.5px��6   $��5q�62   $��5q�6=   ${�False��6I   $��Wynik��6l   5      5       5!      �� 5#   
   $��1��6   $��Szyfr strumieniowy��6    $��5q�6<   $��5q�6G   .��5$      �� .+�5%      ]� $
��True��6   .+�5&      �� $��Ciąg bitów��6   $��5q�61   $��5q�6<   �� 5'      -   5        $��	bitString��5'   G   $��150px��6   $��5q�60   $��5q�6;   $	��...��6X   5(      ]� 5)      $
��True��6   .+�5*      �� $��Seed/Wielomian��6   $��5q�65   $��5q�6@   �� 5+      -   5        $��
streamSeed��5+   h   $��100px��6   $��5q�60   $��5q�6;   ${�false��6G    � ToolTip$
 Seed��6Y   $
��seed��6z   �� 5,      -   5        $��
streamTaps��5,   V   $��100px��6   $��5q�60   $��5q�6;   $
 Taps��6G   $	��...��6h   5-      �� 5.      $ 
Horizontal=�6   $��Right=�66   .+�5/      �� -   5        $��encrypt��5/   b   $��Zakoduj��6   $��Right=�6/   $��5q�6K   $��5q�6W   6q   50      ]� 51      $
��True��6   .+�52      �� $��Szyfr strumieniowy��6   $��5q�69   $��5q�6D   �� 53      -	   5        $��cipherResult��53   Y   $��150px��6   $��5q�60   $��5q�6;   ${�false��6G   $��Wynik��6m   54      55      56      57      58      