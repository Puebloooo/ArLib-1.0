   M S B A M L   `   `   `  ����J  FWpfApplication4, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:ArLib.PagesArLib.Pages  5      '    !ArLib.Pages.SearchTransactionPage   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      +localclr-namespace:ArLib.Pages     5        N� Title$  	ArLib 1.0��5	      $	��600��6   $	��800��6&   .��5
      � ��5   
   �� 5       �� ImageSource$: 4/WpfApplication4;component/Additional/background.png��6   .+�5   
   �� -   5         ��Name$ 	textBlock��5      $
��Left=�6'   $��54��6B   $��	10,10,0,0q�6N   $
��Wrap=�6a   $	��Top=�6u   $	��446��6�   $��36(�6�   $��DejaVu Serif)�6�    �� TextAlignment$ Center=�6�   
���������6�   Z� �� 6  $�ArLib 1.0 - ��6  �� 6!  $��25(�6%  $�Wypożyczenia��63  �� 6I  �� 6U  �� 6a  �� 6m  6t  &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ results_transactions��5      $��Right=�61   $��
0,146,43,0q�6M   $��1��6a   $	��Top=�6n   $	��214��6�   $	��698��6�      
IsReadOnly . 6�   �� 5   
   -   5         ��Name$ quicksearch_tb��5      $��Right=�6*   $��36��6F   $��0,105,159,0q�6R   $��1��6g    �� TextWrapping$
 Wrap=�6t   $	��Top=�6�   $	��582��6�   $��DejaVu Serif Condensed)�6�   $��20(�6�   �� 5   
   -   5         ��Name$ quicksearch_button��5      $��Wyszukaj��6-   $��Right=�6@   $��
0,105,43,0q�6\   $��1��6p   $	��Top=�6}   $	��111��6�   $��36��6�   $��DejaVu Serif Condensed)�6�   $��20(�6�   6�   �� 5   
   -   5        $ returnBook_button��5      $��Zwróć��6,   $��Right=�6<   $��0,365,228,0q�6X   $��1��6m   $	��Top=�6z   $	��135��6�   $��30��6�   	 J� RenderTransformOrigin$	 0.037,1.933&�6�   $��DejaVu Serif Condensed)�6�   $��20(�6�   6   �� 5   
   -   5        $ deleteTransaction_button��5      $��Usuń��63   $��Right=�6B   $��
0,365,43,0q�6^   $��1��6r   $	��Top=�6   $	��135��6�   $��30��6�   $��DejaVu Serif Condensed)�6�   $��20(�6�   6�   �� 5   
   -   5        $ back_button��5      $��Powrót��6&   $��Right=�67   $��0,440,606,0q�6S   $	��Top=�6h   $	��135��6�   $��40��6�   $��DejaVu Serif Condensed)�6�   $��20(�6�   6�   5      5      