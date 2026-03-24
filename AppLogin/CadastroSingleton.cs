namespace AppLogin
{
    public sealed class CadastroSingleton
    {
        static CadastroSingleton _instancia;

        public static CadastroSingleton Instancia
        {
            get
            {
                return _instancia ??
                    (_instancia = new CadastroSingleton());
            }
        }

        public CadastroSingleton() {}

        //Atributos do cadastro
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public string DtNascimento { get; set; }
    }
}
