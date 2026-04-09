using System.Collections.ObjectModel;
using SQLite;
using PCLExt.FileStorage.Folders;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks;

namespace AppListView
{
    public partial class MainPage : ContentPage
    {
        //Para o uso do banco de dados
        //SQLite
        //é preciso instalar os pacotes de dependencias
        //para acessar as bibliotecas do SQLite
        //como o SQLite é manipulado diretamente
        //no arquivo salvo no dispositivo
        //é preciso tambem instalar um pacote
        //para gerenciamento de arquivo

        //Os pacotes:
        //sqlite-net-pcl: gerenciamento do bd
        //PCLExt: gerenciamento de arquivo

        //Nuget é a biblioteca de pacotes do VS
        //Iremos realizar a instalação pelo Nuget
        //instalar o Nuget sqlite-net-pcl (icone pena)
        //instalar o Nuget PCLExt.FileStorage (icone sushi)

        //Acessar o menu
        //Ferramentas > Gerenciador de Pacotes do Nuget >
        //Gerenciador de Pacotes do Nuget para solução
        //(unico icone colorido)

        //Importar as bibliotecas dos pacotes
        //using SQLite;
        //using PCLExt.FileStorage.Folders;

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

        //Precisamos ajustar o Objeto Pessoa
        //pois a tabela no banco é criada/atualizada
        //com base no objeto
        //Portanto é nescessario adicionar o atributo
        //identificador de registros (id)
        //e configurar o campo
        //adicionar chave primaria e o auto incremento

        //Criamos uma classe Pessoa
        //para ser o nosso objeto Pessoa
        //e definimos seus atributos(propriedades)
        public class Pessoa
        {
            //Configuramos os campos através de TAG's ([])
            //A tag sera aplicada no atributo abaixo
            //ou seja cada atributo deve possuir sua propria TAG
            [PrimaryKey, AutoIncrement]
            public int Id { get; set; }
            //Exemplo de configuração de campo no BD
            //[MaxLength(50), NotNull] //VARCHAR(50)
            public string Nome { get; set; }
            public string CPF { get; set; }
        }

        //Agora iremos preparar a conexão com o BD
        //lembrando que a conexão do SQLite
        //é o acesso direto ao arquivo armazenado
        //entre muitas aspas
        //"""a abrir o arquivo no bloco de notas e editalo"""

        //Iremos criar uma variavel que armazena a conexão
        //com o banco de dados
        SQLiteConnection conexao;

        //Função que retorna a conexão com o BD
        public SQLiteConnection GetConnection()
        {
            //Variavel para manipular a pasta onde 
            //a aplicação está instalada/executando
            var pastaRaiz = new LocalRootFolder();

            //Antes de concetar no arquivos
            //precisamos verificar a se o arquivo existe
            //se existir utilizamos ele
            //se não existi criamos um novo
            //neste mesmo processo
            //precisamo definir o nome do banco de dados
            //pois será o nome do arquivo

            //Varaivel para manipular o arquivo do BD
            var arquivoBD =
                pastaRaiz.CreateFile(
                    "oraculo", PCLExt.FileStorage.
                        CreationCollisionOption.OpenIfExists);

            //Abriar a conexão com o arquivo atraves
            //do diretorio do arquivo (a onde ele esta)
            //retorno a conexão
            //Patch é o diretorio
            return new SQLiteConnection(arquivoBD.Path);
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

        //Devido a conexão com o Banco de dados
        //Não iremos mais utilizar a
        //coleção observavel
        //ObservableCollection<Pessoa> registros
        //    = new ObservableCollection<Pessoa>();

        //Mesmo processo se fosse uma lista
        //List<Pessoa> listaRegistro = new List<Pessoa>();

        //Criar o método para carregar os registros
        //do banco de dados e apresentar na ListView
        void AtualizarListView()
        {
            //Realizar uma consulta na tabela Pessoa
            //correspondendo a query:
            //SELECT * FROM Pessoa
            lsvDados.ItemsSource =
                conexao.Table<Pessoa>().ToList();
        }

        public MainPage()
        {
            InitializeComponent();

            //Vincular a coleção de registro 
            //a ListView

            //Removido devido uso do BD
            //lsvDados.ItemsSource = registros;

            //Adicionar um registro fixo de exemplo
            //é somente adicionar um objeto pessoa
            //a coleção registros

            //Removido devido uso do BD
            //registros.Add(
            //    new Pessoa 
            //    {
            //        Nome = "Lucas" ,
            //        CPF = "123.456.789-00"
            //    }
            //);

            //Abrir a conexão com o BD
            conexao = GetConnection();

            //Mapear a tabela do banco com o objeto
            //Ou seja a tabela será criada/atualizada
            //espelhando o objeto
            //neste caso iremos utilizar o objeto Pessoa
            //Similar ao CREATE TABLE e ao ALTER TABLE
            conexao.CreateTable<Pessoa>();

            //Carrego a listView
            AtualizarListView();
        }

        private void btnAdicionar_Clicked(object sender, EventArgs e)
        {
            //Adicionar os dados digitados
            //na lista de forma grosseira

            //Removido devido conexão com o BD
            //registros.Add(
            //    new Pessoa
            //    {
            //        Nome = txtNome.Text,
            //        CPF = txtCPF.Text
            //    }
            //);

            //Iniciar validando se o campos foram preenchidos

            string nome = txtNome.Text;
            string cpf = txtCPF.Text;

            //Realizar a validação
            if(string.IsNullOrEmpty(nome) ||
                string.IsNullOrEmpty(cpf))
            {
                //Se um dos dois estiver vazio
                //apresentamos mensagem para o usuario
                //e abortamos a rotina
                DisplayAlert(
                    "Atenção",
                    "Por favor, preencha os campos corretamente.",
                    "OK");
                return; //Aborto a execução
            }

            //Se chegou até aqui, está tudo certo
            //podemos inserir o registro no banco de dados

            //Antes de inserir precisamos criar e popular
            //o objeto com as informações

            Pessoa pessoa = new Pessoa();
            pessoa.Nome = nome;
            pessoa.CPF = cpf;

            //Preciso do objeto pessoa
            //para identificar a tabela automaticamente

            //Ou seja pelo tipo do objeto (Ex: Pessoa)
            //ele realizar o insert na tabela correta
            conexao.Insert(pessoa);

            //Atualizar a tela
            AtualizarListView();

            //Limpeza dos campos para o proximos registro
            txtNome.Text = "";
            txtCPF.Text = "";
        }

        private async void btnApagar_Clicked(object sender, EventArgs e)
        {
            //Primeiro devemos validar
            //se a execução está vindo do botão apagar
            //Precisamos validar se item recuperado 
            //é do tipo do objeto desejado
            //no caso se for do tipo Pessoa
            //utilizara o is para identificar
            //se a informação é do tipo desejado
            //e ja recuperar a informação em um variavel
            //no nosso caso a informação está vindo
            //pelo CommandParameter através do ponto (.)
            //sender recuperar o componenter
            //que disparou o evento
            //o is realizar 3 funções ao mesmo tempo
            //1 - Comparar tipo de dados
            //2 - Converter o dado bruto em dado final
            //3 - Atributo o dado convertido em uma variavel
            if(sender is Button botao &&
                botao.CommandParameter is Pessoa pessoa)
            {
                //Se chegou até aqui 
                //devido o evento ter sido disparado
                //por um botão e o parametro (.) ser 
                //do tipo de dado correto 
                //no caso tipo de dado Pessoa

                //Precisamos confirmar a exclusão do registro

                //Iremos utilizar um displayAlert com retorno
                //Ou seja uma mensagem de SIM ou NÃO
                //O retorno padrão TRUE é do primeiro botão
                //destá forma obrigatoriamente o primeiro 
                //botão apresentando ao usuário 
                //deve ser o SIM

                //tambe utilizaremos o recurso assincrono
                //para exibir a mensagem evitando
                //o travamento da execução principal do aplicativo
                //devido aguardar uma resposta do usuario
                //Como o display executa em paralelo
                //com o aplicativo é precisso aguardar a resposta
                //para continuar a execução
                //o await significar esperar por essa resposta
                //para usar await preciso adicionar o async
                //no método
                //ex: private async void btnApagar_Clicked(...);
                bool retorno =
                    await DisplayAlert(
                        "Confirmação",
                        "Deseja realmente excluir este registro?",
                        "Sim",
                        "Não");

                //Validar a resposta
                if(retorno)
                {
                    //Segue o mesmo principio do Insert
                    //executa na tabela automaticamente
                    //pelo tipo de dados do objeto
                    conexao.Delete(pessoa);
                    AtualizarListView();
                }

            }
        }
    }
}
