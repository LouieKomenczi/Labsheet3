using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows;
using Newtonsoft.Json;

namespace Labsheet3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<Expenses> expenses = new ObservableCollection<Expenses>();
        internal ObservableCollection<Expenses> Expenses { get => expenses; set => expenses = value; }

        ObservableCollection<Expenses> matchingExpenses = new ObservableCollection<Expenses>();

        string[] categories = {"travel", "office", "entertainment" };



        public MainWindow()
        {
            InitializeComponent();
        }
        
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cbxFilter.ItemsSource = categories;
           
        }
        

        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            Expenses.RemoveAt(Expenses.Count()-1);
            txbResult.Text = GetTotalCost().ToString();
            txbNumber.Text = Expenses.Count().ToString();
        }

        private void btnAddExpenses_Click(object sender, RoutedEventArgs e)
        {
            
            
            AddExpense addExp = new AddExpense();
            addExp.Owner = this;
            addExp.ShowDialog();
            lbxExpenses.ItemsSource = expenses;
            txbResult.Text = GetTotalCost().ToString();
            txbNumber.Text = Expenses.Count().ToString();


        }

        private decimal GetTotalCost()
        {
            decimal total = 0;            
            foreach(Expenses e in Expenses)
            {
                total += e.Price;                
            }
            return total;
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            string searchTerm = tbxSearch.Text;

            if (!String.IsNullOrEmpty(searchTerm))
            {
                matchingExpenses.Clear();
                foreach(Expenses exp in Expenses)
                {
                    string expenseType = exp.Category;
                    if (expenseType.Equals(searchTerm))
                    {
                        matchingExpenses.Add(exp);
                    }
                }
            }

            lbxExpenses.ItemsSource = matchingExpenses;

        }

        private void BtnShowAll_Click(object sender, RoutedEventArgs e)
        {
            lbxExpenses.ItemsSource = Expenses;
        }

        private void CbxFilter_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            string selectedType = cbxFilter.SelectedItem as string;

            if(selectedType != null)
            {
                matchingExpenses.Clear();

                foreach(Expenses exp in Expenses)
                {
                    string expCategory = exp.Category;

                    if (expCategory.Equals(selectedType))
                    {
                        matchingExpenses.Add(exp);
                    }
                }

                lbxExpenses.ItemsSource = matchingExpenses;
            }
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            string json = JsonConvert.SerializeObject(Expenses, Formatting.Indented);

            using (StreamWriter sw = new StreamWriter(@"e:\temp\expenses.json"))
            {
                sw.Write(json);
            }

            MessageBox.Show("values saved");
        }

        private void BtnLoad_Click(object sender, RoutedEventArgs e)
        {
            using (StreamReader sr = new StreamReader(@"e:\temp\expenses.json"))
            {
                string json = sr.ReadToEnd();
                Expenses = JsonConvert.DeserializeObject<ObservableCollection<Expenses>>(json);

                lbxExpenses.ItemsSource = Expenses;
            }

            MessageBox.Show("values loaded");
        }
    }
}
