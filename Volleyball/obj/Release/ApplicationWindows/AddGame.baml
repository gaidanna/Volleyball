   M S B A M L   `   `   `  ����   
Volleyball+    %Volleyball.ApplicationWindows.AddGame   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     -     � Title$  AddGame��$	��690��$	��850�� � Icon$: 4D:\Source\Volleyball\Volleyball\Resources\iconVB.jpg�� � 	Resources    	GrayStyle �� 
TargetType �� Property �� Value  RedStyle  YellowStyle  TransparentBlue �� Color �� Opacity��%�   &	        &	 %     &	 b     &	 �     �� " ��.���  � ��
 ������� " ��.���  � ��
 �  ����  � ��
 ������� " ��.���  � ��
 � �����  � ��
 ������� $ #ffffff��$	 0.5Q�.��� ����  �� ImageSource$ ..\Resources\BGImage.jpg��	 � RowDefinitions	 �� $
��auto ��� $
��auto �.+�� $��0��$��0 30 0 0q�
 � ColumnDefinitions
 �� $
��auto ��� $��* �.+�� $��0��
 �� $
��auto ��� $
��auto �	 �� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $��* �.+��� $��0��$��0��$��30 6 6 6q�$��Select league: ��$	��100��$��Segoe UI)�
�������� $��0��$��1��$��2��
 �� $
��auto ��� $
��auto �.+�	� -   $��RadioButtonMale��$��0��$
��Male��$
��Left=�$��6q�$	��Top=�	� -   $��RadioButtonFemale��$��1��$��Female��$
��Left=�$��6q�$	��Top=��� $��1��$��0��$��30 6 6 6q�$	��100��$��First Referee: ���� -   $��	mainJudge��$��1��$��1��$	��150��$��6q�$
��Left=�#��[ �� $��2��$��0��$	��100��$��30 6 6 6q�$��Second Referee: ���� -   $��secondJudge��$��2��$��1��$	��150��$��6q�$
��Left=�#��[ �� $��3��$��0��$
��Left=�$��30 6 6 6q�$��
Location: ��$	��Top=�$	��100���� -   $��LocationTstBox��$��3��$��1��$
��Left=�$��6q�$	��Top=�$	��150��#��[ �� $��4��$��0��$	��100��$
��Left=�$��30 6 6 6q�$	��Top=�$��First Team: ���� -   $��	team1Name��$��4��$��1��$	��150��$��6q�$
��Left=�$	��Top=�{�.  #��[ �� $��5��$��0��$	��100��$
��Left=�$��30 6 6 6q�$	��Top=�$��Second Team: ���� -   $��	team2Name��$��5��$��1��$	��150��$��6q�$
��Left=�{�.  #��[ �� -	   $��gameDate��$��6��$��0��$
��Left=�$��30 6 6 6q�$��Date of Game: ��$	��Top=�$	��100��(  "System.Windows.Controls.DatePicker  -
   $��
datePicker��$��6��$��1��$
��Left=�$��6q�$	��Top=�$	��150��#��[ � $��1��
 �� $
��auto ��� $
��auto �	 �� $
��auto ��� $
��auto �.+��� -   $��TeamOneName��$��0��$��0��$��4q��� -   $��TeamTwoName��$��1��$��0��$��4q��� -   $��listviewTeamOne�� �� SelectionMode$ Single=�$��1��$��0��$
��Left=�$	��207��$��4q�$	��Top=�$	��250��#��[  �� View �� .P���  �� HeaderContainerStyle# [  $��
First Name�� �� Width$	 125�� �� DisplayMemberBinding ��  �� Path$
 Name��� # [  $��Number��$ 30�� �� $ Number��� # [ $
��🌟��$ 30�� �� CellTemplate �� .R��� $��chBoxBestPlTeam1��-    � DataContext$ 
bestPlayer��
 � Tag �� *
bestPlayer+�� # [ $	��▋��$ 30�� �� .R��� $��chBoxYellowTeam1��$ 
yellowCard�� �� *
yellowCard+�� # [ $	��▋��$ 30�� �� .R��� $��chBoxRedTeam1��$ redCard�� �� *	redCard+�� -    ��Name$ listviewTeamTwo��$��1��$��1��$
��Left=�$	��207��$��4q�$	��Top=�$	��250��#��[  �� .P��� # [  $��
First Name��$	 125�� �� *Name+�� # [  $��Number��$ 30�� �� *Number+�� # [ $
��🌟��$ 30�� �� .R��� $��chBoxBestPlTeam2��-   $ 
bestPlayer�� �� *
bestPlayer+�� # [ $	��▋��$ 30�� �� .R��� $��chBoxYellowTeam2��$ 
yellowCard�� �� *
yellowCard+�� # [ $	��▋��$ 30�� �� .R��� $��chBoxRedTeam2�� �� *	redCard+� $��1��$��0 30 0 0q�	 �� $
��auto ��� $��* �.+�� $��0��
 �� $
��auto ��� $��* �.+�� $��0��$��4 35 4 4q�	 �� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto �.+��� $��1.��$��Right=�$��30 6 6 6q�$	��100��$��0��$��25��$��Center=��� $��2.��$��Right=�$��30 6 6 6q�$	��100��$��1��$��25��$��Center=��� $��3.��$��Right=�$��30 6 6 6q�$	��100��$��2��$��25��$��Center=��� $��4.��$��Right=�$��30 6 6 6q�$	��100��$��3��$��25��$��Center=��� $��5.��$��Right=�$��30 6 6 6q�$	��100��$��4��$��25��$��Center=�� $��1��	 �� $
��auto ��� $
��auto �.+��� -   $ listviewScore��$��0��$ Single=�$
��Left=�$	��200��$��4 20 4 4q�$	��Top=�$	��660��#��[ ���� *score+ �� .P��� $��
First Team��$	 330�� �� .R��� $��25��$��3q�$��Right=����� *Item1+�� $��Second Team��$	 330�� �� .R��� $��25��$��3q�$
��Left=����� *Item2+� $��1��.+��� $��2�� �� Orientation$ 
Horizontal=�$��Center=�$	��Top=�$��10 10 10 10q�.+��� -   $��AddScore��$��	Add Score��$��4 8 4 8q�$��4 7 4 0q�{�.  $
��Left=�$	��Top=�$	��110��$��40���� -   $��DeleteScore��$��Remove Score��$��4 8 4 8q�$��4 7 20 0q�{�.  $
��Left=�$	��Top=�$	��110��$��40���� $��2��$ 
Horizontal=�$��Right=�$��Bottom=�$��10 10 10 10q�.+��� -   $��
SaveButton��$
��Save��$��80��$��4 8 4 8q�$��4 7 4 20q��� -   $��CancelButton��$��Cancel��$��80��$��4 8 4 8q�$��	4 7 20 20q�