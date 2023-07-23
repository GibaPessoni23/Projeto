using Model.BusinessModel;
using Model.BusinessViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WCFServiceContract
{
    // OBSERVAÇÃO: Você pode usar o comando "Renomear" no menu "Refatorar" para alterar o nome da interface "IService1" no arquivo de código e configuração ao mesmo tempo.
    [ServiceContract]
    public interface IService1
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

        // TODO: Adicione suas operações de serviço aqui
    }


    // Use um contrato de dados como ilustrado no exemplo abaixo para adicionar tipos compostos a operações de serviço.
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
}
