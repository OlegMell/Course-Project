   M S B A M L   `   `   `  ����M  ICourse Project Gym, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:Course_Project_GymCourse_Project_Gym  5   	   %    Course_Project_Gym.AddGraficWnd   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:Course_Project_Gym     5   	   V RMaterialDesignThemes.Wpf, Version=2.5.0.1205, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	     � Title$	  Add��5	   	   $	��400��6   $	��600��6"   .��5
      � -   5         �Name$ 	MainPanel��5
      .+�5   
   ��  �� RadiusX$ 15��6    �� RadiusY$ 15��6!   
������� J� Opacity$	 0.6Q�6;    J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5         Color$ 	#FF303030��6#      RenderingBias$ Quality=�65      ShadowDepth$ 2Q�6M   	   Opacity$		 0.2Q�6]   5      �� 5   
   
 �� Orientation$
 
Horizontal=�6   $��80��6.   $	��Top=�6:   .+�5      �� $��
ADD GRAFIC��6   $��35(�6*   $��200,10,-10,0q�68   $��DemiBold"�6N   $	��top=�6d   $	 0.7Q�6|   ���	#FFF44336$��Center=�6�   5      �� 5   
   $
 
Horizontal=�6   .+�5      �� $��	Set coach��6   $��10,80,10,102q�6*   .��5      �� .+�5      �� $��	10,10,0,0q�6   $	��300��61   $��18(�6=   $
��Left=�6K   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Search..��6f    %  !MaterialDesignFloatingHintTextBox#��[  6�   �� 5      -   5         ��Name$ NewsNameCmb��5      $��55��6�   $	��300��6�   $	��Top=�6�   $
��Left=�6�   $��18(�6�   $��
10,10,10,0q�6�   $ Coach��6�    & "MaterialDesignFloatingHintComboBox#��[ 6  ��6d   �� *Coach+��5      �� 5      .R�5   "   �� $
 
Horizontal=�6-   .+�5   &   A� $��50��6.   $��50��69   ��5   *   �� 5   .    �� ImageSource 69   �� *
ProfileImg+5   '   �� 5    &   $��10,0,0,0q�6F   $��18(�6X   ��60   �� *Name+6X   5!   #   5"      5$      5%      5&      �� 5'      $��Set time��6   $
��Left=�6)   $��Center=�6D   $��Center=�6h   $��10,80,0,102q�6�   $	��212��6�   .��5(      �� $
 Vertical=�6   .+�5)      �� -   5        $ Hours��5)      $��	10,0,10,0q�6.   $	��100��6A   $	��Top=�6M   $��18(�6e   $
 Hour��6s   #��[ 6�   �� 5*      -   5        $ Minutes��5*      $��3,20,0,0q�60   $	��100��6B   $	��Top=�6N   $��18(�6f   $ Minutes��6t   #��[ 6�   5+      5,      5-      �� 5.   
   -   5         ��Name$ AddFinallyBtn��5.      $��40��6D   ���	#FFF44336���	#FFF44336$��Bottom=�6   $	��100��6�   $	��ADD��6�   $��20q�6�   5/      50      