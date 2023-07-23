using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.BusinessViewModel
{
    public class TB_CLIENTE_MVM
    {
        public int ID_CLIENTE { get; set; }

        [DisplayName("Nome")]
        [Required(ErrorMessage = "O nome do cliente é obrigatório", AllowEmptyStrings = false)]
        public string NM_NOME { get; set; }

        [DisplayName("CPF")]
        [Required(ErrorMessage = "O CPF do cliente é obrigatório", AllowEmptyStrings = false)]
        public string NM_CPF { get; set; }

        [DisplayName("Data Nascimento")]
        [Required(ErrorMessage = "A Data Nascimento de do cliente é obrigatória", AllowEmptyStrings = false)]
        public System.DateTime DT_NASCIMENTO { get; set; }
        public int TB_CLIENTE_DOCUMENTO_ID_DOCUMENTO { get; set; }
        public int TB_CLIENTE_ENDERECO_ID_CLTE_ENDCO { get; set; }
        public int TB_SEXO_ID_SEXO { get; set; }
        public int TB_ESTADO_CIVIL_ID_ESTD_CIVIL { get; set; }
    }
}
