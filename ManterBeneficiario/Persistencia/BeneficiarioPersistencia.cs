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

        public void AdicionarBeneficiario(BeneficiarioModel beneficiarioModel)
        {
            _beneficiarioPersistenciaValidator.ValidarAoAdicionar(beneficiarioModel);
            _beneficiarios.Add(beneficiarioModel);
        }

        public void EditarBeneficiario(BeneficiarioModel beneficiarioModel)
        {
            _beneficiarioPersistenciaValidator.ValidarAoEditar(beneficiarioModel);
            _beneficiarios[LocalizarIndice(beneficiarioModel.Identificador)] = beneficiarioModel;
        }

        public List<BeneficiarioModel> ListarBeneficiariosAtivos()
        {
            return _beneficiarios.Where(b => !b.EstaRemovido).ToList();
        }

        public void RemoverBeneficiario(long beneficiarioIdentificador)
        {
            _beneficiarioPersistenciaValidator.ValidarAoRemover(beneficiarioIdentificador);
            _beneficiarios[LocalizarIndice(beneficiarioIdentificador)].EstaRemovido = true;
        }

        private int LocalizarIndice(long beneficiarioIdentificador)
        {
            return _beneficiarios.FindIndex(b =>
                b.Identificador == beneficiarioIdentificador);
        }
    }
}