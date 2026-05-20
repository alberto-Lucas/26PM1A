using AppMVC.Models;
using AppMVC.Services;
using AppMVC.Controllers;

namespace AppMVC.Views;

public partial class pgCadPessoaView : ContentPage
{
    //Importar as camdas
    //using NomeProjeto.Models;
    //using NomeProjeto.Services;
    //using NomeProjeto.Controllers;

    //Criar a instancia da comada de controle
    //Usar o underline (_) para identificar
    //variaveis globais do tipo privada
    PessoaController _controller;

    //Variavel global para armazenar
    //a imagem selecionada
    string _imgSelecionada = "";

	public pgCadPessoaView()
	{
		InitializeComponent();

        //Instancia a camada de controle
        _controller = new PessoaController();
	}

    private void btnVoltar_Clicked(object sender, EventArgs e)
    {
        Application.Current.MainPage.Navigation.PopAsync();
    }

    private async void btnAdicionarImagem_Clicked(object sender, EventArgs e)
    {
        //Iremos chama a rotina de seleção de imagem 
        //na camada de serviço
        //Porém pela classe ImageService ser do tipo static
        //Não é preciso criar uma instancia como fizemos
        //com a controller, por ser static podemos
        //chamar a o método desejada diretamente
        //Ex: ImageService.SelecionarImagem();
        //Lembrando que a função de seleção de imagem
        //é executada de forma assincrona, então precisamos
        //utilizar o await para sincronia e recuperação de dados
        //para isso precisa adicionar o async neste método
        //ficando como private async void btnAdic....
        //popular a variavel global com a imgselecionada
        _imgSelecionada = await ImageService.SelecionarImagem();
        //Atualizar a imagem na tela
        imgCadastro.Source = _imgSelecionada;
        //Exibir o botão remover
        btnRemoverImagem.IsVisible = false;
    }

    //Método para remover e limpar a imagem da tela
    //o método é utilizado pois essa rotina
    //seria executada tanto botão remover quanto no salvar
    //então foi centralizado em um método
    void RemoverImagem()
    {
        //Limpar a imagem da tela
        imgCadastro.Source = "";
        //Limpar a variavel
        _imgSelecionada = "";
        //Ocultar o botão remover
        btnRemoverImagem.IsVisible = false;
    }

    private void btnRemoverImagem_Clicked(object sender, EventArgs e)
    {
        RemoverImagem();
    }

    private void btnSalvar_Clicked(object sender, EventArgs e)
    {
        //Iremos recuperar as informações da tela
        string nome = txtNome.Text;
        string cpf = txtCPF.Text;

        //Aplicar uma validação simples se o campos estão preenchidos
        if(string.IsNullOrEmpty(nome) ||
            string.IsNullOrEmpty(cpf))
        {
            //Notificar o usuario
            DisplayAlert("Atenção", "Preencha os campos corretamente.", "OK");
            return; //abortar a rotina
        }

        //Instanciar o objeto Pessoa
        Pessoa pessoa = new Pessoa();

        //Mapear o objeto com os dados
        pessoa.Nome = nome;
        pessoa.CPF = cpf;

        //Neste momento realizar a chamada da função 
        //copiar imagem, para que seja salvo o novo 
        //diretorio no banco de dados
        //Neste caso não precisamos realizar nenhuma validação
        //pois a mesma ja foi feito na propria função Copiar
        pessoa.DirImagem = ImageService.CopiarImagem(_imgSelecionada);

        //Podemos salvar o objeto no banco de dados
        //e validar o retorno da inserção
        if (_controller.Insert(pessoa))
        {
            //Se retorno positivo
            //Nofiticamos o usuario e limpamos a tela
            DisplayAlert("Informação", "Cadastro salvo com sucesso.", "Ok");
            //Limpa tela
            txtNome.Text = "";
            txtCPF.Text = "";
            //Limpa a imagem
            RemoverImagem();
        }
        else
            DisplayAlert("Erro", "Falha ao salvar o cadastro.", "OK");
    }
}