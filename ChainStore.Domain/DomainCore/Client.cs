using ChainStore.Shared.Util;
using System;

namespace ChainStore.Domain.DomainCore
{
    public class Client
    {
        public Guid ClientId { get; protected set; }
        public string Name { get; protected set; }
        public double Balance { get; protected set; }

        public Client(string name)
        {
            CustomValidator.ValidateString(name, 2, 40);
            ClientId = Guid.NewGuid();
            Name = name;
            Balance = 0;
        }

        protected Client(Guid clientId, string name, double balance)
        {
            CustomValidator.CheckId(clientId);
            CustomValidator.ValidateString(name, 2, 40);
            CustomValidator.ValidateNumber(balance, 0, 1000000);
            ClientId = clientId;
            Name = name;
            Balance = balance;
        }

        public void ChangeName(string newName)
        {
            CustomValidator.ValidateString(newName, 2, 40);
            Name = newName;
        }

        public virtual void ReplenishBalance(double sum)
        {
            CustomValidator.ValidateNumber(sum, 0, 1000000);
            Balance += sum;
        }

        public virtual bool Pay(double sum, bool useCashBack, bool usePoints)
        {
            CustomValidator.ValidateNumber(sum, 0, 1000000);
            if (Balance < sum) return false;
            Balance -= sum;
            return true;
        }
    }
}