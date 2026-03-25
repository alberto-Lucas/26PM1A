namespace AppLogin
{
    //Teremos aqui uma classe Singleton
    //Responsavel por armazenar os dados
    //utilizados durante o login

    //Uma classe Singleton é uma classe
    //de uma unica instancia
    //portanto eu não consigo instanciar
    //ou criar novos objetos dessa classe
    //sempre irei utilizar a instancia 
    //criada automaticamente
    //por tanto os dados nela armazenados
    //podem ser recuperados e alterados de 
    //qualquer parte do código

    //Para transformar a classe em singleton
    //é preciso adicionar o termo sealed
    //que significa selada
    public sealed class UsuarioLogado
    {
        //Para o funcionamento é preciso 
        //criar uma variavel para armazenar 
        //a instancia
        //e sempre que ela for usado ira utilizar
        //a instancia dessa variavel

        //Variavel estatica que vai apontar a instancia
        //Estatica pois ela sera acessivel de fora da fora
        //da classe, porém não podera ser modificada

        //uso de _ é para identificar variaveis do tipo private
        static UsuarioLogado _instancia;

        //O método para gerenciamento da instancia
        //Ou seja ao executar a aplicação a instancia
        //será criada automaticamente
        //e quando a classe for usada, ira retorna essa
        //instancia ja criada
        
        public static UsuarioLogado Instancia
        {
            //iremos utilizar um get
            //para retornar a instancia
            get
            {
                //retornar o apontamento da instancia
                //em memoria
                //se não existir (primeira execução)
                //se criada uma nova, caso exista
                //a mesma sera retornada
                //uso ?? para validar se a variavel esta null
                return _instancia ??
                    (_instancia = new UsuarioLogado());
            }
        }
        //Construtor da classe
        public UsuarioLogado() { }

        //Daqui pra cima é documentação
        //é igual para todas as classes singleton
        //Daqui pra baixo é a persinalização de cada classe
        //ou seja o dado q ela ira armazenar

        //As propriedades que são os atributos
        //prop e presciona tab
        public string Login { get; set; }
        public string Nome { get; set; }

        //Posso definir quantos atributos
        //forem nescessarios

    }
}
