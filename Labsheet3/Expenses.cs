using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labsheet3
{
    class Expenses
    {
        public string Category{ get; set; }
        public decimal Price { get; set; }
        public DateTime ExpenseDate { get; set; }

        public override string ToString()
        {
            return $" {Price:C} {Category} {ExpenseDate.ToShortDateString()}";
        }
        
    }
}
