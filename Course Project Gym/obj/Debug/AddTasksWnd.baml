   M S B A M L   `   `   `  ����M  ICourse Project Gym, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:Course_Project_GymCourse_Project_Gym  5   	   $    Course_Project_Gym.AddTasksWnd   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   V RMaterialDesignThemes.Wpf, Version=2.5.0.1205, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   ,local clr-namespace:Course_Project_Gym  5   	     � Title$	  Add��5	   	   $	��500��6   $	��600��6"   .��5
      � -   5         �Name$ 	MainPanel��5
      .+�5   
   ��  �� RadiusX$ 15��6    �� RadiusY$ 15��6!   
������� J� Opacity$	 0.6Q�6;    J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5         Color$ 	#FF303030��6#      RenderingBias$ Quality=�65      ShadowDepth$ 2Q�6M   	   Opacity$		 0.2Q�6]   5      �� 5   
   
 �� Orientation$
 
Horizontal=�6   $��80��6.   $	��Top=�6:   .+�5      �� $��ADD TASK��6   $��35(�6(   $��200,10,-10,0q�66   $��DemiBold"�6L   $	��top=�6b   $	 0.7Q�6z   ���	#FFF44336$��Center=�6�   5      �� 5   
   -   5         ��Name$ TasksNameTb��5      $��65��6'   $	��Top=�63   $��20(�6K   $��10,80q�6Y   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Title��6h    %  !MaterialDesignFloatingHintTextBox#��[  6�   �� 5   
   -   5        $ TasksAboutTb��5      $	��115��6(    �� TextWrapping$
 Wrap=�65   $	��Top=�6I   $��18(�6a   $��10,170,10,0q�6o   $ About...��6�   #��[  6�   �� 5   
   $
 
Horizontal=�6   $��Bottom=�6.   $��64��6I   $��0,0,0,81q�6U   .+�5      �� -   5        $��226,10,10,10q�5      $��30��6B   $��30��6N   ���	#FFF44336 � DataContext$ 	#FFF44336��6p   ���	#FFF44336$��Center=�6�    & "MaterialDesignFloatingActionButton#��[ 6�   �� 5      -   5        $��10q�5      $��30��68   $��30��6D   
������$ 
LightGreen��6g   
������$��Center=�6�   #��[ 6�   �� 5      -   5        $��10q�5      $��30��68   $��30��6D   
�������$ LightYellow��6h   
�������$��Center=�6�   #��[ 6�   5      �� 5   
   -   5         ��Name$ AddFinallyBtn��5      $��40��6D   ���	#FFF44336���	#FFF44336$��Bottom=�6   $	��100��6�   $	��ADD��6�   $��20q�6�   5      5      