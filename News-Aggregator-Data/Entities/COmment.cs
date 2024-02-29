using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace News_Aggregator_Data.Entities
{
    public  class COmment
    {
        [Key]
        public Guid CO_comment_id {  get; set; }
        public Guid CO_art_id { get; set; }
        public Guid CO_user_id { get; set; }
        public string CO_comment { get; set; }
        public bool CO_comm_status { get; set; }

        public /*virtual*/ ARticle ARticle { get; set; }
        public /*virtual*/ USer USer { get; set; }

    }
}
