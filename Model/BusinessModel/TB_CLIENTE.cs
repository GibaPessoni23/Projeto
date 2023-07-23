using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.BusinessModel
{
    public class TB_CLIENTE
    {
        public int ID_CLIENTE { get; set; }
        [DisplayName("Nome")]
        [Required(ErrorMessage ="Nome é obrigatório")]
        public string NM_NOME { get; set; }
        [DisplayName("CPF")]
        [Required(ErrorMessage = "CPF é obrigatório")]
        public string NM_CPF { get; set; }
        [DisplayName("Data Nascimento")]

        [DataType(DataType.Date)]        
        public DateTime DT_NASCIMENTO { get; set; }
        public int TB_CLIENTE_DOCUMENTO_ID_DOCUMENTO { get; set; }
        public int TB_CLIENTE_ENDERECO_ID_CLTE_ENDCO { get; set; }
        [DisplayName("Sexo")]
        public string NM_SEXO { get; set; }
        [DisplayName("Estado Civil")]
        public string NM_ESTADO_CIVI { get; set; }

    }
}
