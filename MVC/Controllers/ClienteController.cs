using Helpers;
using Model.BusinessModel;
using Model.BusinessViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class ClienteController : Controller
    {
        private readonly HttpClient httpClientAPIRest;
        public ClienteController()
        {
            httpClientAPIRest = new HttpClient();
            //Lembrar de verificar no Projeto da API a porta na qual está rodando e realizar a troca da mesma aqui nesse endpoint
            //No meu caso a API está Hosteada na porta 44372
            httpClientAPIRest.BaseAddress = new Uri("http://localhost:44372/");
            httpClientAPIRest.DefaultRequestHeaders.Accept.Clear();
            httpClientAPIRest.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        // GET: Cliente
        public ActionResult Index()
        {
            var response = httpClientAPIRest.GetAsync(@"api\Cliente");
            var ViewListResponse = response.Result.Content.ReadAsStringAsync().Result;

            if (ViewListResponse != null)
            {
                var viewListResult = JsonConvert.DeserializeObject<List<BusinessViewListModel>>(ViewListResponse);
                return View(viewListResult);

            }
            return View();

        }

        // GET: Cliente/Create
        public ActionResult Create()
        {
            
            return View();
        }

        // POST: Cliente/Create
        [HttpPost]
        public async System.Threading.Tasks.Task<ActionResult> Create(BusinessViewModel collection)
        {
            //return View();

            try
            {

                BusinessViewModel objetoDto = objetoCriarDTOFabrica(collection);
                var objetoSerializado = JsonConvert.SerializeObject(objetoDto);
                HttpResponseMessage response = await httpClientAPIRest.PostAsync(@"api\Cliente", new StringContent(objetoSerializado, Encoding.UTF8, "application/json"));

                if (response.IsSuccessStatusCode)
                    return RedirectToAction("Index");


                return View();
            }
            catch
            {
                return View();
            }
        }



        // GET: Cliente/Edit/5
        public ActionResult Edit(int id)
        {

            var response = httpClientAPIRest.GetAsync($@"api\detalhar\{id}");
            var viewResponse = response.Result.Content.ReadAsStringAsync().Result;

            if (viewResponse != null)
            {
                var viewResult = JsonConvert.DeserializeObject<BusinessViewModel>(viewResponse);
                return View(viewResult);

            }
            return View();
        }

        // POST: Cliente/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(int id, FormCollection collection)
        {

            try
            {

                BusinessViewModel objetoDto = objetoEditarDtoFactory(id, collection);

                HttpResponseMessage response = await httpClientAPIRest.PutAsync(@"api\Cliente", new StringContent(JsonConvert.SerializeObject(objetoDto), Encoding.UTF8, "application/json"));

                if (response.IsSuccessStatusCode)
                    return RedirectToAction("Index");


                return View();
            }
            catch (Exception ex)
            {
                return View();
            }


        }


        // GET: Cliente/Delete/5
        [HttpGet]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {

                var response = await Delete(id, null);
                return RedirectToAction("Index");

            }
            catch
            {
                return RedirectToAction("Index");
            }
        }
        [HttpPost]
        public async Task<ActionResult> Delete(int id, FormCollection collection)
        {
            try
            {

                HttpResponseMessage response = await httpClientAPIRest.PostAsync(@"api\deletar", new StringContent(JsonConvert.SerializeObject(id), Encoding.UTF8, "application/json"));

                if (response.IsSuccessStatusCode)
                    return RedirectToAction("Index");

                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }

        private static BusinessViewModel objetoEditarDtoFactory(int id, FormCollection collection)
        {
            TB_CLIENTE cClienteDTO = new TB_CLIENTE();
            cClienteDTO.ID_CLIENTE = id;
            cClienteDTO.NM_NOME = collection["TB_CLIENTE_MVM.NM_NOME"];
            cClienteDTO.NM_CPF = collection["TB_CLIENTE_MVM.NM_CPF"];
            cClienteDTO.NM_ESTADO_CIVI = collection["selectEsCivil"];
            cClienteDTO.NM_SEXO = collection["selectSexo"];
            cClienteDTO.DT_NASCIMENTO = DateTime.Parse(collection["TB_CLIENTE_MVM.DT_NASCIMENTO"]);



            TB_CLIENTE_DOCUMENTO cDocumentoDTO = new TB_CLIENTE_DOCUMENTO();
            cDocumentoDTO.ID_DOCUMENTO = int.Parse(collection["TB_CLIENTE_DOCUMENTO_MVM.ID_DOCUMENTO"]);
            cDocumentoDTO.NM_DOCUMENTO = collection["TB_CLIENTE_DOCUMENTO_MVM.NM_DOCUMENTO"];
            cDocumentoDTO.NM_ORGAO_EXPEDITOR = collection["selectOrgao"];
            cDocumentoDTO.DT_DATA_EXPEDICAO = DateTime.Parse(collection["TB_CLIENTE_DOCUMENTO_MVM.DT_DATA_EXPEDICAO"]);
            cDocumentoDTO.NM_UF_DOCUMENTO = collection["selectUfExpedicao"];


            TB_CLIENTE_ENDERECO cEnderecoDTO = new TB_CLIENTE_ENDERECO();
            cEnderecoDTO.ID_CLTE_ENDCO = int.Parse(collection["TB_CLIENTE_ENDERECO_MVM.ID_CLTE_ENDCO"]);
            cEnderecoDTO.NM_BAIRRO_CLTE_ENDCO = collection["TB_CLIENTE_ENDERECO_MVM.NM_BAIRRO_CLTE_ENDCO"];
            cEnderecoDTO.NM_CEP_CLTE_ENDCO = collection["TB_CLIENTE_ENDERECO_MVM.NM_CEP_CLTE_ENDCO"];
            cEnderecoDTO.NM_CIDADE_CLTE_ENDCO = collection["TB_CLIENTE_ENDERECO_MVM.NM_CIDADE_CLTE_ENDCO"];
            cEnderecoDTO.NM_COMPLEMENTO_CLTE_ENDCO = collection["TB_CLIENTE_ENDERECO_MVM.NM_COMPLEMENTO_CLTE_ENDCO"];
            cEnderecoDTO.NM_LOGRADOURO_CLTE_ENDCO = collection["TB_CLIENTE_ENDERECO_MVM.NM_LOGRADOURO_CLTE_ENDCO"];
            cEnderecoDTO.NM_NUMERO_CLTE_ENDCO = collection["TB_CLIENTE_ENDERECO_MVM.NM_NUMERO_CLTE_ENDCO"];
            cEnderecoDTO.NM_UNID_FEDE = collection["TB_CLIENTE_ENDERECO_MVM.NM_UNID_FEDE"];

            BusinessViewModel objetoDto = new BusinessViewModel();
            objetoDto.TB_CLIENTE_MVM = cClienteDTO;
            objetoDto.TB_CLIENTE_DOCUMENTO_MVM = cDocumentoDTO;
            objetoDto.TB_CLIENTE_ENDERECO_MVM = cEnderecoDTO;
            return objetoDto;
        }

        private static BusinessViewModel objetoCriarDTOFabrica(BusinessViewModel collection)
        {
            TB_CLIENTE cClienteDTO = new TB_CLIENTE();
            cClienteDTO.NM_NOME = collection.NM_NOME;
            cClienteDTO.NM_CPF = collection.NM_CPF;
            cClienteDTO.NM_ESTADO_CIVI = "SOLTEIRO";
            cClienteDTO.NM_SEXO = "MASCULINO";
            cClienteDTO.DT_NASCIMENTO = collection.DT_NASCIMENTO;


            TB_CLIENTE_DOCUMENTO cDocumentoDTO = new TB_CLIENTE_DOCUMENTO();
            cDocumentoDTO.NM_DOCUMENTO = collection.NM_DOCUMENTO;
            cDocumentoDTO.NM_ORGAO_EXPEDITOR = "ssp";
            cDocumentoDTO.DT_DATA_EXPEDICAO = collection.DT_DATA_EXPEDICAO;
            cDocumentoDTO.NM_UF_DOCUMENTO = "sp";

            TB_CLIENTE_ENDERECO cEnderecoDTO = new TB_CLIENTE_ENDERECO();
            cEnderecoDTO.NM_BAIRRO_CLTE_ENDCO = collection.NM_BAIRRO_CLTE_ENDCO;
            cEnderecoDTO.NM_CEP_CLTE_ENDCO = collection.NM_CEP_CLTE_ENDCO;
            cEnderecoDTO.NM_CIDADE_CLTE_ENDCO = collection.NM_CIDADE_CLTE_ENDCO;
            cEnderecoDTO.NM_COMPLEMENTO_CLTE_ENDCO = collection.NM_COMPLEMENTO_CLTE_ENDCO;
            cEnderecoDTO.NM_LOGRADOURO_CLTE_ENDCO = collection.NM_LOGRADOURO_CLTE_ENDCO;
            cEnderecoDTO.NM_NUMERO_CLTE_ENDCO = collection.NM_NUMERO_CLTE_ENDCO;
            cEnderecoDTO.NM_UNID_FEDE = collection.TB_CLIENTE_ENDERECO_MVM.NM_UNID_FEDE;

            BusinessViewModel objetoDto = new BusinessViewModel();
            objetoDto.TB_CLIENTE_MVM = cClienteDTO;
            objetoDto.TB_CLIENTE_DOCUMENTO_MVM = cDocumentoDTO;
            objetoDto.TB_CLIENTE_ENDERECO_MVM = cEnderecoDTO;
            return objetoDto;
        }

        

    }
}
