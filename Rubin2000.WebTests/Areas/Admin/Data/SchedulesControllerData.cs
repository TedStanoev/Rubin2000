using Rubin2000.Models;
using Rubin2000.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

using static Rubin2000.Global.FormatConstants;
using static Rubin2000.Global.WebTestConstants;

namespace Rubin2000.WebTests.Areas.Admin.Data
{
    public static class SchedulesControllerData
    {
        public static Appointment DeleteAppointment()
            => new()
            {
                Id = AppointmentId,
                Schedule = new Schedule
                {
                    Id = ScheduleId,
                    Employee = new Employee()
                },
                ScheduleId = ScheduleId
            };

        public static Appointment ApproveAppointment()
            => new()
            {
                Id = AppointmentId,
                Schedule = new Schedule
                {
                    Id = ScheduleId,
                    Employee = new Employee()
                }
            };

        public static Schedule Schedule()
            => new()
            {
                Id = ScheduleId,
                Employee = new Employee
                {
                    ScheduleId = ScheduleId
                },
                Appointments = Enumerable.Range(0, 2)
                    .Select(a => new Appointment
                    {
                        ScheduleId = ScheduleId,
                        Procedure = new Procedure(),
                        Creator = new AppUser()
                    })
                    .ToList()
            };

        public static IEnumerable<Appointment> Appointments()
            => Enumerable.Range(0, 2)
                .Select(a => new Appointment
                {
                    ScheduleId = ScheduleId,
                    Procedure = new Procedure(),
                    Creator = new AppUser()
                });

        public static IEnumerable<Employee> EmployeesWithSchedules()
        {
            var employeeList = new List<Employee>(2);

            var employee1 = new Employee
            {
                Id = "EmployeeId1",
                Name = "EmployeeName1",
                Schedule = new Schedule
                {
                    Id = "Schedule1Id",
                    StartsAt = DateTime.ParseExact(
                        "03.02.2020 10:00", DateViewFormat + " " + TimeViewFormat, null),
                    EndsAt = DateTime.ParseExact(
                        "03.02.2020 18:00", DateViewFormat + " " + TimeViewFormat, null)
                }
            };

            var employee2 = new Employee
            {
                Id = "EmployeeId2",
                Name = "EmployeeName2",
                Schedule = new Schedule
                {
                    Id = "Schedule2Id",
                    StartsAt = DateTime.ParseExact(
                        "03.02.2020 10:00", DateViewFormat + " " + TimeViewFormat, null),
                    EndsAt = DateTime.ParseExact(
                        "03.02.2020 18:00", DateViewFormat + " " + TimeViewFormat, null)
                }
            };

            employeeList.Add(employee1);
            employeeList.Add(employee2);

            return employeeList;
        }
    }
}
