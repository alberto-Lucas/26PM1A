using System.Collections.ObjectModel;

namespace AppListView
{
    public partial class MainPage : ContentPage
    {
        /*
        Detalhes da ListView
        <ListView>: 
        Componente de Visualização de Dados 
        em formatade Lista

        <ListView.Template>:
        Definimos o tipo de exibição da Lista

        <DataTemplate:
        Definimos que os dados serão carregados
        externamente(codigo, banco de dados, 
        arquivo de texto, etc...)

        <ViewCell: 
        A célula de Visualização
        (como se fosse um div do HTML)

        <Frame>:
        Estilizar as celulas como cada registro
        fosse um card(não é obrigatorio)

        {Binding NomePropriedade}:
        Nescessario para referencia as propriedades
        do objeto em código
        Ex: Proprieade Nome do objeto Pessoa
        */

        //Criamos uma classe Pessoa
        //para ser o nosso objeto Pessoa
        //e definimos seus atributos(propriedades)
        public class Pessoa
        {
            public string Nome { get; set; }
            public string CPF { get; set; }
        }

        //Criar uma coleção de objeto Pessoa
        //Cada registro é um objeto
        //E reunimos todos os objetos em uma
        //coleção de dados(coleção, lista, array, etc)

        //Iremos utilizar a coleção Observavel
        //que é um tipo de coleção que atualiza
        //a ListView de maneira automatica
        //sempre a coleção for alterada
        //será nescessario importar a biblioteca
        //using System.Collections.ObjectModel;

        ObservableCollection<Pessoa> registros
            = new ObservableCollection<Pessoa>();

        //Mesmo processo se fosse uma lista
        //List<Pessoa> listaRegistro = new List<Pessoa>();
        public MainPage()
        {
            InitializeComponent();

            //Vincular a coleção de registro 
            //a ListView
            lsvDados.ItemsSource = registros;

            //Adicionar um registro fixo de exemplo
            //é somente adicionar um objeto pessoa
            //a coleção registros

            registros.Add(
                new Pessoa 
                {
                    Nome = "Lucas" ,
                    CPF = "123.456.789-00"
                }
            );
        }

        private void btnAdicionar_Clicked(object sender, EventArgs e)
        {
            //Adicionar os dados digitados
            //na lista de forma grosseira

            registros.Add(
                new Pessoa
                {
                    Nome = txtNome.Text,
                    CPF = txtCPF.Text
                }
            );
        }
    }
}
