using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eBanking.Model.DBModel
{
    public class User: BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string IdNumber { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [JsonIgnore]
        public virtual ICollection<Account> Accounts { get; set; }

    }
}
