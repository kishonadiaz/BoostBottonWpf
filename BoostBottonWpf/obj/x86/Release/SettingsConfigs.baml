   M S B A M L   `   `   `  ���� I  EBoostBottonWpf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:BoostBottonWpfBoostBottonWpf  $    BoostBottonWpf.SettingsConfigs   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     .localclr-namespace:BoostBottonWpf     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     e aSystem.Activities.Presentation, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35NsapDhttp://schemas.microsoft.com/netfx/2009/xaml/activities/presentation  -     �Name$  
SettingWin�� � Title$ Settings��$��373.104��$��292.325�� � WindowStartupLocation$ Manual=� � WindowStyle$ 
ToolWindow=� � 	Resources ��%    .��� ���	#FFE0E0E0.+��� -    ��Name$ Traymode��
 J� Uid$ 
"traymode"��$	��108��$��21��$��	10,15,0,0q�$
��Left=�$	��Top=�$��	Tray Mode���� -    ��Name$ Save_Btn��$��50��$��23��$��243,220,0,0q�$
��Left=�$	��Top=�
����������	#FF159B27$
��Save�����	#FF159B27�� -   $ 
Cancel_Btn��$��50��$��23��$��298,220,0,0q�$
��Left=�$	��Top=����	#FF8F0F0F$��Cancel�����	#FF8F0F0F�� -   $ startintray��$ "startintray"��$	��144��$��18��$��	10,41,0,0q�$
��Left=�$	��Top=�$��Start InTray���� -   $ 
StartTimer��$��95��$��17��$��	10,64,0,0q�$
��Left=�$	��Top=�$��Start Timer�� d� 	IsChecked$
 TrueY�� $	��357��$	��117��$��	10,86,0,0q�$
��Left=�$	��Top=�.+�� -   	 �Name$	 timebox��$	��338��$��56��$	��Top=�.+�� -   
 �Name$
 	timergrid��$	��338��$��56�� J� RenderTransformOrigin$ 0.5,0.5&� � ColumnDefinitions �� z�V� .~��� �� ��  �� Angle$ 0.143Q�T� .+��� -	   $ StartTimeCheckBox��$	��155��$��18��$��6,30,0,0q�$
��Left=�$	��Top=�.��� -
   $
 starttimergrid��$	��135�� J� Effect -  'System.Windows.Media.Effects.BlurEffect  -   startgridblureffect��.+��� -    ��Name$ 	StartAmPm��$��19��$��82,0,0,0q�$	��Top=� �� SelectedIndex$ 0����Z� ��Z� .@��� $��50��$
��Left=�$��AM���� $��50��$
��Left=�$��PM���� -   $ 	starthour��$��41��$��19��$
��Left=�$	��Top=��� -   $ startmin��$��41��$��19��$��41,0,0,0q�$
��Left=�$	��Top=�$ 0.122,0.579&��� -    ��Name$ starttimefaderec��$��19��$��Bottom=����	#FFF4F4F5 J� Opacity$	 0.5Q�
���   ��� $��68��$��23��$��6,1,0,0q�$
��Left=�$	��Top=�$��
Start Time���� $��74��$��24��$��	161,1,0,0q�$
��Left=�$	��Top=�$��End Time���� -   $ EndTimeCheckBox��$	��157��$��18��$��
166,30,0,0q�$
��Left=�$	��Top=�.��� -   $
 endtimergrid��$	��131��   -   endgridblureffect�� � RowDefinitions �� $��0* ��� .+��� -   $ EndAmPm��$��2��$��19��$��86,0,0,0q�$	��Top=�$ 0����Z� ��Z� .@��� $��50��$
��Left=�$��AM���� $��50��$
��Left=�$��PM���� -   $ endhour��$��2��$��42��$��19��$��2,0,0,0q�$
��Left=�$	��Top=��� -   $ endmin��$��2��$��42��$��19��$��44,0,0,0q�$
��Left=�$	��Top=�$ -0.266,0.636&��� -   $ endfadeoffbec��$��2��$	��131��$��19��$
��Left=�$	��Top=����	#FFF4F4F5$	 0.5Q�
���   �� $��62��.+��� -   $ DialogClosecheck��$ "allwayclose"��$	��156��$��18��$��0,29,0,0q�$
��Left=�$	��Top=�$��Do not show close dialog��$ 0.5,0.5&�&   System.Windows.Media.TextOptions   TextFormattingMode$ Display=�z�V� .~��� ��  �� AngleX$ -0.227Q��� T�  T� X$ 0.004Q��� -   $ Notifications��$	��118��$��	0,5,38,37q�$��Notifications��