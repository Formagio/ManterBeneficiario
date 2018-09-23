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

        public void OnAdicionarBeneficiario(BeneficiarioModel beneficiario)
        {
            _beneficiarioServico.AdicionarBeneficiario(beneficiario);
        }

        public void OnEditarBeneficiario(BeneficiarioModel beneficiario)
        {
            _beneficiarioServico.EditarBeneficiario(beneficiario);
        }

        public List<BeneficiarioModel> OnListarBeneficiariosAtivos()
        {
            return _beneficiarioServico.ListarBeneficiariosAtivos();
        }

        public void OnRemoverBeneficiario(long numeroBeneficiario)
        {
            _beneficiarioServico.RemoverBeneficiario(numeroBeneficiario);
        }        
    }
}
