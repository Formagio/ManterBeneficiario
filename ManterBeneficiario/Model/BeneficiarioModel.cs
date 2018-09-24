using ManterBeneficiario.Exception;

namespace ManterBeneficiario.Model
{
    public class BeneficiarioModel
    {
        public long Identificador { get; set; }
        public string NomeCompleto { get; set; }
        public string Cpf { get; set; }
        public string Rg { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }        
        public bool EstaRemovido { get; set; }

        public void ValidarModel()
        {
            if (string.IsNullOrEmpty(NomeCompleto) ||
                string.IsNullOrEmpty(Cpf) ||
                string.IsNullOrEmpty(Rg) ||
                string.IsNullOrEmpty(Telefone))
            {
                throw new BeneficiarioInvalidoException();
            }
        }
    }
}
