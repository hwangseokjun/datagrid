using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TextFinder.Commands;
using TextFinder.Models;

namespace TextFinder.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public ObservableCollection<AccountBook> Accounts { get; set; }

        public ICommand AddCommand { get; private set; }

        public MainViewModel()
        {
            Accounts = new ObservableCollection<AccountBook>();
            var account1 = new AccountBook { AmountType = AmountType.Income, Amount = 10000, Date = DateTime.Now };
            var account2 = new AccountBook { AmountType = AmountType.Expense, Amount = 5000, Date = DateTime.Now };
            Accounts.Add(account1);
            Accounts.Add(account2);
            AddCommand = new RelayCommand(ExecuteAdd, CanExecuteAdd);
        }

        private void ExecuteAdd(object parameter)
        {
            var account = new AccountBook
            {
                AmountType = AmountType.Income,
                Amount = 9999999,
                Date = DateTime.Now
            };
            Accounts.Add(account);
        }
        private bool CanExecuteAdd(object parameter)
        {
            // 실행 가능한지 여부를 결정하는 로직을 구현합니다.
            return true;
        }
    }
}