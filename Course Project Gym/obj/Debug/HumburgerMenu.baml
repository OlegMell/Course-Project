   M S B A M L   `   `   `  ����M  ICourse Project Gym, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:HamburgerMenuHamburgerMenu  5      !    HamburgerMenu.HumburgerMenu   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      V RMaterialDesignThemes.Wpf, Version=2.5.0.1205, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      'localclr-namespace:HamburgerMenu  5        � 	Resources  5
         OpenMenu �� TargetProperty �� 
TargetName9  3System.Windows.Media.Animation.EasingDoubleKeyFrame O� KeyTime O� Value  	CloseMenu��%|  &	        &	 4    �� 5   
   .��5      U� $V P(UIElement.RenderTransform).(TransformGroup.Children)[2].(RotateTransform.Angle)�6,   $ 	rectangle��6�   .\�5        $ 0��6'   $ 0Q�63     5      $ 0:0:0.5��6'   $
 43.5Q�69   5      U� 5      $V P(UIElement.RenderTransform).(TransformGroup.Children)[2].(RotateTransform.Angle)�6,   $ 
rectangle1��6�   .\�5        $ 0��6'   $ 0Q�63     5      $ 0:0:0.5��6'   $ -43.5Q�69   5      U� 5      $ (UIElement.Opacity)�6,   $ 
rectangle2��6\   .\�5        $ 0��6'   $ 1Q�63     5      $ 0:0:0.5��6'   $ 0Q�69   5      U� 5      $ (FrameworkElement.Width)�6,   $ GridMenu��6a   .\�5        $ 0��6'   $ 70Q�63     5      $ 0:0:0.5��6'   $	 400Q�69   5      5      �� 5   
   .��5      U� $V P(UIElement.RenderTransform).(TransformGroup.Children)[2].(RotateTransform.Angle)�6,   $ 	rectangle��6�   .\�5        $ 0��6'   $
 43.5Q�63     5       $ 0:0:0.5��6'   $ 0Q�69   5!      U� 5"      $V P(UIElement.RenderTransform).(TransformGroup.Children)[2].(RotateTransform.Angle)�6,   $ 
rectangle1��6�   .\�5#        $ 0��6'   $ -43.5Q�63     5$      $ 0:0:0.5��6'   $ 0Q�69   5%      U� 5&      $ (UIElement.Opacity)�6,   $ 
rectangle2��6\   .\�5'        $ 0��6'   $ 0Q�63     5(      $ 0:0:0.5��6'   $ 1Q�69   5)      U� 5*      $ (FrameworkElement.Width)�6,   $ GridMenu��6a   .\�5+        $ 0��6'   $	 400Q�63     5,      $ 0:0:0.5��6'   $ 50Q�69   5-      5.      5/      .��50      � .+�51   
   � -   5         �Name$ GridMenu��51      $
��Left=�6!   
������� J� Opacity$	 0.8Q�6O   $��50��6]    J� Effect 52      3  -System.Windows.Media.Effects.DropShadowEffect  53         ShadowDepth$ 2Q�6#   	   Opacity$	 0.595Q�63   
   Color$
 	#FF5F5E5E��6C   .+�55      �� $��Bottom=�6   .+�56      ��  �� RadiusX$ 2��6    �� RadiusY$ 2��6(   $��50��64   
�������$ 1Q�6M   57      �� 58      -   5         ��Name$ 
ButtonMenu��58      $��Right=�6)   $	��Top=�6E   $��50��6�   $��50��6�   ��6]   Z� ��6s   Z� .��59      � $��Center=�6   $��Center=�64   .+�5:      �� -   5         ��Name$ 	rectangle��5:       $��30��63   $��5��6>   $��0 0 0 0q�6I   
�������$��Center=�6f   $	��Top=�6�    J� RenderTransformOrigin$ -0,0.5&�6�   z�5;      V� 5<      .~�5=   "   �� �� 5>   "   �� 5?   "   T� 5@   "   5A      5C      �� 5D      -   5        $ 
rectangle1��5D       $��30��64   $��5��6?   $��	0 20 0 0 q�6J   
�������$��Center=�6i   $	��Top=�6�   $ -0,0.5&�6�   z�5E      V� 5F      .~�5G   "   �� �� 5H   "   �� 5I   "   T� 5J   "   5K      5M      �� 5N      -   5        $ 
rectangle2��5N       $��30��64   $��5��6?   $��0 10 0 0q�6J   
�������$��Center=�6h   $	��Top=�6�   5O      5P      �� 5Q      $��Bottom=�6<   $	��395��6m   y�6   �� *StateClosed+��6W   Z� .+�5R      �� -   5        $ CalendarBtn��5R      $	��150��6.   $��5q�6:   $
��Left=�6E   .��5S      ��  �� Orientation$ 
Horizontal=�6!   .+�5T      '  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.5.0.1205, Culture=neutral, PublicKeyToken=null]]   Kind$ Calendar=�62   �� 5U      $��Calendar��6$   $��5,0,0,0q�64   5V      5W      �� 5X      $	��150��6   $��5q�6%   $
��Left=�60   .��5Y      �� $ 
Horizontal=�6!   .+�5Z        $ Person=�62   �� 5[      $��Coach��6$   $��5,0,0,0q�61   5\      5]      �� 5^      -   5        $ 
ClientsBtn��5^      $	��150��6F   $��5q�6R   $
��Left=�6]   .��5_      �� $ 
Horizontal=�6!   .+�5`        $ Person=�62   �� 5a      $��Clients��6$   $��5,0,0,0q�63   5b      5c      �� 5d      $	��150��6   $��5q�6%   $
��Left=�60   .��5e      �� $ 
Horizontal=�6!   .+�5f        $ 
Wunderlist=�62   �� 5g      $��Subscriptions��6$   $��5,0,0,0q�69   5h      5i      �� 5j      $	��150��6   $��5q�6%   $
��Left=�60   .��5k      �� $ 
Horizontal=�6!   .+�5l        $ ServiceToolbox=�62   �� 5m      $��Services��6$   $��5,0,0,0q�64   5n      5o      5p      5q      5r      5s      