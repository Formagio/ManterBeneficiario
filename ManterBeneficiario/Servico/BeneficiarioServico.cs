using ManterBeneficiario.Exception;
using ManterBeneficiario.Model;
using ManterBeneficiario.Persistencia;
using System.Collections.Generic;

namespace ManterBeneficiario.Servico
{
    public class BeneficiarioServico
    {
        private readonly BeneficiarioPersistencia _beneficiarioPersistencia;

        public BeneficiarioServico()
        {
            _beneficiarioPersistencia = new BeneficiarioPersistencia();
        }

        public void AdicionarBeneficiario(BeneficiarioModel beneficiario)
        {
            try
            {
                _beneficiarioPersistencia.AdicionarBeneficiario(beneficiario);
            }
            catch (BeneficiarioJaExistenteException)
            {
            }
        }

        public void EditarBeneficiario(BeneficiarioModel beneficiario)
        {
            try
            {
                _beneficiarioPersistencia.EditarBeneficiario(beneficiario);
            }
            catch (BeneficiarioNaoEncontradoException)
            {
            }
        }

        public List<BeneficiarioModel> ListarBeneficiariosAtivos()
        {
            return _beneficiarioPersistencia.ListarBeneficiariosAtivos();
        }

        public void RemoverBeneficiario(long numeroBeneficiario)
        {
            try
            {
                _beneficiarioPersistencia.RemoverBeneficiario(numeroBeneficiario);
            }
            catch (BeneficiarioNaoEncontradoException)
            {
            }
        }
    }
}
