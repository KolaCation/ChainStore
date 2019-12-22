using System;

namespace ChainStore.Domain.Util
{
    internal static class Validator
    {
        public static void CheckId(Guid id)
        {
            if(id.Equals(Guid.Empty)) throw new ArgumentNullException(nameof(id));
        }
        public static void CheckName(string name)
        {
            if (string.IsNullOrEmpty(name) || name.Length >= 20)
                throw new ArgumentException("Invalid name");
        }

        public static void CheckBalance(double balance)
        {
            if (balance < 0 || balance > 400_000) throw new ArgumentException("Invalid balance");
        }

        public static void CheckProfit(double profit)
        {
            if (profit < 0 || profit > 1000000) throw new ArgumentException("Invalid profit");
        }

        public static void CheckPrice(double price)
        {
            if (price < 0) throw new ArgumentException("Invalid price");
        }

        public static void CheckLocation(string location)
        {
            if (string.IsNullOrEmpty(location) || location.Length >= 20)
                throw new ArgumentException("Invalid location");
        }
    }
}