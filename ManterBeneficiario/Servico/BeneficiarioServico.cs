﻿using ManterBeneficiario.Model;
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
            beneficiario.ValidarModel();               
            _beneficiarioPersistencia.AdicionarBeneficiario(beneficiario);
        }

        public void EditarBeneficiario(BeneficiarioModel beneficiario)
        {
            beneficiario.ValidarModel();
            _beneficiarioPersistencia.EditarBeneficiario(beneficiario);
        }

        public List<BeneficiarioModel> ListarBeneficiariosAtivos()
        {
            return _beneficiarioPersistencia.ListarBeneficiariosAtivos();
        }

        public void RemoverBeneficiario(long numeroBeneficiario)
        {
            _beneficiarioPersistencia.RemoverBeneficiario(numeroBeneficiario);
        }
    }
}
