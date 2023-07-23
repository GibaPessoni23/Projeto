using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.BusinessViewModel
{
   public class TB_CLIENTE_ENDERECO_MVM
    {
        public int ID_CLTE_ENDCO { get; set; }

        [DisplayName("Endereço")]
        [Required(ErrorMessage = "Logradouro é obrigatório", AllowEmptyStrings = false)]
        public string NM_LOGRADOURO_CLTE_ENDCO { get; set; }

        [DisplayName("Número")]
        [Required(ErrorMessage = "Número é obrigatório", AllowEmptyStrings = false)]
        public string NM_NUMERO_CLTE_ENDCO { get; set; }

        [DisplayName("CEP")]
        [Required(ErrorMessage = "CEP é obrigatório", AllowEmptyStrings = false)]
        public string NM_CEP_CLTE_ENDCO { get; set; }

        [DisplayName("Complemento")]      
        public string NM_COMPLEMENTO_CLTE_ENDCO { get; set; }

        [DisplayName("Bairro")]
        [Required(ErrorMessage = "Bairro é obrigatório", AllowEmptyStrings = false)]
        public string NM_BAIRRO_CLTE_ENDCO { get; set; }

        [DisplayName("CIdade")]
        [Required(ErrorMessage = "Cidade é obrigatório", AllowEmptyStrings = false)]
        public string NM_CIDADE_CLTE_ENDCO { get; set; }

      
        public int TB_UNIDADE_FEDERATIVA_ID_UNIDE_FEDA { get; set; }
    }
}
