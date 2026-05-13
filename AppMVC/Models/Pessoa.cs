using SQLite;
using System.ComponentModel.DataAnnotations;

namespace AppMVC.Models
{
    //Importar o using SQLite;

    //Deixar a classe publica
    public class Pessoa
    {
        //Definir os atributos do classe
        //Lembrando que seram refletidos
        //para a criação da tabela no BD

        //Precisamos definir o identificador
        //da tabela ou seja o id chave primaria
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        //Local onde a imagem a ser carregada está
        public string DirImagem { get; set; }
    }
}
