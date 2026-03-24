namespace AppLogin;

public partial class pgCadastro : ContentPage
{
	public pgCadastro()
	{
		InitializeComponent();
	}

    private void btnCadastrar_Clicked(object sender, EventArgs e)
    {
        //Primeiro irei validar se a senha
        //foi prenchida corretamente
        //ou seja se a senha e a confirmação de senha
        //estão iguais
        //se estiver diferente ja aborto a execução

        if(txtSenha.Text != txtConfirmarSenha.Text)
        {
            DisplayAlert(
                "Atenção!",
                "As senhas não conferem.",
                "Ok");
            return; //aborta a execução
        }

        //se chegou aqui, é porque está tudo correto

        var cadastroUsuario = CadastroSingleton.Instancia;

        //Atribuir os valores
        cadastroUsuario.Nome         = txtNome.Text;
        cadastroUsuario.Email        = txtEmail.Text;
        cadastroUsuario.Login        = txtLogin.Text;
        cadastroUsuario.Senha        = txtSenha.Text;
        cadastroUsuario.DtNascimento = txtConfirmarSenha.Text;

        DisplayAlert(
            "Sucesso!",
            "Usuário cadastrado com sucesso.",
            "Ok");

        Application.Current.MainPage.Navigation.PopAsync();
    }
}