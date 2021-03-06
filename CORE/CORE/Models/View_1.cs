using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CORE.Models
{
    class View_1
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
        public static async Task Insert(View_1 transact)
        {
            await App.MobileService.GetTable<View_1>().InsertAsync(transact);
        }

        public static async Task Update(View_1 transact)
        {
            await App.MobileService.GetTable<View_1>().UpdateAsync(transact);
        }
        public static async Task Delete(View_1 transact)
        {
            await App.MobileService.GetTable<View_1>().DeleteAsync(transact);
        }

        public static async Task<List<View_1>> Read()
        {
            var transact = await App.MobileService.GetTable<View_1>().ToListAsync();
            return transact;
        }
    }
}
