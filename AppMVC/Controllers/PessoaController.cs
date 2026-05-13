using SQLite;
using AppMVC.Models;
using AppMVC.Services;

namespace AppMVC.Controllers
{
    //Importar using SQLite;
    //Importar a camada de Service
    //Importar a camada Model

    //Deixar a classe publica
    public class PessoaController
    {
        //Criar as variaveis globais para uso na classe
        //Variavel para a camada de serviço
        //Variavel para conexão com o BD

        //OBS: o uso do underline _ indica que a variavel é privada
        DatabaseService _database;
        SQLiteConnection _connection;

        //Criar o método construtor da classe
        //que é o metodo a ser executado automaticamente
        //quando a classe for instanciada
        public PessoaController()
        {
            //Intanciar a camada de serviço
            _database = new DatabaseService();

            //Recuperar a conexão com o BD
            _connection = _database.GetConnection();

            //Mapear a tabela do BD com base na classe Model
            //o método CreateTable possui tanto a função
            //de criar (Create Table) quanto a função de 
            //atualizar (Alter Table) ou seja, sempre que mapear
            //ira criar ou alterar o banco de acordo com o objeto
            _connection.CreateTable<Pessoa>();
        }

        //Criar o métodos de manipulação Insert, Update e Delete
        //Os métodos de manipulação serão do tipo
        //boolean pois será retornada a execução com sucesso ou não
        //e sempre recebera o objeto como parametro
        public bool Insert(Pessoa value)
        {
            //Como iremos inserir um objeto por vez
            //teremos apenas 2 status
            //0 - Nenhuma linha afetada
            //1 - uma linha afetada
            return _connection.Insert(value) > 0;
        }

        public bool Update(Pessoa value)
        {
            return _connection.Update(value) > 0;
        }

        public bool Delete(Pessoa value)
        {
            return _connection.Delete(value) > 0;
        }

        //Métodos de Consulta
        //Ou seja os SELECT'S no banco de dados
        public Pessoa GetById(int value)
        {
            //Semelhante ao 
            //SELECT * FROM Pessoa WHERE id = value

            //Pelo ID ser a chave primaria da tabela
            //podemos usar o método Find q pesquisa
            //exclusivamente na coluna de PK
            return _connection.Find<Pessoa>(value);

            //Um alternativa é o filtro usando lambda
            //_connection.Table<Pessoa>().
            //    Where(x => x.Id == value).ToList();
        }

        //Método de Consulta por Nome
        public List<Pessoa> GetByName(string value)
        {
            //SELECT * FROM Pessoa
            //WHERE Nome LIKE '%value%'

            //Usaremos o método Where para aplicar o filtro
            //Passar registro a registro
            //procurando a coluna desejada com o valor procurado
            //o x será o registro atual
            //o => é o lambda que ira converter o registro em objeto
            return _connection.Table<Pessoa>().
                    Where(x => x.Nome.Contains(value)).ToList();            
        }

        //Método para consular todos
        public List<Pessoa> GetAll()
        {
            //SELECT * FROM Pessoa
            return _connection.Table<Pessoa>().ToList();
        }
    }
}
