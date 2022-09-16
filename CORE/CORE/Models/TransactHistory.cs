using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CORE.Models
{
    class TransactHistory
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


        public static async Task Insert(TransactHistory transact)
        {
            await App.MobileService.GetTable<TransactHistory>().InsertAsync(transact);
        }

        public static async Task Update(TransactHistory transact)
        {
            await App.MobileService.GetTable<TransactHistory>().UpdateAsync(transact);
        }
        public static async Task Delete(TransactHistory transact)
        {
            await App.MobileService.GetTable<TransactHistory>().DeleteAsync(transact);
        }
        public static async Task<List<TransactHistory>> Read()
        {
            var transact = await App.MobileService.GetTable<TransactHistory>().ToListAsync();
            return transact;
        }
    }
}
