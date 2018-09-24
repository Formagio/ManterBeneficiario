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
            if (ExisteBeneficiario(beneficiarioModel.Identificador, 
                beneficiarioModel.Cpf, beneficiarioModel.Rg))
            {
                throw new BeneficiarioJaExistenteException();
            }
        }

        public void ValidarAoEditar(BeneficiarioModel beneficiarioModel)
        {
            if (!ExisteBeneficiario(beneficiarioModel.Identificador))
            {
                throw new BeneficiarioNaoEncontradoException();
            }
        }

        public void ValidarAoRemover(long beneficiarioIdentificador)
        {            
            if (!ExisteBeneficiario(beneficiarioIdentificador))
            {
                throw new BeneficiarioNaoEncontradoException();
            }
        }

        private bool ExisteBeneficiario(long beneficiarioIdentificador)
        {
            var beneficiarioIndex = _beneficiarios.FindIndex(b =>
                b.Identificador == beneficiarioIdentificador);

            return beneficiarioIndex >= 0;
        }

        private bool ExisteBeneficiario(long beneficiarioIdentificador, 
            string beneficiarioCpf, string beneficiarioRg)
        {
            return _beneficiarios.Any(b =>
                b.Identificador == beneficiarioIdentificador ||
                b.Cpf == beneficiarioCpf ||
                b.Rg == beneficiarioRg);
        }
    }
}
