   M S B A M L   `   `   `  ����J  FWpfApplication4, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:ArLib.PagesArLib.Pages  5          ArLib.Pages.MainView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      +localclr-namespace:ArLib.Pages     5        N� Title$  	ArLib 1.0��5	      .��5      �  � RowDefinitions 5   
   �� 5      $	��33* �6   �� 5      $
��536* �6   .+�5   
   o�  o� 
IsMainMenu . $��25(�6!   $��50��6/   $��	0,0,0,519q�6;   $	��792��6N   $��Center=�6Z   
�������$��2��6�   ��6u   Z� .@�5      m� $��Przeglądaj...��6   $��DejaVu Serif Condensed)�6.   $��25(�6R   $��0,0,50,0q�6`   
�������.@�5      m� -   5        $��Czytelników��5      $��DejaVu Serif Condensed)�60   $��20(�6T   
���   �6}   m� 5      -   5        $��Wypożyczenia��5      $��DejaVu Serif Condensed)�61   $��20(�6U   
���   �6�   m� 5      -   5        $��Mandaty��5      $��DejaVu Serif Condensed)�6,   $��20(�6P   
���   �6w   5      m� 5      $��	Książki��6   $��DejaVu Serif Condensed)�6(   $��25(�6L   $��0,0,50,0q�6Z   
�������.@�5      m� -   5        $��Dodaj Książkę��5      $��DejaVu Serif Condensed)�62   $��20(�6V   
���   �6z   5      m� 5      $��
Czytelnicy��6   $��DejaVu Serif Condensed)�6+   $��25(�6O   $��0,0,50,0q�6]   
�������.@�5      m� -   5        $��Dodaj Czytelnika��5      $��DejaVu Serif Condensed)�65   $��20(�6Y   
���   �6   5      m� 5      $
��Kary��6   $��DejaVu Serif Condensed)�6%   $��25(�6I   $��0,0,0,0q�6W   {�.  6h   5      o� 5   
   $��Bottom=�6   $��0,0,0,10q�6*   $��1��6<   ��6I   Z� .@�5      m� -   5        $��Zmień dane��5      $��DejaVu Serif Condensed)�6+   $��20(�6O   $��0,0,50,0q�6]   
�������6�   m� 5       -   5        $��Zmień hasło��5       $��DejaVu Serif Condensed)�6,   $��20(�6P   $��0,0,50,0q�6^   
�������6�   m� 5!      -   5        $��Wyloguj��5!      $��DejaVu Serif Condensed)�6(   $��20(�6L   
�������$��89��6�   $��0,0,6,0q�6�   m� 5"      -	   5        $��O programie��5"      $��DejaVu Serif Condensed)�6,   $��20(�6P   
�������$	��130��6�   $��0,0,6,0q�6�   $��	200,0,0,0q�6�   5#      &   System.Windows.Controls.DataGrid  5$   
   -
   5          Name$ dataGrid��5$      $��Right=�6%   $��
0,146,43,0q�6A   $��1��6U   $	��Top=�6b   $	��214��6z   $	��698��6�      
IsReadOnly . 6�   �� 5%   
   -   5         ��Name$ quicksearch_tb��5%      $��Right=�6*   $��36��6F   $��0,105,159,0q�6R   $��1��6g    �� TextWrapping$
 Wrap=�6t   $	��Top=�6�   $	��582��6�   $��DejaVu Serif Condensed)�6�   $��20(�6�   �� 5&   
   -   5         ��Name$ quicksearch_button��5&      $��Wyszukaj��6-   $��Right=�6@   $��
0,105,43,0q�6\   $��1��6p   $	��Top=�6}   $	��111��6�   $��36��6�   $��DejaVu Serif Condensed)�6�   $��20(�6�   6�   �� 5'   
   -   5        $ editBook_button��5'      $��Edytuj��6*   $��Right=�6;   $��0,365,606,0q�6W   $��1��6l   $	��Top=�6y   $	��135��6�   $��30��6�   $��DejaVu Serif Condensed)�6�   $��20(�6�   6�   �� 5(   
   -   5        $ deleteBook_button��5(      $��Usuń��6,   $��Right=�6;   $��
0,365,43,0q�6W   $��1��6k   $	��Top=�6x   $	��135��6�   $��30��6�   $��DejaVu Serif Condensed)�6�   $��20(�6�   6�   �� 5)   
   -   5        $ takeBook_button��5)      $��	Wypożycz��6*   $��Right=�6=   $��0,365,421,0q�6Y   $��1��6n   $	��Top=�6{   $	��135��6�   $��30��6�   $��DejaVu Serif Condensed)�6�   $��20(�6�   �� 5*   
   -   5        $ returnBook_button��5*      $��Zwróć��6,   $��Right=�6<   $��0,365,228,0q�6X   $��1��6m   $	��Top=�6z   $	��135��6�   $��30��6�    J� RenderTransformOrigin$ 0.037,1.933&�6�   $��DejaVu Serif Condensed)�6�   $��20(�6�   6   ��5+   
   �� 5,      	 �� ImageSource$:	 4/WpfApplication4;component/Additional/background.png��6   5.      5/      