using System;
using System.Collections.Generic;
using System.Collections;
using Data;

namespace Tests
{
    public class TestLists
    {
        public void Test()
        {
            Currency rur = new Currency()
            {
                Name = "RUR",
                FullName = "Russian ruble",
            };

            ArrayList list = new ArrayList();
            list.Add(rur);

            var item = list[0] as Currency;

            List<Currency> currencyList = new List<Currency>();
            currencyList.Add(rur);
            var item1 = currencyList[0];
            currencyList.ToArray();

            MyList<int> intList = new MyList<int>();
            intList.Add(14);
            intList.Add(15);

            MyList<double> doubleList = new MyList<double>();
            doubleList.Add(1.2);
        }

    }
}
