using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CORE.Models
{
    class tbl_rating
    {
        public string id { get; set; }
        public int ratedrep { get; set; }

        public static async Task Insert(tbl_rating tbl_Rating)
        {
            await App.MobileService.GetTable<tbl_rating>().InsertAsync(tbl_Rating);
        }

        public static async Task Update(tbl_rating tbl_Rating)
        {
            await App.MobileService.GetTable<tbl_rating>().UpdateAsync(tbl_Rating);
        }
        public static async Task<List<tbl_rating>> Read()
        {
            var tbl_Ratings = await App.MobileService.GetTable<tbl_rating>().ToListAsync();
            return tbl_Ratings;
        }
    }
}
