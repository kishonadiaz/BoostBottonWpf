   M S B A M L   `   `   `  ����I  EBoostBottonWpf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:BoostBottonWpfBoostBottonWpf  5          BoostBottonWpf.MainWindow   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .localclr-namespace:BoostBottonWpf     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      -   5          �Name$  boostbtnWIndow��5       � Title$ 
MainWindow��5	      $��162.5��5
      $��188.438��5       � AllowsTransparency .  � Icon$' !assets/black_hole_icon_149792.ico��5       � WindowStyle$
 None=�5      ��5      Z�  � 	Resources 5         
Boostbtnon �� ImageSource j� Stretch  Boostbtnoff  Boostbtnhover-  'System.Windows.Media.Effects.BlurEffect  TitleblurReset   Radius  TitleblurEffect��%D  &	        &	 G     &	 �     &	 �     &	 �     �� 5   
   $ assets/powerbtnon.png��5      $
 None=�5       �� 5!   
   $ assets/powerbtnoff.png��5#      $
 None=�5$      �� 5%   
   $ assets/powerbtnhover.png��5'      $ Uniform=�5(        5*   
   $ 0Q�6,     5+   
   $ 5Q�6-   5-      .��52      � 	 � ColumnDefinitions	 53   
   �� 54      .+�57   
   �� -   5        
 ��Name$
 BoostBtn��58      $��10,46,12,10q�59      $��0q�5;       J� IsManipulationEnabled .   ButtonStyle1#���  5@      ��5:      Z�  5A        FocusVisual �� Property �� Value J� SnapsToDevicePixels �� StrokeDashArray  Button.Static.Background �� Color  Button.Static.Border 	 Button.MouseOver.Background 
 Button.MouseOver.Border  Button.Pressed.Background  Button.Pressed.Border  Button.Disabled.Background  Button.Disabled.Border  Button.Disabled.Foreground �� 
TargetType �� 
TargetType ��Name ��Name �� Triggers P� Property P� Value �� 
TargetName��%�  &	       &	 �     &	 �     &		      &	
 #    &	 F    &	 i    &	 �    &	 �    &	 �    &	 �    7  7  7  7   7  �� 5B      .�5C      ��  � �� 5D      �� 5E      .R�5F   "   �� $��2q�5G   %    . #��� ��5I   %   $	 1 2R�5J   %   $��1��5K   %   5L      5N      5O      �� 5P      $ 	#FFDDDDDD��6C   �� 5Q      $ 	#FF707070��6?   �� 5R      $ 	#FFBEE6FD��6F   �� 5S      $ 	#FF3C7FB1��6B   �� 5T      $ 	#FFC4E5F6��6D   �� 5U      $ 	#FF2C628B��6@   �� 5V      $ 	#FFF4F4F4��6E   �� 5W      $ 	#FFADB2B5��6A   �� 5X      $ 	#FF838383��6E   �� 5Y      " ��6-   .�5Z      ��  �@�FocusVisualStyle8   69   �� 5[       � ��8  63   �� 5\       � ��8  64   �� 5]       � ��# � ��63   �� 5^       � ��$ 1q�68   �� 5_       � ��$ Center=�6C   �� 5`       � ��$ Center=�6A   �� 5a       � ��$ 1q�60   �� 5b       � �� 5c      �� 5d      " ��6.   .R�5e   "   �� $ border��5f   %   #��z��5g   %   #��z��5h   %   #��z��5i   %    . ._�5k   &   �� $ contentPresenter��5l   )   #��z��5m   )   #��z��5n   )   #��z��5o   )   |�.  ��. # z 5r   )   5s   #    5t   "   P� 5u   &    �@��IsDefaulted . . �5v   *   �� $ border��61   # � ��6\    � ��5w   '   P� 5y   &    � �� . . �5z   *   �� $ border��61   8   � ��6[   �� 5{   *   $ border��61   8   � ��6\   5|   '   5      5�      5�      5�      ��5�      �� 5�      $ assets/powerbtnoff.png��6   $
 None=�6B   5�      ]� 5�   
   $	��162��5�      $��33��5�      $
��Left=�5�      $	��Top=�5�      ��.  5�      �� 5�   
   -   5         ��Name$ Button_pressedCheck��5�      $��19��5�      $��18��5�      $��
0,31,-36,0q�5�      $��Right=�5�      $	��Top=�5�      $��CheckBox��5�      ��5�      Z� ��5�      Z� ��5�      Z� �� 5�   
   -   5        $ moving��5�      $��15��5�      $��16��5�      $��179,10,-32,0q�5�      $
��Left=�5�      $	��Top=�5�      $��CheckBox��5�      $y�Hidden=�5�      � 5�   
   -   5         �Name$ TitleBar��5�      $	��162��5�      $��33��5�      $
��Left=�5�      $	��Top=�5�      
������� J� Opacity$ .4Q�5�       J� Effect 5�        5�      .+�5�      �� $��91��5�      $��33��5�      $
��Left=�5�      $	��Top=�5�      $��
Boost Mode��5�       � Cursor$ Arrow��5�      $��Calibri)�5�      $��16(�5�      $
��Bold"�5�      �� 5�      -   5        $��34��5�      $��33��5�      $
��Left=�5�      $	��Top=�5�      $	��0,1q�5�      $��-��5�      $��20(�5�      $��UltraExpanded&�5�      $��	ExtraBold"�5�       �� IsCancel .  J� RenderTransformOrigin$ 0.017,0.455&�5�      ��.   � UseLayoutRounding  . ��5�      Z� ��5�      Z� 5�      �� 5�      -   5        $��32��5�      $��33��5�      $
��Left=�5�      $	��Top=�5�      $��X��5�      $��16(�5�      $
��Bold"�5�      
���  ��$ -0.371,0.312&�5�      ��5�      Z� ��5�      Z� 5�      5�      � 5�   
   -   5        $ Setting_BtnPanel��5�      $��28��5�      $��30��5�      $��
134,33,0,0q�5�      $
��Left=�5�      $	��Top=�5�      ���	#FF0C1A59$	 0.2Q�5�      ! J� OpacityMask
! �����.+�5�      �� -	   5        $
 
settingbtn��5�      $��28��5�      $��30��5�      $
��Left=�5�      $	��Top=�5�      
�������$��0,0,0,1q�5�      $��Button��5�      ��5�      Z� ��5�      Z� ! 5�      �� 5�      $F @assets/4137161-building-construction-industry-setting_114090.png��6!   $ Uniform=�6p    5�        5�      5�      5�      �� 5�   
   -
   5        $
 Helpbtn��5�      $��23��5      $��20��5     $��	0,163,0,0q�5     $
��Left=�5     $	��Top=�5     $�� ��5     ��5     Z� ��5     Z� ��5	     �� 5
     $&  assets/information_info_1565.png��6   $ Uniform=�6L   5     5     5     