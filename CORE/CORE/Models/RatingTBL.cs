using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CORE.Models
{
    class RatingTBL
    {
        public string id { get; set; }
        public string Repid { get; set; }
        public int star { get; set; }
        public int stars { get; set; }
        public int starss { get; set; }
        public int starsss { get; set; }
        public int starssss { get; set; }
        public int CusCount { get; set; }
        public int TotRate { get; set; }

        public static async Task Insert(RatingTBL transact)
        {
            await App.MobileService.GetTable<RatingTBL>().InsertAsync(transact);
        }

        public static async Task Update(RatingTBL transact)
        {
            await App.MobileService.GetTable<RatingTBL>().UpdateAsync(transact);
        }
        public static async Task Delete(RatingTBL transact)
        {
            await App.MobileService.GetTable<RatingTBL>().DeleteAsync(transact);
        }
        public static async Task<List<RatingTBL>> Read()
        {
            var transact = await App.MobileService.GetTable<RatingTBL>().ToListAsync();
            return transact;
        }
    }
}
