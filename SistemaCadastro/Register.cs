using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaCadastro
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }
        void limpaCampo()
        {
            txtSenha.Text = "";
            textEmailUser.Text = "";
            txtUsuario.Text = "";
        }
        private void Register_Load(object sender, EventArgs e)
        {

        }

        private void btnCriarConta_Click(object sender, EventArgs e)
        {
            Usuario u = new Usuario();
            string senhaHash = Hash.makeHash(txtSenha.Text);
            u.NomeUser = txtUsuario.Text;
            u.EmailUser = textEmailUser.Text;
            u.SenhaUser = senhaHash;


            ConectaBanco conecta = new ConectaBanco();
            bool retorno = conecta.insereUsuarios(u);
            if (retorno == true)
            {
                MessageBox.Show("Dados Inseridos com Sucesso :)");
            }
            else
                MessageBox.Show("Erro :(" + conecta.mensagem);

            limpaCampo();
            Login fazer = new Login();
            this.Hide();
            fazer.ShowDialog();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
    }
}
