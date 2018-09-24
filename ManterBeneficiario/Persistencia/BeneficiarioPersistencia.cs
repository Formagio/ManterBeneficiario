using ManterBeneficiario.Model;
using ManterBeneficiario.PersistenciaValidator;
using System.Collections.Generic;
using System.Linq;

namespace ManterBeneficiario.Persistencia
{
    public class BeneficiarioPersistencia
    {
        // Este conjunto estático faz o papel do banco de dados em memória
        private static readonly List<BeneficiarioModel> _beneficiarios = new List<BeneficiarioModel>();
        private readonly BeneficiarioPersistenciaValidador _beneficiarioPersistenciaValidator;

        public BeneficiarioPersistencia()
        {
            _beneficiarioPersistenciaValidator = new BeneficiarioPersistenciaValidador(_beneficiarios);
        }

        public void AdicionarBeneficiario(BeneficiarioModel beneficiario)
        {
            _beneficiarioPersistenciaValidator.ValidarAoAdicionar(beneficiario);
            _beneficiarios.Add(beneficiario);
        }

        public void EditarBeneficiario(BeneficiarioModel beneficiario)
        {
            _beneficiarioPersistenciaValidator.ValidarAoEditar(beneficiario);
            _beneficiarios[LocalizarIndice(beneficiario.NumeroBeneficiario)] = beneficiario;
        }

        public List<BeneficiarioModel> ListarBeneficiariosAtivos()
        {
            return _beneficiarios.Where(b => !b.EstaRemovido).ToList();
        }

        public void RemoverBeneficiario(long numeroBeneficiario)
        {
            _beneficiarioPersistenciaValidator.ValidarAoRemover(numeroBeneficiario);
            _beneficiarios[LocalizarIndice(numeroBeneficiario)].EstaRemovido = true;
        }

        private int LocalizarIndice(long numeroBeneficiario)
        {
            return _beneficiarios.FindIndex(b =>
                b.NumeroBeneficiario == numeroBeneficiario);
        }
    }
}