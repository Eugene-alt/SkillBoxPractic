   M S B A M L   `   `   `  ����I  Epractic9WpfApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:practic9WpfApppractic9WpfApp  5   	       practic9WpfApp.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:practic9WpfApp     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   $	��450��5	   	   $	��800��5
   	   .��5      � $	��434��6   $��Bottom=�6    � RowDefinitions 5   
   �� 5      $��4* �6   �� 5      $��3* �6   .+�5   
   �� -   5        $%��Превратить в ListBox��5      $��Center=�5      $	��Top=�5       J� RenderTransformOrigin$ 0.651,-0.592&�5      $��50��5      $	��150��5      $
��Bold"�5      $��	0,119,0,0q�5      �� 5   
   -   5         ��Name$ TextBoxList��5      $
��Left=�5      $��	10,40,0,0q�5       �� TextWrapping$
 Wrap=�5      $g��aВведите предложение, которое нужно разбить по словам��5      $��Center=�5      $	��300��5       $	��197��5!      �� 5$   
   -   5        $��ListDb��5&      $��	0,46,10,6q�5%      $��Right=�5'      $	��300��6.   �� 5)   
   -   5        $.��(Обратный порядок слов��5)      $��Center=�5*   	   $��1��5+   	   $��Center=�5,   	   $��50��5-   	   $	��150��5.   	   $
��Bold"�5/   	   $ 0.192,0.791&�50   	   6-   �� 52   
   -   5        $ TextBoxReverse��52      $
��Left=�53   
   $��10,0,0,0q�54   
   $
 Wrap=�55   
   $���{Введите предложение, в котором нужно сделать обратный порядок слов��56   
   $��Center=�57   
   $	��300��58   
   $	��166��59   
   $��1��6   �� 5;   
   -   5         ��Name$ LabelReverse��5;      $�� ��6&   $��Right=�5<      $��	490,0,0,0q�5=      $��1��5>      $��Center=�5?      $	��300��5@      $	��166��5A      5D      5E      