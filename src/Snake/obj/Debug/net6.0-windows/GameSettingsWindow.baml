   M S B A M L   `   `   `  ����@  <Snake, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:SnakeSnake  5   	       Snake.GameSettingsWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   %localclr-namespace:Snake     5   	     � Title$  Snake��5   	   $	��550��6   $	��600��6$    � WindowStartupLocation$ CenterScreen=�60   ��5	      �� 5
   
    �� EndPoint$ 0.5,1&�6    �� 
StartPoint$ 0.5,0&�6/   .��5      �  � Color$ 	#FF2C1D3D��6   � 5      $ 	#FF7E3798��6    � Offset$ 1Q�6-   5      .��5      � .+�5   
   �� -   5         ��Name$ MapSizeLabel��5         	lblDesign#��[  6&   $��Map Size��6I   $��Center=�6\   $��0,10,0,0q�6y   $	��Top=�6�   $��30(�6�   
�������6�   �� 5   
   -   5        $ 
SpeedLabel��5      #��[  6$   $��Speed��6G   $��Center=�6W   $��	0,160,0,0q�6t   $	��Top=�6�   $��30(�6�   
�������6�   �� 5   
   -   5        $ 	ModeLabel��5      #��[  6#   $
��Mode��6F   $��Center=�6U   $��	0,310,0,0q�6r   $	��Top=�6�   
�������$��30(�6�   �� 5   
   -   5         ��Name$ SmallMapButton��5        	btnDesign#��[ 6)   $��Small��6L   $
��Left=�6\   $��	56,75,0,0q�6w   $	��Top=�6�   $��60��6�   $	��150��6�   6�   �� 5   
   -   5        $ NormalMapButton��5      #��[ 6*   $��Normal��6M   $��Center=�6^   $��0,75,0,0q�6{   $	��Top=�6�   $��60��6�   $	��150��6�   6�   �� 5   
   -   5        $ LargeMapButton��5      #��[ 6)   $��Large��6L   $��Right=�6\   $��	0,75,56,0q�6x   $	��Top=�6�   $��60��6�   $	��150��6�   6�   �� 5   
   -   5        $ SlowSpeedButton��5      #��[ 6*   $
��Slow��6M   $
��Left=�6\   $��
56,226,0,0q�6w   $	��Top=�6�   $��60��6�   $	��150��6�   6�   �� 5   
   -   5        $ NormalSpeedButton��5      #��[ 6,   $��Normal��6O   $��Center=�6`   $	��Top=�6}   $��60��6�   $	��150��6�   $��	0,226,0,0q�6�   6�   �� 5   
   -	   5        $ FastSpeedButton��5      #��[ 6*   $
��Fast��6M   $��Right=�6\   $��
0,226,56,0q�6x   $	��Top=�6�   $��60��6�   $	��150��6�   6�   �� 5   
   -
   5        $ NormalModeButton��5      #��[ 6+   $��Normal��6N   $
��Left=�6_   $��131,375,0,0q�6z   $	��Top=�6�   $��60��6�   $	��150��6�   6�   �� 5   
   -   5        $ WallModeButton��5      #��[ 6)   $��Walls��6L   $��Right=�6\   $��0,375,131,0q�6x   $	��Top=�6�   $��60��6�   $	��150��6�   6�   �� 5   
   -   5        $ GoBackButton��5      #��[ 6'   $
��Back��6J   $
��Left=�6Y   $��
25,469,0,0q�6t   $	��Top=�6�   $��30��6�   $	��110��6�   $��10(�6�   6�   �� 5   
   -   5        $ StartGameButton��5      #��[ 6*   $��
Start Game��6M   $��Right=�6b   $��
0,469,25,0q�6~   $	��Top=�6�   $��30��6�   $	��110��6�   $��10(�6�   6�   5      5      