//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class TB_CLIENTE_DOCUMENTO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TB_CLIENTE_DOCUMENTO()
        {
            this.TB_CLIENTE = new HashSet<TB_CLIENTE>();
        }
    
        public int ID_DOCUMENTO { get; set; }
        public string NM_DOCUMENTO { get; set; }
        public System.DateTime DT_DATA_EXPEDICAO { get; set; }
        public int TB_UNIDADE_FEDERATIVA_ID_UNIDE_FEDA { get; set; }
        public int TB_ORGAO_EXPEDIDOR_ID_ORGAO_EXPEDIDOR { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TB_CLIENTE> TB_CLIENTE { get; set; }
        public virtual TB_ORGAO_EXPEDIDOR TB_ORGAO_EXPEDIDOR { get; set; }
        public virtual TB_UNIDADE_FEDERATIVA TB_UNIDADE_FEDERATIVA { get; set; }
    }
}
