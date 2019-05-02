using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eBanking.Model.DBModel
{
    public class Transference: BaseEntity
    {
        public int OriginAccountId { get; set; }
        public int DestinationAccountId { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }

        [JsonIgnore]
        public virtual Account OriginAccount { get; set; }
        [JsonIgnore]
        public virtual Account DestinationAccount { get; set; }
    }
}
