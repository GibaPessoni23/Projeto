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
    
    public partial class TB_UNIDADE_FEDERATIVA
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TB_UNIDADE_FEDERATIVA()
        {
            this.TB_CLIENTE_DOCUMENTO = new HashSet<TB_CLIENTE_DOCUMENTO>();
            this.TB_CLIENTE_ENDERECO = new HashSet<TB_CLIENTE_ENDERECO>();
        }
    
        public int ID_UNIDE_FEDA { get; set; }
        public string NM_UNIDE_FEDA { get; set; }
        public string ST_UNIDE_FEDA_SIGLA { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TB_CLIENTE_DOCUMENTO> TB_CLIENTE_DOCUMENTO { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TB_CLIENTE_ENDERECO> TB_CLIENTE_ENDERECO { get; set; }
    }
}
