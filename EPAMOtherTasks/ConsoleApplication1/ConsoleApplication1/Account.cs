using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Account
    {
        int _sum; // Переменная для хранения суммы
        int _percentage; // Переменная для хранения процента

        // Объявляем делегат
        public delegate void AccountStateHandler(string message);
        // Создаем переменную делегата
        AccountStateHandler del;
        // Регистрируем делегат
        // Регистрируем делегат
        public void RegisterHandler(AccountStateHandler _del)
        {
            del += _del; // добавляем делегат
        }
        // Отмена регистрации делегата
        public void UnregisterHandler(AccountStateHandler _del)
        {
            del -= _del; // удаляем делегат
        }

        public Account(int sum, int percentage)
        {
            _sum = sum;
            _percentage = percentage;
        }

        public int CurrentSum
        {
            get { return _sum; }
        }

        public void Put(int sum)
        {
            _sum += sum;
        }

        public void Withdraw(int sum)
        {
            if (sum <= _sum)
            {
                _sum -= sum;

                if (del != null)
                    del("Сумма " + sum.ToString() + " снята со счета");
            }
            else
            {
                if (del != null)
                    del("Недостаточно денег на счете");
            }
        }

        public int Percentage
        {
            get { return _percentage; }
        }
    }
}
