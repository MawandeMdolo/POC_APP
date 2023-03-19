using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAPP.Classes
{
    public class SecondList
    {

        public static List<Address> GetSecondList(List<Data> values)
        {

            try
            {
                List<Address> SecondList = new List<Address>();

                foreach (var grp in values.GroupBy(i => i.Address))
                {
                    Address obj = new Address();
                    if (!String.IsNullOrEmpty(grp.Key))
                    {
                        var firstSpaceIndex = grp.Key.IndexOf(" ");
                        obj.StreetNumber = grp.Key.Substring(0, firstSpaceIndex);
                        obj.StreetName = grp.Key.Substring(firstSpaceIndex + 1);
                        SecondList.Add(obj);
                    }

                }

                var orderByStreetNameAkph = SecondList.OrderBy(x => x.StreetName);
                List<Address> sortedList = new List<Address>();
                foreach (var item in orderByStreetNameAkph)
                {
                    Address obj = new Address();
                    obj.StreetNumber = item.StreetNumber;
                    obj.StreetName = item.StreetName;
                    obj.FullAddress = obj.StreetNumber + " " + obj.StreetName;
                    sortedList.Add(obj);

                }

                return sortedList;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
