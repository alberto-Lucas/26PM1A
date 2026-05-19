using System.Globalization;

namespace AppMVC.Services
{
    //Classe Estatica (static)
    //Não precisa de instancia
    //Ou seja não teremos um
    //ImageService img = new ImageService();
    //img.SelecionarImagem();
    //Realizar a chamada de maneira direta
    //ex: ImageService.SelecionarImagem();
    //Usar classe static somente para execução
    //de funções genericas sem armazenamento
    //de dados em memoria
    //Adicionar a palavra reservada static
    //Obrigatoriamente todos as funções devem 
    //tambem do tipo static
    public static class ImageService
    {
        //Função para selecionar e retornar o
        //diretorio da imagem selecionada, neste o 
        //diretorio de origem
        //Nesta rotina a tela de selação de imagem 
        //será carrega sobre a aplicação principal
        //e executada em segundo plano para que 
        //não trave o aplicativo principaç
        //para isso precisamos executa alem de forma
        //assincrona é preciso executar em segundo plano
        //usando TASK
        //ou seja, sera iniciado uma nova tarefa
        //para a selação da imagem
        //pois caso não seja dessa forma, o aplicativo 
        //ficaria travado até q a imagem seja selecionada
        //com isso o Android ou IOS poderia encerrar a aplicação
        //a famosa mensagem (Sua aplicação parou)
        //Usaremos o recurso TASK para executar em segundo plano
        //e como receberemos um retorno
        //precisaremos definir o tipo de dado q TASK ira retornar
        public static async Task<string> SelecionarImagem()
        {
            //Iniciamos definindo uma variavel default
            //para retorno do diretorio
            //Essa variavel iniciada vazio é importante
            //pois caso não tenha seleção, ou ocorra erro no processo
            //o retorno não fique null
            //pois ao retornar null em uma função com tipo de dado
            //pode gerar erro
            string diretorio = "";

            //Executar o componente de seleção de imagem
            //MediaPicker um componente de midi
            //Onde eu selecionar imagens ou videos
            //a execução ocorre de maneira especifica
            //para o tipo de midia definido
            //Pick = Selecionar
            //Capture = Tirar/Gravar
            var imgSelecionada =
                await MediaPicker.PickPhotoAsync();

            //Validar se o selecionado é valido
            //Ou se realmente foi selecionada algo
            //se existir uma seleção populamos a nossa variavel
            if (imgSelecionada != null)
                diretorio = imgSelecionada.FullPath;

            //Mesmo que o imgSelecionada for nullo
            //iremos retornar o valor default da variavel
            //no caso vazio ""
            //lembrando que vazio é diferente de null
            return diretorio;
        }

        //Função que ira realizar a copia da imagem
        //OU sej não usaremos a imagem original para salvar 
        //no cadastro, pois caso a mesma seja excluida ou alterada
        //pode impactar no aplicativo
        //para solucionar isso, iremos realizar uma copia da imagem
        //para dentro da pasta da aplicação
        public static string CopiarImagem(string dirOriginal)
        {
            //Iniciamos com a variavel default
            string dirDestino = "";

            //Validar se o diretorio original existe
            //Pois se não existir
            //não é possivel realizar a copia
            if (!string.IsNullOrEmpty(dirOriginal))
            {
                //Agora iremos montar o diretorio de destino
                //Pois criaremos uma pasta exclusive para as imagens
                //dentro a pasta da aplicação
                //Ex: C:\AppMVC\Imagens
                //O o diretorio da pasta da aplicação + o nome da Pasta
                //Usaremos o AppContext.BaseDirectory para recuperar
                //o diretorio da aplicação
                var dirPasta =
                    Path.Combine(AppContext.BaseDirectory, "Imagens");

                //Validar a existencia da pasta, pois em uma primeira
                //execução ela pode não existir
                //caso não exista iremos cria-la
                if (!Directory.Exists(dirPasta))
                    Directory.CreateDirectory(dirPasta);

                //Para a criação do novo diretorio
                //é preciso recuperar o nome da imagem selecionada
                //pois iremos reutilizar este nome
                //na imagem copiada
                //Recuperar o nome da imagem original usando o 
                //GetFileName
                string nomeOriginal = Path.GetFileName(dirOriginal);

                //Podemos montar o nome diretorio
                //Diretorio da Pasta + NomeOriginal
                //e sera o nosso diretorio de destino
                dirDestino = Path.Combine(dirPasta, nomeOriginal);

                //Agora sim podemos realizar a copia do arquivo
                //pois temos o diretorio original
                //e o diretorio de destino
                //para não gerar erro, iremos habilitar a opção
                //de sobrescrever o arquivo, caso o mesmo ja exista
                //ou seja, caso o usuario suba a mesma imagem porém modificada
                //File.Copy função para copia de arquivo
                File.Copy(dirOriginal, dirDestino, overwrite: true);
                //Aqui a copia ja foi feita e salva
            }
            //Basta retornar a variavel dirDestino
            return dirDestino;
        }
    }
}
