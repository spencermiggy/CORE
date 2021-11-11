using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CORE.Models
{
    class RatingTBLL
    {
        public string id { get; set; }
        public string Repid { get; set; }
        public int TotRate { get; set; }
        public static async Task Insert(RatingTBLL transact)
        {
            await App.MobileService.GetTable<RatingTBLL>().InsertAsync(transact);
        }

        public static async Task Update(RatingTBLL transact)
        {
            await App.MobileService.GetTable<RatingTBLL>().UpdateAsync(transact);
        }
        public static async Task Delete(RatingTBLL transact)
        {
            await App.MobileService.GetTable<RatingTBLL>().DeleteAsync(transact);
        }
        public static async Task<List<RatingTBLL>> Read()
        {
            var transact = await App.MobileService.GetTable<RatingTBLL>().ToListAsync();
            return transact;
        }
    }
}
