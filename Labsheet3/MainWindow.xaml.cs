using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace Labsheet3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<Expenses> expenses = new ObservableCollection<Expenses>();

        public MainWindow()
        {
            InitializeComponent();
        }
        
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
        }
        

        private void BtnRemove_Click(object sender, RoutedEventArgs e)
        {
            expenses.RemoveAt(expenses.Count()-1);
            txbResult.Text = GetTotalCost().ToString();
            txbNumber.Text = expenses.Count().ToString();

        }

        private void btnAddExpenses_Click(object sender, RoutedEventArgs e)
        {
            Expenses ex = new Expenses();
            ex.Category = tbxCategory.Text;
            ex.Price = Convert.ToDecimal(tbxCost.Text);
            ex.ExpenseDate = dpExpenseDate.SelectedDate.Value;

            expenses.Add(ex);

      
            lbxExpenses.ItemsSource = expenses;
            txbResult.Text = GetTotalCost().ToString();
            txbNumber.Text = expenses.Count().ToString();

        }

        private decimal GetTotalCost()
        {
            decimal total = 0;            
            foreach(Expenses e in expenses)
            {
                total += e.Price;                
            }
            return total;
        }


    }
}
