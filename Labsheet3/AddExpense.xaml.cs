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
using System.Windows.Shapes;

namespace Labsheet3
{
    /// <summary>
    /// Interaction logic for AddExpense.xaml
    /// </summary>
    public partial class AddExpense : Window
    {
        string[] categories = { "travel", "office", "entertainment" };

        public AddExpense()
        {
            InitializeComponent();
            cbxSelectCategory.ItemsSource = categories;

        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            Expenses ex = new Expenses();
            if (!String.IsNullOrEmpty(tbxCategory.Text))
            {
                ex.Category = tbxCategory.Text;
            }
            else
            {
                ex.Category = cbxSelectCategory.SelectedItem as string;
            }

            ex.Price = Convert.ToDecimal(tbxCost.Text);
            ex.ExpenseDate = dpExpenseDate.SelectedDate.Value;

            MainWindow main = Owner as MainWindow;

            main.Expenses.Add(ex);
            this.Close();
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
