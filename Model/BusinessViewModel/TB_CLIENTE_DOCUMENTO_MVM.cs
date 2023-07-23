using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.BusinessViewModel
{
   public class TB_CLIENTE_DOCUMENTO_MVM
    {
        public int ID_DOCUMENTO { get; set; }

        [DisplayName("Documento")]
        [Required(ErrorMessage = "Documento é obrigatório", AllowEmptyStrings = false)]
        public string NM_DOCUMENTO { get; set; }

        [DisplayName("Data expedição")]
        [Required(ErrorMessage = "Data expedição", AllowEmptyStrings = false)]
        public System.DateTime DT_DATA_EXPEDICAO { get; set; }

        public int TB_UNIDADE_FEDERATIVA_ID_UNIDE_FEDA { get; set; }
        public int TB_ORGAO_EXPEDIDOR_ID_ORGAO_EXPEDIDOR { get; set; }
    }
}
