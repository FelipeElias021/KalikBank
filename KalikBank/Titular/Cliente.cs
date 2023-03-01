namespace KalikBank.Titular
{
    public class Cliente
    {
        private static int _totalClientes { get; set; }
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }
        public string Email { get; set; }
        public string Cpf { get; set; }
        public string Profissao { get; set; }

        public Cliente(string nome, string cpf, string profissao)
        {
            Nome = nome;
            Cpf = cpf;
            Profissao = profissao;
            Id = ++_totalClientes;
        }
    }
}
