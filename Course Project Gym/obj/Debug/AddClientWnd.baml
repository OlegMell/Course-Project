   M S B A M L   `   `   `  ����M  ICourse Project Gym, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:Course_Project_GymCourse_Project_Gym  5   	   %    Course_Project_Gym.AddClientWnd   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   V RMaterialDesignThemes.Wpf, Version=2.5.0.1205, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   ,local clr-namespace:Course_Project_Gym  5   	     � Title$	  Add��5	   	   $	��400��6   $	��600��6"   .��5
      �� .+�5   
   ��  �� RadiusX$ 15��6    �� RadiusY$ 15��6!   
������� J� Opacity$	 0.6Q�6;    J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5         Color$ 	#FF303030��6#      RenderingBias$ Quality=�65      ShadowDepth$ 2Q�6M      Opacity$	 0.2Q�6]   5      �� 5   
   	 �� Orientation$	 
Horizontal=�6   $��80��6.   $	��Top=�6:   .+�5      �� $��ADD CLIENTS��6   $��35(�6+   $��200,10,-10,0q�69   $��DemiBold"�6O   $	��top=�6e   $	 0.7Q�6}   ���	#FFF44336$��Center=�6�   5      �� 5   
   .+�5      �� -   5        
 ��Name$
 ClientsNameTb��5      $��5q�6-   $��50��68   $��20(�6D   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$
 Name��6R    %  !MaterialDesignFloatingHintTextBox#��[  6x   �� 5      -   5        $
 ClientsSurNameTb��5      $��50��60   $��5,10,5,0q�6<    �� TextWrapping$
 Wrap=�6N   $��20(�6b   $ Surname��6p   #��[  6�   �� 5      -   5        $
 ClientsPhoneTb��5      $��50��6.   $
 Wrap=�6:   $��20(�6N   $ Phone number��6\   $��5,10,5,0q�6�   5      �� 5   
   -   5         ��Name$ AddFinallyBtn��5      $��40��6D   ���	#FFF44336���	#FFF44336$��Bottom=�6   $	��100��6�   $	��ADD��6�   $��50q�6�   5      5      