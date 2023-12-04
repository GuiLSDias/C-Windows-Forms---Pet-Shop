using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaCadastro
{
    internal class Usuario
    {
        string nomeUser;
        string emailUser;
        string senhaUser;

        public string NomeUser { get => nomeUser; set => nomeUser = value; }
        public string EmailUser { get => emailUser; set => emailUser = value; }
        public string SenhaUser { get => senhaUser; set => senhaUser = value; }
    }
}
