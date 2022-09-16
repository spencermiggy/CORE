using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CORE.Models
{
    class TransactCus
    {
        public string id { get; set; }
        public string Cfname { get; set; }
        public string Clname { get; set; }
        public string Cnum { get; set; }
        public string Clatt { get; set; }
        public string Clongg { get; set; }
        public string Repid { get; set; }
        public string Cusid { get; set; }
        public string Caddr { get; set; }
        public string Accdec { get; set; }
        public string Transid { get; set; }


        public static async Task Insert(TransactCus transact)
        {
            await App.MobileService.GetTable<TransactCus>().InsertAsync(transact);
        }

        public static async Task Update(TransactCus transact)
        {
            await App.MobileService.GetTable<TransactCus>().UpdateAsync(transact);
        }
        public static async Task Delete(TransactCus transact)
        {
            await App.MobileService.GetTable<TransactCus>().DeleteAsync(transact);
        }
        public static async Task<List<TransactCus>> Read()
        {
            var transact = await App.MobileService.GetTable<TransactCus>().ToListAsync();
            return transact;
        }
    }
}
