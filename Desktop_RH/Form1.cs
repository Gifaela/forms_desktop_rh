using Consumindo_WebApi_Funcionario;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Desktop_RH
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string URI = "";



        int codigoFuncionario = 1;


        private void btnObterFuncionario_Click(object sender, EventArgs e)
        {
            GetAllFuncionarios();
        }

        private void btnFuncionarioPorId_Click(object sender, EventArgs e)
        {
            InputBoxID();
            if(codigoFuncionario != -1)
            {
                GetFuncionarioByID(codigoFuncionario);
            }

        }

        private void btnIncluirFuncionario_Click(object sender, EventArgs e)
        {

            // Crie uma nova janela (formulário) para a inclusão de funcionários
            Form formularioFuncionario = new Form();
            formularioFuncionario.Text = "Incluir Funcionário";
            formularioFuncionario.Size = new Size(400, 400); // Ajuste o tamanho da janela

            // Crie labels para identificar as caixas de texto
            Label lblNome = new Label();
            lblNome.Text = "Nome:";
            lblNome.Location = new Point(20, 20);
            formularioFuncionario.Controls.Add(lblNome);

            Label lblCpf = new Label();
            lblCpf.Text = "CPF:";
            lblCpf.Location = new Point(20, 50);
            formularioFuncionario.Controls.Add(lblCpf);

            Label lblEmail = new Label();
            lblEmail.Text = "Email:";
            lblEmail.Location = new Point(20, 80);
            formularioFuncionario.Controls.Add(lblEmail);

            Label lblDataNascimento = new Label();
            lblDataNascimento.Text = "Data de Nascimento:";
            lblDataNascimento.Location = new Point(20, 110);
            formularioFuncionario.Controls.Add(lblDataNascimento);

            Label lblFerias = new Label();
            lblFerias.Text = "Férias:";
            lblFerias.Location = new Point(20, 140);
            formularioFuncionario.Controls.Add(lblFerias);

            Label lblTelefone = new Label();
            lblTelefone.Text = "Telefone:";
            lblTelefone.Location = new Point(20, 170);
            formularioFuncionario.Controls.Add(lblTelefone);

            Label lblSalario = new Label();
            lblSalario.Text = "Salário:";
            lblSalario.Location = new Point(20, 200);
            formularioFuncionario.Controls.Add(lblSalario);

            Label lblCargo = new Label();
            lblCargo.Text = "Cargo:";
            lblCargo.Location = new Point(20, 230);
            formularioFuncionario.Controls.Add(lblCargo);

            // Crie caixas de texto para coletar os dados
            TextBox txtNome = new TextBox();
            TextBox txtCpf = new TextBox();
            TextBox txtEmail = new TextBox();
            TextBox txtDataNascimento = new TextBox();
            TextBox txtFerias = new TextBox();
            TextBox txtTelefone = new TextBox();
            TextBox txtSalario = new TextBox();
            TextBox txtCargo = new TextBox();

            // Posicione as caixas de texto no formulário
            int yOffset = 20;
            txtNome.Location = new Point(150, yOffset);
            txtNome.Size = new Size(200, 20); // Ajuste o tamanho da caixa de texto
            formularioFuncionario.Controls.Add(txtNome);

            yOffset += 30;
            txtCpf.Location = new Point(150, yOffset);
            txtCpf.Size = new Size(200, 20);
            formularioFuncionario.Controls.Add(txtCpf);

            yOffset += 30;
            txtEmail.Location = new Point(150, yOffset);
            txtEmail.Size = new Size(200, 20);
            formularioFuncionario.Controls.Add(txtEmail);

            yOffset += 30;
            txtDataNascimento.Location = new Point(150, yOffset);
            txtDataNascimento.Size = new Size(200, 20);
            formularioFuncionario.Controls.Add(txtDataNascimento);

            yOffset += 30;
            txtFerias.Location = new Point(150, yOffset);
            txtFerias.Size = new Size(200, 20);
            formularioFuncionario.Controls.Add(txtFerias);

            yOffset += 30;
            txtTelefone.Location = new Point(150, yOffset);
            txtTelefone.Size = new Size(200, 20);
            formularioFuncionario.Controls.Add(txtTelefone);

            yOffset += 30;
            txtSalario.Location = new Point(150, yOffset);
            txtSalario.Size = new Size(200, 20);
            formularioFuncionario.Controls.Add(txtSalario);

            yOffset += 30;
            txtCargo.Location = new Point(150, yOffset);
            txtCargo.Size = new Size(200, 20);
            formularioFuncionario.Controls.Add(txtCargo);

            // Crie um botão "Salvar e Fechar"
            Button btnSalvarFechar = new Button();
            btnSalvarFechar.Text = "Salvar e Fechar";
            btnSalvarFechar.Size = new Size(100, 30); // Ajuste o tamanho do botão


            btnSalvarFechar.Click += async (senderSalvar, eSalvar) =>
            {
                // Capture os dados das caixas de texto
                string nome = txtNome.Text;
                int cpf = int.Parse(txtCpf.Text);
                string email = txtEmail.Text;
                string dataNascimento = txtDataNascimento.Text;
                string ferias = txtFerias.Text;
                int telefone = int.Parse(txtTelefone.Text);
                double salario = double.Parse(txtSalario.Text);
                string cargo = txtCargo.Text;

                // Crie um objeto Funcionario com os dados
                var funcionario = new Funcionario
                {
                    myName = nome,
                    myCpf = cpf,
                    myemail = email,
                    mybirthdate = dataNascimento,
                    myferias = ferias,
                    myPhone = telefone,
                    MySalario = salario,
                    MyCargo = cargo
                };

                // Serializar o objeto para JSON
                string json = Newtonsoft.Json.JsonConvert.SerializeObject(funcionario);

                using (var client = new HttpClient())
                {
                    // Defina a URL da API
                    string apiUrl = "https://localhost:44320/api/Funcionarios";

                    // Defina os cabeçalhos da requisição
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    // Crie o conteúdo da requisição com o JSON
                    var content = new StringContent(json, Encoding.UTF8, "application/json");

                    // Faça a requisição POST
                    var response = await client.PostAsync(apiUrl, content);

                    if (response.IsSuccessStatusCode)
                    {
                        // Requisição bem-sucedida, faça o que for necessário
                        MessageBox.Show("Funcionário cadastrado com sucesso!");
                    }
                    else
                    {
                        // Tratar erros, se necessário
                        MessageBox.Show("Ocorreu um erro ao cadastrar o funcionário.");
                    }
                }

                // Feche a janela após salvar
                formularioFuncionario.Close();
            };

            // Posicione o botão "Salvar e Fechar"
            yOffset += 40;
            btnSalvarFechar.Location = new Point(150, yOffset);

            // Adicione o botão "Salvar e Fechar" ao formulário
            formularioFuncionario.Controls.Add(btnSalvarFechar);

            // Exiba o formulário para o usuário
            formularioFuncionario.ShowDialog();
        }

        private void btnAtualizaFuncionario_Click(object sender, EventArgs e)
        {
            // Crie uma nova janela (formulário) para a inclusão de funcionários
            Form formularioFuncionario = new Form();
            formularioFuncionario.Text = "Incluir Funcionário";
            formularioFuncionario.Size = new Size(400, 450); // Ajuste o tamanho da janela para acomodar a nova caixa de texto

            // Crie labels para identificar as caixas de texto
            Label lblNome = new Label();
            lblNome.Text = "Nome:";
            lblNome.Location = new Point(20, 20);
            formularioFuncionario.Controls.Add(lblNome);

            Label lblCpf = new Label();
            lblCpf.Text = "CPF:";
            lblCpf.Location = new Point(20, 50);
            formularioFuncionario.Controls.Add(lblCpf);

            Label lblEmail = new Label();
            lblEmail.Text = "Email:";
            lblEmail.Location = new Point(20, 80);
            formularioFuncionario.Controls.Add(lblEmail);

            Label lblDataNascimento = new Label();
            lblDataNascimento.Text = "Data de Nascimento:";
            lblDataNascimento.Location = new Point(20, 110);
            formularioFuncionario.Controls.Add(lblDataNascimento);

            Label lblFerias = new Label();
            lblFerias.Text = "Férias:";
            lblFerias.Location = new Point(20, 140);
            formularioFuncionario.Controls.Add(lblFerias);

            Label lblTelefone = new Label();
            lblTelefone.Text = "Telefone:";
            lblTelefone.Location = new Point(20, 170);
            formularioFuncionario.Controls.Add(lblTelefone);

            Label lblSalario = new Label();
            lblSalario.Text = "Salário:";
            lblSalario.Location = new Point(20, 200);
            formularioFuncionario.Controls.Add(lblSalario);

            Label lblCargo = new Label();
            lblCargo.Text = "Cargo:";
            lblCargo.Location = new Point(20, 230);
            formularioFuncionario.Controls.Add(lblCargo);

            // Nova label e caixa de texto para o ID
            Label lblId = new Label();
            lblId.Text = "ID:";
            lblId.Location = new Point(20, 260);
            formularioFuncionario.Controls.Add(lblId);

            TextBox txtNome = new TextBox();
            TextBox txtCpf = new TextBox();
            TextBox txtEmail = new TextBox();
            TextBox txtDataNascimento = new TextBox();
            TextBox txtFerias = new TextBox();
            TextBox txtTelefone = new TextBox();
            TextBox txtSalario = new TextBox();
            TextBox txtCargo = new TextBox();
            TextBox txtId = new TextBox(); // Nova caixa de texto para o ID

            // Posicione as caixas de texto no formulário
            int yOffset = 20;
            txtNome.Location = new Point(150, yOffset);
            txtNome.Size = new Size(200, 20);
            formularioFuncionario.Controls.Add(txtNome);

            yOffset += 30;
            txtCpf.Location = new Point(150, yOffset);
            txtCpf.Size = new Size(200, 20);
            formularioFuncionario.Controls.Add(txtCpf);

            yOffset += 30;
            txtEmail.Location = new Point(150, yOffset);
            txtEmail.Size = new Size(200, 20);
            formularioFuncionario.Controls.Add(txtEmail);

            yOffset += 30;
            txtDataNascimento.Location = new Point(150, yOffset);
            txtDataNascimento.Size = new Size(200, 20);
            formularioFuncionario.Controls.Add(txtDataNascimento);

            yOffset += 30;
            txtFerias.Location = new Point(150, yOffset);
            txtFerias.Size = new Size(200, 20);
            formularioFuncionario.Controls.Add(txtFerias);

            yOffset += 30;
            txtTelefone.Location = new Point(150, yOffset);
            txtTelefone.Size = new Size(200, 20);
            formularioFuncionario.Controls.Add(txtTelefone);

            yOffset += 30;
            txtSalario.Location = new Point(150, yOffset);
            txtSalario.Size = new Size(200, 20);
            formularioFuncionario.Controls.Add(txtSalario);

            yOffset += 30;
            txtCargo.Location = new Point(150, yOffset);
            txtCargo.Size = new Size(200, 20);
            formularioFuncionario.Controls.Add(txtCargo);

            // Posicione a nova caixa de texto para o ID
            yOffset += 30;
            txtId.Location = new Point(150, yOffset);
            txtId.Size = new Size(200, 20);
            formularioFuncionario.Controls.Add(txtId);

            // Crie um botão "Salvar e Fechar"
            Button btnSalvarFechar = new Button();
            btnSalvarFechar.Text = "Salvar e Fechar";
            btnSalvarFechar.Size = new Size(100, 30);

            btnSalvarFechar.Click += async (senderSalvar, eSalvar) =>
            {
                // Capture os dados das caixas de texto
                int id = int.Parse(txtId.Text);
                string nome = txtNome.Text;
                int cpf = int.Parse(txtCpf.Text);
                string email = txtEmail.Text;
                string dataNascimento = txtDataNascimento.Text;
                string ferias = txtFerias.Text;
                int telefone = int.Parse(txtTelefone.Text);
                double salario = double.Parse(txtSalario.Text);
                string cargo = txtCargo.Text;

                // Crie um objeto Funcionario com os dados
                var funcionario = new FuncionarioUtualiza
                {
                    id = id,
                    myName = nome,
                    myCpf = cpf,
                    myemail = email,
                    mybirthdate = dataNascimento,
                    myferias = ferias,
                    myPhone = telefone,
                    MySalario = salario,
                    MyCargo = cargo
                };


                // Serializar o objeto para JSON
                string json = Newtonsoft.Json.JsonConvert.SerializeObject(funcionario);

                using (var client = new HttpClient())
                {
                    // Defina a URL da API
                    string apiUrl = "https://localhost:44320/api/Funcionarios/"+funcionario.id;

                    // Defina os cabeçalhos da requisição
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    // Crie o conteúdo da requisição com o JSON
                    var content = new StringContent(json, Encoding.UTF8, "application/json");

                    // Faça a requisição POST
                    var response = await client.PutAsync(apiUrl, content);

                    if (response.IsSuccessStatusCode)
                    {
                        // Requisição bem-sucedida, faça o que for necessário
                        MessageBox.Show("Funcionário cadastrado com sucesso!");
                    }
                    else
                    {
                        // Tratar erros, se necessário
                        MessageBox.Show("Ocorreu um erro ao cadastrar o funcionário.");
                    }
                }

                // Feche a janela após salvar
                formularioFuncionario.Close();
            };

            // Posicione o botão "Salvar e Fechar"
            yOffset += 40;
            btnSalvarFechar.Location = new Point(150, yOffset);

            // Adicione o botão "Salvar e Fechar" ao formulário
            formularioFuncionario.Controls.Add(btnSalvarFechar);

            // Exiba o formulário para o usuário
            formularioFuncionario.ShowDialog();
        }

        private void btnDeletarFuncionario_Click(object sender, EventArgs e)
        {
            InputBoxID();
            if(codigoFuncionario != -1)
            {
                DeleteFuncionario(codigoFuncionario);
            }
        }

        private void InputBoxID()
        {
            // usando a função VB.Net para exibir um prompt para o usuário informar a senha 
            string Prompt = "Informe o ID do Funcionário.";
            string Titulo = "ByID";
            string Resultado = Microsoft.VisualBasic.Interaction.InputBox(Prompt, Titulo, "", 600, 350);
            // verifica se o resultado é uma string vazia o que indica que foi cancelado. 
            if (Resultado != "")
            {
                codigoFuncionario = Convert.ToInt32(Resultado);
            }
            else
            {
                codigoFuncionario = -1;
            }
        }




        private async void GetAllFuncionarios()
        {
            URI = txtURI.Text; // passando a URI
            using (var client = new HttpClient())
            {
                using (var response = await client.GetAsync(URI)) // Dando um GET na URI
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var FuncionarioJsonString = await response.Content.ReadAsStringAsync();
                        dgvDados.DataSource = JsonConvert.DeserializeObject<Funcionario[]>(FuncionarioJsonString).ToList();
                    }
                    else
                    {
                        MessageBox.Show("Não foi possível obter os funcionários: " + response.StatusCode);
                    }
                }
            }
        }

        private async void GetFuncionarioByID(int codFuncionario)
        {
            using (var client = new HttpClient())
            {
                BindingSource bsDados = new BindingSource();
                URI = txtURI.Text + "/" + codFuncionario.ToString(); // Passando a URI com o número do ID

                HttpResponseMessage response = await client.GetAsync(URI); // Dando um GET na URI com ID

                if (response.IsSuccessStatusCode)
                {
                    var FuncionarioJsonString = await response.Content.ReadAsStringAsync();
                    bsDados.DataSource = JsonConvert.DeserializeObject<Funcionario>(FuncionarioJsonString);
                    dgvDados.DataSource = bsDados;
                }
            }
        }

        /*
          private async void GetFuncionarioByName(int nameFuncionario)
         {
             using (var client = new HttpClient())
             {
                 BindingSource bsDados = new BindingSource();
                 URI = txtURI.Text + "/" + nameFuncionario.ToString(); // Passando a URI com o número do nome

                 HttpResponseMessage response = await client.GetAsync(URI); // Dando um GET na URI com nome

                 if (response.IsSuccessStatusCode)
                 {
                     var FuncionarioJsonString = await response.Content.ReadAsStringAsync();
                     bsDados.DataSource = JsonConvert.DeserializeObject<Funcionario>(FuncionarioJsonString);
                     dgvDados.DataSource = bsDados;
                 }
             }
         }
         */

        private async void AddFuncionario()
        {
        }

        private async void UpdateFuncionario(int codFuncionario)
        {
           
        }

        private async void DeleteFuncionario(int codFuncionario)
        {
            URI = txtURI.Text;
            int FuncionarioID = codFuncionario;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(URI);
                HttpResponseMessage responseMessage = await client.DeleteAsync(String.Format("{0}/{1}", URI, FuncionarioID));

                if (responseMessage.IsSuccessStatusCode)
                {
                    MessageBox.Show("Funcionário excluído com sucesso");
                }
                else
                {
                    MessageBox.Show("Falha ao excluir o funcionário  : " + responseMessage.StatusCode);
                }
                GetAllFuncionarios();
            }
        }

        private void dgvDados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
