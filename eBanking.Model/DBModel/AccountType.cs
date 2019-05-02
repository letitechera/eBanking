using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eBanking.Model.DBModel
{
    public class AccountType: BaseEntity
    {
        public string Name { get; set; }
    }
}
