using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAPP
{
    public class Data
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }

        public static Data FromCsv(string csvLine)
        {
            Data data = new Data();
            if (!String.IsNullOrEmpty(csvLine))
            {
                string[] values = csvLine.Split(',');
                data.FirstName = values[0];
                data.LastName = values[1];
                data.Address = values[2];
                data.PhoneNumber = values[3];
            }
            return data;
        }

    }
}
