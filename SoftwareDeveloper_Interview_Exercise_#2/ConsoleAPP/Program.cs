using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Windows;
using System.IO;
using ConsoleAPP.Classes;

namespace ConsoleAPP
{
    public class Program
    {
        private static string fullPathCSV = ConfigurationManager.AppSettings["FileServerPathCSV"];
        private static string pathText = ConfigurationManager.AppSettings["FileServerPathTEXT"];
        public static void Main(string[] args)
        {
            List<Data> values = File.ReadAllLines(fullPathCSV)
                                        .Skip(1)
                                        .Select(v => Data.FromCsv(v))
                                        .ToList();


            #region firstlist
            var firstList = FirstList.GetFirstList(values);

            var fullPathText = pathText + "FirstOutPut.txt";
            File.WriteAllText(fullPathText, String.Empty);
            TextWriter tw = new StreamWriter(fullPathText, true);

            foreach (var item in firstList)
            {
                tw.WriteLine(item.Name + "," + item.frequency);
            }
            tw.Close();
            string readText = File.ReadAllText(fullPathText);
            Console.WriteLine(readText);
            #endregion


            #region second list
            var secondList = SecondList.GetSecondList(values);

            var fullPathText2 = pathText + "SecondOutPut.txt";
            File.WriteAllText(fullPathText2, String.Empty);
            TextWriter tw2 = new StreamWriter(fullPathText2, true);

            foreach (var item in secondList)
            {
                tw2.WriteLine(item.FullAddress);
            }
            tw2.Close();
            string readText2 = File.ReadAllText(fullPathText2);
            Console.WriteLine(readText2);
            #endregion

            Console.ReadLine();

        }
        public static List<Data> ReadCSV()
        {
            string csv = ConfigurationManager.AppSettings["FileServerPathCSV"];
            List<Data> values = File.ReadAllLines(csv)
                                           .Skip(1)
                                           .Select(v => Data.FromCsv(v))
                                           .ToList();
            return values;

        }
        public static  List<Names> FreqFirstLastNameOrderByAlphDesc()
        {
         
            return FirstList.GetFirstList(ReadCSV());

        }
        public static List<Address> AddressSortedByStreetName()
        {

            return SecondList.GetSecondList(ReadCSV());

        }
    }
}
