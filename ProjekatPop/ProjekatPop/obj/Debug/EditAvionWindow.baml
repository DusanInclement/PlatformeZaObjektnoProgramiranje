   M S B A M L   `   `   `  ����F  BProjekatPop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:ProjekatPopProjekatPop  5   	   !    ProjekatPop.EditAvionWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:ProjekatPop     5   	     � Title$  EditAvionWindow��5   	   $��406.594��6!   $��366.195��62    � WindowStartupLocation$ CenterScreen=�5	   	   .��5
      � .+�5   
   �� -   5         ��Name$ label��5      $��Naziv: ��6   $
��Left=�61   $��	37,50,0,0q�6L   $	��Top=�6_   �� 5   
   -   5        $ label1��5      $��Avio Kompanija: ��6    $
��Left=�6;   $��	37,80,0,0q�6V   $	��Top=�6i   �� 5   
   -   5        $ labelBrREKON��5      $#��Broj redova Ekonomske klase: ��6&   $
��Left=�6N   $��
37,110,0,0q�6i   $	��Top=�6}   �� 5   
   -   5        $ labelBeSedistaEkon��5      $+��%Broj sedista u redu Ekonomske klase: ��6,   $
��Left=�6\   $��
37,140,0,0q�6w   $	��Top=�6�   �� 5   
   -   5        $ labelBrRBIZ��5      $��Broj redova Bizis klase: ��6%   $
��Left=�6I   $��
37,170,0,0q�6d   $	��Top=�6x   �� 5   
   -   5         ��Name$ buttonSacuvaj��5      $��Sacuvaj��6(   $
��Left=�6:   $��
58,285,0,0q�6U   $	��Top=�6i   $��92��6�   $��31��6�   6�   �� 5   
   -   5         ��Name$ textBoxNaziv��5      $
��Left=�6(   $��23��6C   $��
146,50,0,0q�6O    �� TextWrapping$
 Wrap=�6c   $	��Top=�6�   $	��184��6�   ��6w   ��  �� Path$ Naziv�6�   �� 5   
   -   5        $ textBoxBrREkonKl��5      $
��Left=�6,   $��23��6G   $��264,110,0,0q�6S   $
 Wrap=�6h   $�� ��6|   $	��Top=�6�   $��66��6�   �� 5   
   -	   5        $ textBoxBrSuREkonKl��5      $
��Left=�6.   $��23��6I   $��264,140,0,0q�6U   $
 Wrap=�6j   $�� ��6~   $	��Top=�6�   $��66��6�   �� 5   
   -
   5         ��Name$ comboBoxAvioKompanija��5       �� DisplayMemberPath$ Naziv��5      	 �� SelectedValuePath$	 Naziv��5      $
��Left=�5      $��
146,80,0,0q�6.   $	��Top=�6B   $	��184��6Z   
 �� SelectedItem
 5      �� $ AvioKompanija� �� SelectedValue 5      �� $ AvioKompanija.Naziv�5   Z   �� 5   
   -   5        $ labelBRojSedistBIz��5      $(��"Broj sedista u redu Biznis klase: ��6,   $
��Left=�6Y   $��
37,200,0,0q�6t   $	��Top=�6�   �� 5   
   -   5        $ buttonCancel��5      $��Cancel��6'   $
��Left=�68   $��220,285,0,0q�6S   $	��Top=�6h   $��92��6�   $��31��6�   6�   �� 5   
   -   5        $ textBoxBrRBizKl��5      $
��Left=�6+   $��23��6F   $��264,170,0,0q�6R   $
 Wrap=�6g   $�� ��6{   $	��Top=�6�   $��66��6�   �� 5   
   -   5        $ textBoxBrSuRBizKl��5      $
��Left=�6-   $��23��6H   $��264,200,0,0q�6T   $
 Wrap=�6i   $�� ��6}   $	��Top=�6�   $��66��6�   5!      5"      