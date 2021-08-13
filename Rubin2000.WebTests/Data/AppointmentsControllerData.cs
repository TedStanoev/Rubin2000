using Microsoft.AspNetCore.Identity;
using Rubin2000.Models;
using Rubin2000.Web.Models.Appointments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rubin2000.WebTests.Data
{
    public static class AppointmentsControllerData
    {
        public static AppUser User()
            => new() { Id = "TestId" };

        public static Procedure ProcedureWithOccupationAndEmployee()
            => new()
            {
                Id = "ProcedureId",
                Name = "ProcedureName",
                Occupation = new Occupation 
                { 
                    Employees = new[] 
                    { 
                        new Employee
                        {
                            Id = "EmployeeId",
                            Schedule = new Schedule
                            {
                                EmployeeId = "EmployeeId"
                            }
                        } 
                    }
                }
            };

        public static IEnumerable<Appointment> UserAppointments()
        {
            var user = User();

            var appointments = Enumerable.Range(0, 5)
                .Select(a => new Appointment
                {
                    Creator = user
                });

            var deletedAppointments = Enumerable.Range(0, 4)
                .Select(a => new Appointment
                {
                    Creator = user,
                    IsDeletedToUser = true
                });

            foreach (var appointment in deletedAppointments)
            {
                appointments = appointments.Append(appointment);
            }

            return appointments;
        }

        public static Appointment Appointment()
            => new()
            {
                Id = "AppointmentId",
                Schedule = new Schedule
                {
                    Employee = new Employee
                    {
                        Occupation = new Occupation()
                    }
                },
                Procedure = ProcedureWithOccupationAndEmployee(),
                Creator = User()
            };

        public static AppointmentInputViewModel ValidInputForAppointment()
            => new()
            {
                ProcedureName = "ProcedureName",
                Date = "2100-02-03",
                Time = "18:00",
                Description = "Some description",
                ClientName = "Emanuela",
                EmployeeId = "EmployeeId"
            };

        public static AppointmentInputViewModel InvalidInputForAppointment()
            => new()
            {
                ProcedureName = "ProcedureName",
                Date = "1990-02-03",
                Time = "18:00",
                Description = "Some description",
                ClientName = "Emanuela",
                EmployeeId = "EmployeeId"
            };

        public static DeclineAppointmentViewModel ValidDecline()
            => new()
            {
                Id = "AppointmentId"
            };

        public static DeclineAppointmentViewModel InvalidDecline()
            => new()
            {
                Id = "AppointmentId",
                Description = Enumerable.Range(0, 300).ToString()
            };

        public static Employee Employee()
            => new() 
            { 
                Id = "EmployeeId",
                Schedule = new Schedule()
            };
    }
}
