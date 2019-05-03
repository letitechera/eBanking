using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eBanking.Model.DBModel
{
    public class Account: BaseEntity
    {
        public int AccountTypeId { get; set; }
        public decimal Balance { get; set; }
        public int UserId { get; set; }

        public virtual AccountType AccountType { get; set; }
        [JsonIgnore]
        public virtual User User { get; set; }
        [JsonIgnore]
        public virtual ICollection<Transference> OriginTransferences { get; set; }
        [JsonIgnore]
        public virtual ICollection<Transference> DestinationTransferences { get; set; }
    }
}
