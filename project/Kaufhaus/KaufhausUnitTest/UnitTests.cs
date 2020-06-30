using Kaufhaus;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace KaufhausUnitTest
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void TestReorderMethod()
        {
            Stock stock = new Stock();

            try
            {
                stock.ReOrder();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        [TestMethod]
        public void TestCustomerAvoidsBuy()
        {
            Simulation simulator = new Simulation();
            simulator.PopulateProductsToChoose();

            List<Product> testProductList = new List<Product>();
            testProductList.Add(new Product("test", 100, 200, 50, 10));

            simulator.CustomerProductDecision(testProductList);
        }

        [TestMethod]
        public void TestDepartmentsHaveEmployees()
        {
            Mall mall = new Mall("Testgeschäft", "Teststraße 2, 00000 Teststadt, Testistan");
            Department department = new Department("", 0, "");

            mall.GetDepartmentList();

            foreach (Department dep in mall.GetMallDepartmentList())
            {
                foreach (Officer emp in department.GetCompleteOfficerList())
                {
                    //Jede Abteilung hat mindestens einen Abteilungsleiter...
                    Assert.IsTrue(department.GetCompleteOfficerList().Count >= mall.GetMallDepartmentList().Count);

                    if (dep.GetOfficer() == emp.GetName())
                    {
                        //Jeder Abteilungsleiter hat mindestens 2 Angestellte unter sich...
                        Assert.IsTrue(emp.GetOfficersEmployees().Count >= 2);
                    }
                    else
                    {
                        Assert.Fail("Something went wrong");
                    }
                }
            }
            //Jede Abteilung hat mind. 1 Abteilungsleiter, Jeder Abteilungsleiter hat mind. 2 Angestellte unter sich
            Console.WriteLine("Test bestanden!");
        }
    }
}