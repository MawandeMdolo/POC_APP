using ConsoleAPP;
using ConsoleAPP.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;

namespace ConsoleAPP_UnitTests
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void GetFirstList_FreqFirstLastNameOrderByAlphDesc_ReturnList()
        {
            List<Names> expectedList = new List<Names>();
            expectedList.Add(new Names { Name = "Brown", frequency = 2 });
            expectedList.Add(new Names { Name = "Clive", frequency = 2 });
            expectedList.Add(new Names { Name = "Graham", frequency = 2 });
            expectedList.Add(new Names { Name = "Howe", frequency = 2 });
            expectedList.Add(new Names { Name = "James", frequency = 2 });
            expectedList.Add(new Names { Name = "Owen", frequency = 2 });
            expectedList.Add(new Names { Name = "Smith", frequency = 2 });
            expectedList.Add(new Names { Name = "Jimmy", frequency = 1 });
            expectedList.Add(new Names { Name = "John", frequency = 1 });

            List<Names> list = Program.FreqFirstLastNameOrderByAlphDesc();
            expectedList.Should().BeEquivalentTo(list);
        }
        [TestMethod]
        public void GetSecondList_AddressSortedByStreetName_ReturnList()
        {
            List<Address> expectedList = new List<Address>();
            expectedList.Add(new Address { StreetName = "Ambling Way", StreetNumber = "65", FullAddress = "65 Ambling Way" });
            expectedList.Add(new Address { StreetName = "Crimson Rd", StreetNumber = "8", FullAddress = "8 Crimson Rd" });
            expectedList.Add(new Address { StreetName = "Short Lane", StreetNumber = "78", FullAddress = "78 Short Lane" });
            expectedList.Add(new Address { StreetName = "Howard St", StreetNumber = "12", FullAddress = "12 Howard St" });
            expectedList.Add(new Address { StreetName = "Long Lane", StreetNumber = "102", FullAddress = "102 Long Lane" });
            expectedList.Add(new Address { StreetName = "Roland St", StreetNumber = "94", FullAddress = "94 Roland St" });
            expectedList.Add(new Address { StreetName = "Stewart St", StreetNumber = "82", FullAddress = "82 Stewart St" });
            expectedList.Add(new Address { StreetName = "Sutherland St", StreetNumber = "49", FullAddress = "49 Sutherland St" });
            List<Address> list = Program.AddressSortedByStreetName();
            expectedList.Should().BeEquivalentTo(list);
        }
    }
}
