using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.BusinessModel
{
    public class TB_CLIENTE_ENDERECO
    {
        
        public TB_CLIENTE_ENDERECO()
        {
        }

        public int ID_CLTE_ENDCO { get; set; }
        [DisplayName("Logradouro")]
        [Required]
        [MaxLength(100)]
        public string NM_LOGRADOURO_CLTE_ENDCO { get; set; }


        [DisplayName("Número")]
        [MaxLength(20)]
        [Required]
        public string NM_NUMERO_CLTE_ENDCO { get; set; }

        [DisplayName("CEP")]
        [MaxLength(20)]
        [Required]
        public string NM_CEP_CLTE_ENDCO { get; set; }


        [DisplayName("Complemento")]
        [MaxLength(50)]
        public string NM_COMPLEMENTO_CLTE_ENDCO { get; set; }


        [MaxLength(50)]
        [Required]
        [DisplayName("Bairro")]
        public string NM_BAIRRO_CLTE_ENDCO { get; set; }

        [MaxLength(50)]
        [DisplayName("Cidade")]
        [Required]
        public string NM_CIDADE_CLTE_ENDCO { get; set; }

        [MaxLength(50)]
        [DisplayName("UF")]
        [Required]
        public string NM_UNID_FEDE { get; set; }
       
    }
}
