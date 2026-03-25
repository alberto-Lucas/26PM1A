namespace AppLogin;

public partial class pgPrincipal : ContentPage
{
	public pgPrincipal()
	{
		InitializeComponent();

		//Iremos recuperar o usuario logado
		//salvo na classe singleton

		//Crio a variavel que recebe a instancia
		var usuarioLogado = UsuarioLogado.Instancia;

        lblUsuario.Text =
			"Olá " + usuarioLogado.Login +
			", seja bem-vindo!";

        //Agora vou carregar os dados cadastrados
        //na classe cadastroSingleton

        var cadastroUsuario = CadastroSingleton.Instancia;

        //Preencher as labels com os dados

        lblNome.Text = cadastroUsuario.Nome;
        lblEmail.Text = cadastroUsuario.Email;
        lblLogin.Text = cadastroUsuario.Login;
        lblDtNascimento.Text = cadastroUsuario.DtNascimento;
    }

    private void lblVoltar_Tapped(object sender, TappedEventArgs e)
    {
        //Aplicar o POP
        //Remover a tela atual da PILHA

        Application.Current.MainPage.
            Navigation.PopAsync();
    }
}