using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAPP.Classes
{
    public class FirstList
    {

        public static List<Names> GetFirstList(List<Data> values)
        {
            try
            {
                List<Names> firstList = new List<Names>();

                foreach (var grp in values.GroupBy(i => i.FirstName))
                {
                    Names obj = new Names();
                    if (!String.IsNullOrEmpty(grp.Key))
                    {
                        obj.frequency = grp.Count();
                        obj.Name = grp.Key;
                        firstList.Add(obj);
                    }

                }
                foreach (var grp in values.GroupBy(i => i.LastName))
                {
                    Names obj = new Names();
                    if (!String.IsNullOrEmpty(grp.Key))
                    {
                        obj.frequency = grp.Count();
                        obj.Name = grp.Key;
                        firstList.Add(obj);
                    }
                }
                var orderByAlphAsc = firstList.OrderBy(x => x.Name);
                var orderByFreqDesc= orderByAlphAsc.OrderByDescending(x => x.frequency);                                               
                return orderByFreqDesc.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
