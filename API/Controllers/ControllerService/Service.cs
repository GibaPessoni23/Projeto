using Model.BusinessModel;
using Model.BusinessViewModel;
using System;
using System.Configuration;

namespace API.Controllers.ControllerService
{
    public class Service:IService
    {
        DataBaseContext.DataBaseContext data = null;

        
        string conn = ConfigurationManager.ConnectionStrings["gti_solution_sistema_cliente"].ConnectionString;
        public Service()
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

        public System.Collections.Generic.List<BusinessViewListModel> listarTodosClientes()
        {
            return data.listarTodosClientes();
        }

        public void RegistrarCliente(TB_CLIENTE tb_Cliente_Objeto_DTO, TB_CLIENTE_DOCUMENTO tB_CLIENTE_DOCUMENTO_DTO, TB_CLIENTE_ENDERECO tB_CLIENTE_ENDERECO_DTO)
        {
            data.RegistrarCliente(tb_Cliente_Objeto_DTO, tB_CLIENTE_DOCUMENTO_DTO, tB_CLIENTE_ENDERECO_DTO);
        }
    }
}