using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace News_Aggregator_Data.Entities
{
    public class ARticle
    {
        [Key]
        public Guid AR_art_id { get; set; }
        public string AR_content {  get; set; }
        public string AR_source_adr { get; set; }
        public Guid AR_user_id { get; set; }
        public int AR_positivity {  get; set; }
        public bool AR_art_status {  get; set; }
        
        public /*virtual*/ ICollection <COmment> COmments { get; set; }
        public /*virtual*/ USer USers { get; set; }
    }
}
