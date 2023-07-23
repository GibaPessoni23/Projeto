<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebForms._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
     
       
    <h4>Sistema de Gestão de Clientes</h4>
    <p>&nbsp;</p>
    <asp:Label ID="lblMsg" runat="server"></asp:Label>
    <h6>Cliente</h6>
    <table>
        <tr>
            <td></td>
            <td>
                <asp:HiddenField ID="txt_ID_CLIENTE" runat="server"></asp:HiddenField>
            </td>
        </tr>
        <tr>
            <td>Nome *:
            </td>
            <td>
                <asp:TextBox ID="txtNome" runat="server" required="true" Width="299px"></asp:TextBox>
                <%--    <asp:RequiredFieldValidator id="clienteNome" runat="server" ControlToValidate="txtNome" ErrorMessage="Nome é obrigatório" ForeColor="Red">

                </asp:RequiredFieldValidator> --%> 
            </td>
        </tr>
        <tr>
            <asp:Label ID="Label2" runat="server"></asp:Label>
            <td>CPF *:</td>
            <td>
                <asp:TextBox ID="txtCpf" runat="server" AutoPostBack="true" Style="width: 300px" OnTextChanged="txtCpf_TextChanged" required="true"></asp:TextBox>
                <%--         <asp:RequiredFieldValidator id="clienteCPF" runat="server" ControlToValidate="txtCpf" ErrorMessage="Cpf é obrigatório" ForeColor="Red">
                      </asp:RequiredFieldValidator>  --%>
            </td>
        </tr>
        <tr>
            <td>Data Nascimento * :
            </td>
            <td>
                <asp:TextBox ID="txtNasc" runat="server" Style="width: 300px" TextMode="Date" min="1900-01-01" max="2022-12-31"></asp:TextBox>
                <%--    <asp:RequiredFieldValidator id="dataNascimentoCliente" runat="server" ControlToValidate="txtNasc" ErrorMessage="Data de Nascimento é obrigatório" ForeColor="Red">
                      </asp:RequiredFieldValidator>  --%>
            </td>
        </tr>
        <tr>
            <td>Sexo *:
            </td>
            <td>
                <asp:DropDownList ID="sexoList" runat="Server">
                    <asp:ListItem Text="MASCULINO" Value="MASCULINO" />
                    <asp:ListItem Text="FEMININO" Value="FEMININO" />
                </asp:DropDownList>

            </td>
        </tr>
        <tr>
            <td>Estado Civil *:
            </td>
            <td>
                <asp:DropDownList ID="civilList" runat="Server">
                    <asp:ListItem Text="SOLTEIRO" Value="SOLTEIRO" />
                    <asp:ListItem Text="CASADO" Value="CASADO" />
                    <asp:ListItem Text="SEPARADO" Value="SEPARADO" />
                </asp:DropDownList>
            </td>
        </tr>

    </table>

    <p>&nbsp;</p>
    <h6>Documento</h6>
    <table>
        <tr>
            <td></td>
            <td>
                <asp:HiddenField ID="txt_ID_CLIENTE_Documento" runat="server"></asp:HiddenField>
            </td>
        </tr>
        <tr>
            <td>RG :
            </td>
            <td>
                <asp:TextBox ID="txt_NM_CLIENTE_Documento" runat="server" Style="width: 300px" required="true"></asp:TextBox>

            </td>
        </tr>
        <tr>
            <td>Data expedição :
            </td>
            <td>
                <asp:TextBox ID="txt_DT_CLIENTE_Documento" runat="server" Style="width: 300px" min="1900-01-01" max="2022-12-31" TextMode="Date" ></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Orgão Expedidor :
            </td>
            <td>
                <asp:DropDownList ID="orgaoList" runat="Server">
                    <asp:ListItem Text="SSP" Value="SSP" />
                    <asp:ListItem Text="AGU" Value="AGU" />
                    <asp:ListItem Text="Outros" Value="Outros" />
                </asp:DropDownList>
            </td>
        </tr>

        <tr>
            <td>UF Expedição :
            </td>
            <td>
                <asp:DropDownList ID="uf_Expedicao_Documento" runat="Server">
                    <asp:ListItem Text="SP" Value="SP" />
                    <asp:ListItem Text="DF" Value="DF" />
                    <asp:ListItem Text="Outros" Value="Outros" />
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td colspan="2">&nbsp;</td>
        </tr>
    </table>

    <h6>Endereço</h6>
    <table>
        <tr>
            <td></td>
            <td>
                <asp:HiddenField ID="txt_ID_CLIENTE_Endereco" runat="server"></asp:HiddenField>
            </td>
        </tr>
        <tr>
            <td>Cep :
            </td>
            <td>
                <asp:TextBox ID="txt_Cep_CLIENTE_Endereco" runat="server" Style="width: 300px" AutoPostBack="true"  OnTextChanged="txt_Cep_CLIENTE_Endereco_TextChanged" required="true"></asp:TextBox>
                <%--      <asp:RequiredFieldValidator id="clienteCep" runat="server" ControlToValidate="txt_Cep_CLIENTE_Endereco" ErrorMessage="CEP é obrigatório" ForeColor="Red">
                      </asp:RequiredFieldValidator>--%>
            </td>
        </tr>
        <tr>
            <td>Logradouro :
            </td>
            <td>
                <asp:TextBox ID="txt_Logr_CLIENTE_Endereco" runat="server" Style="width: 300px"></asp:TextBox>
                <%--        <asp:RequiredFieldValidator id="logradouroEnderecoCliente" runat="server" ControlToValidate="txt_Logr_CLIENTE_Endereco" ErrorMessage="Logradouro é obrigatório" ForeColor="Red">
                      </asp:RequiredFieldValidator>--%>
            </td>
        </tr>
        <tr>
            <td>Número :
            </td>
            <td>
                <asp:TextBox ID="txt_Num_CLIENTE_Endereco" runat="server" Style="width: 300px" required="true"></asp:TextBox>
                <%--      <asp:RequiredFieldValidator id="clienteEnderecoNumero" runat="server" ControlToValidate="txt_Num_CLIENTE_Endereco" ErrorMessage="Número é obrigatório" ForeColor="Red">
                      </asp:RequiredFieldValidator>--%>
            </td>
        </tr>

        <tr>
            <td>Complemento :
            </td>
            <td>
                <asp:TextBox ID="txt_Comp_CLIENTE_Endereco" runat="server" Style="width: 300px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Bairro :
            </td>
            <td>
                <asp:TextBox ID="txt_Bairro_CLIENTE_Endereco" runat="server" Style="width: 300px"></asp:TextBox>
                <%--   <asp:RequiredFieldValidator id="clienteBairro" runat="server" ControlToValidate="txt_Bairro_CLIENTE_Endereco" ErrorMessage="Bairro é obrigatório" ForeColor="Red">
                      </asp:RequiredFieldValidator>--%>
            </td>
        </tr>
        <tr>
            <td>Cidade :
            </td>
             <td>
                <asp:TextBox ID="txt_Cid_CLIENTE_Endereco" runat="server" Style="width: 300px"></asp:TextBox>
                <%--        <asp:RequiredFieldValidator id="clienteCidade" runat="server" ControlToValidate="txt_Cid_CLIENTE_Endereco" ErrorMessage="Cidade é obrigatório" ForeColor="Red">
                      </asp:RequiredFieldValidator>--%>
            </td>
            
        </tr>
        <tr>
            <td>UF:
            </td>
           <td>
                <asp:TextBox ID="txt_uf_CLIENTE_Endereco" runat="server" Style="width: 300px"></asp:TextBox>
                <%--        <asp:RequiredFieldValidator id="clienteCidade" runat="server" ControlToValidate="txt_Cid_CLIENTE_Endereco" ErrorMessage="Cidade é obrigatório" ForeColor="Red">
                      </asp:RequiredFieldValidator>--%>
            </td>
        </tr>
        <tr>
            <td colspan="2">&nbsp;</td>
        </tr>
    </table>
    <table>


        <tr>
            <td colspan="2">
                <asp:Button ID="ButtonInsert" runat="server" Text="Criar Cliente" OnClick="InsertButton_Click" />
                <asp:Button ID="ButtonUpdate" runat="server" Visible="false" Text="Alterar Cliente" OnClick="EditButton_Click" />
                <asp:Button ID="ButtonDelete" runat="server" Visible="false" Text="Deletar Cliente" OnClick="DeleteButton_Click" />
            </td>
        </tr>
    </table>
     <p>&nbsp;</p>
     <p>&nbsp;</p>
    
    <h3>Listagem de Clientes</h3>

    <asp:GridView ID="GridViewCliente" DataKeyNames="ID_CLIENTE" AutoGenerateColumns="false"
        runat="server" OnSelectedIndexChanged="GridViewCliente_SelectedIndexChanged" Width="887px">
        <HeaderStyle BackColor="#0A9A9A" ForeColor="White" Font-Bold="true" Height="30" />
        <AlternatingRowStyle BackColor="#f5f5f5" />
        <Columns>
            <asp:TemplateField HeaderText="Ações">
                <ItemTemplate>
                    <asp:LinkButton ID="lbtnSelect" runat="server" CommandName="Select" Text="Alterar/Excluir" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Código">
                <ItemTemplate>
                    <asp:Label ID="lblID_CLIENTE" runat="server" Text='<%#Eval("ID_CLIENTE") %>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Nome">
                <ItemTemplate>
                    <asp:Label ID="lblNM_CLIENTE" runat="server" Text='<%#Eval("NM_NOME") %>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="CPF">
                <ItemTemplate>
                    <asp:Label ID="lblLastNM_CPF" runat="server" Text='<%#Eval("NM_CPF") %>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="RG.">
                <ItemTemplate>
                    <asp:Label ID="lblNM_DOCUMENTO" runat="server" Text='<%#Eval("NM_DOCUMENTO") %>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Sexo">
                <ItemTemplate>
                    <asp:Label ID="lblNM_SEXO" runat="server" Text='<%#Eval("NM_SEXO") %>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Estado Civil">
                <ItemTemplate>
                    <asp:Label ID="lblNM_ESTD_CIVIL" runat="server" Text='<%#Eval("NM_ESTD_CIVIL") %>' />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>



    </table>
  


    </table>
  
   

</asp:Content>



