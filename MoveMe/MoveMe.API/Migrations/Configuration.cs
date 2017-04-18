namespace MoveMe.API.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Spatial;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MoveMe.API.Data.MoveMeDataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MoveMe.API.Data.MoveMeDataContext context)
        {
            if(context.Companys.Count() == 0)
            {
                var geocoderService = new Geocoder.GeocodeService();
                var tmaatLocation = geocoderService.GeocodeLocation("9245 Farnham St, San Diego, CA 92123");

                // 1. Setup a fake company
                var company = new Models.Company
                {
                    CompanyName = "Two Men and a Truck",
                    Telephone = "+19092247557",
                    HourlyRate = 50M,
                    Radius = 10,
                    Location = DbGeography.FromText($"POINT({tmaatLocation.Longitude} {tmaatLocation.Latitude})"),
                    StreetAddress = "9245 Farnham St",
                    City = "San Diego",
                    State = "CA",
                    Zip = "92123",
                    Employees = 2
                };

                context.Companys.Add(company);
                context.SaveChanges();

                // 2. Setup a fake customer
                var customer = new Models.Customer
                {
                    FirstName = "Cameron",
                    LastName = "Wilby",
                    Telephone = "+19092247557",
                    User = new Models.User
                    {
                        EmailAddress = "cameron@wilby.com",
                        Password = "password123"
                    }
                };

                context.Customers.Add(customer);
                context.SaveChanges();

                var fromLocation = geocoderService.GeocodeLocation("3590 Central Ave #101, Riverside, CA 92506");
                var toLocation = geocoderService.GeocodeLocation("101 W Broadway, San Diego CA 92101");

                // 3. Setup some stuff ready for an order
                var jobDetail = new Models.JobDetail
                {
                    Customer = customer,
                    Distance = 100,
                    Elevator = true,
                    FromStreetAddress = "3590 Central Ave #101",
                    FromState = "CA",
                    FromCity = "Riverside",
                    FromZip = "92506",
                    FromLocation = DbGeography.FromText($"POINT({fromLocation.Longitude} {fromLocation.Latitude})"),
                    ToStreetAddress = "101 W Broadway",
                    ToCity = "San Diego",
                    ToState = "CA",
                    ToZip = "92109",
                    ToLocation = DbGeography.FromText($"POINT({toLocation.Longitude} {toLocation.Latitude})"),
                    MovingDay = DateTime.Now.AddDays(5),
                    NumBedroom = 2,
                    NumHours = 8,
                    NumMovers = 2,
                    NumPooper = 1,
                    SqFeet = 800,
                    Stairs = 1
                };
                context.JobDetails.Add(jobDetail);

                var paymentDetail = new Models.PaymentDetail
                {
                    CCNumber = "4242424242424242",
                    CCV = "828",
                    City = "San Diego",
                    State = "CA",
                    Zip = "92109",
                    ExpDate = DateTime.Now.AddYears(2).ToString("MM/YYYY"),
                    StreetAddress = "101 W Broadway",
                    Customer = customer
                };
                context.PaymentDetails.Add(paymentDetail);
                context.SaveChanges();
            }
        }
    }
}
