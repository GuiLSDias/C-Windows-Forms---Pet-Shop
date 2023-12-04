using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;

namespace SistemaCadastro
{
    public partial class Sistema : Form
    {
        int codAlterarPet;
        int codAlteraCliente;
        public Sistema()
        {
            InitializeComponent();
            
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnCadastra_Click(object sender, EventArgs e)
        {
            marcador.Height = btnCadastra.Height;
            marcador.Top = btnCadastra.Top;
            tabControl1.SelectedTab = tabControl1.TabPages[0];
        }
        

        private void btnBusca_Click(object sender, EventArgs e)
        {
            marcador.Height = btnBusca.Height;
            marcador.Top = btnBusca.Top;
            tabControl1.SelectedTab = tabControl1.TabPages[1];
            ConectaBanco con = new ConectaBanco();
            dgListaCliente.DataSource = con.listaClientes();
            btnConfimaAlt.Visible = false;

            lblClienteAlt.Visible = false;
            lblEmailAlt.Visible = false;
            lblCpfAlt.Visible = false;
            lblEnderecoAlt.Visible = false;
            lblBairroAlt.Visible = false;  

            txtNomeCliAlt.Visible = false;
            txtEmailCliAlt.Visible = false;
            txtCpfCliAlt.Visible = false;
            txtEnderecoCliAlt.Visible = false;
            txtBairroCliAlt.Visible = false;

            plinhaClienteAlt.Visible = false;
            plinhaEmailAlt.Visible = false;
            plinhaCpfAlt.Visible = false;
            plinhaEnderecoAlt.Visible = false;
            plinhaBairroAlt.Visible = false;

            lblHeaderCliente.Visible = false;
        }

        private void Sistema_Load(object sender, EventArgs e)
        {
            listaClienteCB();
            lista_gridCliente();
            lista_gridPets();
        }
        void lista_gridPets()
        {
            ConectaBanco con = new ConectaBanco();
            dgPets.DataSource = con.listaPets();
        }
        void lista_gridCliente() 
        { 
            ConectaBanco con = new ConectaBanco();
            dgListaCliente.DataSource = con.listaClientes();
        }
        
        void listaClienteCB()
        {
            ConectaBanco con = new ConectaBanco();
            DataTable tabelaDados = new DataTable();
            tabelaDados = con.listaClientes();
            cbClientes.DataSource = tabelaDados;
            cbClientes.DisplayMember = "Nome";
            cbClientes.ValueMember = "Codigo";
            cbClientes.Text = "Selecione um Cliente";
            
        }

        private void btnRemoveBanda_Click(object sender, EventArgs e)
        {
            int linha = dgListaCliente.CurrentRow.Index; //pegar linha selecionada
            int codRemover = Convert.ToInt32(dgListaCliente.Rows[linha].Cells["Codigo"].Value.ToString());

            DialogResult resposta = MessageBox.Show("Confirmar Exclusão?", "Deletar Cliente", MessageBoxButtons.YesNo);

            if (resposta == DialogResult.Yes)
            {
                ConectaBanco conecta = new ConectaBanco();
                bool retorno = conecta.deletaCliente(codRemover);
                if (retorno == true)
                {
                    MessageBox.Show("Cliente Removido !");
                }
                
            } // final if YES
            else
                MessageBox.Show("Operação Cancelada");

            lista_gridCliente();
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            lblHeaderCliente.Text = "Alterar dados do Cliente:";


            btnConfimaAlt.Visible = true;

            lblClienteAlt.Visible = true;
            lblEmailAlt.Visible = true;
            lblCpfAlt.Visible = true;
            lblEnderecoAlt.Visible = true;
            lblBairroAlt.Visible = true;

            txtNomeCliAlt.Visible = true;
            txtEmailCliAlt.Visible = true;
            txtCpfCliAlt.Visible = true;
            txtEnderecoCliAlt.Visible = true;
            txtBairroCliAlt.Visible = true;

            plinhaClienteAlt.Visible = true;
            plinhaEmailAlt.Visible = true;
            plinhaCpfAlt.Visible = true;
            plinhaEnderecoAlt.Visible = true;
            plinhaBairroAlt.Visible = true;

            lblHeaderCliente.Visible = true;

            int linha = dgListaCliente.CurrentRow.Index; //pegar linha selecionada
            codAlteraCliente = Convert.ToInt32(dgListaCliente.Rows[linha].Cells["Codigo"].Value.ToString());

            txtNomeCliAlt.Text = dgListaCliente.Rows[linha].Cells["nome"].Value.ToString();
            txtCpfCliAlt.Text = dgListaCliente.Rows[linha].Cells["cpf"].Value.ToString();
            txtEmailCliAlt.Text = dgListaCliente.Rows[linha].Cells["email"].Value.ToString();
            txtEnderecoCliAlt.Text = dgListaCliente.Rows[linha].Cells["endereco"].Value.ToString();
            txtBairroCliAlt.Text = dgListaCliente.Rows[linha].Cells["bairro"].Value.ToString();

        }

        private void btnConfirmaAlteracao_Click(object sender, EventArgs e)
        {
           


        }

        private void bntAddGenero_Click(object sender, EventArgs e)
        {
          
        }
        void limpaCampoPet()
        {
            txtNomePet.Text = "";
            txtTipoPet.Text = "";
            txtPortePet.Text = "";
            txtRacaPet.Text = "";
            cbClientes.Text = "Selecione um Cliente";
            txtCorPet.Text = "";
            txtNomePet.Focus();
        }
        void limpaCampos()
        {
            txtNomeCli.Clear();
            txtCpfCli.Clear();
            txtEmailCli.Clear();
            txtEnderecoCli.Clear();
            txtBairroCli.Clear();
            txtNomeCli.Focus(); 
        }
        private void BtnConfirmaCadastro_Click(object sender, EventArgs e)
        {
            Cliente novoCliente = new Cliente();
            novoCliente.NomeCliente = txtNomeCli.Text;
            novoCliente.CpfCliente = txtCpfCli.Text;
            novoCliente.EmailCliente = txtEmailCli.Text;
            novoCliente.EnderecoCliente = txtEnderecoCli.Text;
            novoCliente.BairroCliente = txtBairroCli.Text;

            ConectaBanco conecta = new ConectaBanco();
            bool retorno = conecta.insereCliente(novoCliente);
            if (retorno == true)
            {
                MessageBox.Show("Dados cadastrados com sucesso !");
                limpaCampos();
            }
            
        }
        
        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textbairro_TextChanged(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void dgBandas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void listaCliente_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnPet_Click(object sender, EventArgs e)
        {
            marcador.Height = btnPet.Height;
            marcador.Top = btnPet.Top;
            tabControl1.SelectedTab = tabControl1.TabPages[2];
            ConectaBanco con = new ConectaBanco();
            dgPets.DataSource = con.listaPets();
        }

        private void marcador_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tabPet_Click(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void txtBusca_TextChanged_1(object sender, EventArgs e)
        {
            ((DataTable)dgListaCliente.DataSource).DefaultView.RowFilter = string.Format("Nome like '{0}%'", txtBusca.Text);
        }

        


        private void label12_Click_1(object sender, EventArgs e)
        {

        }

        private void txtBuscaPet_TextChanged(object sender, EventArgs e)
        {
            ((DataTable)dgPets.DataSource).DefaultView.RowFilter = string.Format("Nome like '{0}%'", txtBuscaPet.Text);
        }

        private void btnRemoverPet_Click(object sender, EventArgs e)
        {
            int linha = dgPets.CurrentRow.Index; //pegar linha selecionada
            int codRemover = Convert.ToInt32(dgPets.Rows[linha].Cells["Codigo"].Value.ToString());

            DialogResult resposta = MessageBox.Show("Confirmar Exclusão?", "Deletar Pet", MessageBoxButtons.YesNo);

            if (resposta == DialogResult.Yes)
            {
                ConectaBanco conecta = new ConectaBanco();
                bool retorno = conecta.deletaPet(codRemover);
                if (retorno == true)
                {
                    MessageBox.Show("Pet Removido !");
                }
               
               
            } // final if YES
            else
                MessageBox.Show("Operação Cancelada");

            lista_gridPets();
        }

        private void btnAlterarPet_Click(object sender, EventArgs e)
        {
            lblHeaderPet.Text = "Alterar Pet";

            btnConfirmarPet.Visible = false;
            btnConcluirPet.Visible = true;

            int linha = dgPets.CurrentRow.Index; //pegar linha selecionada
            codAlterarPet = Convert.ToInt32(dgPets.Rows[linha].Cells["Codigo"].Value.ToString());

            txtNomePet.Text = dgPets.Rows[linha].Cells["Nome"].Value.ToString();
            txtTipoPet.Text = dgPets.Rows[linha].Cells["Especie"].Value.ToString();
            txtCorPet.Text = dgPets.Rows[linha].Cells["Cor"].Value.ToString();
            txtRacaPet.Text = dgPets.Rows[linha].Cells["Raca"].Value.ToString();
            txtPortePet.Text = dgPets.Rows[linha].Cells["Porte"].Value.ToString();
            cbClientes.Text = dgPets.Rows[linha].Cells["Dono"].Value.ToString();
        }

        private void btnConcluirPet_Click(object sender, EventArgs e)
        {
            Pet novoPet = new Pet();
            novoPet.NomePet = txtNomePet.Text;
            novoPet.TipoPet = txtTipoPet.Text;
            novoPet.CorPet = txtCorPet.Text;
            novoPet.RacaPet = txtRacaPet.Text;
            novoPet.PortePet = txtPortePet.Text;
            novoPet.DonoPet = Convert.ToInt32(cbClientes.SelectedValue.ToString());


            //Enviar dados para alterar
            ConectaBanco conecta = new ConectaBanco();
            bool retorno = conecta.alteraPet(novoPet, codAlterarPet);

            if (retorno == true)
            {
                MessageBox.Show("Dados alterados com sucesso !");
                limpaCampoPet();
            }
            

            lista_gridPets();
            btnConcluirPet.Visible = false;
            btnConfirmarPet.Visible = true;
            lblHeaderPet.Text = "Cadastrar Pet";

        }

        private void btnLimpaPet_Click(object sender, EventArgs e)
        {
            limpaCampoPet();
        }

        private void dgPets_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnConfirmarPet_Click(object sender, EventArgs e)
        {
            Pet novoPet = new Pet();
            novoPet.NomePet = txtNomePet.Text;
            novoPet.TipoPet = txtTipoPet.Text;
            novoPet.CorPet = txtCorPet.Text;
            novoPet.RacaPet = txtRacaPet.Text;
            novoPet.PortePet = txtPortePet.Text;
            novoPet.DonoPet = Convert.ToInt32(cbClientes.SelectedValue.ToString());

            ConectaBanco conecta = new ConectaBanco();
            bool retorno = conecta.inserePet(novoPet);
            if (retorno == true)
            {
                MessageBox.Show("Dados Inseridos com Sucesso :)");
            }

            ConectaBanco con = new ConectaBanco();
            dgPets.DataSource = con.listaPets();

            limpaCampoPet();
        }

        private void tabCadastrar_Click(object sender, EventArgs e)
        {

        }

        private void btnConfimaAlt_Click(object sender, EventArgs e)
        {
            Cliente novoCliente = new Cliente();
            novoCliente.NomeCliente = txtNomeCliAlt.Text;
            novoCliente.CpfCliente = txtCpfCliAlt.Text;
            novoCliente.EmailCliente = txtEmailCliAlt.Text;
            novoCliente.EnderecoCliente = txtEnderecoCliAlt.Text;
            novoCliente.BairroCliente = txtBairroCliAlt.Text;

            ConectaBanco conecta = new ConectaBanco();
            bool retorno = conecta.alteraCliente(novoCliente, codAlteraCliente);
            if (retorno == true)
            {
                MessageBox.Show("Dados cadastrados com sucesso !");
                limpaCampos();
            }
            lista_gridCliente();
            btnConfimaAlt.Visible = true;

            lblClienteAlt.Visible = true;
            lblEmailAlt.Visible = true;
            lblCpfAlt.Visible = true;
            lblEnderecoAlt.Visible = true;
            lblBairroAlt.Visible = true;

            txtNomeCliAlt.Visible = true;
            txtEmailCliAlt.Visible = true;
            txtCpfCliAlt.Visible = true;
            txtEnderecoCliAlt.Visible = true;
            txtBairroCliAlt.Visible = true;

            plinhaClienteAlt.Visible = true;
            plinhaEmailAlt.Visible = true;
            plinhaCpfAlt.Visible = true;
            plinhaEnderecoAlt.Visible = true;
            plinhaBairroAlt.Visible = true;

            lblHeaderCliente.Visible = true;
        }

        private void lblVersao_Click(object sender, EventArgs e)
        {

        }

        private void btnClic_Cli_Click(object sender, EventArgs e)
        {
            btnCadastra_Click(sender, e);
            txtNomeCli.Focus();
        }
    }
}
