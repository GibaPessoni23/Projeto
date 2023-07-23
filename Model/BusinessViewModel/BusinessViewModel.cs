

using Model.BusinessModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Model.BusinessViewModel
{
   public class BusinessViewModel
    {


        public BusinessViewModel()
        {
            TB_CLIENTE_MVM = new TB_CLIENTE();
            TB_CLIENTE_DOCUMENTO_MVM = new TB_CLIENTE_DOCUMENTO();
            TB_CLIENTE_ENDERECO_MVM = new TB_CLIENTE_ENDERECO();
        }
                

        [DisplayName("Nome")]
        [Required]
        [MaxLength(100)]
        public string NM_NOME { get; set; }

        [DisplayName("CPF")]
        [Required]
        [MaxLength(14)]
        public string NM_CPF { get; set; }

        [DisplayName("Data Nascimento")]
      
        [DataType(DataType.Date)]
        public DateTime DT_NASCIMENTO { get; set; }
       


        public int ID_DOCUMENTO { get; set; }

        [DisplayName("RG")]
        [Required]
        [MaxLength(50)]
        public string NM_DOCUMENTO { get; set; }

        [DisplayName("Data expedição")]       
        [DataType(DataType.Date)]
        public DateTime DT_DATA_EXPEDICAO { get; set; }


        [DisplayName("Logradouro")]
        [Required]
        [MaxLength(100)]
        public string NM_LOGRADOURO_CLTE_ENDCO { get; set; }


        [DisplayName("Número")]
        [Required]
        [MaxLength(20)]
        public string NM_NUMERO_CLTE_ENDCO { get; set; }


        [DisplayName("CEP")]
        [Required]
        [MaxLength(20)]
        public string NM_CEP_CLTE_ENDCO { get; set; }


        [MaxLength(50)]
        [DisplayName("Complemento")]     
        public string NM_COMPLEMENTO_CLTE_ENDCO { get; set; }


        [MaxLength(50)]
        [DisplayName("Bairro")]
        [Required]
        public string NM_BAIRRO_CLTE_ENDCO { get; set; }


        [MaxLength(50)]
        [DisplayName("Cidade")]
        [Required]
        public string NM_CIDADE_CLTE_ENDCO { get; set; }        

        public TB_CLIENTE TB_CLIENTE_MVM { get; set; }
        public TB_CLIENTE_DOCUMENTO TB_CLIENTE_DOCUMENTO_MVM { get; set; }
        public TB_CLIENTE_ENDERECO TB_CLIENTE_ENDERECO_MVM { get; set; }
       
    }
}
