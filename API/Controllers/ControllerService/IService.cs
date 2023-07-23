using Model.BusinessModel;
using Model.BusinessViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace API.Controllers.ControllerService
{
    [ServiceContract]
    interface IService
    {
        [OperationContract]
        void RegistrarCliente(TB_CLIENTE tb_Cliente_Objeto_DTO, TB_CLIENTE_DOCUMENTO tB_CLIENTE_DOCUMENTO_DTO,
           TB_CLIENTE_ENDERECO tB_CLIENTE_ENDERECO_DTO);

        [OperationContract]
        void ExcluirCliente(int id_Cliente);

        [OperationContract]
        void EditarCliente(TB_CLIENTE tb_Cliente_Objeto_DTO, TB_CLIENTE_DOCUMENTO tB_CLIENTE_DOCUMENTO_DTO,
            TB_CLIENTE_ENDERECO tB_CLIENTE_ENDERECO_DTO);

        [OperationContract]
        BusinessViewModel DetalharCliente(int id_cliente);

        [OperationContract]
        List<BusinessViewListModel> listarTodosClientes();
    }
}
