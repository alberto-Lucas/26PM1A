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
            string usuario = txtUsuario.Text;
            string senha = txtSenha.Text;

            if (usuario == "admin" && senha == "admin")
                Application.Current.MainPage.
                    Navigation.PushAsync(new pgPrincipal());
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
    }
}
