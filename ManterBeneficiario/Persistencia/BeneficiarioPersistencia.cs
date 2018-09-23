using ManterBeneficiario.Exception;
using ManterBeneficiario.Model;
using System.Collections.Generic;
using System.Linq;

namespace ManterBeneficiario.Persistencia
{
    public class BeneficiarioPersistencia
    {
        // Este conjunto estático faz o papel do banco de dados em memória
        private static readonly List<BeneficiarioModel> _beneficiarios = new List<BeneficiarioModel>();

        public void AdicionarBeneficiario(BeneficiarioModel beneficiario)
        {
            if (_beneficiarios.Any(b => 
                b.NumeroBeneficiario == beneficiario.NumeroBeneficiario ||
                b.Cpf == beneficiario.Cpf ||
                b.Rg == beneficiario.Rg))
            {
                throw new BeneficiarioJaExistenteException();
            }
                        
            _beneficiarios.Add(beneficiario);
        }

        public void EditarBeneficiario(BeneficiarioModel beneficiario)
        {
            var beneficiarioIndex = _beneficiarios.FindIndex(b => 
                b.NumeroBeneficiario == beneficiario.NumeroBeneficiario);

            if (beneficiarioIndex == -1)
            {
                throw new BeneficiarioNaoEncontradoException();
            }

            _beneficiarios[beneficiarioIndex] = beneficiario;
        }

        public List<BeneficiarioModel> ListarBeneficiariosAtivos()
        {
            return _beneficiarios.Where(b => !b.EstaRemovido).ToList();
        }

        public void RemoverBeneficiario(long numeroBeneficiario)
        {
            var beneficiarioIndex = _beneficiarios.FindIndex(b =>
                b.NumeroBeneficiario == numeroBeneficiario);

            if (beneficiarioIndex == -1)
            {
                throw new BeneficiarioNaoEncontradoException();
            }

            _beneficiarios[beneficiarioIndex].EstaRemovido = true;
        }
    }
}