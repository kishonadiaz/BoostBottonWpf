   M S B A M L   `   `   `  ���� I  EBoostBottonWpf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:BoostBottonWpfBoostBottonWpf      BoostBottonWpf.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     .localclr-namespace:BoostBottonWpf     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     -     �Name$  boostbtnWIndow�� � Title$ 
MainWindow��$��162.5��$��188.438�� � AllowsTransparency .  � Icon$' !assets/black_hole_icon_149792.ico�� � WindowStyle$
 None=���Z�  � 	Resources    
Boostbtnon �� ImageSource j� Stretch  Boostbtnoff  Boostbtnhover-  'System.Windows.Media.Effects.BlurEffect  TitleblurReset   Radius  TitleblurEffect��%�   &	        &	 ,     &	 Y     &	 �     &	 �     �� $ assets/powerbtnon.png��$
 None=��� $ assets/powerbtnoff.png��$
 None=��� $ assets/powerbtnhover.png��$ Uniform=�  $ 0Q�  $ 5Q�.��� 	 � ColumnDefinitions	 �� .+��� -   
 ��Name$
 BoostBtn��$��10,46,12,10q�$��0q� J� IsManipulationEnabled .   ButtonStyle1#���  ��Z�    FocusVisual �� Property �� Value J� SnapsToDevicePixels �� StrokeDashArray  Button.Static.Background �� Color  Button.Static.Border 	 Button.MouseOver.Background 
 Button.MouseOver.Border  Button.Pressed.Background  Button.Pressed.Border  Button.Disabled.Background  Button.Disabled.Border  Button.Disabled.Foreground �� 
TargetType �� 
TargetType ��Name ��Name �� Triggers P� Property P� Value �� 
TargetName��%�  &	       &	 N     &	 c     &		 x     &	
 �     &	 �     &	 �     &	 �     &	 �     &	 �     &	     7  7  7  7   7  �� .���  � �� �� .R��� $��2q� . #��� ��$	 1 2R�$��1���� $ 	#FFDDDDDD���� $ 	#FF707070���� $ 	#FFBEE6FD���� $ 	#FF3C7FB1���� $ 	#FFC4E5F6���� $ 	#FF2C628B���� $ 	#FFF4F4F4���� $ 	#FFADB2B5���� $ 	#FF838383���� " ��.���  �@�FocusVisualStyle8   ��  � ��8  ��  � ��8  ��  � ��# � ����  � ��$ 1q���  � ��$ Center=���  � ��$ Center=���  � ��$ 1q���  � �� �� " ��.R��� $ border��#��z��#��z��#��z�� . ._��� $ contentPresenter��#��z��#��z��#��z��|�.  ��. # z  P�  �@��IsDefaulted . . ��� $ border��# � �� � ��P�  � �� . . ��� $ border��8   � ���� $ border��8   � ������ $ assets/powerbtnoff.png��$
 None=�]� $	��162��$��33��$
��Left=�$	��Top=���.  �� -    ��Name$ Button_pressedCheck��$��19��$��18��$��
0,31,-36,0q�$��Right=�$	��Top=�$��CheckBox����Z� ��Z� ��Z� �� -   $ moving��$��15��$��16��$��179,10,-32,0q�$
��Left=�$	��Top=�$��CheckBox��$y�Hidden=�� -    �Name$ TitleBar��$	��162��$��33��$
��Left=�$	��Top=�
������� J� Opacity$ .4Q� J� Effect   .+��� $��91��$��33��$
��Left=�$	��Top=�$��
Boost Mode�� � Cursor$ Arrow��$��Calibri)�$��16(�$
��Bold"��� -   $��34��$��33��$
��Left=�$	��Top=�$	��0,1q�$��-��$��20(�$��UltraExpanded&�$��	ExtraBold"� �� IsCancel .  J� RenderTransformOrigin$ 0.017,0.455&���.   � UseLayoutRounding  . ��Z� ��Z� �� -   $��32��$��33��$
��Left=�$	��Top=�$��X��$��16(�$
��Bold"�
���  ��$ -0.371,0.312&���Z� ��Z� � -   $ Setting_BtnPanel��$��28��$��30��$��
134,33,0,0q�$
��Left=�$	��Top=����	#FF0C1A59$	 0.2Q�! J� OpacityMask
! �����.+��� -	   $
 
settingbtn��$��28��$��30��$
��Left=�$	��Top=�
�������$��0,0,0,1q�$��Button����Z� ��Z� ! �� $F @assets/4137161-building-construction-industry-setting_114090.png��$ Uniform=�   �� -
   $
 Helpbtn��$��23��$��20��$��	0,163,0,0q�$
��Left=�$	��Top=�$�� ����Z� ��Z� ���� $&  assets/information_info_1565.png��$ Uniform=�