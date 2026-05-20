using AppMVC.Models;

namespace AppMVC.Views;

public partial class pgVisualizarPessoa : ContentPage
{
	//Adicionar no método construtor o parametro
	//para receber o objeto do cadastro que sera exibido na tela
	//para isso é nescessario importar a camada de model
	//using NomeProjeto.Models;
	public pgVisualizarPessoa(Pessoa pessoa)
	{
		InitializeComponent();

		//Mapear a tela com o objeto
		lblId.Text = pessoa.Id.ToString();
		lblNome.Text = pessoa.Nome;
		lblCPF.Text = pessoa.CPF;
		imgCadastro.Source = pessoa.DirImagem;
	}

    private void btnVoltar_Clicked(object sender, EventArgs e)
    {
		Application.Current.MainPage.Navigation.PopAsync();
    }
}