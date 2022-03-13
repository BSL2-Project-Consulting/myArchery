using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myArchery.Services
{
    public static class PasswordHistoryService
    {
        public static void ClearDb()
        {
            using (myarcheryContext db = new myarcheryContext())
            {
                db.RemoveRange(100);
                db.SaveChanges();
            }
        }
    }
}
