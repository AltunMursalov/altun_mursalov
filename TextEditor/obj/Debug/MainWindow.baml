   M S B A M L   `   `   `  ����E  ATextEditor, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:TextEditor
TextEditor  5   	       TextEditor.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:TextEditor     5   	   -   5        $	��250��5   	   $	��420��6     � Title$  Text Editor - NewTextFile��5
   	   $	��500��6+   $	��800��68   .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   ��  �� Orientation$ 
Horizontal=�6   $��0��6.   ���#0C0C0D.+�5      o� $��0��6   $
��Auto��6    $
��Auto��6-   ���#0C0C0D.@�5      m� $
��File��6   $��15(�6)   ���#F9F9FA.@�5      m� -   5        $
��Open��5      ���#0000006B   m� 5      -   5        $
��Save��5      ���#0000006B   5      m� 5      $
��Edit��6   $��15(�6)   ���#F9F9FA.@�5      m� -   5        $��copyBtn��5      $
��Copy��6.   ���#0000006Q   m� 5      -   5        $	��Cut��5      ���#0000006A   m� 5      -   5        $��Paste��5      ���#0000006C   m� 5      -   5        $��
Select All��5      ���#0000006H   5      5      �� 5      $��	AutoSave:��6   $��15(�6(   $��0 -4 0 0q�66   ���#F9F9FA6H   �� 5      -   5        $��-4 5 0 0q�5      6D   5      �� 5    
   -	   5        $��contentTextBox��5       $��1��6(    �� 	IsEnabled . $��18(�6Q    �� TextWrapping$
 Wrap=�6_    �� AcceptsReturn . 6s   5!      5"      