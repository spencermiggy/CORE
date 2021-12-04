using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CORE.View
{
    public class PickerMVVMViewModel : INotifyPropertyChanged
    {
        public List<City> statuslist { get; set; }
        public List<City> timelist { get; set; }


        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        protected void OnPropertyChanged1([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private string statusI;
        public string mystat
        {
            get { return statusI; }
            set
            {
                if (statusI != value)
                {
                    statusI = value;
                    OnPropertyChanged();
                }
            }
        }
        private string timeI;
        public string mytime
        {
            get { return timeI; }
            set
            {
                if (timeI != value)
                {
                    timeI = value;
                    OnPropertyChanged1();
                }
            }
        }

        private City _selectedstat { get; set; }
        public City Selectedstat
        {
            get { return _selectedstat; }
            set
            {
                if (_selectedstat != value)
                {
                    _selectedstat = value;
                    // Do whatever functionality you want...When a selectedItem is changed..
                    // write code here..
                    mystat = _selectedstat.Value;
                }
            }
        }
        private City _selectedtime { get; set; }
        public City Selectedtime
        {
            get { return _selectedtime; }
            set
            {
                if (_selectedtime != value)
                {
                    _selectedtime = value;
                    // Do whatever functionality you want...When a selectedItem is changed..
                    // write code here..
                    mytime = _selectedtime.Values;
                }
            }
        }





        public PickerMVVMViewModel()
        {
            statuslist = GetCities().OrderBy(t => t.Value).ToList();
            mystat = "";
            timelist = GetCities1().OrderBy(t => t.Values).ToList();
            mytime = "";
        }
        public List<City> GetCities()
        {
            var cities = new List<City>()
            {
                new City(){Key =  1, Value= "Active"},
                new City(){Key =  2, Value= "Inactive"}
            };

            return cities;
        }
        public List<City> GetCities1()
        {
            var citiess = new List<City>()
            {
                new City(){Keys =  1, Values= "Available"},
                new City(){Keys =  2, Values= "Not Available"}
            };

            return citiess;
        }
    }


    public class City
    {
        public int Key { get; set; }
        public string Value { get; set; }
        public int Keys { get; set; }
        public string Values { get; set; }
    }


}
