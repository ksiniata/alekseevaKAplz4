   M S B A M L   `   `   `  ����D  @Alekseeva, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:Alekseeva	Alekseeva  5   	       Alekseeva.Admin   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:Alekseeva     5   	     � Title$/  )Панель Администратора��5   	   $	��500��6'   $	��600��64    � 
ResizeMode$ NoResize=�6@    � WindowStartupLocation$ CenterScreen=�6V   ��5	      �� 5
   
    �� 
StartPoint$	 0,0&�6    �� EndPoint$	 1,1&�6/   .��5      �  � Color$ 	AliceBlue��6    � Offset$	 1.0Q�6-   5      .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   �� $/��)Панель Администратора��6   $��24(�5      $
��Bold"�5      
���   �$��Center=�5      $��	0,20,0,20q�5      �� 5   
   $��1��6   $	��Top=�6"   $��Center=�6:   $	��500��6W   $��0,10,0,0q�6c   .+�5      �� -   5        $+��%Добавить Сотрудника��5      $	��200��5      $��40��5       
���P��
�������$��16(�5#      $
��Bold"�5$      $��Center=�5%      $��10q�5&      5'      �� 5)      -   5        $#��Изменить Пароль��5)      $	��200��5*      $��40��5+      
���P��
�������$��16(�5.      $
��Bold"�5/      $��Center=�50      $��10q�51      52      �� 54      -   5        $-��'Удалить Пользователя��54      $	��200��55      $��40��56      
���P��
�������$��16(�59      $
��Bold"�5:      $��Center=�5;      $��10q�5<      5=      �� 5?      -   5         ��Name$ UsersListBox��5?      $��1q�5@      
����d�
�������$��10q�5C      5D      5E      5F      5G      