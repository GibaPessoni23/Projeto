using DataBaseContext;
using Model.BusinessModel;
using Model.BusinessViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace WCFServiceContract.ServiceContract
{
    public class ServiceCliente : InterfaceServiceContract.IClienteService
    {

        DataBaseContext.DataBaseContext data = null;


        string conn = ConfigurationManager.ConnectionStrings["gti_solution_sistema_cliente"].ConnectionString;
        public ServiceCliente()
        {
            data = new DataBaseContext.DataBaseContext(conn);
        }
        public BusinessViewModel DetalharCliente(int id_cliente)
        {
            throw new NotImplementedException();
        }

        public void EditarCliente(TB_CLIENTE tb_Cliente_Objeto_DTO, TB_CLIENTE_DOCUMENTO tB_CLIENTE_DOCUMENTO_DTO, TB_CLIENTE_ENDERECO tB_CLIENTE_ENDERECO_DTO)
        {
            throw new NotImplementedException();
        }

        public void ExcluirCliente(int id_Cliente)
        {
            throw new NotImplementedException();
        }

        public List<BusinessViewListModel> listarTodosClientes()
        {
            throw new NotImplementedException();
        }

        public void RegistrarCliente(TB_CLIENTE tb_Cliente_Objeto_DTO, TB_CLIENTE_DOCUMENTO tB_CLIENTE_DOCUMENTO_DTO, TB_CLIENTE_ENDERECO tB_CLIENTE_ENDERECO_DTO)
        {
            throw new NotImplementedException();
        }
    }
}