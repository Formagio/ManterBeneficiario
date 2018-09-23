namespace ManterBeneficiario.Model
{
    public class BeneficiarioModel
    {
        public string NomeCompleto { get; set; }
        public string Cpf { get; set; }
        public string Rg { get; set; }
        public string Email { get; set; }
        public string NumeroTelefone { get; set; }
        public long NumeroBeneficiario { get; set; }
        public bool EstaRemovido { get; set; }
    }
}
