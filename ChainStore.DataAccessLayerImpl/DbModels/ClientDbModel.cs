using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using ChainStore.Shared.Util;

namespace ChainStore.DataAccessLayerImpl.DbModels
{
    internal class ClientDbModel
    {
        public Guid ClientDbModelId { get; protected set; }
        public string Name { get; protected set; }
        public double Balance { get; protected set; }

        public ClientDbModel(Guid clientDbModelId, string name, double balance)
        {
            CustomValidator.ValidateId(clientDbModelId);
            CustomValidator.ValidateString(name, 2, 40);
            CustomValidator.ValidateNumber(balance, 0, 100_000_000);
            ClientDbModelId = clientDbModelId;
            Name = name;
            Balance = balance;
        }
    }
}