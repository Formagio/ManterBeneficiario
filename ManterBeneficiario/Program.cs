using ManterBeneficiario.Builder;
using ManterBeneficiario.Controller;
using System;

namespace ManterBeneficiario
{
    public class Program
    {
        private static BeneficiarioController _beneficiarioController = new BeneficiarioController();
        
        /// <summary>
        /// O método main irá simular o disparo de eventos de clique do usuário
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            Console.WriteLine("Usuário clicou em 'Adicionar Beneficiário'");
            AdicionarBeneficiario();

            Console.WriteLine("\nUsuário clicou em 'Editar Beneficiário'");
            EditarBeneficiario();

            Console.WriteLine("\nUsuário clicou em 'Listar Beneficiários Ativos'");
            ListarBeneficiariosAtivos();

            Console.WriteLine("\nUsuário clicou em 'Remover Beneficiário'");
            RemoverBeneficiario();

            Console.Read();
        }

        private static void AdicionarBeneficiario()
        {
            Console.WriteLine("Adicionando beneficiário..");

            var beneficiarioModel = new BeneficiarioBuilder()
                .ComIdentificador(1)
                .ComNomeCompleto("Carlos Magno")
                .ComCpf("001.001.001-01")
                .ComRg("01010101")
                .ComEmail("email@email.com")
                .ComTelefone("(55)51999999999")                
                .ComEstaRemovido(false)
                .Build();            

            _beneficiarioController.OnAdicionarBeneficiario(beneficiarioModel);

            Console.WriteLine("Beneficiário adicionado");
        }

        private static void EditarBeneficiario()
        {
            Console.WriteLine("Editando beneficiário..");

            var beneficiarioModel = new BeneficiarioBuilder()
                .ComIdentificador(1)
                .ComNomeCompleto("Carlos Magno")
                .ComCpf("001.001.001-01")
                .ComRg("01010101")
                .ComEmail("email@email.com")
                .ComTelefone("(55)51988888888")                
                .ComEstaRemovido(false)
                .Build();

            _beneficiarioController.OnEditarBeneficiario(beneficiarioModel);

            Console.WriteLine("Beneficiário editado");
        }

        private static void ListarBeneficiariosAtivos()
        {
            Console.WriteLine("Listando beneficiários ativos..");

            _beneficiarioController.OnListarBeneficiariosAtivos().ForEach(beneficiario =>
            {
                Console.WriteLine($"Número: {beneficiario.Identificador}, Nome completo: {beneficiario.NomeCompleto}, Ativo: {!beneficiario.EstaRemovido}");
            });
        }

        private static void RemoverBeneficiario()
        {
            Console.WriteLine("Removendo beneficiário..");

            _beneficiarioController.OnRemoverBeneficiario(1);

            Console.WriteLine("Beneficiário removido");
        }
    }
}
