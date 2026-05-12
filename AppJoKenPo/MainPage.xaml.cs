using SQLite;
using PCLExt.FileStorage.Folders;
using Microsoft.Maui.Controls.Handlers.Compatibility;

namespace AppJoKenPo
{
    public partial class MainPage : ContentPage
    {
        //utilizado o _ para identificar
        //que a variavel é do tipo private
        SQLiteConnection _connection;

        //Variavel que ira armazenar a pontual Atual
        int _pontuacaoAtual = 0;

        //Variavel que ira armazenar a rodada Atual
        int _rodadaAtual = 0;

        //Variavel que ira armazenar os pontos de jogos
        int _pontos = 2;



        SQLiteConnection GetConnection()
        {
            //Acesso a pasta onde o aplicativo está 
            //sendo executado;
            var pastaRaiz = new LocalRootFolder();

            //Recupero o arquivo do banco de dados
            //o mesmo será criado quase não exista
            var arquivoDB =
                pastaRaiz.CreateFile("jokenpo",
                    PCLExt.FileStorage.CreationCollisionOption.OpenIfExists);

            //Retorno a conexão com o arquivo
            return new SQLiteConnection(arquivoDB.Path);
        }

        public MainPage()
        {
            InitializeComponent();
            //Abro a conexão com o banco
            _connection = GetConnection();
            //Atualizo a tabela do banco de acordo com a classe
            _connection.CreateTable<Jogada>();
            //Resetamos a tela
            Reset();
            //Atualizar a grade
            AtualizarLista();

            Animation(imgPedra);
            Animation(imgPapel);
            Animation(imgTesoura);
        }

        //EXTRA
        //Método para girar a imagem da moeda
        async Task Animation(Image Mao)
        {
            while (true)
            {
                // reseta a posição
                Mao.RotationY = 0;
                //Realiza um giro vertical em 360 graus 
                //com duranção de 500 milisegundos
                await Mao.RotateYTo(360, 5000);
            }
        }

        //Método para atualizar a lista com base no bd
        void AtualizarLista()
        {
            lsvLista.ItemsSource =
                _connection.Table<Jogada>().ToList();
        }

        //Método Reset
        void Reset()
        {
            _pontuacaoAtual = 10;
            _rodadaAtual = 0;
            _pontos = 2;

            txtJogador.Text = string.Empty;
            lblResultadoMao.Text = "";
            lblResultadoJogada.Text = "";
            lblPontuacao.Text = _pontuacaoAtual.ToString();

            ckbPedra.IsChecked = true;
        }

        //Método JogarMao
        int JogarMao()
        {
            //Utilizando o tipo de dado Randon
            //para sorte um valor entre 1 e 3
            Random moeda = new Random();
            //Retorno o resultado convertido para bool
            //0: Pedra
            //1: Papel
            //2: Tesoura
            return moeda.Next(0, 3);
        }

        //Método salvar
        Jogada Salvar(
            string Nome, int Aposta, int Resultado, int Pontuacao)
        {
            Jogada jogada = new Jogada();

            jogada.Jogador = Nome;
            //Grava a data e hora atual
            jogada.DtHora = DateTime.Now;
            jogada.Aposta = Aposta;
            jogada.Resultado = Resultado;
            jogada.Pontuacao = Pontuacao;

            //Insere no banco de dados
            _connection.Insert(jogada);
            //Atualizamos a ListView
            AtualizarLista();
            //Retorna o objeto
            return jogada;
        }

        //Método ExibirResultado
        void ExibirResultado(Jogada RJogada)
        {
            lblResultadoMao.Text = RJogada.ResultadoMao;
            lblResultadoJogada.Text = RJogada.ResultadoJogada;
            lblPontuacao.Text = RJogada.Pontuacao.ToString();

            lblResultadoJogada.TextColor =
                RJogada.ResultadoAposta ? Colors.Green : Colors.Red;
        }

        //Método para calcular os pontos
        int GetPontos()
        {
            //Calcula a quantidade de ciclos
            //a cada 4 rodadas
            int ciclosCompletos = (_rodadaAtual - 1) / 4;

            return _pontos + (ciclosCompletos * 2);
        }

        //Método Jogar
        void Jogar(string Jogador, int Aposta)
        {
            //Iniciamos jogando a moeda
            int resultado = JogarMao();


            if (Aposta == resultado)
                _pontuacaoAtual += _pontos;
            else
                _pontuacaoAtual -= _pontos;

            //Salvamos os dados e recuperamos o objeto
            var jogada =
                Salvar(Jogador, Aposta, resultado, _pontuacaoAtual);

            //Atualizo a exibição do resultado
            ExibirResultado(jogada);
        }
    }
}
