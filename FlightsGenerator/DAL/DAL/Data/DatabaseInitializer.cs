using Common.Enums;
using Common.Models;
using System.Data.Entity;

namespace DAL.Data
{
    /// <summary>
    /// Custom database initializer class used to populate
    /// the database with seed data.
    /// </summary>
    public class DatabaseInitializer : DropCreateDatabaseAlways<Context>
    {
        protected override void Seed(Context context)
        {
            // This is our database's seed data
            // 8 stations.

            StationModel station1 = new StationModel
            {
                Strip = StripEnum.LandingStrip,
                IsDepartureEnd = false,
                IsDepartureStart = false,
                IsLandingEnd = false,
                IsLandingStart = true,
                Id = 1
            };
            StationModel station2 = new StationModel
            {
                Strip = StripEnum.LandingStrip,
                IsDepartureEnd = false,
                IsDepartureStart = false,
                IsLandingEnd = false,
                IsLandingStart = false,
                Id = 2
            };
            StationModel station3 = new StationModel
            {
                Strip = StripEnum.LandingStrip,
                IsDepartureEnd = false,
                IsDepartureStart = false,
                IsLandingEnd = false,
                IsLandingStart = false,
                Id = 3
            };
            StationModel station4 = new StationModel
            {
                Strip = StripEnum.AirLandingStrip,
                IsDepartureEnd = true,
                IsDepartureStart = false,
                IsLandingEnd = false,
                IsLandingStart = false,
                Id = 4
            };
            StationModel station5 = new StationModel
            {
                Strip = StripEnum.LandingStrip,
                IsDepartureEnd = false,
                IsDepartureStart = false,
                IsLandingEnd = false,
                IsLandingStart = false,
                Id = 5
            };
            StationModel station6 = new StationModel
            {
                Strip = StripEnum.AirLandingStrip,
                IsDepartureEnd = false,
                IsDepartureStart = true,
                IsLandingEnd = true,
                IsLandingStart = false,
                Id = 6
            };
            StationModel station7 = new StationModel
            {
                Strip = StripEnum.AirLandingStrip,
                IsDepartureEnd = false,
                IsDepartureStart = true,
                IsLandingEnd = true,
                IsLandingStart = false,
                Id = 7
            };
            StationModel station8 = new StationModel
            {
                Strip = StripEnum.AirStrip,
                IsDepartureEnd = false,
                IsDepartureStart = false,
                IsLandingEnd = false,
                IsLandingStart = false,
                Id = 8
            };

            StationModel station9 = new StationModel
            {
                Strip = StripEnum.LandingStrip,
                IsDepartureEnd = false,
                IsDepartureStart = false,
                IsLandingEnd = true,
                IsLandingStart = false,
                Id = 9
            };
            station1.NextLandingStations.Add(station2);

            station2.NextLandingStations.Add(station3);

            station3.NextLandingStations.Add(station4);

            station4.NextLandingStations.Add(station5);

            station5.NextLandingStations.Add(station6);
            station5.NextLandingStations.Add(station7);
            station5.NextLandingStations.Add(station9);

            station6.NextDepartureStations.Add(station8);

            station7.NextDepartureStations.Add(station8);

            station8.NextDepartureStations.Add(station4);



            context.Stations.Add(station1);
            context.Stations.Add(station2);
            context.Stations.Add(station3);
            context.Stations.Add(station4);
            context.Stations.Add(station5);
            context.Stations.Add(station6);
            context.Stations.Add(station7);
            context.Stations.Add(station8);
            context.Stations.Add(station9);

            context.SaveChanges();
        }
    }
}