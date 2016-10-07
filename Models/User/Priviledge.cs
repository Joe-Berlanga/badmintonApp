using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication2.Models.Enum;

namespace WebApplication2.Models.User
{
    [Serializable]
    public class Priviledge
    {
        public PriviledgeEnum PriviledgeId { get; set; }

        public string PriviledgeName { get; set; }
    }
}