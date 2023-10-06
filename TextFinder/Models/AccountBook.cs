using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextFinder.Models
{
    public enum AmountType
    {
        Income,
        Expense
    }

    public class AccountBook
    {
        public AmountType AmountType { get; set; }
        public int Amount { get; set; }
        public DateTime Date { get; set; }
    }
}