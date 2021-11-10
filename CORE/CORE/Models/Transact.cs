using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace CORE.Models
{
    class Transact
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


        public static async Task Insert(Transact transact)
        {
            await App.MobileService.GetTable<Transact>().InsertAsync(transact);
        }

        public static async Task Update(Transact transact)
        {
            await App.MobileService.GetTable<Transact>().UpdateAsync(transact);
        }
        public static async Task Delete(Transact transact)
        {
            await App.MobileService.GetTable<Transact>().DeleteAsync(transact);
        }
        public static async Task<List<Transact>> Read()
        {
            var transact = await App.MobileService.GetTable<Transact>().ToListAsync();
            return transact;
        }
    }
}
