using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebEntity.Models;
using Newtonsoft.Json;

namespace WebEntity.Actions
{
    public static class Cheques
    {
        public static string AddNewCheque()
        {
            using (BaseContext context = new BaseContext())
            {

                context.Cheques.Add(new Cheque());
                context.SaveChanges();
            }
            return "OK";
        }

        public static string GetAll()
        {
            string res = "";

            using (BaseContext context = new BaseContext())
            {

                var val = context.Cheques.Where(x => x.Date > DateTime.Now.AddDays(-1)).OrderByDescending(x => x.Date);
                res = JsonConvert.SerializeObject(val);
            }

            return res;
        }


    }
}
