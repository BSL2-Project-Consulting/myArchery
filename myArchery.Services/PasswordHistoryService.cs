using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myArchery.Services
{
    public static class PasswordHistoryService
    {
        public static async Task AddPasswordByUserId(int userId,string pw)
        {
            var user = UserService.GetUserById(userId);
            if (user == null) return;

            var pwh = await GetLatestPasswordByIdAsync(userId);
            
            if (pwh != null)
            {
                pwh.Untildate = DateTime.Now;
                pwh.IsActive = 0;

                using (myarcheryContext db = new myarcheryContext())
                {
                    db.PasswordHistories.Update(pwh);

                    await db.SaveChangesAsync();
                }
            }

            var newPwh = new PasswordHistory
            {
                Fromdate = DateTime.Now,
                Password = pw,
                IsActive = 1,
                UseId = userId
            };

            using (myarcheryContext db = new myarcheryContext())
            {
                db.PasswordHistories.Add(newPwh);

                await db.SaveChangesAsync();
            }
            
        }

        public static async Task<PasswordHistory?> GetLatestPasswordByIdAsync(int userId)
        {
            var user = UserService.GetUserById(userId);
            if (user == null) return null;

            using (myarcheryContext db = new myarcheryContext())
            {
                var tmp = await db.PasswordHistories.FirstAsync(x => x.UseId == userId && x.Untildate == null);
                return tmp;
            }
        }
    }
}
