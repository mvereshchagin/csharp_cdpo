using System;
using Data;
using System.Collections.Generic;

namespace MySecondProject
{
    class Program
    {
        #region fields
        static ExchangeRateRetriever retriever =
                new SimpleExchangeRateRetiever();

        static Currency rur = new Currency()
        { Name = "RUR", FullName = "Russian ruble" };

        static Currency usd = new Currency()
        { Name = "USD", FullName = "USA dollar" };

        static Currency eur = new Currency()
        { Name = "EUR", FullName = "Euro" };

        #endregion


        static void Main(string[] args)
        {
            FillExchangeRates();

            var money = FillMoney();

            var currencyList = new List<Currency>();
            currencyList.AddRange(new Currency[] { usd, rur, eur });
            currencyList.Sort();


            var newMoneyItem = money[0] + money[1];
            Console.WriteLine($"new money item = {newMoneyItem}");

            var wallet = CreateWallet();
            Console.WriteLine(
                $"Amount of money in wallet (rur): {wallet.CountAllMoney(rur)}");
            Console.WriteLine(
                $"Amount of money in wallet (usd): {wallet.CountAllMoney(usd)}");

            Console.WriteLine(
                $"Amount of usd in wallet (usd): {wallet.CountMoney(usd)}");

            Console.WriteLine(
                $"Amount of usd in wallet (rur): {wallet.CountMoney("RUR")}");

            Console.WriteLine(
                $"Amount of usd in wallet (pln): {wallet.CountMoney("PLN")}");

            Console.WriteLine(wallet);

            Console.ReadLine();
        }

        #region methods

        static void FillExchangeRates()
        {
            rur.ExchangeRate =
                retriever.Retrieve(rur.Name);

            usd.ExchangeRate =
                    retriever.Retrieve(usd.Name);

            eur.ExchangeRate =
                    retriever.Retrieve(eur.Name);
        }

        static MoneyItem[] FillMoney()
        {
            return new MoneyItem[]
            {
                new MoneyItem() { Currency = rur, Amount = 10000 },
                new MoneyItem() { Currency = rur, Amount = 10000 },
            };
        }

        static Wallet CreateWallet()
        {
            Wallet wallet = new Wallet();
            wallet.Add(new MoneyItem() { Currency = rur, Amount = 10000 });
            wallet.Add(new MoneyItem() { Currency = usd, Amount = 100 });
            wallet.Add(new MoneyItem() { Currency = eur, Amount = 200 });
            wallet.Add(new MoneyItem() { Currency = rur, Amount = 3000 });
            wallet.Add(new MoneyItem() { Currency = usd, Amount = 150 });
            wallet.Add(new MoneyItem() { Currency = eur, Amount = 50 });
            wallet.Add(new MoneyItem() { Currency = usd, Amount = 300 });

            return wallet;
        }
        #endregion
    }
}
