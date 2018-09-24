using ManterBeneficiario.Exception;
using ManterBeneficiario.Model;
using System.Collections.Generic;
using System.Linq;

namespace ManterBeneficiario.PersistenciaValidator
{
    public class BeneficiarioPersistenciaValidador
    {
        private readonly List<BeneficiarioModel> _beneficiarios;

        public BeneficiarioPersistenciaValidador(List<BeneficiarioModel> beneficiarios)
        {
            _beneficiarios = beneficiarios;
        }

        public void ValidarAoAdicionar(BeneficiarioModel beneficiarioModel)
        {
            if (_beneficiarios.Any(b =>
                b.NumeroBeneficiario == beneficiarioModel.NumeroBeneficiario ||
                b.Cpf == beneficiarioModel.Cpf ||
                b.Rg == beneficiarioModel.Rg))
            {
                throw new BeneficiarioJaExistenteException();
            }
        }

        public void ValidarAoEditar(BeneficiarioModel beneficiarioModel)
        {
            if (!ExisteNumeroBeneficiario(beneficiarioModel.NumeroBeneficiario))
            {
                throw new BeneficiarioNaoEncontradoException();
            }
        }

        public void ValidarAoRemover(long numeroBeneficiario)
        {            
            if (!ExisteNumeroBeneficiario(numeroBeneficiario))
            {
                throw new BeneficiarioNaoEncontradoException();
            }
        }

        private bool ExisteNumeroBeneficiario(long numeroBeneficiario)
        {
            var beneficiarioIndex = _beneficiarios.FindIndex(b =>
                b.NumeroBeneficiario == numeroBeneficiario);

            return beneficiarioIndex >= 0;
        }
    }
}
