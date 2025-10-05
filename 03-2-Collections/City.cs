using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_2_Collections
{
    internal class City : IEquatable<City> // implement IEquatable interface to delete duplication automatically (for classes (object))
    {

        // how HashSet<T> knows if an object exists

        /// الفكرة ان اكتر من اوبجكت ممكن يبقي لهم نفس الهاش .. بيتحطوا في باكيت
        /// 
        /// ال HashSet<T>
        /// الاول بيجيب الباكيت دي باستخدام GetHasCode()
        /// فممكن يبقي اكتر من اوبجكت في الباكيت دي لان لهم نفس الهاش
        /// بعد كده يستخدم الدالة Equals
        /// عشان يتأكد اذا كان الاوبجكت موجود ولا لا
        public int CityId { get; set; }
        public string CityName { get; set; }
        public string Country { get; set; }

        public bool Equals(City city)
        {
            return this.CityName.Equals(city.CityName); // better to use CityId not CityName
        }
        public override int GetHashCode()
        {
            return this.CityName.GetHashCode(); // // better to use CityId not CityName
        }

    }
}
