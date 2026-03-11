namespace AppLogin;

public partial class pgPrincipal : ContentPage
{
	public pgPrincipal()
	{
		InitializeComponent();
	}

    private void btnVoltar_Clicked(object sender, EventArgs e)
    {
		//Aplicar o POP
		//Remover a tela atual da PILHA

		Application.Current.MainPage.
			Navigation.PopAsync();
    }
}