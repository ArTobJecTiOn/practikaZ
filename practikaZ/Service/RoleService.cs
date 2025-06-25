using practikaZ.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practikaZ.Service
{
    internal class RoleService
    {
        public static List<Role> GetRoles(bool excludeAdmin = false)
        {
            using (var context = new MyDbContext())
            {
                var query = context.Roles.AsQueryable();
                if (excludeAdmin)
                    query = query.Where(r => r.Id != 1);
                return query.ToList();
            }
        }
    }
}