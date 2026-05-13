using SQLite;
using PCLExt.FileStorage.Folders;

namespace AppMVC.Services
{
    //Importar using SQLite;
    //Importar using PCLExt.FileStorage.Folders;

    //Deixar a classe publica
    public class DatabaseService
    {
        //Método que retorna a conexão com o banco
        public SQLiteConnection GetConnection()
        {
            //Acessar a pasta raiz da aplicação
            var pasta = new LocalRootFolder();

            //Gerenciamento do arquivo do BD
            var arquivo =
                pasta.CreateFile("appmvc",
                    PCLExt.FileStorage.CreationCollisionOption.
                        OpenIfExists);

            //Retornar a conexão com o arquivo
            return new SQLiteConnection(arquivo.Path);
        }
    }
}
