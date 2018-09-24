using ManterBeneficiario.Model;
using ManterBeneficiario.Servico;
using System.Collections.Generic;

namespace ManterBeneficiario.Controller
{
    public class BeneficiarioController
    {
        private readonly BeneficiarioServico _beneficiarioServico;

        public BeneficiarioController()
        {
            _beneficiarioServico = new BeneficiarioServico();
        }

        public void OnAdicionarBeneficiario(BeneficiarioModel beneficiarioModel)
        {
            _beneficiarioServico.AdicionarBeneficiario(beneficiarioModel);
        }

        public void OnEditarBeneficiario(BeneficiarioModel beneficiarioModel)
        {
            _beneficiarioServico.EditarBeneficiario(beneficiarioModel);
        }

        public List<BeneficiarioModel> OnListarBeneficiariosAtivos()
        {
            return _beneficiarioServico.ListarBeneficiariosAtivos();
        }

        public void OnRemoverBeneficiario(long beneficiarioIdentificador)
        {
            _beneficiarioServico.RemoverBeneficiario(beneficiarioIdentificador);
        }        
    }
}
