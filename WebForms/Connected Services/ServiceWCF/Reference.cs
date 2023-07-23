﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebForms.ServiceWCF {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceWCF.IService1")]
    public interface IService1 {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/RegistrarCliente", ReplyAction="http://tempuri.org/IService1/RegistrarClienteResponse")]
        void RegistrarCliente(Model.BusinessModel.TB_CLIENTE tb_Cliente_Objeto_DTO, Model.BusinessModel.TB_CLIENTE_DOCUMENTO tB_CLIENTE_DOCUMENTO_DTO, Model.BusinessModel.TB_CLIENTE_ENDERECO tB_CLIENTE_ENDERECO_DTO);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/RegistrarCliente", ReplyAction="http://tempuri.org/IService1/RegistrarClienteResponse")]
        System.Threading.Tasks.Task RegistrarClienteAsync(Model.BusinessModel.TB_CLIENTE tb_Cliente_Objeto_DTO, Model.BusinessModel.TB_CLIENTE_DOCUMENTO tB_CLIENTE_DOCUMENTO_DTO, Model.BusinessModel.TB_CLIENTE_ENDERECO tB_CLIENTE_ENDERECO_DTO);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/ExcluirCliente", ReplyAction="http://tempuri.org/IService1/ExcluirClienteResponse")]
        void ExcluirCliente(int id_Cliente);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/ExcluirCliente", ReplyAction="http://tempuri.org/IService1/ExcluirClienteResponse")]
        System.Threading.Tasks.Task ExcluirClienteAsync(int id_Cliente);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/EditarCliente", ReplyAction="http://tempuri.org/IService1/EditarClienteResponse")]
        void EditarCliente(Model.BusinessModel.TB_CLIENTE tb_Cliente_Objeto_DTO, Model.BusinessModel.TB_CLIENTE_DOCUMENTO tB_CLIENTE_DOCUMENTO_DTO, Model.BusinessModel.TB_CLIENTE_ENDERECO tB_CLIENTE_ENDERECO_DTO);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/EditarCliente", ReplyAction="http://tempuri.org/IService1/EditarClienteResponse")]
        System.Threading.Tasks.Task EditarClienteAsync(Model.BusinessModel.TB_CLIENTE tb_Cliente_Objeto_DTO, Model.BusinessModel.TB_CLIENTE_DOCUMENTO tB_CLIENTE_DOCUMENTO_DTO, Model.BusinessModel.TB_CLIENTE_ENDERECO tB_CLIENTE_ENDERECO_DTO);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/DetalharCliente", ReplyAction="http://tempuri.org/IService1/DetalharClienteResponse")]
        Model.BusinessViewModel.BusinessViewModel DetalharCliente(int id_cliente);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/DetalharCliente", ReplyAction="http://tempuri.org/IService1/DetalharClienteResponse")]
        System.Threading.Tasks.Task<Model.BusinessViewModel.BusinessViewModel> DetalharClienteAsync(int id_cliente);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/listarTodosClientes", ReplyAction="http://tempuri.org/IService1/listarTodosClientesResponse")]
        Model.BusinessViewModel.BusinessViewListModel[] listarTodosClientes();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/listarTodosClientes", ReplyAction="http://tempuri.org/IService1/listarTodosClientesResponse")]
        System.Threading.Tasks.Task<Model.BusinessViewModel.BusinessViewListModel[]> listarTodosClientesAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IService1Channel : WebForms.ServiceWCF.IService1, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class Service1Client : System.ServiceModel.ClientBase<WebForms.ServiceWCF.IService1>, WebForms.ServiceWCF.IService1 {
        
        public Service1Client() {
        }
        
        public Service1Client(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public Service1Client(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1Client(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1Client(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public void RegistrarCliente(Model.BusinessModel.TB_CLIENTE tb_Cliente_Objeto_DTO, Model.BusinessModel.TB_CLIENTE_DOCUMENTO tB_CLIENTE_DOCUMENTO_DTO, Model.BusinessModel.TB_CLIENTE_ENDERECO tB_CLIENTE_ENDERECO_DTO) {
            base.Channel.RegistrarCliente(tb_Cliente_Objeto_DTO, tB_CLIENTE_DOCUMENTO_DTO, tB_CLIENTE_ENDERECO_DTO);
        }
        
        public System.Threading.Tasks.Task RegistrarClienteAsync(Model.BusinessModel.TB_CLIENTE tb_Cliente_Objeto_DTO, Model.BusinessModel.TB_CLIENTE_DOCUMENTO tB_CLIENTE_DOCUMENTO_DTO, Model.BusinessModel.TB_CLIENTE_ENDERECO tB_CLIENTE_ENDERECO_DTO) {
            return base.Channel.RegistrarClienteAsync(tb_Cliente_Objeto_DTO, tB_CLIENTE_DOCUMENTO_DTO, tB_CLIENTE_ENDERECO_DTO);
        }
        
        public void ExcluirCliente(int id_Cliente) {
            base.Channel.ExcluirCliente(id_Cliente);
        }
        
        public System.Threading.Tasks.Task ExcluirClienteAsync(int id_Cliente) {
            return base.Channel.ExcluirClienteAsync(id_Cliente);
        }
        
        public void EditarCliente(Model.BusinessModel.TB_CLIENTE tb_Cliente_Objeto_DTO, Model.BusinessModel.TB_CLIENTE_DOCUMENTO tB_CLIENTE_DOCUMENTO_DTO, Model.BusinessModel.TB_CLIENTE_ENDERECO tB_CLIENTE_ENDERECO_DTO) {
            base.Channel.EditarCliente(tb_Cliente_Objeto_DTO, tB_CLIENTE_DOCUMENTO_DTO, tB_CLIENTE_ENDERECO_DTO);
        }
        
        public System.Threading.Tasks.Task EditarClienteAsync(Model.BusinessModel.TB_CLIENTE tb_Cliente_Objeto_DTO, Model.BusinessModel.TB_CLIENTE_DOCUMENTO tB_CLIENTE_DOCUMENTO_DTO, Model.BusinessModel.TB_CLIENTE_ENDERECO tB_CLIENTE_ENDERECO_DTO) {
            return base.Channel.EditarClienteAsync(tb_Cliente_Objeto_DTO, tB_CLIENTE_DOCUMENTO_DTO, tB_CLIENTE_ENDERECO_DTO);
        }
        
        public Model.BusinessViewModel.BusinessViewModel DetalharCliente(int id_cliente) {
            return base.Channel.DetalharCliente(id_cliente);
        }
        
        public System.Threading.Tasks.Task<Model.BusinessViewModel.BusinessViewModel> DetalharClienteAsync(int id_cliente) {
            return base.Channel.DetalharClienteAsync(id_cliente);
        }
        
        public Model.BusinessViewModel.BusinessViewListModel[] listarTodosClientes() {
            return base.Channel.listarTodosClientes();
        }
        
        public System.Threading.Tasks.Task<Model.BusinessViewModel.BusinessViewListModel[]> listarTodosClientesAsync() {
            return base.Channel.listarTodosClientesAsync();
        }
    }
}
