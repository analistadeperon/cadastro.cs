public partial class FrmFuncionariosCadastrar : Form
    {
        public FrmFuncionariosCadastrar()
        {
            InitializeComponent();
        }

        #region "Botões"

        private void tsbtnSalvar_Click(object sender, EventArgs e)
        {
            Salvar();
        }

        private void tsbtn_CancelarCadastro_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Você tem certeza que deseja voltar e cancelar o cadastro?", "Mensagem do Sistema",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void tsbtnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion "BOTÕES --> FIM "

        #region "Métodos"
        private void Salvar()
        {
            bool camposValidados = false;

            try
            {
                SqlConnection objConexao = new SqlConnection(@"Data Source=POS-PC\SQLEXPRESS;Initial Catalog=CADASTRO_CLASSEA;Integrated Security=True");

                string strConn = @"INSERT INTO FUNCIONARIO ([NOME], [CPF], [RG], [ENDERECO], [CIDADE], [UF], [TELEFONE_FIXO], [TELEFONE_RECADO], [TELEFONE_CELULAR], [DATA_ADMISSAO], [DATA_NASCIMENTO], [DATA_DEMISSAO] [EMAIL], [CARGO], [OBSERVACAO] )" +
                                   "VALUES (@NOME, @CPF, @RG, @ENDERECO, @CIDADE, @UF, @TELEFONE_FIXO, @TELEFONE_RECADO, @TELEFONE_CELULAR, @DATA_ADMISSAO, @DATA_NASCIMENTO, @DATA_DEMISSAO, @EMAIL, @CARGO, @OBSERVACAO)";

                SqlCommand objCommand = new SqlCommand(strConn, objConexao);


                #region "Validações dos Campos"


                //Nome 
                if (!String.IsNullOrEmpty(txtNome.Text))
                {
                    objCommand.Parameters.AddWithValue("@NOME", txtNome.Text);
                    camposValidados = true;
                }
                else
                {
                    epErro.SetError(txtNome, "O campo Nome é obrigatório!");
                    camposValidados = false;
                }

                //Cpf
                if (!String.IsNullOrEmpty(txtCpf.Text))
                {
                    objCommand.Parameters.AddWithValue("@CPF", txtCpf.Text);
                    camposValidados = true;
                }
                else
                {
                    epErro.SetError(txtCpf, "O Campo CPF é obrigatório!");
                    camposValidados = false;
                }
                //Rg
                if (!String.IsNullOrEmpty(txtRg.Text))
                {
                    objCommand.Parameters.AddWithValue("@RG", txtRg.Text);
                    camposValidados = true;
                }
                else
                {
                    epErro.SetError(txtRg, "o campo RG é obrigatório!");
                    camposValidados = false;
                }
                //Endereço
                if (!String.IsNullOrEmpty(txtEndereco.Text))
                {
                    objCommand.Parameters.AddWithValue("@ENDERECO", txtEndereco.Text);
                    camposValidados = true;
                }
                else
                {
                    epErro.SetError(txtEndereco, "o campo Endereço é obrigatório!");
                    camposValidados = false;
                }
                //Cidade
                //Uf
                //Telefone Fixo
                if (!String.IsNullOrEmpty(txtTelefoneFixo.Text))
                {
                    objCommand.Parameters.AddWithValue("@TELEFONE_FIXO", txtTelefoneFixo.Text);
                    camposValidados = true;
                }
                //Telefone Recado
                if (!String.IsNullOrEmpty(TxtTelRecado.Text))
                {
                    objCommand.Parameters.AddWithValue("@TELEFONE_RECADO", TxtTelRecado.Text);
                    camposValidados = true;
                }
                //Telefone Celular
                if (!String.IsNullOrEmpty(TxtTelCelular.Text))
                {
                    objCommand.Parameters.AddWithValue("@TELEFONE_CELULAR", TxtTelCelular.Text);
                    camposValidados = true;
                }
                //Data Admissão
                if (!String.IsNullOrEmpty(txtDataAdm.Text))
                {
                    objCommand.Parameters.AddWithValue("@DATA_ADMISSAO", txtDataAdm.Text);
                    camposValidados = true;
                }
                //Data Nascimento
                if (!String.IsNullOrEmpty(txtDataNascimento.Text))
                {
                    objCommand.Parameters.AddWithValue("@DATA_NASCIMENTO", txtDataNascimento.Text);
                    camposValidados = true;
                }
                //E-mail
                if (!String.IsNullOrEmpty(txtEmail.Text))
                {
                    objCommand.Parameters.AddWithValue("@EMAIL", txtEmail.Text);
                    camposValidados = true;
                }
                //Cargo
                if (!String.IsNullOrEmpty(txtCargo.Text))
                {
                    objCommand.Parameters.AddWithValue("@CARGO", txtCargo.Text);
                    camposValidados = true;
                }
                //Observação
                if (!String.IsNullOrEmpty(rtext_Obs.Text))
                {
                    objCommand.Parameters.AddWithValue("@OBSERVACAO", rtext_Obs.Text);
                    camposValidados = true;
                }


                #endregion "Validações dos Campos"

                //Verifico o retorno da variável camposValidados é true
                if (camposValidados)
                {
                    objConexao.Open();

                    objCommand.ExecuteNonQuery();

                    objConexao.Close();

                    MessageBox.Show("Registro inserido com sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LimparCampos();
                    txtNome.Focus();

                    tsbtnVoltar.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Ops, ocorreram erros!\n\nPreencha os campos e tente novamente",
                        "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LimparCampos()
        {
           try
            {
                txtNome.Text = string.Empty;
                txtCpf.Text = string.Empty;
                txtRg.Text = string.Empty;
                txtEndereco.Text = string.Empty;
                //falta cidade
                //uf
                txtTelefoneFixo.Text = string.Empty;
                TxtTelRecado.Text = string.Empty;
                TxtTelCelular.Text = string.Empty;
                txtDataAdm.Text = string.Empty;
                txtDataNascimento.Text = string.Empty;
                txtEmail.Text = string.Empty;
                txtCargo.Text = string.Empty;
                rtext_Obs.Text = string.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion "Fim --> Métodos"


        private void FrmFuncionariosCadastrar_Load(object sender, EventArgs e)
        {

        }

        
    }
}
