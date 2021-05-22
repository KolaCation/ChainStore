using ChainStore.Shared.Util;
using System;

namespace ChainStore.DataAccessLayerImpl.DbModels
{
    internal class ClientDbModel
    {
        public Guid Id { get; protected set; }
        public string Name { get; protected set; }
        public double Balance { get; protected set; }

        public ClientDbModel(Guid id, string name, double balance)
        {
            CustomValidator.ValidateId(id);
            CustomValidator.ValidateString(name, 2, 40);
            CustomValidator.ValidateNumber(balance, 0, 100_000_000);
            Id = id;
            Name = name;
            Balance = balance;
        }
    }
}