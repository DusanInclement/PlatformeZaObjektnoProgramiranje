   M S B A M L   `   `   `  ����F  BProjekatPop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:ProjekatPopProjekatPop  5   	       ProjekatPop.AvionWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:ProjekatPop     5   	   -   5          � Title$  AvionWindow��5   	   $��399.013��6   $��990.806��6.    � WindowStartupLocation$ CenterScreen=�5	   	   .��5      � .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ dataGridAvioni��5      $
��Left=�6+   $��	26,20,0,0q�6F   $	��Top=�6Y   $	��226��6q   $	��685��6~      SelectionMode$ Single=�5         
IsReadOnly .  �� AlternationCount$ 2��5         AlternatingRowBackground
 � ���   CanUserAddRows .  5      �� 5   
   -   5         ��Name$ buttonObrisi��5      $��Obrisi��6'   $
��Left=�68   $��300,265,0,0q�6S   $	��Top=�6h   $	��110��6�   $��28��6�   6�   �� 5   
   -   5        $ buttonPromeni��5      $��Promeni��6(   $
��Left=�6:   $��162,265,0,0q�6U   $	��Top=�6j   $	��110��6�   $��28��6�   6�   �� 5   
   -   5        $ buttonDodaj��5      $��Dodaj��6&   $
��Left=�66   $��
26,265,0,0q�6Q   $	��Top=�6e   $	��110��6}   $��28��6�   6�   �� 5   
   -   5        	 ��Name$	 label1��5      $��Naziv: ��6    $
��Left=�62   $��
761,55,0,0q�6M   $	��Top=�6a   �� 5   
   -   5        $	 label2��5      $��AvioKompanija: ��6    $
��Left=�6:   $��711,101,0,0q�6U   $	��Top=�6j   �� 5   
   -   5        
 ��Name$
 textBoxNaziv��5      $
��Left=�6(   $��23��6C   $��
815,59,0,0q�6O    �� TextWrapping$
 Wrap=�6c   $�� ��6w   $	��Top=�6   $	��140��6�   6�   �� 5   
   -	   5        $
 textBoxAvioKompanija��5      $
��Left=�60   $��23��6K   $��815,105,0,0q�6W   $
 Wrap=�6l   $�� ��6�   $	��Top=�6�   $	��140��6�   6�   5      5      