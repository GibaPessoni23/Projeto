using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.BusinessViewModel
{
   public class BusinessViewListModel
    {
        public int ID_CLIENTE { get; set; }
        [DisplayName("Nome")]
        public string NM_NOME { get; set; }
        [DisplayName("CPF")]
        public string NM_CPF { get; set; }
        [DisplayName("Documento")]
        public string NM_DOCUMENTO { get; set; }
        [DisplayName("Sexo")]
        public string NM_SEXO { get; set; }
        [DisplayName("Estado Civil")]
        public string NM_ESTD_CIVIL { get; set; }
    }
}
