namespace WebApplication1.DAL.NiagaraMigrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Validation;
    using System.Linq;
    using System.Text;
    using WebApplication1.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<WebApplication1.Models.Model1>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"DAL\NiagaraMigrations";
        }

        private void SaveChanges(DbContext context)
        {
            try
            {
                context.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                StringBuilder sb = new StringBuilder();

                foreach (var failure in ex.EntityValidationErrors)
                {
                    sb.AppendFormat("{0} failed validation\n", failure.Entry.Entity.GetType());
                    foreach (var error in failure.ValidationErrors)
                    {
                        sb.AppendFormat("- {0} : {1}", error.PropertyName, error.ErrorMessage);
                        sb.AppendLine();
                    }
                }

                throw new DbEntityValidationException(
                    "Entity Validation Failed - errors follow:\n" +
                    sb.ToString(), ex
                ); // Add the original exception as the innerException
            }
            catch (Exception e)
            {
                throw new Exception(
                     "Seed Failed - errors follow:\n" +
                     e.InnerException.InnerException.Message.ToString(), e
                 ); // Add the original exception as the innerException
            }
        }

        protected override void Seed(WebApplication1.Models.Model1 context)
        {

            var jobLocations = new List<JobLocation>
            {

                new JobLocation { locationName = "Alexander Kuska", locationAddress = "333 Rice Rd.", locationPostalCode = "L3C2V9", locationPhoneNumber = 9057354471, locationCity = "Welland" },
                new JobLocation { locationName = "Assumption", locationAddress = "225 Parnell Rd.", locationPostalCode = "L2M1W3", locationPhoneNumber = 9059355281, locationCity = "St. Catharines" },
                new JobLocation { locationName = "Canadian Martyrs", locationAddress = "502 Scott St.", locationPostalCode = "L2M3X2", locationPhoneNumber = 9059349972, locationCity = "St. Catharines" },
                new JobLocation { locationName = "Cardinal Newman", locationAddress = "8120 Beaverdams Rd.", locationPostalCode = "L2H1R8", locationPhoneNumber = 9053549033, locationCity = "Niagara Falls" },
                new JobLocation { locationName = "Father Hennepin", locationAddress = "6032 Churchill St.", locationPostalCode = "L2G2X1", locationPhoneNumber = 9053544469, locationCity = "Niagara Falls" },
                new JobLocation { locationName = "Holy Name", locationAddress = "290 Fitch Street", locationPostalCode = "L3C4W5", locationPhoneNumber = 9057324992, locationCity = "Welland" },
                new JobLocation { locationName = "Monsignor Clancy", locationAddress = "41 Collier Road S.", locationPostalCode = "L2V3S9", locationPhoneNumber = 9052274910, locationCity = "Thorold" },
                new JobLocation { locationName = "Our Lady of Fatima", locationAddress = "69 Olive St.", locationPostalCode = "L3M2C3", locationPhoneNumber = 9059455500, locationCity = "Grimsby" },
                new JobLocation { locationName = "St. Alexander", locationAddress = "26 Highway #20", locationPostalCode = "L0S1E0", locationPhoneNumber = 9058923841, locationCity = "Fonthill" },
                new JobLocation { locationName = "St. Ann", locationAddress = "832 Canboro Road", locationPostalCode = "L0S1C0", locationPhoneNumber = 9058923942, locationCity = "Fenwick" },
                new JobLocation { locationName = "St. Charles", locationAddress = "25 Whyte Ave.", locationPostalCode = "L2V2T4", locationPhoneNumber = 9052273522, locationCity = "Thorold" },
                new JobLocation { locationName = "St. Edward", locationAddress = "2807 4th Avenue", locationPostalCode = "L0R1S0", locationPhoneNumber = 9055625531, locationCity = "Jordan" },
                new JobLocation { locationName = "St. Elizabeth", locationAddress = "31950 Sugarloaf Street", locationPostalCode = "L0S1V0", locationPhoneNumber = 9058993041, locationCity = "Wainfleet" },
                new JobLocation { locationName = "St. George", locationAddress = "3800 Wellington Rd.", locationPostalCode = "L0S1B0", locationPhoneNumber = 9058943670, locationCity = "Crystal Beach" },
                new JobLocation { locationName = "St. John", locationAddress = "5684 Regional Road 81", locationPostalCode = "L0R1B0", locationPhoneNumber = 9059455331, locationCity = "Beamsville" },
                new JobLocation { locationName = "St. John Bosco", locationAddress = "191 Highland Ave.", locationPostalCode = "L3K3S7", locationPhoneNumber = 9058351930, locationCity = "Port Colborne" },
                new JobLocation { locationName = "St. Joseph", locationAddress = "3650 Netherby Road", locationPostalCode = "L0S1S0", locationPhoneNumber = 9053823822, locationCity = "Stevensville" },
                new JobLocation { locationName = "St. Joseph", locationAddress = "5 Robinson St. N.", locationPostalCode = "L3M3C8", locationPhoneNumber = 9059454955, locationCity = "Grimsby" },
                new JobLocation { locationName = "St. Mark", locationAddress = "4114 Mountain St.", locationPostalCode = "L0R1B7", locationPhoneNumber = 9055639191, locationCity = "Beamsville" },
                new JobLocation { locationName = "St. Martin", locationAddress = "18 Streamside Drive", locationPostalCode = "L0R2A0", locationPhoneNumber = 9059573032, locationCity = "Smithville" },
                new JobLocation { locationName = "St. Michael", locationAddress = "387 Line 3, RR #2", locationPostalCode = "L0S1J0", locationPhoneNumber = 9056841051, locationCity = "Niagara on the Lake" },
                new JobLocation { locationName = "St. Patrick", locationAddress = "266 Rosemount Ave.", locationPostalCode = "L3K5R4", locationPhoneNumber = 9058351091, locationCity = "Port Colborne" },
                new JobLocation { locationName = "Dennis Morris", locationAddress = "40 Glen Morris Drive", locationPostalCode = "L2T2M9", locationPhoneNumber = 9056848731, locationCity = "St. Catharines" },
                new JobLocation { locationName = "Blessed Trinity", locationAddress = "145 Livingston Ave.", locationPostalCode = "L3M5J6", locationPhoneNumber = 9059456706, locationCity = "Grimsby" },
                new JobLocation { locationName = "Lakeshore", locationAddress = "150 Janet St.", locationPostalCode = "L3K2E7", locationPhoneNumber = 9058352451, locationCity = "Port Colborne" },
                new JobLocation { locationName = "Notre Dame", locationAddress = "64 Smith Street", locationPostalCode = "L3C4H4", locationPhoneNumber = 9057883060, locationCity = "Welland" },
                new JobLocation { locationName = "Saint Paul", locationAddress = "3834 Windermere Rd.", locationPostalCode = "L2J2Y5", locationPhoneNumber = 9053564313, locationCity = "Niagara Falls" }
            };
            jobLocations.ForEach(a => context.JobLocations.AddOrUpdate(n => n.locationAddress, a));
            SaveChanges(context);

            var jobPosts = new List<JobPost>
            {
                new JobPost { jobName = "Principal", postingStart = DateTime.Parse("2018-09-24"), postingStartTime = DateTime.Parse("9:13PM"), postingEnd = DateTime.Parse("2018-09-25"), postingEndTime = DateTime.Parse("9:14PM"), successfulStart = DateTime.Parse("2018-09-26"), successfulEnd = DateTime.Parse("2018-09-27"), jobDescription = "Fun Job", jobLocationID = 1, jobActive = "T"},
                new JobPost { jobName = "Vice Principal", postingStart = DateTime.Parse("2018-09-24"), postingStartTime = DateTime.Parse("9:13PM"),postingEnd = DateTime.Parse("2018-09-25"), postingEndTime = DateTime.Parse("9:14PM"), successfulStart = DateTime.Parse("2018-09-26"), successfulEnd = DateTime.Parse("2018-09-27"), jobDescription = "Great Job", jobLocationID = 3, jobActive = "T"},
                new JobPost { jobName = "Custodian", postingStart = DateTime.Parse("2018-09-24"), postingStartTime = DateTime.Parse("9:13PM"),postingEnd = DateTime.Parse("2018-09-25"), postingEndTime = DateTime.Parse("9:14PM"), successfulStart = DateTime.Parse("2018-09-26"), successfulEnd = DateTime.Parse("2018-09-27"), jobDescription = "Pays well", jobLocationID = 6, jobActive = "T"},
                new JobPost { jobName = "Grade 2 Teacher", postingStart = DateTime.Parse("2018-09-24"), postingStartTime = DateTime.Parse("9:13PM"),postingEnd = DateTime.Parse("2018-09-25"), postingEndTime = DateTime.Parse("9:14PM"), successfulStart = DateTime.Parse("2018-09-26"), successfulEnd = DateTime.Parse("2018-09-27"), jobDescription = "Teacher grade 2", jobLocationID = 4, jobActive = "T"},
                new JobPost { jobName = "Special Needs Assistant", postingStart = DateTime.Parse("2018-09-24"), postingStartTime = DateTime.Parse("9:13PM"),postingEnd = DateTime.Parse("2018-09-25"), postingEndTime = DateTime.Parse("9:14PM"), successfulStart = DateTime.Parse("2018-09-26"), successfulEnd = DateTime.Parse("2018-09-27"), jobDescription = "", jobLocationID = 2, jobActive = "T"},
                new JobPost { jobName = "Physical Education Teacher", postingStart = DateTime.Parse("2018-09-24"), postingStartTime = DateTime.Parse("9:13PM"), postingEnd = DateTime.Parse("2018-09-25"),  postingEndTime = DateTime.Parse("9:14PM"), successfulStart = DateTime.Parse("2018-09-26"), successfulEnd = DateTime.Parse("2018-09-27"), jobDescription = "", jobLocationID = 4, jobActive = "T"},
            };
            jobPosts.ForEach(a => context.JobPosts.AddOrUpdate(n => n.jobCode, a));
            SaveChanges(context);
        }
    }
}
