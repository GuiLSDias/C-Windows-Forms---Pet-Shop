using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaCadastro
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            ConectaBanco conecta = new ConectaBanco();
            if (conecta.verifica(txtUsuario.Text, txtSenha.Text) == true)
            {
                Sistema banco_petshop = new Sistema();
                this.Hide();
                banco_petshop.ShowDialog();
                this.Close();
            }
            else
                MessageBox.Show("Usuário ou Senha Incorretos !" + conecta.mensagem);
        }

        private void btnCriarConta_Click(object sender, EventArgs e)
        {
            Register criar = new Register();
            this.Hide();
            criar.ShowDialog();
            this.Close();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void txtSenha_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
