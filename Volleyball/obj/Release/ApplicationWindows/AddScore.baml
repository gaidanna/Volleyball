   M S B A M L   `   `   `  ����   
Volleyball,    &Volleyball.ApplicationWindows.AddScore   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     -     � Title$  	Add Score��$	��190��$	��300�� � Icon$: 4D:\Source\Volleyball\Volleyball\Resources\iconVB.jpg��.��� ����  �� ImageSource$ ..\Resources\BGImage.jpg�� � RowDefinitions �� $
��auto ��� $��* �.+�� $��0��$	��100�� � ColumnDefinitions �� $
��auto ��� $��* ��� $
��auto �.+�� $��0�� �� $
��auto ��� $��* �.+��� -   $��TeamOneName��$��0��$��Center=�$��25��$	��Top=�$��10 4 4 4q��� -   $��ScoreTeamOne��$��1��$
��Left=�$��25�� �� TextWrapping$
 Wrap=�$	��Top=�$	��125��$��10 4 4 4q��� $��1��$��Center=�$��4 40 4 4q�$��:��$	��Top=�� $��2�� �� $
��auto ��� $��* �.+��� -   $��TeamTwoName��$��0��$��Center=�$��25��$	��Top=�$��4 4 10 4q��� -   $��ScoreTeamTwo��$��1��$
��Left=�$��25��$
 Wrap=�$	��Top=�$	��125��$��4 4 10 4q��� $��1�� �� Orientation$ 
Horizontal=�$��Right=�$��Bottom=�.+��� -   $��
saveButton��$
��Save��$��
10 4 10 10q�$��90��$��35���� -   $��cancelButton��$��Cancel��$��	0 4 10 10q�$��90��$��35��