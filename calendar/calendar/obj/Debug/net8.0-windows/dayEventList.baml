   M S B A M L   `   `   `  ����C  ?calendar, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:calendarcalendar  5          calendar.dayEventList   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      (localclr-namespace:calendar     5      $��Stretch=�5   7     � 	Resources  5	         SimpleExpanderButtonTemp �� 
TargetType ��Name �� Padding � ColumnDefinitions  PrimatyTextBrush F�Name J� RenderTransformOrigin �� Angle ��Name	 �� Triggers
 P� Property P� Value �� 
TargetName �� Property �� Value  SimpleExpanderTemp d�Name � OverridesDefaultStyle d� 	IsChecked �� Path �� RelativeSource��%Q  &	        &	 O    7   �� 5
   
   " d�6;   .R�5      �� $ ExpanderButtonBorder��6   #��z��5      #��z��5      #��z��5      # z��5      ._�5      �  5      �� 5      $
��Auto �6+   �� 5      $��* �6+   .+�5      �� 
������ $��2��63   A� 5      $��Circle��6   $��0��6,   #���  5      $��15��5      $��15��6)   $��Center=�5      $��Center=�6;   F� 5      $
 Sign��6   $��0��5      +����    ��- р�[ ��- ���-     ���- ��[ 	#���  5      $��6��5      $��6��6%   $��2��5      $��Center=�5       $��Center=�5!      $ 0.5,0.5&�5"      z�5#      �� 5$      $ 0Q�6.   5&      �� 5'      $ HeaderContent��6'   $��1��5(   '   $��4,0,0,0q�5)   '   $��Content��5*   '   5+      5,      	 5-      P� 5/      
 �@d�	IsChecked$
 TrueY�6/   . �50      �� $
 Sign��6-    � �� ��    ��- р�[ ��- 	6?   51      P� 54      
 �@J�IsMouseOver$
 true��55      . �56      �� $ Circle��58       � ��
 ������� 59      $
 Sign��5;       � ��
 �����5<      P� 5=      
 � ��$
 true��5>      . �5?      �� $ Circle��5A       � �� �	#FF526C7B�� 5B      $ Circle��5D       � ��$	 1.5��5C      5D      �� 5E      $
 Sign��5G       � �� �	#FF0033665H      5J      �� 5L   
   " 9�65   .R�5M      ]� .+�5N      d� $ ExpanderButton��6   $	��Top=�5O      8��  #��z��5Q      $
 True��5T      $��1.5,0q�5U       5R      �� $ 
IsExpanded� �� *TemplatedParent+5V      �� 5W      $ ExpanderContent��6#   $y�	Collapsed=�5X      $��Bottom=�5Y      5Z      	 5[      P� 5\      
 �@9�
IsExpanded$
 True��60   . �5]      �� $ ExpanderContent��6    � y�$ Visible=�5^   %   5_      5a      5b      .��5c      � $��Stretch=�6    5d   
   �� 5e      $��* �6    � RowDefinitions 5g   
   �� 5h      $
��Auto �6   �� 5i      $��* �6   �� 5j      $
��Auto �6   .+�5l   
   �� $��0��6   $��0��6     �� ContentStringFormat$ 
dd.MM.yyyy��6l   #���  6�   $
��Left=�6�   ��6-   �� *Date+ �� UpdateSourceTrigger$ PropertyChanged=�6�   �� 5m   
   -   5         ��Name$ EventListControl��5m   S   $��0��6   $��1��6'   ��64   �� *events+��5n      �� 5o      .R�5p      � $��Stretch=�6    5q      �� 5r      $
��Auto �6/   �� 5s      $��* �6/   .+�5v      A� $��7��6"   $��7��6,   $��0��67   $	��Top=�6�   $
��Left=�6�   $��0 3 0 0q�6�   ��6G   �� *Color+$ PropertyChanged=�6�   9� 5w      -   5        #��[ 5w   #   #���  6�   $��	10 0 0 0 q�6�   $��Stretch=�6�   ��6R   �� *Title+$ PropertyChanged=�.��5x      �� $
��Wrap=�6(   $��1��6<   #���  6�   ��6L   �� *Note+$ PropertyChanged=�6�   5y      5z      5{      ��5}      �� 5~      .R�5      $� 5�      5�      �� 5�   
     RoundButton#���  6     monthControlButton#���  6:   $��0��6g   $��2��6w   $	��Add��6�   $��10q�6�   $��Bottom=�6�   $��Right=�6�     ButtonBackBrush#���  6�   5�      5�      