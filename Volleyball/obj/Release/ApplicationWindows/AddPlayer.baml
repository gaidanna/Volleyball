   M S B A M L   `   `   `  ����   
Volleyball    Volleyball.AddPlayer   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     -     � Title$  	AddPlayer��$	��400��$	��460�� � Icon$: 4D:\Source\Volleyball\Volleyball\Resources\iconVB.jpg��.��� ����  �� ImageSource$ ..\Resources\BGImage.jpg�� � RowDefinitions �� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto � � ColumnDefinitions �� $
��auto ��� $��* �.+��� $��0��$��0��$��60��$��	20 20 4 4q�$��Gender: ��� $��0��$��1�� �� $
��auto ��� $
��auto �.+�	� -   $��RadioButtonMale��$
��Male��$��0��$
��Left=�$��	20 20 4 4q�	� -   $��RadioButtonFemale��$��Female��$��1��$
��Left=�$��	20 20 4 4q��� $��1��$��0��$��60��$��20 4 4 4q�$��Team: ���� -   $��teamsCombobox��$��1��$��1�� �� DisplayMemberPath$
 Name��$��20 4 4 4q�$��25��$	��300��$
��Left=�{�.  ����  �� Path$ listOfTeams��� $��2��$��60��$��0��$��20 4 4 4q�$��Name: ���� -   $��
playerName��$��2��$��1��$��20 4 4 4q�$	��300��$
��Left=��� $��3��$��60��$��0��$��20 4 4 4q�$��Number: ���� -   $��playerNumber��$��3��$��1��$��20 4 4 4q�$	��300��$
��Left=��� $��4��$��60��$��0��$��20 4 4 4q�$��
Position: ���� -   $��amplua��$��4��$��1��$��20 4 4 4q�$	��300��$
��Left=��� $��5��$��60��$��0��$��20 4 4 4q�$��Age: ���� -   $��	playerAge��$��5��$��1��$��20 4 4 4q�$	��300��$
��Left=��� $��6��$��60��$��0��$��20 4 4 4q�$��Height: ���� -	   $��playerHeight��$��6��$��1��$��20 4 4 4q�$	��300��$
��Left=��� $��7��$��0��$��20 4 4 4q�$��Select image:��� $��7��$��1�� �� $
��auto ��� $��* �.+��� -
   $��	imagePath��$��0��$	��270��$��20 4 4 4q�$
��Left=��� -   $��imageButton��$	��...��$��1��$��20��$��6 4 4 4q�$
��Left=��� $��8��$��60��$��0��$��20 4 4 4q�$��Captain���� -   $��captainSign��$��8��$��1��$��20 4 4 4q�$
��Left=�� $��9��$��1��$��Right=�$��20q�.+��� -   $��
saveButton��$
��Save��$��80��$��4 8 4 8q�$��4 4 4 10q�$��38���� -   $��updateButton��$��Update��$��80��$��4 8 4 8q�$��4 4 4 10q�$��38��$y�	Collapsed=��� -   $��cancelButton��$��Cancel��$��80��$��4 8 4 8q�$��4 4 4 10q�$��38��