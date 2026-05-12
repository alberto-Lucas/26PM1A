using SQLite;

namespace AppJoKenPo
{
    public class Jogada
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Jogador { get; set; }
        public DateTime DtHora { get; set; }
        //0: Pedra
        //1: Papel
        //2: Tesoura
        public int Aposta { get; set; }
        public int Resultado { get; set; }
        public int Pontuacao { get; set; }

        [Ignore] //Usado para não vincular ao banco de dados
        public string MaoAposta
        {
            get
            {
                return GetStringMao(Aposta);
            }
        }

        [Ignore]
        public string ResultadoMao
        {
            get
            {
                return GetStringMao(Resultado);
            }
        }

        [Ignore]
        public bool ResultadoAposta
        {
            get
            {
                return Aposta == Resultado;
            }
        }

        [Ignore]
        public string ResultadoJogada
        {
            get
            {
                //If ternario para retorna a conversão do campo ResultadoAposta 
                return ResultadoAposta ? "Ganhou" : "Perdeu";
            }
        }

        //Método para converte numero em Mão
        string GetStringMao(int Mao)
        {
            string mao;

            switch (Mao)
            {
                case 0: mao = "Pedra"; break;
                case 1: mao = "Papel"; break;
                case 2: mao = "Tesoura"; break;
                default: mao = "Desconhecido"; break;
            }

            return mao;
        }
    }
}
