using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace CORE.Models
{
    public class customer
    {
        public string id { get; set; }
        public string fname { get; set; }
        public string lname { get; set; }
        public string pnum { get; set; }
        public string addr { get; set; }
        public string city { get; set; }
        public string pass { get; set; }
        public string propics { get; set; }
        public string picstr { get; set; }

        public static async Task Insert(customer customer)
        {
            await App.MobileService.GetTable<customer>().InsertAsync(customer);
        }

        public static async Task Update(customer customer)
        {
            await App.MobileService.GetTable<customer>().UpdateAsync(customer);
        }
        public static async Task<List<customer>> Read()
        {
            var customer = await App.MobileService.GetTable<customer>().ToListAsync();
            return customer;
        }
    }
}
