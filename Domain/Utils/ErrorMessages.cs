using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lucasvieiravicentenetcore.Domain.Utils
{
    public abstract class ErrorMessages
    {
        public const string NameNecessary = "É necessário um nome";
        public const string EmailNecessary = "É necesário um e-mail";
        public const string EmailIncorrect = "É necessário um e-mail válido";
        public const string PhoneNecessary = "É necesário um telefone";
        public const string PhoneIncorrect = "É necessário um telefone válido";
        public const string BodyNecessary = "É necesário uma mensagem";
    }
}
