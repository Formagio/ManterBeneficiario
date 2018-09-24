using ManterBeneficiario.Model;

namespace ManterBeneficiario.Builder
{
    public class BeneficiarioBuilder
    {
        private readonly BeneficiarioModel _beneficiarioModel;

        public BeneficiarioBuilder()
        {
            _beneficiarioModel = new BeneficiarioModel();
        }

        public BeneficiarioBuilder(BeneficiarioModel beneficiarioModel)
        {
            _beneficiarioModel = beneficiarioModel;
        }

        public BeneficiarioBuilder ComIdentificador(long identificador)
        {
            _beneficiarioModel.Identificador = identificador;
            return this;
        }

        public BeneficiarioBuilder ComNomeCompleto(string nomeCompleto)
        {
            _beneficiarioModel.NomeCompleto = nomeCompleto;
            return this;
        }

        public BeneficiarioBuilder ComCpf(string cpf)
        {
            _beneficiarioModel.Cpf = cpf;
            return this;
        }

        public BeneficiarioBuilder ComRg(string rg)
        {
            _beneficiarioModel.Rg = rg;
            return this;
        }
        
        public BeneficiarioBuilder ComEmail(string email)
        {
            _beneficiarioModel.Email = email;
            return this;
        }

        public BeneficiarioBuilder ComTelefone(string telefone)
        {
            _beneficiarioModel.Telefone = telefone;
            return this;
        }

        public BeneficiarioBuilder ComEstaRemovido(bool estaRemovido)
        {
            _beneficiarioModel.EstaRemovido = estaRemovido;
            return this;
        }

        public BeneficiarioModel Build()
        {
            return _beneficiarioModel;
        }
    }
}
