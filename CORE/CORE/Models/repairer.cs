using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CORE.Models
{
    class repairer
    {
        public string id { get; set; }
        public string fname { get; set; }
        public string lname { get; set; }
        public string job { get; set; }
        public string pnum { get; set; }
        public string addr { get; set; }
        public string city { get; set; }
        public string pass { get; set; }
        public string propics { get; set; }
        public string picstr { get; set; }
        public string activetime { get; set; }
        public string statusact { get; set; }
        public string latt { get; set; }
        public string longg { get; set; }
        public string currentloc { get; set; }
        public float star { get; set; }
        public float stars { get; set; }
        public float starss { get; set; }
        public float starsss { get; set; }
        public float starssss { get; set; }
        public float TotalRate { get; set; }

        public static async Task Insert(repairer repairer)
        {
            await App.MobileService.GetTable<repairer>().InsertAsync(repairer);
        }
        public static async Task Update(repairer repairer)
        {
            await App.MobileService.GetTable<repairer>().UpdateAsync(repairer);
        }
        public static async Task<List<repairer>> Read()
        {
            var repairer = await App.MobileService.GetTable<repairer>().ToListAsync();
            return repairer;
        }
    }
}
