using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace News_Aggregator_Data.Entities
{
    public class USer
    {
        [Key]
        public Guid US_user_id {  get; set; }
        public string US_user_name { get; set; }
        public string US_email { get; set; }
        public string US_user_role { get; set; }
        public bool US_user_status {  get; set; }
        public int US_positivity_treshold { get; set; }
        public /*virtual*/ ICollection<COmment> COmments { get; set; }
        public /*virtual*/ ICollection<ARticle> ARticles { get; set;}
    }
}
