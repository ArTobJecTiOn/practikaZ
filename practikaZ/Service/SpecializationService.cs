using practikaZ.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practikaZ.Service
{
    internal class SpecializationService
    {
        public static List<Specialization> GetSpecializations()
        {
            using (var context = new MyDbContext())
            {
                return context.Specializations.ToList();
            }
        }
    }
}

