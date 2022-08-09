using ListViewWrap.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ListViewWrap
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static List<Phone> All_Phones = null;
        static List<List<Phone>> All_Pages = null;
        static int current_page = 0;
        static int max_page = 0;
        public MainWindow()
        {
            InitializeComponent();

            All_Phones = new List<Phone>();

            using (var DbContext = new DatabaseEntities())
            {
                All_Phones = DbContext.Phones.ToList();
            }

            int pages = All_Phones.Count / 4;
            int last_page_elem = All_Phones.Count % 4;

            max_page = pages;

            All_Pages = new List<List<Phone>>();
            int elem_index = 0;

            for(int i = 0; i < pages; i++)
            {
                List<Phone> page_phones = new List<Phone>();
                for (int j = 0; j < 4; j++)
                {
                    page_phones.Add(All_Phones[elem_index++]);
                }
                All_Pages.Add(page_phones);
            }

            if(last_page_elem > 0)
            {
                List<Phone> page_phones = new List<Phone>();
                for(int i = 0; i < last_page_elem; i++)
                {
                    page_phones.Add(All_Phones[elem_index++]);
                }
                All_Pages.Add(page_phones);
                max_page++;
            }

            //MessageBox.Show($"count = {elem_count}, pages = {pages}, last page elements count = {last_page_elem}");

            LW1.ItemsSource = All_Pages[current_page];
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (current_page == 0)
                return;

            LW1.ItemsSource = All_Pages[--current_page];
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (current_page == (max_page - 1))
                return;

            LW1.ItemsSource = All_Pages[++current_page];
        }
    }
}
