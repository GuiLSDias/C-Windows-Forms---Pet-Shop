﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaCadastro
{
    class Cliente
    {
        string nomeCliente;
        string emailCliente;
        string cpfCliente;
        string enderecoCliente;
        string bairroCliente;

        public string NomeCliente { get => nomeCliente; set => nomeCliente = value; }
        public string EmailCliente { get => emailCliente; set => emailCliente = value; }
        public string CpfCliente { get => cpfCliente; set => cpfCliente = value; }
        public string EnderecoCliente { get => enderecoCliente; set => enderecoCliente = value; }
        public string BairroCliente { get => bairroCliente; set => bairroCliente = value; }
    }
}
