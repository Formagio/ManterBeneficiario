using ManterBeneficiario.Model;

namespace ManterBeneficiario.Builder
{
    public class BeneficiarioBuilder
    {
        private readonly BeneficiarioModel _beneficiario;

        public BeneficiarioBuilder()
        {
            _beneficiario = new BeneficiarioModel();
        }

        public BeneficiarioBuilder(BeneficiarioModel beneficiario)
        {
            _beneficiario = beneficiario;
        }

        public BeneficiarioBuilder ComNomeCompleto(string nomeCompleto)
        {
            _beneficiario.NomeCompleto = nomeCompleto;
            return this;
        }

        public BeneficiarioBuilder ComCpf(string cpf)
        {
            _beneficiario.Cpf = cpf;
            return this;
        }

        public BeneficiarioBuilder ComRg(string rg)
        {
            _beneficiario.Rg = rg;
            return this;
        }
        
        public BeneficiarioBuilder ComEmail(string email)
        {
            _beneficiario.Email = email;
            return this;
        }

        public BeneficiarioBuilder ComNumeroTelefone(string numeroTelefone)
        {
            _beneficiario.NumeroTelefone = numeroTelefone;
            return this;
        }

        public BeneficiarioBuilder ComNumeroBeneficiario(long numeroBeneficiario)
        {
            _beneficiario.NumeroBeneficiario = numeroBeneficiario;
            return this;
        }

        public BeneficiarioBuilder ComEstaRemovido(bool estaRemovido)
        {
            _beneficiario.EstaRemovido = estaRemovido;
            return this;
        }

        public BeneficiarioModel Build()
        {
            return _beneficiario;
        }
    }
}
