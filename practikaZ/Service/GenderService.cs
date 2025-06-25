using practikaZ.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practikaZ.Service
{
    internal class GenderService
    {
        public static List<Gender> GetGender()
        {
            using (var context = new MyDbContext())
            {
                return context.Genders.ToList();
            }
        }
    }
}

