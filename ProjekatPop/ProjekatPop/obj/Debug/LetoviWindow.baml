   M S B A M L   `   `   `  ����F  BProjekatPop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:ProjekatPopProjekatPop  5   	       ProjekatPop.LetoviWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:ProjekatPop     5   	   -   5          � Title$  LetoviWindow��5   	   $��399.013��6   $��1142.906��6/    � WindowStartupLocation$ CenterScreen=�5	   	   .��5      � .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ dataGridLetovi��5      $
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
   -   5        	 ��Name$	 label2��5      $��Sifra:��6    $
��Left=�61   $��
786,65,0,0q�6L   $	��Top=�6`   �� 5   
   -   5        
 ��Name$
 textBoxSifra��5      $
��Left=�6(   $��23��6C   $��
884,66,0,0q�6O    �� TextWrapping$
 Wrap=�6c   $�� ��6w   $	��Top=�6   $	��185��6�   6�   �� 5   
   -   5        $	 
labelPilot��5      $��Cena:��6$   $
��Left=�64   $��786,165,0,0q�6O   $	��Top=�6d   �� 5   
   -	   5        $
 textBoxCena��5      $
��Left=�6'   $��23��6B   $��884,165,0,0q�6N   $
 Wrap=�6c   $�� ��6w   $	��Top=�6   $	��185��6�   6�   �� 5   
   -
   5        $	 label3��5      $��Avio Kompanija:��6    $
��Left=�6:   $��786,115,0,0q�6U   $	��Top=�6j   �� 5   
   -   5         ��Name$ comboBoxAerodrom��5      $
��Left=�6-   $��883,115,0,0q�6H   $	��Top=�6]   $	��185��6u   6�   �� 5   
   -   5        $	 label4��5      $��Polazni Grad:��6    $
��Left=�68   $��786,215,0,0q�6S   $	��Top=�6h   �� 5   
   -   5        $
 textBoxPolazniAerodrom��5      $
��Left=�62   $��23��6M   $��884,215,0,0q�6Y   $
 Wrap=�6n   $�� ��6�   $	��Top=�6�   $	��185��6�   6�   �� 5   
   -   5        $
 textBoxDestinacija��5      $
��Left=�6.   $��23��6I   $��884,266,0,0q�6U   $
 Wrap=�6j   $�� ��6~   $	��Top=�6�   $	��185��6�   6�   �� 5   
   -   5        $	 label5��5      $��Destinacija:��6    $
��Left=�67   $��786,265,0,0q�6R   $	��Top=�6g   �� 5   
   -   5        $	 label6��5      $��	Pretraga:��6    $
��Left=�64   $��
883,20,0,0q�6O   $	��Top=�6c   $��73��6{   5!      5"      