using Model.BusinessModel;
using Model.BusinessViewModel;
using Model.InfrasctrcutureModel.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseContext
{
    /// <summary>
    /// Classe responsável pela comunicação com o Banco de Dados, utilizando ADO.NET
    /// Poderia ter utilizado o EF, mas quis ser dinâmico e simples ... Por isso estou utilizando o ADO.NET puro, sem ORM

    public class DataBaseContext : IRepositoyGenericDB
    {

        private readonly string _connectionstring = string.Empty;

        SqlConnection conexaoDataBase;

        public DataBaseContext(string conn)
        {
            _connectionstring = conn;
        }


        public void RegistrarCliente(TB_CLIENTE tb_Cliente_Objeto_DTO, TB_CLIENTE_DOCUMENTO tB_CLIENTE_DOCUMENTO_DTO, TB_CLIENTE_ENDERECO tB_CLIENTE_ENDERECO_DTO)
        {

            int id_Endereco = CadastrarEnderecoCliente(tB_CLIENTE_ENDERECO_DTO);
            int id_Documento = CadastrarDocumentoCliente(tB_CLIENTE_DOCUMENTO_DTO);
            CadastrarCliente(tb_Cliente_Objeto_DTO, id_Documento, id_Endereco);
        }

        public void ExcluirCliente(int id_Cliente)
        {
            try
            {
                conexaoDataBase = new SqlConnection(_connectionstring);
                using (conexaoDataBase)
                {
                    conexaoDataBase.Open();


                    using (SqlCommand cmd = new SqlCommand(DataBaseDMLCommand.SP_EXCLUIR_CLIENTE, conexaoDataBase))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ID_CLIENTE", id_Cliente);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
        }

        public void EditarCliente(TB_CLIENTE tb_Cliente_Objeto_DTO, TB_CLIENTE_DOCUMENTO tB_CLIENTE_DOCUMENTO_DTO, TB_CLIENTE_ENDERECO tB_CLIENTE_ENDERECO_DTO)
        {
            EditarClienteDocumento(tB_CLIENTE_DOCUMENTO_DTO);
            EditarClienteEndereco(tB_CLIENTE_ENDERECO_DTO);

            try
            {
                conexaoDataBase = new SqlConnection(_connectionstring);
                using (conexaoDataBase)
                {
                    conexaoDataBase.Open();


                    using (SqlCommand cmd = new SqlCommand(DataBaseDMLCommand.SP_ALTERAR_CLIENTE, conexaoDataBase))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ID_CLIENTE", tb_Cliente_Objeto_DTO.ID_CLIENTE);
                        cmd.Parameters.AddWithValue("@NM_NOME", tb_Cliente_Objeto_DTO.NM_NOME);
                        cmd.Parameters.AddWithValue("@NM_CPF", tb_Cliente_Objeto_DTO.NM_CPF);
                        cmd.Parameters.AddWithValue("@DT_NASCIMENTO", tb_Cliente_Objeto_DTO.DT_NASCIMENTO);                       
                        cmd.Parameters.AddWithValue("@NM_SEXO", tb_Cliente_Objeto_DTO.NM_SEXO);
                        cmd.Parameters.AddWithValue("@NM_ESTADO_CIVIL", tb_Cliente_Objeto_DTO.NM_ESTADO_CIVI);

                        cmd.ExecuteNonQuery();
                    }

                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Erro ao realizar o cadastro Documento Banco de Dados {ex.Message}");
            }

            
        }




        private void CadastrarCliente(TB_CLIENTE tb_Cliente_Objeto, int tB_CLIENTE_DOCUMENTO, int tB_CLIENTE_ENDERECO)
        {
            try
            {
                conexaoDataBase = new SqlConnection(_connectionstring);
                using (conexaoDataBase)
                {
                    conexaoDataBase.Open();


                    using (SqlCommand cmd = new SqlCommand(DataBaseDMLCommand.SP_CRIAR_CLIENTE, conexaoDataBase))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;                        
                        cmd.Parameters.AddWithValue("@NM_NOME", tb_Cliente_Objeto.NM_NOME);
                        cmd.Parameters.AddWithValue("@NM_CPF", tb_Cliente_Objeto.NM_CPF);
                        cmd.Parameters.AddWithValue("@DT_NASCIMENTO", tb_Cliente_Objeto.DT_NASCIMENTO);
                        cmd.Parameters.AddWithValue("@TB_CLIENTE_DOCUMENTO_ID_DOCUMENTO", tB_CLIENTE_DOCUMENTO);
                        cmd.Parameters.AddWithValue("@TB_CLIENTE_ENDERECO_ID_CLTE_ENDCO", tB_CLIENTE_ENDERECO);
                        cmd.Parameters.AddWithValue("@NM_SEXO", tb_Cliente_Objeto.NM_SEXO);
                        cmd.Parameters.AddWithValue("@NM_ESTADO_CIVIL", tb_Cliente_Objeto.NM_ESTADO_CIVI);

                        cmd.ExecuteNonQuery();
                    }

                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Erro ao realizar o cadastro Documento Banco de Dados {ex.Message}");
            }
        }

        private int CadastrarDocumentoCliente(TB_CLIENTE_DOCUMENTO tB_CLIENTE_DOCUMENTO)
        {
            int identificador;
            try
            {
                conexaoDataBase = new SqlConnection(_connectionstring);
                using (conexaoDataBase)
                {
                    conexaoDataBase.Open();


                    using (SqlCommand cmd = new SqlCommand(DataBaseDMLCommand.SP_CRIAR_CLIENTE_DOCUMENTO, conexaoDataBase))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;                       
                        cmd.Parameters.AddWithValue("@NM_DOCUMENTO", tB_CLIENTE_DOCUMENTO.NM_DOCUMENTO);
                        cmd.Parameters.AddWithValue("@DT_DATA_EXPEDICAO", tB_CLIENTE_DOCUMENTO.DT_DATA_EXPEDICAO);                      
                        cmd.Parameters.AddWithValue("@NM_ORGAO_EXPEDITOR", tB_CLIENTE_DOCUMENTO.NM_ORGAO_EXPEDITOR);
                        cmd.Parameters.AddWithValue("@NM_UF_DOCUMENTO", tB_CLIENTE_DOCUMENTO.NM_UF_DOCUMENTO);
                        
                        var returnParameter = cmd.Parameters.Add("@identificadorDocumento", SqlDbType.Int);
                        returnParameter.Direction = ParameterDirection.ReturnValue;


                        cmd.ExecuteNonQuery();
                 
       identificador = Convert.ToInt32(returnParameter.Value);

                    }

                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Erro ao realizar o cadastro Documento Banco de Dados {ex.Message}");
            }
            return identificador;
        }

        private int CadastrarEnderecoCliente(TB_CLIENTE_ENDERECO tB_CLIENTE_ENDERECO)
        {
            int identificadorDocumento;
            try
            {
                conexaoDataBase = new SqlConnection(_connectionstring);
                using (conexaoDataBase)
                {
                    conexaoDataBase.Open();


                    using (SqlCommand cmd = new SqlCommand(DataBaseDMLCommand.SP_CRIAR_CLIENTE_ENDERECO, conexaoDataBase))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;                     
                        cmd.Parameters.AddWithValue("@NM_LOGRADOURO_CLTE_ENDCO", tB_CLIENTE_ENDERECO.NM_LOGRADOURO_CLTE_ENDCO);
                        cmd.Parameters.AddWithValue("@NM_NUMERO_CLTE_ENDCO", tB_CLIENTE_ENDERECO.NM_NUMERO_CLTE_ENDCO);
                        cmd.Parameters.AddWithValue("@NM_CEP_CLTE_ENDCO", tB_CLIENTE_ENDERECO.NM_CEP_CLTE_ENDCO);
                        cmd.Parameters.AddWithValue("@NM_COMPLEMENTO_CLTE_ENDCO", tB_CLIENTE_ENDERECO.NM_COMPLEMENTO_CLTE_ENDCO);
                        cmd.Parameters.AddWithValue("@NM_BAIRRO_CLTE_ENDCO", tB_CLIENTE_ENDERECO.NM_BAIRRO_CLTE_ENDCO);
                        cmd.Parameters.AddWithValue("@NM_CIDADE_CLTE_ENDCO", tB_CLIENTE_ENDERECO.NM_CIDADE_CLTE_ENDCO);
                        cmd.Parameters.AddWithValue("@NM_UNID_FEDE", tB_CLIENTE_ENDERECO.NM_UNID_FEDE);

                        var returnParameter = cmd.Parameters.Add("@identificadorEndereco", SqlDbType.Int);
                        returnParameter.Direction = ParameterDirection.ReturnValue;


                        cmd.ExecuteNonQuery();
                        identificadorDocumento = Convert.ToInt32(returnParameter.Value);

                    }

                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Erro ao realizar o cadastro De Endereço Banco de Dados {ex.Message}");
            }
            return identificadorDocumento;
        }

        private void EditarClienteDocumento(TB_CLIENTE_DOCUMENTO tB_CLIENTE_DOCUMENTO_DTO)
        {
            try
            {
                conexaoDataBase = new SqlConnection(_connectionstring);
                using (conexaoDataBase)
                {
                    conexaoDataBase.Open();


                    using (SqlCommand cmd = new SqlCommand(DataBaseDMLCommand.SP_ALTERAR_CLIENTE_DOCUMENTO, conexaoDataBase))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ID_DOCUMENTO", tB_CLIENTE_DOCUMENTO_DTO.ID_DOCUMENTO);
                        cmd.Parameters.AddWithValue("@NM_DOCUMENTO", tB_CLIENTE_DOCUMENTO_DTO.NM_DOCUMENTO);
                        cmd.Parameters.AddWithValue("@DT_DATA_EXPEDICAO", tB_CLIENTE_DOCUMENTO_DTO.DT_DATA_EXPEDICAO);
                        cmd.Parameters.AddWithValue("@NM_ORGAO_EXPEDITOR", tB_CLIENTE_DOCUMENTO_DTO.NM_ORGAO_EXPEDITOR);
                        cmd.Parameters.AddWithValue("@NM_UF_DOCUMENTO", tB_CLIENTE_DOCUMENTO_DTO.NM_UF_DOCUMENTO);
                        
                        cmd.ExecuteNonQuery();

                    }

                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Erro ao realizar o cadastro Documento Banco de Dados {ex.Message}");
            }

        }

        private void EditarClienteEndereco(TB_CLIENTE_ENDERECO tB_CLIENTE_ENDERECO_DTO)
        {
            try
            {
                conexaoDataBase = new SqlConnection(_connectionstring);
                using (conexaoDataBase)
                {
                    conexaoDataBase.Open();


                    using (SqlCommand cmd = new SqlCommand(DataBaseDMLCommand.SP_ALTERAR_CLIENTE_ENDERECO, conexaoDataBase))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ID_CLTE_ENDCO", tB_CLIENTE_ENDERECO_DTO.ID_CLTE_ENDCO);
                        cmd.Parameters.AddWithValue("@NM_LOGRADOURO_CLTE_ENDCO", tB_CLIENTE_ENDERECO_DTO.NM_LOGRADOURO_CLTE_ENDCO);
                        cmd.Parameters.AddWithValue("@NM_NUMERO_CLTE_ENDCO", tB_CLIENTE_ENDERECO_DTO.NM_NUMERO_CLTE_ENDCO);
                        cmd.Parameters.AddWithValue("@NM_CEP_CLTE_ENDCO", tB_CLIENTE_ENDERECO_DTO.NM_CEP_CLTE_ENDCO);
                        cmd.Parameters.AddWithValue("@NM_COMPLEMENTO_CLTE_ENDCO", tB_CLIENTE_ENDERECO_DTO.NM_COMPLEMENTO_CLTE_ENDCO);
                        cmd.Parameters.AddWithValue("@NM_BAIRRO_CLTE_ENDCO", tB_CLIENTE_ENDERECO_DTO.NM_BAIRRO_CLTE_ENDCO);
                        cmd.Parameters.AddWithValue("@NM_CIDADE_CLTE_ENDCO", tB_CLIENTE_ENDERECO_DTO.NM_CIDADE_CLTE_ENDCO);
                        cmd.Parameters.AddWithValue("@NM_UNID_FEDE", tB_CLIENTE_ENDERECO_DTO.NM_UNID_FEDE);

                        cmd.ExecuteNonQuery();

                    }

                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Erro ao realizar o cadastro De Endereço Banco de Dados {ex.Message}");
            }

        }

        public List<BusinessViewListModel> listarTodosClientes()
        {
            List<BusinessViewListModel> lista = new List<BusinessViewListModel>();

            BusinessViewListModel clientes = null;
            try
            {
                conexaoDataBase = new SqlConnection(_connectionstring);
                using (conexaoDataBase)
                {
                    conexaoDataBase.Open();

                    using (SqlCommand cmd = new SqlCommand(DataBaseDQLCommand.SP_LISTAR_CLIENTE, conexaoDataBase))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataReader exc = cmd.ExecuteReader();

                        while (exc.Read())
                        {
                            clientes = new BusinessViewListModel();
                            clientes.ID_CLIENTE = Convert.ToInt32(exc.GetValue(0).ToString());
                            clientes.NM_NOME = exc.GetValue(1).ToString();
                            clientes.NM_CPF = exc.GetValue(2).ToString();
                            clientes.NM_DOCUMENTO = exc.GetValue(3).ToString();
                            clientes.NM_SEXO = exc.GetValue(4).ToString();
                            clientes.NM_ESTD_CIVIL = exc.GetValue(5).ToString();
                            lista.Add(clientes);
                        }
                    }
                }

            }
            catch (Exception ex)
            {

                throw new ApplicationException(ex.Message);
            }

            return lista;
        }

        public BusinessViewModel DetalharCliente(int id_cliente)
        {
            BusinessViewModel clienteDetalhe = new BusinessViewModel();
            


            try
            {
                conexaoDataBase = new SqlConnection(_connectionstring);
                using (conexaoDataBase)
                {
                    conexaoDataBase.Open();

                    using (SqlCommand cmd = new SqlCommand(DataBaseDQLCommand.SP_DETALHAR_CLIENTE, conexaoDataBase))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ID_CLIENTE", id_cliente);
                        SqlDataReader exc = cmd.ExecuteReader();

                        while (exc.Read())
                        {
                            //Cliente
                            clienteDetalhe.TB_CLIENTE_MVM.ID_CLIENTE = Convert.ToInt32(exc.GetValue(0).ToString());
                            clienteDetalhe.TB_CLIENTE_MVM.NM_NOME    = exc.GetValue(1).ToString();
                            clienteDetalhe.TB_CLIENTE_MVM.NM_CPF = exc.GetValue(2).ToString();
                            clienteDetalhe.TB_CLIENTE_MVM.DT_NASCIMENTO = DateTime.Parse(exc.GetValue(3).ToString());
                            clienteDetalhe.TB_CLIENTE_MVM.TB_CLIENTE_DOCUMENTO_ID_DOCUMENTO = Convert.ToInt32(exc.GetValue(4).ToString());
                            clienteDetalhe.TB_CLIENTE_MVM.TB_CLIENTE_ENDERECO_ID_CLTE_ENDCO = Convert.ToInt32(exc.GetValue(5).ToString());
                            clienteDetalhe.TB_CLIENTE_MVM.NM_SEXO = exc.GetValue(6).ToString();
                            clienteDetalhe.TB_CLIENTE_MVM.NM_ESTADO_CIVI = exc.GetValue(7).ToString();

                            //Documento
                            clienteDetalhe.TB_CLIENTE_DOCUMENTO_MVM.ID_DOCUMENTO = Convert.ToInt32(exc.GetValue(8).ToString());
                            clienteDetalhe.TB_CLIENTE_DOCUMENTO_MVM.NM_DOCUMENTO = exc.GetValue(9).ToString();
                            clienteDetalhe.TB_CLIENTE_DOCUMENTO_MVM.DT_DATA_EXPEDICAO = DateTime.Parse(exc.GetValue(10).ToString());
                            clienteDetalhe.TB_CLIENTE_DOCUMENTO_MVM.NM_ORGAO_EXPEDITOR = exc.GetValue(11).ToString();
                            clienteDetalhe.TB_CLIENTE_DOCUMENTO_MVM.NM_UF_DOCUMENTO = exc.GetValue(12).ToString();
                            //Endereço
                            clienteDetalhe.TB_CLIENTE_ENDERECO_MVM.ID_CLTE_ENDCO = Convert.ToInt32(exc.GetValue(13).ToString());
                            clienteDetalhe.TB_CLIENTE_ENDERECO_MVM.NM_LOGRADOURO_CLTE_ENDCO = exc.GetValue(14).ToString();
                            clienteDetalhe.TB_CLIENTE_ENDERECO_MVM.NM_NUMERO_CLTE_ENDCO = exc.GetValue(15).ToString();
                            clienteDetalhe.TB_CLIENTE_ENDERECO_MVM.NM_CEP_CLTE_ENDCO = exc.GetValue(16).ToString();
                            clienteDetalhe.TB_CLIENTE_ENDERECO_MVM.NM_COMPLEMENTO_CLTE_ENDCO = exc.GetValue(17).ToString();
                            clienteDetalhe.TB_CLIENTE_ENDERECO_MVM.NM_BAIRRO_CLTE_ENDCO = exc.GetValue(18).ToString();
                            clienteDetalhe.TB_CLIENTE_ENDERECO_MVM.NM_CIDADE_CLTE_ENDCO = exc.GetValue(19).ToString();
                            clienteDetalhe.TB_CLIENTE_ENDERECO_MVM.NM_UNID_FEDE = exc.GetValue(20).ToString();
                        }
                    }
                }

            }
            catch (Exception ex)
            {

                throw new ApplicationException(ex.Message);
            }

            return clienteDetalhe;

        }
    }
}
