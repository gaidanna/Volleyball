   M S B A M L   `   `   `  ����   
Volleyball1    +Volleyball.ApplicationWindows.AddTeamWindow   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     -     � Title$  AddTeamWindow��$	��335��$	��565�� � Icon$: 4D:\Source\Volleyball\Volleyball\Resources\iconVB.jpg��.��� ����  �� ImageSource$ ..\Resources\BGImage.jpg�� � ColumnDefinitions �� $
��auto ��� $��* �.+�� $��0�� �� $
��auto ��� $��* � � RowDefinitions �� $
��auto ��� $
��auto ��� $��* �.+�� $��0�� �� $
��auto ��� $��* ��� $��* �.+��� $��0��$��
15 37 4 10q�$��Select league: ��	� -   $��RadioButtonMale��$
��Male��$��1��$
��Left=�$��	5 37 4 10q�$��16��$��42��	� -   $��RadioButtonFemale��$��Female��$��2��$
��Left=�$��	0 37 4 10q�$��16��$��55��� $��1�� �� $
��auto ��� $��* � �� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto �.+��� $��0��$��0��$��15 4 4 4q�$��	Team Name���� -   $
��team��$��0��$��1��$	��150��$��4q�$
��Left=��� $��1��$��0��$��15 4 4 4q�$��Manager���� -   $��manager��$��1��$��1��$	��150��$��4q�$
��Left=��� $��2��$��0��$��15 4 4 4q�$��Phone:���� -   $��phone��$��2��$��1��$	��150��$��4q�$
��Left=��� $��3��$��0��$��15 4 4 4q�$��Email:���� -   $��email��$��3��$��1��$	��150��$��4q�$
��Left=��� $��4��$��0��$��15 4 4 4q�$��Select image:��� $��1��$��4�� �� $
��auto ��� $��* �.+��� -   $��imageUrl��$��0��$	��120��$��4q�$
��Left=��� -	   $��imageButton��$	��...��$��1��$��20��$��6 4 4 4q�$
��Left=�� $��2�� �� $
��auto ��� $��* �.+��� -
   $��	AddPlayer��$��
Add Player��$��0��$��Right=�$��	25 10 4 4q�$	��Top=�$��39��$��90��{�.  �� -   $��UpdatePlayer��$��Update Player��$��0��$��Right=�$��	25 10 4 4q�$	��Top=�$��39��$��90��$y�	Collapsed=��� -   $��DeletePlayer��$��Remove Player��$��1��$
��Left=�$��4 10 4 4q�$	��Top=�$��39��$��90��{�.  � $��1�� �� $
��auto ��� $
��auto ��� $��* �.+�� $��0�� �� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto �.+��� $	��100��$��0��$��	15,15,4,2q�$
��Name���� $��15��$��1��$��4,15,4,2q�$��#���� $��87��$��2��$��4,15,4,2q�$��Position���� $��3��$��4,15,4,2q�$��Captain��� $��1��.+��� -   $��listBoxPlayers��$��Center=�$��4 4 15 4q�$	��280��$	��200�� �� SelectionMode$ Single=����� *playersList+���� .R��  �� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto �.+��� $	��100��$��CharacterEllipsis=�$��0��$��2,2,4,2q����� *Name+�� $��15��$��CharacterEllipsis=�$��1��$��4,2,4,2q����� *Number+�� $	��100��$��2��$��4,2,4,2q����� *Amplua+�� $��	isCaptain��$��20��$��3��$��4,2,4,2q����� *CaptainTextPresentation+� $��2��$��Right=�$��Bottom=�.+�� $��4q�.+��� -   $
��Save��$
��Save��$��80��$��4 8 4 8q�$��4q��� -   $��Cancel��$��Cancel��$��80��$��4 8 4 8q�$��4q�