using Model.BusinessModel;
using Model.BusinessViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WCFServiceContract
{
    // OBSERVAÇÃO: Você pode usar o comando "Renomear" no menu "Refatorar" para alterar o nome da classe "Service1" no arquivo de código, svc e configuração ao mesmo tempo.
    // OBSERVAÇÃO: Para iniciar o cliente de teste do WCF para testar esse serviço, selecione Service1.svc ou Service1.svc.cs no Gerenciador de Soluções e inicie a depuração.
    public class Service1 : IService1
    {
        DataBaseContext.DataBaseContext data = null;


        string conn = ConfigurationManager.ConnectionStrings["gti_solution_sistema_cliente"].ConnectionString;
        public Service1()
        {
            data = new DataBaseContext.DataBaseContext(conn);
        }
        public BusinessViewModel DetalharCliente(int id_cliente)
        {
            return data.DetalharCliente(id_cliente);
        }

        public void EditarCliente(TB_CLIENTE tb_Cliente_Objeto_DTO, TB_CLIENTE_DOCUMENTO tB_CLIENTE_DOCUMENTO_DTO, TB_CLIENTE_ENDERECO tB_CLIENTE_ENDERECO_DTO)
        {
            data.EditarCliente(tb_Cliente_Objeto_DTO, tB_CLIENTE_DOCUMENTO_DTO, tB_CLIENTE_ENDERECO_DTO);
        }

        public void ExcluirCliente(int id_Cliente)
        {
               data.ExcluirCliente(id_Cliente);
        }

        public List<BusinessViewListModel> listarTodosClientes()
        {
            return data.listarTodosClientes();
        }

        public void RegistrarCliente(TB_CLIENTE tb_Cliente_Objeto_DTO, TB_CLIENTE_DOCUMENTO tB_CLIENTE_DOCUMENTO_DTO, TB_CLIENTE_ENDERECO tB_CLIENTE_ENDERECO_DTO)
        {
            data.RegistrarCliente(tb_Cliente_Objeto_DTO, tB_CLIENTE_DOCUMENTO_DTO, tB_CLIENTE_ENDERECO_DTO);
        }
    }
}
