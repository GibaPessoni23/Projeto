using Model.BusinessModel;
using Model.BusinessViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.InfrasctrcutureModel.Interface
{
    public interface IRepositoyGenericDB
    {
        void RegistrarCliente(TB_CLIENTE tb_Cliente_Objeto_DTO, TB_CLIENTE_DOCUMENTO tB_CLIENTE_DOCUMENTO_DTO,
            TB_CLIENTE_ENDERECO tB_CLIENTE_ENDERECO_DTO);
        BusinessViewModel.BusinessViewModel DetalharCliente(int id_cliente);
        void ExcluirCliente(int id_Cliente);
        void EditarCliente(TB_CLIENTE tb_Cliente_Objeto_DTO, TB_CLIENTE_DOCUMENTO tB_CLIENTE_DOCUMENTO_DTO,
            TB_CLIENTE_ENDERECO tB_CLIENTE_ENDERECO_DTO);
        List<BusinessViewListModel> listarTodosClientes();

    }
}
