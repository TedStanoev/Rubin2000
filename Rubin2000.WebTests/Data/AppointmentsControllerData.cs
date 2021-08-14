using Rubin2000.Models;
using Rubin2000.Models.Enums;
using Rubin2000.Services.ForAppointments.Models;
using Rubin2000.Web.Models.Appointments;
using System;
using System.Collections.Generic;
using System.Linq;

using static Rubin2000.Global.FormatConstants;
using static Rubin2000.Global.WebTestConstants;

namespace Rubin2000.WebTests.Data
{
    public static class AppointmentsControllerData
    {
        public static AppUser User()
            => new() 
            { 
                Id = "TestId",
                FirstName = "UserFirstName",
                LastName = "UserLastName"
            };

        public static Procedure ProcedureWithOccupationAndEmployee()
            => new()
            {
                Id = ProcedureId,
                Name = ProcedureName,
                Duration = Duration.One_Hour,
                Price = 10,
                Occupation = new Occupation 
                { 
                    Name = Global.OccupationConstants.HairStyler,
                    Employees = new[] 
                    { 
                        new Employee
                        {
                            Id = EmployeeId,
                            Name = "EmployeeName",
                            Schedule = new Schedule
                            {
                                Id = ScheduleId,
                                EmployeeId = EmployeeId
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
                Id = AppointmentId,
                Description = Description,
                Procedure = ProcedureWithOccupationAndEmployee(),
                ScheduleId = ScheduleId,
                Creator = User(),
                ClientName = "ClientName",
                Status = AppointmentStatus.Pending,
                DateAndTime = DateTime.ParseExact("03.02.2100 18:00", DateViewFormat + " " + TimeViewFormat, null),
            };

        public static AppointmentInputViewModel ValidInputForAppointment()
            => new()
            {
                ProcedureName = ProcedureName,
                Date = "2100-02-03",
                Time = "18:00",
                Description = Description,
                ClientName = "Emanuela",
                EmployeeId = EmployeeId
            };

        public static AppointmentInputViewModel InvalidInputForAppointment()
            => new()
            {
                ProcedureName = ProcedureName,
                Date = "1990-02-03",
                Time = "18:00",
                Description = Description,
                ClientName = "Emanuela",
                EmployeeId = EmployeeId
            };

        public static AppointmentEditServiceModel ValidEditAppointment()
            => new()
            {
                ProcedureId = ProcedureId,
                ProcedureName = ProcedureName,
                ClientName = "Aria",
                Date = "2100-02-03",
                Time = "18:00",
                Description = Description,
                EmployeeId = EmployeeId
            };

        public static AppointmentEditServiceModel InvalidEditAppointment()
            => new()
            {
                ProcedureId = ProcedureId,
                ProcedureName = ProcedureName,
                ClientName = "Aria",
                Date = "1989-02-03",
                Time = "23:00",
                Description = Description,
                EmployeeId = EmployeeId
            };

        public static DeclineAppointmentViewModel ValidDecline()
            => new()
            {
                Id = AppointmentId
            };

        public static Employee Employee()
            => new() 
            { 
                Id = EmployeeId,
                Schedule = new Schedule
                {
                    Id = ScheduleId
                }
            };
    }
}
