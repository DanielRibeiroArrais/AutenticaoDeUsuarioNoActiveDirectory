using System;
using System.DirectoryServices;
using System.Windows.Forms;

namespace WindowsFormsApplication
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtUsuario.Text) && !string.IsNullOrWhiteSpace(txtSenha.Text))
            {
                try
                {
                    DirectoryEntry directoryEntry = new DirectoryEntry("LDAP://dominio.com:389", txtUsuario.Text, txtSenha.Text);
                    DirectorySearcher directorySearcher = new DirectorySearcher(directoryEntry);
                    directorySearcher.Filter = "(SAMAccountName=" + txtUsuario.Text + ")";
                    SearchResult searchResult = directorySearcher.FindOne();
                    if ((Int32)searchResult.Properties["userAccountControl"][0] == 512)
                    {
                        MessageBox.Show("Usuário Autenticado!");
                    }
                    else
                    {
                        MessageBox.Show("ERRO: Usuário/Senha Inválido!");
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Usuário não encontrado!");
                }
            }
        }
    }
}
