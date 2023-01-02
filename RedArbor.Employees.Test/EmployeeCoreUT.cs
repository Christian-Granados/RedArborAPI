using AutoMapper;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace RedArbor.Employees.Test
{
    [TestFixture]
    public class EmployeeProcessUnitTest
    {

        Mock<DAL.Interfaces.IEmployeeDAL> mockEmployeeDAL;
        readonly IMapper mapper = new MapperConfiguration(mapperConfig => { mapperConfig.AddProfile(new Maps.EmployeesMapping()); }).CreateMapper();
        Core.EmployeeCore processTested;

        private static readonly object[] _sourceListEmployeeTest ={  new List<Core.Models.Employee>
            {
               ProcessEmployeeTest
            }
        };

        private static readonly List<DAL.Entities.Employee> DALEmployeeListTest = new()
        {
               DALEmployeeTest
            };
        private static readonly DAL.Entities.Employee DALEmployeeTest = new()
        {
            Id = 1,
            CompanyId = 1,
            CreatedOn = DateTime.Parse("2000-01-01 00:00:00"),
            DeletedOn = DateTime.Parse("2000-01-01 00:00:00"),
            Email = "test1@test.test.tmp",
            Fax = "000.000.000",
            Name = "test1",
            LastLogin = DateTime.Parse("2000-01-01 00:00:00"),
            Password = "test1",
            PortalId = 1,
            RoleId = 1,
            StatusId = 1,
            Telephone = "000.000.000",
            UpdatedOn = DateTime.Parse("2000-01-01 00:00:00"),
            Username = "test1"
        };

        private static readonly Core.Models.Employee ProcessEmployeeTest = new()
        {
            Id = 1,
            CompanyId = 1,
            CreatedOn = DateTime.Parse("2000-01-01 00:00:00"),
            DeletedOn = DateTime.Parse("2000-01-01 00:00:00"),
            Email = "test1@test.test.tmp",
            Fax = "000.000.000",
            Name = "test1",
            LastLogin = DateTime.Parse("2000-01-01 00:00:00"),
            Password = "test1",
            PortalId = 1,
            RoleId = 1,
            StatusId = 1,
            Telephone = "000.000.000",
            UpdatedOn = DateTime.Parse("2000-01-01 00:00:00"),
            Username = "test1"
        };

        private static readonly object[] _sourceIdTest = { ProcessEmployeeTest };

        [TestCaseSource("_sourceListEmployeeTest")]
        public void GetAll_ReturnsExpectedResult(List<Core.Models.Employee> expectedResult)
        {

            mockEmployeeDAL = new Mock<DAL.Interfaces.IEmployeeDAL>(MockBehavior.Strict);
            mockEmployeeDAL.Setup(a => a.GetEmployees()).Returns(DALEmployeeListTest);

            processTested = new Core.EmployeeCore(mapper, mockEmployeeDAL.Object);
            var result = processTested.GetEmployees();

            Assert.IsTrue(result.ToList().ToString() == expectedResult.ToString());

        }

        [Test, TestCaseSource("_sourceIdTest")]
        public void GetById_ReturnsExpectedResult(Core.Models.Employee expectedResult)
        {
            int id = 1;
            //Process.Models.Employee expectedResult = ProcessEmployeeTest;
            mockEmployeeDAL = new Mock<DAL.Interfaces.IEmployeeDAL>(MockBehavior.Strict);
            mockEmployeeDAL.Setup(a => a.GetEmployee(id)).Returns(DALEmployeeTest);

            processTested = new Core.EmployeeCore(mapper, mockEmployeeDAL.Object);
            var result = processTested.GetEmployee(id);

            Assert.IsTrue(result.ToString() == expectedResult.ToString());
        }

        [Test, TestCaseSource("_sourceIdTest")]
        public void Add_ReturnsExpectedResult(Core.Models.Employee expectedResult)
        {
            Core.Models.Employee ProcessEmployee = ProcessEmployeeTest;
            mockEmployeeDAL = new Mock<DAL.Interfaces.IEmployeeDAL>(MockBehavior.Strict);
            mockEmployeeDAL.Setup(a => a.AddEmployee(It.IsAny<DAL.Entities.Employee>())).Returns(DALEmployeeTest);

            processTested = new Core.EmployeeCore(mapper, mockEmployeeDAL.Object);
            Core.Models.Employee result = processTested.AddEmployee(ProcessEmployee);


            Assert.IsTrue(result.ToString() == expectedResult.ToString());
        }

        [TestCase(1)]
        public void Delete_ReturnsExpectedResult(int id)
        {

            mockEmployeeDAL = new Mock<DAL.Interfaces.IEmployeeDAL>(MockBehavior.Strict);
            mockEmployeeDAL.Setup(a => a.DeleteEmployee(id));

            processTested = new Core.EmployeeCore(mapper, mockEmployeeDAL.Object);
            Assert.DoesNotThrow(() => processTested.DeleteEmployee(id));
        }


    }
}