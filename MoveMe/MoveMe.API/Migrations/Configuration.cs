namespace MoveMe.API.Migrations
{
    using MoveMe.API.Utility;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Spatial;
    using System.Linq;
    using Microsoft.AspNet.Identity;
    using MoveMe.API.Models;
    using Microsoft.AspNet.Identity.EntityFramework;

    internal sealed class Configuration : DbMigrationsConfiguration<MoveMe.API.Data.MoveMeDataContext>
    {
        private readonly int _numberOfCustomers = 5;
        private readonly int _numberOfCompanies = 5;
        private readonly string _twilioTestNumber = "16193134173";

        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MoveMe.API.Data.MoveMeDataContext context)
        {

            string[] addresses = new string[]
           {
                "101 W Broadway, San Diego, CA, 92101",
                "13030 Salmon River Road, San Diego, CA, 92129",
                "1930 Georgia Court, San Diego, CA, 92104",
                "3872 Jewell Street, San Diego, CA, 92109"
           };

            var userManager = new UserManager<User>(new UserStore<User>(context));

            // generate companies
            if (context.Companys.Count() == 0)
            {
                var user = new User
                {
                    UserName = "owner@finchmoving.com",
                    Email = "owner@finchmoving.com",
                    Company = new Models.Company
                    {
                        CompanyName = "Finch Moving San Diego",
                        StreetAddress = "1080 Park Blvd",
                        City = "San Diego",
                        State = "CA",
                        Zip = "92101",
                        Employees = 5,
                        HourlyRate = 100,
                        Location = LocationConverter.GeocodeAddress("1080 Park Blvd, San Diego CA 92101"),
                        Radius = 25,
                        Telephone = _twilioTestNumber
                    }
                };
                userManager.Create(user, "password123");

                user = new User
                {
                    UserName = "owner@sdexpertmovers.com",
                    Email = "owner@sdexpertmovers.com",
                    Company = new Models.Company
                    {
                        CompanyName = "San Diego Expert Movers",
                        StreetAddress = "2004 C St",
                        City = "San Diego",
                        State = "CA",
                        Zip = "92102",
                        Employees = 15,
                        HourlyRate = 80,
                        Location = LocationConverter.GeocodeAddress("2004 C St, San Diego CA 92102"),
                        Radius = 25,
                        Telephone = _twilioTestNumber
                    }
                };

                userManager.Create(user, "password123");

                user = new User
                {
                    UserName = "owner@sdmovingllc.com",
                    Email = "owner@sdmovingllc.com",
                    Company = new Models.Company
                    {
                        CompanyName = "San Diego Moving LLC",
                        StreetAddress = "301 W G St",
                        City = "San Diego",
                        State = "CA",
                        Zip = "92101",
                        Employees = 15,
                        HourlyRate = 80,
                        Location = LocationConverter.GeocodeAddress("301 W G St, San Diego CA 92101"),
                        Radius = 10,
                        Telephone = _twilioTestNumber
                    }
                };

                userManager.Create(user, "password123");

                user = new User
                {
                    UserName = "owner@calimovers.com",
                    Email = "owner@calimovers.com",
                    Company = new Models.Company
                    {
                        CompanyName = "California Movers. Local & Long Distance Moving Company",
                        StreetAddress = "1399 Ninth Ave #303",
                        City = "San Diego",
                        State = "CA",
                        Zip = "92101",
                        Employees = 10,
                        HourlyRate = 50,
                        Location = LocationConverter.GeocodeAddress("1399 Ninth Ave #303, San Diego CA 92101"),
                        Radius = 50,
                        Telephone = _twilioTestNumber
                    }
                };

                userManager.Create(user, "password123");

                user = new User
                {
                    UserName = "owner@starvingstudents.com",
                    Email = "owner@starvingstudents.com",
                    Company = new Models.Company
                    {
                        CompanyName = "Starving Students Movers, Inc",
                        StreetAddress = "2734 Main St",
                        City = "San Diego",
                        State = "CA",
                        Zip = "92113",
                        Employees = 5,
                        HourlyRate = 25,
                        Location = LocationConverter.GeocodeAddress("2734 Main St, San Diego CA 92113"),
                        Radius = 50,
                        Telephone = _twilioTestNumber
                    }
                };

                userManager.Create(user, "password123");


                //context.Companys.Add(new Models.Company
                //{
                //    CompanyName = "San Diego Expert Movers",
                //    StreetAddress = "2004 C St",
                //    City = "San Diego",
                //    State = "CA",
                //    Zip = "92102",
                //    Employees = 15,
                //    HourlyRate = 80,
                //    Location = LocationConverter.GeocodeAddress("2004 C St, San Diego CA 92102"),
                //    Radius = 25,
                //    Telephone = _twilioTestNumber,
                //    User = new Models.User
                //    {
                //        UserName = "owner@sdexpertmovers.com",
                //        EmailAddress = "owner@sdexpertmovers.com",
                //        Password = "password123"
                //    }
                //});

                //context.Companys.Add(new Models.Company
                //{
                //    CompanyName = "California Movers. Local & Long Distance Moving Company",
                //    StreetAddress = "1399 Ninth Ave #303",
                //    City = "San Diego",
                //    State = "CA",
                //    Zip = "92101",
                //    Employees = 10,
                //    HourlyRate = 50,
                //    Location = LocationConverter.GeocodeAddress("1399 Ninth Ave #303, San Diego CA 92101"),
                //    Radius = 50,
                //    Telephone = _twilioTestNumber,
                //    User = new Models.User
                //    {
                //        UserName = "owner@calimovers.com",
                //        EmailAddress = "owner@calimovers.com",
                //        Password = "password123"
                //    }
                //});
                //context.Companys.Add(new Models.Company
                //{
                //    CompanyName = "Starving Students Movers, Inc",
                //    StreetAddress = "2734 Main St",
                //    City = "San Diego",
                //    State = "CA",
                //    Zip = "92113",
                //    Employees = 5,
                //    HourlyRate = 25,
                //    Location = LocationConverter.GeocodeAddress("2734 Main St, San Diego CA 92113"),
                //    Radius = 50,
                //    Telephone = _twilioTestNumber,
                //    User = new Models.User
                //    {
                //        UserName = "owner@starvingstudents.com",
                //        EmailAddress = "owner@starvingstudents.com",
                //        Password = "password123"
                //    }
                //});

                context.SaveChanges();
            }

            // generate customers
            if (context.Customers.Count() == 0)
            {
                for (int i = 0; i < _numberOfCustomers; i++)
                {
                    var emailAddress = Faker.InternetFaker.Email();

                    var customer = new Models.Customer
                    {
                        FirstName = Faker.NameFaker.FirstName(),
                        LastName = Faker.NameFaker.LastName(),
                        Telephone = _twilioTestNumber,
                    };

                    var randomAddress = addresses[Faker.NumberFaker.Number(0, addresses.Length)].Split(' ');

                    customer.PaymentDetails.Add(new Models.PaymentDetail
                    {
                        CCNumber = "4242424242424242",
                        CCV = "123",
                        ExpDate = "10/12/2020",
                        StreetAddress = randomAddress[0],
                        City = randomAddress[1],
                        State = randomAddress[2],
                        Zip = randomAddress[3]
                    });

                    if(Faker.BooleanFaker.Boolean())
                    {
                        customer.Orders.Add(new Models.Order
                        {
                            Canceled = false,
                            CompanyId = Faker.NumberFaker.Number(1, context.Companys.Count()),
                            Completed = false,
                            Confirmed = false,
                            Cost = 500,
                            PaymentDetail = customer.PaymentDetails.First(),
                            JobDetail = new Models.JobDetail
                            {
                                Customer = customer,
                                Distance = 50,
                                Elevator = true,
                                MovingDay = DateTime.Now.AddDays(Faker.NumberFaker.Number(3, 14)),
                                NumBedroom = Faker.NumberFaker.Number(1, 3),
                                NumPooper = Faker.NumberFaker.Number(1, 2),
                                NumHours = Faker.NumberFaker.Number(2, 4),
                                SqFeet = Faker.NumberFaker.Number(500, 1000),
                                Stairs = Faker.NumberFaker.Number(0, 2),
                                NumMovers = Faker.NumberFaker.Number(2, 4),
                                FromStreetAddress = "101 W Broadway",
                                FromCity = "San Diego",
                                FromState = "CA",
                                FromZip = "92101",
                                FromLocation = LocationConverter.GeocodeAddress("101 W Broadway, San Diego CA 92101"),
                                ToStreetAddress = "3872 Jewell Street",
                                ToCity = "San Diego",
                                ToZip = "CA",
                                ToState = "CA",
                                ToLocation = LocationConverter.GeocodeAddress("3872 Jewell Street, San Diego CA 92109")
                            }
                        });
                    }

                    var user = new Models.User
                    {
                        UserName = emailAddress,
                        Email = emailAddress,
                        Customer = customer
                    };

                    userManager.Create(user);
                }
            }
        }
    }
}
