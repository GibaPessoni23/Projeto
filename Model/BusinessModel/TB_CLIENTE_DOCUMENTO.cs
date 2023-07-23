using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.BusinessModel
{
   public class TB_CLIENTE_DOCUMENTO
    {
        
        public TB_CLIENTE_DOCUMENTO()
        {
           
        }

        public int ID_DOCUMENTO { get; set; }

        [Required]
        [DisplayName("RG")]
        public string NM_DOCUMENTO { get; set; }


        [DisplayName("Data expedição")]      
        [DataType(DataType.Date)]
       
        public DateTime DT_DATA_EXPEDICAO { get; set; }



        [DisplayName("Orgão expedição")]
        public string NM_ORGAO_EXPEDITOR { get; set; }

        [DisplayName("UF expedição")]
        [MaxLength(10)]
        public string NM_UF_DOCUMENTO { get; set; }

        

    }
}
