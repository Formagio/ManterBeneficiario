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
                b.Identificador == beneficiarioModel.Identificador ||
                b.Cpf == beneficiarioModel.Cpf ||
                b.Rg == beneficiarioModel.Rg))
            {
                throw new BeneficiarioJaExistenteException();
            }
        }

        public void ValidarAoEditar(BeneficiarioModel beneficiarioModel)
        {
            if (!ExisteBeneficiarioIdentificador(beneficiarioModel.Identificador))
            {
                throw new BeneficiarioNaoEncontradoException();
            }
        }

        public void ValidarAoRemover(long beneficiarioIdentificador)
        {            
            if (!ExisteBeneficiarioIdentificador(beneficiarioIdentificador))
            {
                throw new BeneficiarioNaoEncontradoException();
            }
        }

        private bool ExisteBeneficiarioIdentificador(long beneficiarioIdentificador)
        {
            var beneficiarioIndex = _beneficiarios.FindIndex(b =>
                b.Identificador == beneficiarioIdentificador);

            return beneficiarioIndex >= 0;
        }
    }
}
