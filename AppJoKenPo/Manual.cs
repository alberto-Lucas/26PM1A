namespace AppJoKenPo
{
    internal class Manual
    {
        //Desenvolver um app de JoKenPo (Pedra, Papel ou Tesoura)
        //que grava o historico de jogadas

        //Primeiro iniciamos com a instalação do pacotes
        //1 - Pacote para banco de dados
        //sqlite-net-pcl (Icone Pena)
        //2 - Pacote para gerenciamento de arquivo
        //PclExt.FieStorage (Icone Sushi)
        //A instalação ocorre pleo caminho:
        //Ferramentas > Gerenciador de Pacotes do NuGet >
        //Gerenciar Pacotes do NuGet na Solução (unico icone colorido)
        //Após a instalação precisamos chamar as bibliotecas
        //using SQLite;
        //using PCLExt.FileStorage.Folders;
        //A bliblioteca deve ser importada e todo classe
        //que usuara banco de dados 
        //***********************************************************
        //Segundo passo devemos criar a classe objeto de
        //acordo com a solicitação
        //Neste caso teremos a Classe Jogada com os atributos
        //Jogador
        //Data Hora
        //Aposta
        //Resultado
        //Pontuacao
        //Podemos criar essa classe em um arquivo separado
        //ou no mesmo arquivo do projeto
        //Neste caso iremos utilizar em arquivo separado
        //para melhor organização
        //Lembrando que é nescessario deixar a classe publica
        //e importar a biblioteca do SqLite
        //Obs: implementando logica de retorno direto na classe
        //assim gravamos apenas os dados brutos
        //e as conversoes de texto direto na classe
        //Como podemos ter mais de 2 opções, iremos gravar aposta 
        //e resultado em formato int
        //0: Pedra
        //1: Papel
        //2: Tesoura
        //Para isso iremos criar um método para converter o int em String de legenda
        //***********************************************************
        //Terceiro iremos implementar as rotinas de jogadas na tela
        //Primeiro devemos criar a conexão com o banco de dados
        //iremos criar uma variavel global para armazenar a conexão
        //SQLiteConnection _connection;
        //depois iremos desenvolver o método GetConnection
        //que ira validar o arquivo do banco de dados
        //cria-lo caso não exista, e retorna a conexão com o banco
        //***********************************************************
        //Quarto Abrir a conexão com o banco de dados no
        //construtor da Classe
        //No caso na public MainPage() abaixo do InitializeComponent();
        //Abro a conexão com o banco
        //_connection = GetConnection();
        //Atualizo a tabela do banco de acordo com a classe
        //_connection.CreateTable<Jogada>();
        //Chamo o método AtualizarListView();
        //***********************************************************
        //Iremos desenvolver o app de forma fragmentada
        //quebrando as rotinas em pequenos métodos
    }
}
