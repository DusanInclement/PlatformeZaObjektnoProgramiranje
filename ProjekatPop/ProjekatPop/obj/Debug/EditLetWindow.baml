   M S B A M L   `   `   `  ����F  BProjekatPop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:ProjekatPopProjekatPop  5   	       ProjekatPop.EditLetWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:ProjekatPop     5   	   X TXceed.Wpf.Toolkit, Version=3.4.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f47toolkit)http://schemas.xceed.com/wpf/xaml/toolkit  5   	   -   5          � Title$  EditLetWindow��5	   	   $��652.994��6   $��464.195��60    � WindowStartupLocation$ CenterScreen=�5
   	   .��5      � .+�5   
   �� -   5         ��Name$ label��5      $��Sifra:��6   $
��Left=�60   $��	30,40,0,0q�6K   $	��Top=�6^   �� 5   
   -   5        $ label1��5      $��Pilot:��6    $
��Left=�61   $��
30,100,0,0q�6L   $	��Top=�6`   �� 5   
   -   5        $ label2��5      $��Vreme Polaska:��6    $
��Left=�69   $��
30,160,0,0q�6T   $	��Top=�6h   �� 5   
   -   5        $ label3��5      $��Vreme Dolaska:��6    $
��Left=�69   $��
30,220,0,0q�6T   $	��Top=�6h   �� 5   
   -   5        $ label4��5      $��Polazni Aerodrom:��6    $
��Left=�6<   $��
30,280,0,0q�6W   $	��Top=�6k   �� 5   
   -   5        $ label5��5      $��Dolazni Aerodrom:��6    $
��Left=�6<   $��
30,340,0,0q�6W   $	��Top=�6k   �� 5   
   -   5        $ label6��5      $��Avion��6    $
��Left=�60   $��
30,400,0,0q�6K   $	��Top=�6_   �� 5   
   -	   5        $ label7��5      $
��Cena��6    $
��Left=�6/   $��
30,460,0,0q�6J   $	��Top=�6^   �� 5   
   -
   5         ��Name$ textBoxSifra��5      $
��Left=�6(   $��23��6C   $��
150,44,0,0q�6O    �� TextWrapping$
 Wrap=�6c   $	��Top=�6�   $	��287��6�   ��6w   ��  �� Path$ Sifra�6�   �� 5   
   -   5        $ textBoxPilot��5      $
��Left=�6(   $��22��6C   $��153,104,0,0q�6O   $
 Wrap=�6d   $	��Top=�6�   $	��284��6�   ��6x   �� $ Pilot�6�   &   Xceed.Wpf.Toolkit.DateTimePicker  5   
   -   5        $��datePickerDatumPolaska��5   !   $��153,154,20.4,437.2q�6c   �  �Xceed.Wpf.Toolkit.Primitives.UpDownBase`1[[System.Nullable`1[[System.DateTime, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]   Value 6?   �� $ vremePolaska�6c     5   
   -   5        $��datePickerDatumDolaska��5   !   $��153,214,20.2,377.2q�6@    6\   �� $ vremeDolaska��� 5   
   -   5         ��Name$ comboBoxPolazniAerodrom��5      $
��Left=�64    �� DisplayMemberPath$
 Grad��5      	 �� SelectedValuePath$
	 Grad��5      $��153,280,0,0q�5      $	��Top=�6'   $	��284��6?   $��26��6K   
 �� SelectedItem
 5      �� $ PolazniAerodrom� �� SelectedValue 5      �� $ PolazniAerodrom.Grad�5   K   �� 5!   
   -   5        $ comboBoxDolazniAerodrom��5!      $
��Left=�64   $
 Grad��5#      $
	 Grad��5&      $��153,340,0,0q�5(      $	��Top=�6(   $	��284��6@   $��26��6L   
 5$      �� $ DolazniAerodrom� 5%      �� $ DolazniAerodrom.Grad�5(   L   �� 5)   
   -   5        $ comboBoxAvion��5)      $
��Left=�6*   $ Naziv��5,      $	 Naziv��5/      $��153,400,0,0q�52      $	��Top=�6(   $	��284��6@   $��26��6L   
 5-      �� $ Avion� 5.      �� $ Avion.Naziv�52   L   �� 53   
   -   5        $ textBoxCena��53      $
��Left=�6'   $��23��6B   $��150,464,0,0q�6N   $
 Wrap=�6c   $	��Top=�6�   $	��287��6�   ��6w   �� $
 Cena�6�   �� 54   
   -   5         ��Name$ buttonSacuvaj��54      $��Sacuvaj��6(   $
��Left=�6:   $��
32,562,0,0q�6U   $	��Top=�6i   $	��110��6�   $��32��6�   6�   �� 55   
   -   5        $ buttonCancel��55      $��Button��6'   $
��Left=�68   $��327,562,0,0q�6S   $	��Top=�6h   $	��110��6�   $��32��6�   56      57      