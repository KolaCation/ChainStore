using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Validator = ChainStore.Domain.Util.Validator;

namespace ChainStore.Domain.DomainCore
{
    public class Client
    {
        public Guid ClientId { get; protected set; }
        public string Name { get; protected set; }
        public double Balance { get; protected set; }

        public Client(string name)
        {
            ClientId = Guid.NewGuid();
            Validator.CheckName(name);
            Name = name;
            Balance = 0;
        }

        protected Client(Guid clientId, string name, double balance)
        {
            Validator.CheckName(name);
            Validator.CheckBalance(balance);
            Validator.CheckId(clientId);
            ClientId = clientId;
            Name = name;
            Balance = balance;
        }

        public void ChangeName(string newName)
        {
            Validator.CheckName(newName);
            Name = newName;
        }

        public virtual void ReplenishBalance(double sum)
        {
            Validator.CheckBalance(sum);
            Balance += sum;
        }

        public virtual void Pay(double sum, bool useCashBack, bool usePoints)
        {
            Validator.CheckBalance(sum);
            if (Balance < sum) return;
            Balance -= sum;
        }
    }
}