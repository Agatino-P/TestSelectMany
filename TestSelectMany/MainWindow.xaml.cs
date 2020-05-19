using System;
using System.Collections.Generic;
using System.Diagnostics.PerformanceData;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TestSelectMany
{
    public class SubItem
    {
        public int Counter { get; set; }
        public List<string> Strings { get; set; } = new List<string>();
        public SubItem(int counter)
        {
            Counter = counter;
        }
    }
    
    public partial class MainWindow : Window
    {
       
        
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Test_Click(object sender, RoutedEventArgs e)
        {
            List<SubItem> SubItems = new List<SubItem>();
            SubItem subItem1 = new SubItem(1);
            subItem1.Strings.Add("1-a");
            subItem1.Strings.Add("1-b");
            SubItems.Add(subItem1);

            SubItem subItem2 = new SubItem(2);
            subItem2.Strings.Add("2-a");
            SubItems.Add(subItem2);

            SubItem subItem3 = new SubItem(3);
            subItem3.Strings.Add("3-a");
            subItem3.Strings.Add("3-b");
            subItem3.Strings.Add("3-c");
            SubItems.Add(subItem3);

            IEnumerable<string> s1strings = subItem1.Strings.Select(s => $"{subItem1.Counter} - {s}");
            //LB.ItemsSource = s1strings;


            List<string> allStrings = SubItems.SelectMany(si => si.Strings.Select(s => $"{si.Counter} - {s}")).ToList();
            LB.ItemsSource = allStrings;

        }
    }
}
