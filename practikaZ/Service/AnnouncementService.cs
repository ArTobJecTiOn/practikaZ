using Microsoft.EntityFrameworkCore;
using practikaZ.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practikaZ.Service
{
    internal class AnnouncementService
    {
        public static List<Announcement> GetAnnounc(int userRoleId)
        {
            using (var context = new MyDbContext())
            {
                return context.Announcements
                    .Include(a => a.Author)
                    .Where(a => a.TargetRoleId == null || a.TargetRoleId == userRoleId)
                    .ToList();
            }
        }
        public static void AddAnnouncement(Announcement announcement)
        {
            using (var context = new MyDbContext())
            {
                context.Announcements.Add(announcement);
                context.SaveChanges();
            }
        }
    }
}