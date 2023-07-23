
using Correios.Net;
using Helpers;
using Model.BusinessModel;
using Model.BusinessViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebForms.ServiceWCF;

namespace WebForms
{
    public partial class _Default : Page
    {
        Service1Client wcfServiceProxy;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                try
                {
                    GridViewCliente.Visible = true;
                    wcfServiceProxy = new Service1Client();
                    GridViewCliente.DataSource = wcfServiceProxy.listarTodosClientes();
                    GridViewCliente.DataBind();

                }
                catch (Exception ex)
                {

                    throw new ApplicationException($"Erro no Sistema de Cliente {ex.Message}");
                }
            }

        }

        protected void InsertButton_Click(object sender, EventArgs e)
        {
            
            try
            {
                TB_CLIENTE cClienteDTO;
                TB_CLIENTE_DOCUMENTO cDocumentoDTO;
                TB_CLIENTE_ENDERECO cEnderecoDTO;
                cClienteDto(out cClienteDTO, out cDocumentoDTO, out cEnderecoDTO);
                ValidarCamposObrigatorios();
                wcfServiceProxy = new Service1Client();
                wcfServiceProxy.RegistrarCliente(cClienteDTO, cDocumentoDTO, cEnderecoDTO);
                GridViewCliente.DataSource = wcfServiceProxy.listarTodosClientes();
                GridViewCliente.DataBind();
                Response.Write("<script>alert('Cliente cadastrado com sucesso. A listagem de cliente foi atualizada!!')</script>");


            }
            catch (Exception  ex)
            {
                if (ButtonInsert.Visible == true)
                {
                    lblMsg.Text = "Error while adding new customer details :" + ex.Message;
                }
                else
                {
                    lblMsg.Text = "Error while updating customer details :" + ex.Message;
                }
            }


            LimparForm();

        }
      

        protected void GridViewCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            FormAlteracao();
            int id_ClienteSelecionado= Convert.ToInt32(GridViewCliente.DataKeys[GridViewCliente.SelectedRow.RowIndex].Value.ToString());            
            wcfServiceProxy = new Service1Client();
            ServiceWCF.BusinessViewModel detalheClientes = wcfServiceProxy.DetalharCliente(id_ClienteSelecionado);
            CarregarForm(detalheClientes);


        }

        protected void DeleteButton_Click(object sender, EventArgs e)
        {
            try
            {               
                int ID_CLIENTE = Convert.ToInt32(GridViewCliente.DataKeys[GridViewCliente.SelectedRow.RowIndex].Value.ToString());

                wcfServiceProxy = new Service1Client();
                wcfServiceProxy.ExcluirCliente(ID_CLIENTE);
                GridViewCliente.DataSource = wcfServiceProxy.listarTodosClientes();
                GridViewCliente.DataBind();
                Response.Write("<script>alert('Cliente deletado. A listagem de cliente foi atualizada!!')</script>");
            }
            catch (Exception ex)
            {
                lblMsg.Text = "Erro :" + ex.Message;
            }
            LimparForm();
        }

        protected void EditButton_Click(object sender, EventArgs e)
        {
            try
            {


                aClienteDto(out TB_CLIENTE cClienteDTO, out TB_CLIENTE_DOCUMENTO cDocumentoDTO, out TB_CLIENTE_ENDERECO cEnderecoDTO);
                ValidarCamposObrigatorios();
                wcfServiceProxy = new Service1Client();
                wcfServiceProxy.EditarCliente(cClienteDTO, cDocumentoDTO, cEnderecoDTO);


                GridViewCliente.DataSource = wcfServiceProxy.listarTodosClientes();
                GridViewCliente.DataBind();
                Response.Write("<script>alert('Cliente alterado. A listagem de cliente foi atualizada!!')</script>");
            }
            catch (Exception ex)
            {
                lblMsg.Text = "Erro na alteração do cadastro :" + ex.Message;
            }
            LimparForm();
        }

        #region Métodos privados Classe
        private void LimparForm()
        {
            
            ButtonInsert.Visible = true;
            ButtonUpdate.Visible = false;
            ButtonDelete.Visible = false;
            txtNome.Text="";
            txtCpf.Text="";
            civilList.SelectedValue="";
            sexoList.SelectedValue = "";
            txtNasc.Text = "";    
            txt_NM_CLIENTE_Documento.Text="";
            orgaoList.SelectedValue="";
            txt_DT_CLIENTE_Documento.Text = "";         
            txt_Bairro_CLIENTE_Endereco.Text="";
            txt_Cep_CLIENTE_Endereco.Text="";
            txt_Cid_CLIENTE_Endereco.Text="";
            txt_Comp_CLIENTE_Endereco.Text="";
            txt_Logr_CLIENTE_Endereco.Text="";
            txt_Num_CLIENTE_Endereco.Text="";
            txt_uf_CLIENTE_Endereco.Text = "";
            uf_Expedicao_Documento.SelectedValue = "";
        }

        private void FormAlteracao() {
            ButtonInsert.Visible = false;
            ButtonUpdate.Visible = true;
            ButtonDelete.Visible = true;
          
            
          
        }

        private void CarregarForm(ServiceWCF.BusinessViewModel businessViewModel)
        {
            txtNome.Text = businessViewModel.TB_CLIENTE_MVM.NM_NOME;
            txtCpf.Text = businessViewModel.TB_CLIENTE_MVM.NM_CPF; 
            civilList.SelectedValue = businessViewModel.TB_CLIENTE_MVM.NM_ESTADO_CIVI;
            sexoList.SelectedValue = businessViewModel.TB_CLIENTE_MVM.NM_SEXO;
            txtNasc.Text = businessViewModel.TB_CLIENTE_MVM.DT_NASCIMENTO.ToString();

            txt_ID_CLIENTE_Documento.Value = businessViewModel.TB_CLIENTE_DOCUMENTO_MVM.ID_DOCUMENTO.ToString();
            txt_NM_CLIENTE_Documento.Text = businessViewModel.TB_CLIENTE_DOCUMENTO_MVM.NM_DOCUMENTO;
            orgaoList.SelectedValue = businessViewModel.TB_CLIENTE_DOCUMENTO_MVM.NM_ORGAO_EXPEDITOR;
            txt_DT_CLIENTE_Documento.Text = businessViewModel.TB_CLIENTE_DOCUMENTO_MVM.DT_DATA_EXPEDICAO.ToString();
            uf_Expedicao_Documento.SelectedValue = businessViewModel.TB_CLIENTE_DOCUMENTO_MVM.NM_UF_DOCUMENTO;

            txt_ID_CLIENTE_Endereco.Value = businessViewModel.TB_CLIENTE_ENDERECO_MVM.ID_CLTE_ENDCO.ToString();
            txt_Bairro_CLIENTE_Endereco.Text = businessViewModel.TB_CLIENTE_ENDERECO_MVM.NM_BAIRRO_CLTE_ENDCO;
            txt_Cep_CLIENTE_Endereco.Text = businessViewModel.TB_CLIENTE_ENDERECO_MVM.NM_CEP_CLTE_ENDCO;
            txt_Cid_CLIENTE_Endereco.Text = businessViewModel.TB_CLIENTE_ENDERECO_MVM.NM_CIDADE_CLTE_ENDCO;
            txt_Comp_CLIENTE_Endereco.Text = businessViewModel.TB_CLIENTE_ENDERECO_MVM.NM_COMPLEMENTO_CLTE_ENDCO;
            txt_Logr_CLIENTE_Endereco.Text = businessViewModel.TB_CLIENTE_ENDERECO_MVM.NM_LOGRADOURO_CLTE_ENDCO;
            txt_Num_CLIENTE_Endereco.Text = businessViewModel.TB_CLIENTE_ENDERECO_MVM.NM_NUMERO_CLTE_ENDCO;
            txt_uf_CLIENTE_Endereco.Text = businessViewModel.TB_CLIENTE_ENDERECO_MVM.NM_UNID_FEDE;
        }

        private void cClienteDto(out TB_CLIENTE cClienteDTO, out TB_CLIENTE_DOCUMENTO cDocumentoDTO, out TB_CLIENTE_ENDERECO cEnderecoDTO)
        {
            cClienteDTO = new TB_CLIENTE();
            cClienteDTO.NM_NOME = txtNome.Text;
            cClienteDTO.NM_CPF = txtCpf.Text;
            cClienteDTO.NM_ESTADO_CIVI = civilList.SelectedValue;
            cClienteDTO.NM_SEXO = sexoList.SelectedValue;
            if(String.IsNullOrWhiteSpace(txtNasc.Text)) Response.Write("<script>alert('Data Nascimento é obrigatório')</script>");
            cClienteDTO.DT_NASCIMENTO = DateTime.Parse(txtNasc.Text);           




            cDocumentoDTO = new TB_CLIENTE_DOCUMENTO();
            cDocumentoDTO.NM_DOCUMENTO = txt_NM_CLIENTE_Documento.Text;
            cDocumentoDTO.NM_ORGAO_EXPEDITOR = orgaoList.SelectedValue;
            if(String.IsNullOrWhiteSpace(txt_DT_CLIENTE_Documento.Text)) Response.Write("<script>alert('Data expedição é obrigatório')</script>");
            cDocumentoDTO.DT_DATA_EXPEDICAO = DateTime.Parse(txt_DT_CLIENTE_Documento.Text);
            cDocumentoDTO.NM_UF_DOCUMENTO = uf_Expedicao_Documento.SelectedValue;


            cEnderecoDTO = new TB_CLIENTE_ENDERECO();
            cEnderecoDTO.NM_BAIRRO_CLTE_ENDCO = txt_Bairro_CLIENTE_Endereco.Text;
            cEnderecoDTO.NM_CEP_CLTE_ENDCO = txt_Cep_CLIENTE_Endereco.Text;
            cEnderecoDTO.NM_CIDADE_CLTE_ENDCO = txt_Cid_CLIENTE_Endereco.Text;
            cEnderecoDTO.NM_COMPLEMENTO_CLTE_ENDCO = txt_Comp_CLIENTE_Endereco.Text;
            cEnderecoDTO.NM_LOGRADOURO_CLTE_ENDCO = txt_Logr_CLIENTE_Endereco.Text;
            cEnderecoDTO.NM_NUMERO_CLTE_ENDCO = txt_Num_CLIENTE_Endereco.Text;
            cEnderecoDTO.NM_UNID_FEDE = txt_uf_CLIENTE_Endereco.Text;
        }

        private void aClienteDto(out TB_CLIENTE cClienteDTO, out TB_CLIENTE_DOCUMENTO cDocumentoDTO, out TB_CLIENTE_ENDERECO cEnderecoDTO)
        {
            int id_ClienteSelecionado = Convert.ToInt32(GridViewCliente.DataKeys[GridViewCliente.SelectedRow.RowIndex].Value.ToString());
            cClienteDTO = new TB_CLIENTE();
            cClienteDTO.ID_CLIENTE = id_ClienteSelecionado;
            cClienteDTO.NM_NOME = txtNome.Text;
            cClienteDTO.NM_CPF = txtCpf.Text;
            cClienteDTO.NM_ESTADO_CIVI = civilList.SelectedValue;
            cClienteDTO.NM_SEXO = sexoList.SelectedValue;
            if(String.IsNullOrWhiteSpace(txtNasc.Text)) Response.Write("<script>alert('Data Nascimento é obrigatório')</script>");
            cClienteDTO.DT_NASCIMENTO = DateTime.Parse(txtNasc.Text);       




            cDocumentoDTO = new TB_CLIENTE_DOCUMENTO();
            cDocumentoDTO.ID_DOCUMENTO = Convert.ToInt32(txt_ID_CLIENTE_Documento.Value);
            cDocumentoDTO.NM_DOCUMENTO = txt_NM_CLIENTE_Documento.Text;
            cDocumentoDTO.NM_ORGAO_EXPEDITOR = orgaoList.SelectedValue;
            if(String.IsNullOrWhiteSpace(txt_DT_CLIENTE_Documento.Text)) Response.Write("<script>alert('Data expedição é obrigatório')</script>");
            cDocumentoDTO.DT_DATA_EXPEDICAO = DateTime.Parse(txt_DT_CLIENTE_Documento.Text);   
            cDocumentoDTO.NM_UF_DOCUMENTO = uf_Expedicao_Documento.SelectedValue;


            cEnderecoDTO = new TB_CLIENTE_ENDERECO();
            cEnderecoDTO.ID_CLTE_ENDCO = Convert.ToInt32(txt_ID_CLIENTE_Endereco.Value);
            cEnderecoDTO.NM_BAIRRO_CLTE_ENDCO = txt_Bairro_CLIENTE_Endereco.Text;
            cEnderecoDTO.NM_CEP_CLTE_ENDCO = txt_Cep_CLIENTE_Endereco.Text;
            cEnderecoDTO.NM_CIDADE_CLTE_ENDCO = txt_Cid_CLIENTE_Endereco.Text;
            cEnderecoDTO.NM_COMPLEMENTO_CLTE_ENDCO = txt_Comp_CLIENTE_Endereco.Text;
            cEnderecoDTO.NM_LOGRADOURO_CLTE_ENDCO = txt_Logr_CLIENTE_Endereco.Text;
            cEnderecoDTO.NM_NUMERO_CLTE_ENDCO = txt_Num_CLIENTE_Endereco.Text;
            cEnderecoDTO.NM_UNID_FEDE = txt_uf_CLIENTE_Endereco.Text;
        }

        #endregion

        protected void txt_Cep_CLIENTE_Endereco_TextChanged(object sender, EventArgs e)
        {
            //Tive que contornar o preenchimento automatico de CEP via Back-End, pq via javascript
            //estava dando erro de CORS
            ValidarCep();

        }

     

        protected void txtCpf_TextChanged(object sender, EventArgs e)
        {
            if (!Validation.cpfValidar(txtCpf.Text)) {
                Response.Write("<script>alert('CPF inválido')</script>");
            };
        }


        //Método obter dados endereço
        //o Ideal seria ter esse método numa classe de Helpers, Util ou coisa do tipo
        private void ValidarCep()
        {
            HttpWebRequest request = null;
            HttpWebResponse responseService = null;
            try
            {
                request = (HttpWebRequest)WebRequest.Create("https://viacep.com.br/ws/" + txt_Cep_CLIENTE_Endereco.Text + "/json/");
                request.AllowAutoRedirect = false;
                responseService = (HttpWebResponse)request.GetResponse();

                if (responseService.StatusCode != HttpStatusCode.OK)
                {

                    return; // Sai da rotina
                }

            }
            catch
            {

                Response.Write("<script>alert('CEP inválido')</script>");
                return;
            }


            using (Stream webStream = responseService.GetResponseStream())
            {
                if (webStream != null)
                {
                    using (StreamReader responseReader = new StreamReader(webStream))
                    {
                        string response = responseReader.ReadToEnd();
                        response = Regex.Replace(response, "[{},]", string.Empty);
                        response = response.Replace("\"", "");

                        String[] substrings = response.Split('\n');

                        int cont = 0;
                        foreach (var substring in substrings)
                        {
                            
                            //Logradouro
                            if (cont == 2)
                            {
                                string[] valor = substring.Split(":".ToCharArray());
                                txt_Logr_CLIENTE_Endereco.Text = valor[1];
                                txt_Logr_CLIENTE_Endereco.Attributes.Add("readonly", "true");
                            }     
                            //Bairro
                            if (cont == 4)
                            {
                                string[] valor = substring.Split(":".ToCharArray());
                                txt_Bairro_CLIENTE_Endereco.Text = valor[1];
                                txt_Bairro_CLIENTE_Endereco.Attributes.Add("readonly", "true");
                            }     
                            //Cidade
                            if (cont == 5)
                            {
                                string[] valor = substring.Split(":".ToCharArray());
                                txt_Cid_CLIENTE_Endereco.Text = valor[1];
                                txt_Cid_CLIENTE_Endereco.Attributes.Add("readonly", "true");
                            }    
                            //Unidade Federativa
                            if (cont == 6)
                            {
                                string[] valor = substring.Split(":".ToCharArray());
                                txt_uf_CLIENTE_Endereco.Text = valor[1];
                                txt_uf_CLIENTE_Endereco.Attributes.Add("readonly", "true"); ;
                            }

                            cont++;
                        }
                    }
                }
            }
        }


        //Fazer um Double_Check de validação
        //Sempre necessário validar no Front_end e no Back_end
        private void ValidarCamposObrigatorios()
        {
            if(String.IsNullOrWhiteSpace(txtNome.Text)) Response.Write("<script>alert('Nome é obrigatório')</script>");
            if (String.IsNullOrWhiteSpace(civilList.SelectedValue)) Response.Write("<script>alert('Estado Civil é obrigatório')</script>");
            if (String.IsNullOrWhiteSpace(sexoList.SelectedValue)) Response.Write("<script>alert('Campo Sexo é obrigatório')</script>");
            if (String.IsNullOrWhiteSpace(txtNasc.Text)) Response.Write("<script>alert('Data Nascimento é obrigatório')</script>");
            if (String.IsNullOrWhiteSpace(txt_NM_CLIENTE_Documento.Text)) Response.Write("<script>alert('RG é obrigatório')</script>");
            if (String.IsNullOrWhiteSpace(orgaoList.SelectedValue)) Response.Write("<script>alert('Orgão expedidor é obrigatório')</script>");
            if (String.IsNullOrWhiteSpace(txt_DT_CLIENTE_Documento.Text)) Response.Write("<script>alert('Data expedição é obrigatório')</script>");
            if (String.IsNullOrWhiteSpace(uf_Expedicao_Documento.SelectedValue)) Response.Write("<script>alert('Nome inválido')</script>");
            if (String.IsNullOrWhiteSpace(txt_Cep_CLIENTE_Endereco.Text)) Response.Write("<script>alert('CEP é obrigatório')</script>");        
            if (String.IsNullOrWhiteSpace(txt_Num_CLIENTE_Endereco.Text)) Response.Write("<script>alert('Número é obrigatório')</script>");
           
            
        }

    }
}