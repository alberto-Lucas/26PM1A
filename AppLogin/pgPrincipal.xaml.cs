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
	}

    private void btnVoltar_Clicked(object sender, EventArgs e)
    {
		//Aplicar o POP
		//Remover a tela atual da PILHA

		Application.Current.MainPage.
			Navigation.PopAsync();
    }
}