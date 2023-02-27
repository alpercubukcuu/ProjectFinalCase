using Core.Domain.Common;
using Core.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Entities.Roles
{
    public class Role
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }

        public IQueryable<User> Users { get; set; }
    }
}
