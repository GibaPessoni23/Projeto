using API.Controllers.ControllerService;
using Helpers;
using Model.BusinessModel;
using Model.BusinessViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace API.Controllers
{
    public class ClienteController : ApiController
    {

        Service contratoService = null;
        public ClienteController()
        {
            contratoService = new Service();
        }
               

        public IHttpActionResult Get()
        {
            List<BusinessViewListModel> listaTodoClientes = contratoService.listarTodosClientes();

            return Ok(listaTodoClientes);
        }

        [System.Web.Http.Route("api/detalhar/{id}")]
        public IHttpActionResult Get(int id)
        {

            BusinessViewModel detalheClientes = contratoService.DetalharCliente(id);

            return Ok(detalheClientes);
            
        }

        // POST: api/Cliente
        [System.Web.Mvc.HttpPost]
        public HttpResponseMessage Post([FromBody] BusinessViewModel value)
        {
            AssertionData.AssertionArgumentNotNull(value, "Modelo inválido");

            contratoService.RegistrarCliente(value.TB_CLIENTE_MVM, value.TB_CLIENTE_DOCUMENTO_MVM, value.TB_CLIENTE_ENDERECO_MVM);


            var msg = Request.CreateResponse(HttpStatusCode.Created, value.TB_CLIENTE_MVM.NM_NOME);
            return msg;


        }
        [System.Web.Http.Route("api/deletar")]
        public void Post([FromBody]int id)
        {
            Delete(id);         
            
        }

        // PUT: api/Cliente/5
        public void Put([FromBody] BusinessViewModel value)
        {
            AssertionData.AssertionArgumentNotNull(value, "Modelo inválido");

            contratoService.EditarCliente(value.TB_CLIENTE_MVM, value.TB_CLIENTE_DOCUMENTO_MVM, value.TB_CLIENTE_ENDERECO_MVM);
            
            var msg = Request.CreateResponse(HttpStatusCode.Created, value.TB_CLIENTE_MVM.NM_NOME);



        }
        
        [System.Web.Http.HttpDelete]
        [System.Web.Http.Route("cliente/deletar/{id}")]
        public void Delete(int id)
        {
            Delete(id, null);
            
        }


        // DELETE: api/Cliente/5
        [System.Web.Http.Route("deletar/{id}")]
        public void Delete(int id, FormCollection collection)
        {
            AssertionData.AssertionArgumentNotNull(id, "Id de Cliente não informado");
            AssertionData.AssertionIntNotEqualsZero(id, "Id de Cliente informado é inválido");
            AssertionData.AssertionIntNotNegativeNumber(id, "Id de Cliente informado é inválido");
            contratoService.ExcluirCliente(id);
        }
    }
}
