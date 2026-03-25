namespace AppLogin
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void btnEntrar_Clicked(object sender, EventArgs e)
        {
            //o Trim() é usado par remover caracteres
            //vazio do inicio e do final da string
            string usuario = txtUsuario.Text;
            string senha = txtSenha.Text;

            //nescessario vaidar se os campos estão preenchidos

            if (string.IsNullOrEmpty(usuario) ||
                string.IsNullOrEmpty(senha))
            { 
                DisplayAlert(
                    "Atenção!",
                    "Preencha os dados de login.",
                    "Ok");
                return;
            }

            //chamada da classe singleton de cadastro
            var cadastroSingleton = CadastroSingleton.Instancia;

            if (usuario == cadastroSingleton.Login && 
                senha == cadastroSingleton.Senha)
            {
                //Com usuário e senha corretos
                //Podemos adicionar o login
                //na classe singleton

                //Criar a variavel para acesso a singleton
                //var significar uma variavel do tipo variant
                //ou seja é uma variavel coringa
                //ela sera do tipo de dados atribuido a ela
                //resumindo, se receber um tipo de dado int
                //ela se torna int, se string, se torna string
                //e assim por diante

                //Iremos atribuir a instancia da singleton
                //a variavel
                var usuarioLogado = UsuarioLogado.Instancia;

                //atribuir os valores aos atributos
                //da classe sigleton
                usuarioLogado.Login = cadastroSingleton.Login;
                usuarioLogado.Nome = cadastroSingleton.Nome;

                Application.Current.MainPage.
                    Navigation.PushAsync(new pgPrincipal());
            }
            else
                //Similar ao MessageBox
                //Titulo
                //Texto
                //Botão
                DisplayAlert(
                    "Atenção!",
                    "Usuário ou Senha inválidos.",
                    "Ok");
        }

        private void ckbMostrarSenha_Checked(object sender, CheckedChangedEventArgs e)
        {
            //A propriedade de ocultas senha
            //será alterada de acordo com a 
            //marcação do check box

            txtSenha.IsPassword = 
                !ckbMostrarSenha.IsChecked;
        }

        private void lblMostrarSenha_Tapped(object sender, TappedEventArgs e)
        {
            ckbMostrarSenha.IsChecked =
                !ckbMostrarSenha.IsChecked;

        }

        private void lblCadastro_Tapped(object sender, TappedEventArgs e)
        {
            Application.Current.MainPage.
                Navigation.PushAsync(new pgCadastro());
        }
    }
}
