using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Wallet : ICollection<MoneyItem>
    {
        #region private members
        private List<MoneyItem> items = new List<MoneyItem>();
        #endregion

        #region ICollection implementation
        public MoneyItem this[int index]
        {
            get
            {
                return items[index];
            }
            set
            {
                items[index] = value;
            }
        }

        public int Count
        {
            get
            {
                return ((ICollection<MoneyItem>)items).Count;
            }
        }

        public bool IsReadOnly
        {
            get
            {
                return ((ICollection<MoneyItem>)items).IsReadOnly;
            }
        }

        public void Add(MoneyItem item)
        {
            ((ICollection<MoneyItem>)items).Add(item);
        }

        public void Clear()
        {
            ((ICollection<MoneyItem>)items).Clear();
        }

        public bool Contains(MoneyItem item)
        {
            return ((ICollection<MoneyItem>)items).Contains(item);
        }

        public void CopyTo(MoneyItem[] array, int arrayIndex)
        {
            ((ICollection<MoneyItem>)items).CopyTo(array, arrayIndex);
        }

        public IEnumerator<MoneyItem> GetEnumerator()
        {
            return ((ICollection<MoneyItem>)items).GetEnumerator();
        }

        public bool Remove(MoneyItem item)
        {
            return ((ICollection<MoneyItem>)items).Remove(item);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((ICollection<MoneyItem>)items).GetEnumerator();
        }
        #endregion

        #region public methods
        /// <summary>
        /// Counts all money in wallet in chosen currency
        /// </summary>
        /// <param name="currency">resulting currency</param>
        /// <returns>count of money</returns>
        public double CountAllMoney(Currency currency)
        {
            double sum = 0.0;
            foreach (var item in items)
                sum += item.ConvertTo(currency);

            return sum;
        }

        /// <summary>
        /// Count money stored in chosen currency
        /// </summary>
        /// <param name="currency">currency</param>
        /// <returns>amount of money in currency</returns>
        public double CountMoney(Currency currency)
        {
            if (currency == null)
                return 0.0;

            double sum = 0.0;
            foreach (var item in items)
                if (item.Currency == currency)
                    sum += item.Amount;

            return sum;
        }

        public double CountMoney(string currencyName)
        {
            Currency currency = null;
            foreach (var item in items)
                if (String.Equals(item.Currency.Name, currencyName,
                    StringComparison.InvariantCultureIgnoreCase))
                {
                    currency = item.Currency;
                    break;
                }
            return this.CountMoney(currency);       
        }
        #endregion

        #region overriden
        public override string ToString()
        {
            List<string> strList = new List<string>();
            foreach (var item in items)
                strList.Add(item.ToString());
            return String.Join("\r\n", strList);
        }
        #endregion
    }
}
