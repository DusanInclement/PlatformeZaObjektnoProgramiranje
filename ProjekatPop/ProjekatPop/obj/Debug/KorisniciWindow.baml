   M S B A M L   `   `   `  ����F  BProjekatPop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:ProjekatPopProjekatPop  5   	   !    ProjekatPop.KorisniciWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:ProjekatPop     5   	   -   5          � Title$  KorisniciWindow��5   	   $��358.213��6!   $��1028.006��62    � WindowStartupLocation$ CenterScreen=�5	   	   .��5      � .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ dataGridKorisnici��5      $
��Left=�6.   $��	26,20,0,0q�6I   $	��Top=�6\   $	��226��6t   $	��685��6�      SelectionMode$ Single=�5         
IsReadOnly .  �� AlternationCount$ 2��5         AlternatingRowBackground
 � ���   CanUserAddRows .  5      �� 5   
   -   5         ��Name$ buttonObrisi��5      $��Obrisi��6'   $
��Left=�68   $��334,266,0,0q�6S   $	��Top=�6h   $	��110��6�   $��28��6�   6�   �� 5   
   -   5        $ buttonPromeni��5      $��Promeni��6(   $
��Left=�6:   $��187,266,0,0q�6U   $	��Top=�6j   $	��110��6�   $��28��6�   6�   �� 5   
   -   5        $ buttonDodaj��5      $��Dodaj��6&   $
��Left=�66   $��
26,266,0,0q�6Q   $	��Top=�6e   $	��110��6~   $��28��6�   6�   �� 5   
   -   5        	 ��Name$	 label1��5      $
��Ime:��6    $
��Left=�6/   $��
756,40,0,0q�6J   $	��Top=�6^   �� 5   
   -   5        $	 label2��5      $��Prezime:��6    $
��Left=�63   $��
756,90,0,0q�6N   $	��Top=�6b   �� 5   
   -   5        $	 label3��5      $��	UserName:��6    $
��Left=�64   $��756,140,0,0q�6O   $	��Top=�6d   �� 5   
   -	   5        $	 label4��5      $
��Tip:��6    $
��Left=�6/   $��756,190,0,0q�6J   $	��Top=�6_   �� 5   
   -
   5        
 ��Name$
 
textBoxIme��5      $
��Left=�6&   $��23��6A   $��
838,43,0,0q�6M    �� TextWrapping$
 Wrap=�6a   $�� ��6u   $	��Top=�6}   $	��161��6�   6�   �� 5   
   -   5        $
 textBoxPrezime��5      $
��Left=�6*   $��23��6E   $��
838,93,0,0q�6Q   $
 Wrap=�6e   $�� ��6y   $	��Top=�6�   $	��161��6�   6�   �� 5   
   -   5        $
 textBoxUserName��5      $
��Left=�6+   $��23��6F   $��838,144,0,0q�6R   $
 Wrap=�6g   $�� ��6{   $	��Top=�6�   $	��161��6�   6�   �� 5   
   -   5        $
 
textBoxTip��5      $
��Left=�6&   $��23��6A   $��838,195,0,0q�6M   $
 Wrap=�6b   $�� ��6v   $	��Top=�6~   $	��161��6�   6�   5      5       