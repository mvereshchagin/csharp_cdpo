using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class MoneyItem
    {
        #region Properties
        public double Amount { get; set; }

        public Currency Currency { get; set; }

        #endregion

        #region operators

        public static bool operator ==(MoneyItem first, MoneyItem second)
        {
            return Equals(first, second);
            
        }

        public static bool operator !=(MoneyItem first, MoneyItem second)
        {
            return !(first == second);
        }

        public static MoneyItem operator + (MoneyItem first, MoneyItem second)
        {
            if (first == null || second == null)
                return null;

            if (first.Currency == null || second.Currency == null)
                return null;

            if (second.Currency.ExchangeRate == 0)
                return null;

            MoneyItem newAccount = new MoneyItem()
            {
                Currency = first.Currency,
                Amount = first.Amount + 
                         second.Amount / first.Currency.ExchangeRate * 
                         second.Currency.ExchangeRate
            };

            return newAccount;
        }

        public static MoneyItem operator -(MoneyItem first, MoneyItem second)
        {
            if (first == null || second == null)
                return null;

            if (first.Currency == null || second.Currency == null)
                return null;

            if (second.Currency.ExchangeRate == 0)
                return null;

            MoneyItem newAccount = new MoneyItem()
            {
                Currency = first.Currency,
                Amount = first.Amount -
                         second.Amount / first.Currency.ExchangeRate *
                         second.Currency.ExchangeRate
            };

            return newAccount;
        }

        #endregion

        #region overriden
        public override bool Equals(object obj)
        {
            if (Object.ReferenceEquals(obj, null))
                return false;

            if (obj.GetType() != this.GetType())
                return false;

            return Equals(this, obj as MoneyItem);
        }

        public override string ToString()
        {
            return $"Currency: {this.Currency}; Amount: {this.Amount}";
        }
        #endregion

        #region static methods

        public static bool Equals(MoneyItem first, MoneyItem second)
        {
            if (Object.ReferenceEquals(first, null) && 
                Object.ReferenceEquals(second, null))
                return true;

            if (Object.ReferenceEquals(first, null))
                return false;

            if (Object.ReferenceEquals(second, null))
                return false;

            return first.Currency == second.Currency &&
                first.Amount == second.Amount;
        }

        #endregion

        #region methods
        public double ConvertTo(Currency currency)
        {
            if (currency == null || this.Currency == null)
                return this.Amount;

            return this.Amount / currency.ExchangeRate * this.Currency.ExchangeRate;
        }
        #endregion
    }
}
