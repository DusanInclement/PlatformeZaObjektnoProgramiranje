   M S B A M L   `   `   `  ����F  BProjekatPop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:ProjekatPopProjekatPop  5   	       ProjekatPop.LetoviZaKartu   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:ProjekatPop     5   	   -   5          � Title$  LetoviZaKartu��5   	   $��705.139��6   $��1002.67��60    � WindowStartupLocation$ CenterScreen=�5
   	   .��5      � .+�5   
   �� -   5         ��Name$ label��5      $��Izaberite Let:��6   $
��Left=�68   $��
316,19,0,0q�6S   $	��Top=�6g   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ dataGridLetovi��5      $
��Left=�6+   $	��196��6F   $��	10,70,0,0q�6S   $	��Top=�6f   $	��666��6~      SelectionMode$ Single=�5         
IsReadOnly .  �� AlternationCount$ 2��5         AlternatingRowBackground
 � ���   CanUserAddRows .  5      �� 5   
   -   5        	 ��Name$	 buttonKupiKartu��5      $��
Kupi Kartu��6*   $
��Left=�6?   $��142,516,0,0q�6Z   $	��Top=�6o   $	��128��6�   $��32��6�   6�   �� 5   
   -   5        $	 buttonOdustani��5      $��Odustani��6)   $
��Left=�6<   $��443,516,0,0q�6W   $	��Top=�6l   $	��128��6�   $��32��6�     5   
   -   5        $ dataGridPovratniLet��5      $
��Left=�60   $	��124��6K   $��
10,339,0,0q�6X   $	��Top=�6l   $	��666��6�   $ Single=�5       . $ 2��5      
 � ��� .  5      �� 5   
   -   5        $ label1��5      $��Povratni Letovi:��6    $
��Left=�6;   $��302,290,0,0q�6V   $	��Top=�6k   �� 5   
   -   5        $ label2��5      $��Sifra:��6    $
��Left=�61   $��
701,72,0,0q�6L   $	��Top=�6`   �� 5    
   -	   5        
 ��Name$
 textBoxSifra��5       $
��Left=�6(   $��23��6C   $��
798,73,0,0q�6O    �� TextWrapping$
 Wrap=�6c   $�� ��6w   $	��Top=�6   $	��185��6�   6�   �� 5!   
   -
   5        $ 
labelPilot��5!      $��Cena:��6$   $
��Left=�64   $��701,172,0,0q�6O   $	��Top=�6d   �� 5"   
   -   5        $
 textBoxCena��5"      $
��Left=�6'   $��23��6B   $��798,172,0,0q�6N   $
 Wrap=�6c   $�� ��6w   $	��Top=�6   $	��185��6�   6�   �� 5#   
   -   5        $ label3��5#      $��Avio Kompanija:��6    $
��Left=�6:   $��701,122,0,0q�6U   $	��Top=�6j   �� 5$   
   -   5         ��Name$ comboBoxAerodrom��5$      $
��Left=�6-   $��798,122,0,0q�6H   $	��Top=�6]   $	��185��6u   6�   �� 5%   
   -   5        $ label4��5%      $��Polazni Grad:��6    $
��Left=�68   $��701,222,0,0q�6S   $	��Top=�6h   �� 5&   
   -   5        $
 textBoxPolazniAerodrom��5&      $
��Left=�62   $��23��6M   $��798,222,0,0q�6Y   $
 Wrap=�6n   $�� ��6�   $	��Top=�6�   $	��185��6�   6�   �� 5'   
   -   5        $
 textBoxDestinacija��5'      $
��Left=�6.   $��23��6I   $��798,273,0,0q�6U   $
 Wrap=�6j   $�� ��6~   $	��Top=�6�   $	��185��6�   6�   �� 5(   
   -   5        $ label5��5(      $��Destinacija:��6    $
��Left=�67   $��701,272,0,0q�6R   $	��Top=�6g   �� 5)   
   -   5        $ label6��5)      $��	Pretraga:��6    $
��Left=�64   $��
798,27,0,0q�6O   $	��Top=�6c   $��73��6{   5-      5.      