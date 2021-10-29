using officeNow_api.Models;
using System;
using System.Globalization;
using System.Linq;

namespace officeNow_api.Data
{
    public static class DbInitializer
    {
        public static void Initialize(OfficeNowContext context)
        {
            context.Database.EnsureCreated();
            var companyLocations = new[]
            {
                new Location {LocationDescription = "TERANET PAMBA BUILDING FLOOR 1"}
            };

            if (!context.CompanyLocations.Any())
            {
                foreach (var e in companyLocations) context.CompanyLocations.Add(e);

                context.SaveChanges();
            }
            var userRoles = new[]
            {
                new UserRole {RoleDesc = "Individual Contributor"}
            };

            if (!context.UserRoles.Any())
            {
                foreach (var c in userRoles) context.UserRoles.Add(c);

                context.SaveChanges();
            }

            var tags = new[]
            {
                new Tags() {TagName = "EAGLES"},
                new Tags() {TagName = "EAGLES_Leader"},
                new Tags() {TagName = "REC_DIRECTOR"}
            };

            if (!context.Tags.Any())
            {
                foreach (var c in tags) context.Tags.Add(c);

                context.SaveChanges();
            }
            var eagleTag = context.Tags.First();
            var location = context.CompanyLocations.First();
            if (!context.UserRoles.Any())
            {
                foreach (var c in userRoles) context.UserRoles.Add(c);

                context.SaveChanges();
            }
            var users = new[]
            {
                new User {RoleId = 1, UserName = "jithin.johnson@teranet.ca",UserRealName = "Jithin Johnson",UserLocation = location},
                new User {RoleId = 1, UserName = "Anju.jinu@teranet.ca",UserRealName = "Anju Jinu",UserLocation = location},
                new User {RoleId = 1, UserName = "Sreevidya.jayadev@teranet.ca",UserRealName = "Sreevidya Jayadev",UserLocation = location}
            };
            if (!context.Users.Any())
            {
                foreach (var e in users) context.Users.Add(e);

                context.SaveChanges();
            }
  

            var userTags = new[]
            {
            new UserTags() {UserId = 1, Tag = eagleTag},
            new UserTags() {UserId = 2, Tag = eagleTag},
            new UserTags() {UserId = 3, Tag = eagleTag}

            };
            if (!context.UserTags.Any())
            {
                foreach (var e in userTags) context.UserTags.Add(e);

                context.SaveChanges();
            }

            


            var workStations = new[]
            {
                new WorkStation {SeatNo = 1, CompanyLocation = location},
                new WorkStation {SeatNo = 2,CompanyLocation = location},
                new WorkStation {SeatNo = 3, CompanyLocation = location}
            };
            if (!context.WorkStations.Any())
                try
                {
                    foreach (var e in workStations)
                    {
                        context.WorkStations.Add(e);
                        context.SaveChanges();
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }

            var wsTags = new[]
            {
                new WorkStationTags() {WorkStationId = 1, Tag = eagleTag},
                new WorkStationTags() {WorkStationId = 2, Tag = eagleTag},
                new WorkStationTags() {WorkStationId = 3, Tag = eagleTag}

            };
            if (!context.WorkStationTags.Any())
            {
                foreach (var e in wsTags) context.WorkStationTags.Add(e);

                context.SaveChanges();
            }
          
           
            var bookingLogs = new[]
            {
                new BookingLog {WorkStationId = 1, BookedDate = "2021-10-29 14:15:15.143", UserId = 1},
                new BookingLog {WorkStationId = 2, BookedDate = "2021-10-29 14:15:15.143", UserId = 2},
                new BookingLog {WorkStationId = 3, BookedDate = "2021-10-29 14:15:15.143", UserId = 3}
            };

            if (!context.BookingLogs.Any())
                foreach (var e in bookingLogs)
                {
                    context.BookingLogs.Add(e);
                }
            context.SaveChanges();
        }
    }
}
