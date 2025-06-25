using Microsoft.EntityFrameworkCore;
using practikaZ.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practikaZ.Service
{
    internal class AchivementService
    {
        public static List<Achievement> GetAchieves(int userId)
        {
            using (var context = new MyDbContext())
            {
                return context.Userachievements
                    .Where(ua => ua.UserId == userId)
                    .Include(ua => ua.Achievement)
                    .Select(ua => ua.Achievement)
                    .ToList();
            }
        }
        public static void AssignAchievement(int userId, int achievementId)
        {
            using (var context = new MyDbContext())
            {
                bool alreadyGiven = context.Userachievements
                    .Any(ua => ua.UserId == userId && ua.AchievementId == achievementId);

                if (!alreadyGiven)
                {
                    var assignment = new Userachievement
                    {
                        UserId = userId,
                        AchievementId = achievementId
                    };

                    context.Userachievements.Add(assignment);
                    context.SaveChanges();
                }
            }
        }
            public static void AddAchievement(Achievement achievement)
        {
            using (var context = new MyDbContext())
            {
                context.Achievements.Add(achievement);
                context.SaveChanges();
            }
        }
        public static List<Achievement> GetAllAchievements()
        {
            using (var context = new MyDbContext())
            {
                return context.Achievements.ToList();
            }
        }
    }
}
