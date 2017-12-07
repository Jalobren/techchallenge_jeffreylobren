namespace RaceDay.Entity.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<RaceDay.Entity.RaceDayContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(RaceDay.Entity.RaceDayContext context)
        {
            var customers = new[] {
                new Customer { Name = "Rob" },
                new Customer { Name = "Mark" },
                new Customer { Name = "Lachlan" },
                new Customer { Name = "Peter" },
                new Customer { Name = "Jared" }
            };
            context.Customers.AddOrUpdate(p => p.Name, customers);

            var horses = new[] {
                new Horse { Name = "Big Orange", Odds = 5.5M },
                new Horse { Name = "OUR IVANHOWE", Odds = 1.5M },
                new Horse { Name = "CURREN MIROTIC", Odds = 3M },
                new Horse { Name = "BONDI BEACH", Odds = 5.5M }
            };
            context.Horses.AddOrUpdate(h => h.Name, horses);
            context.SaveChanges();

            var races = new[] {
                new Race { Name = "R1", Status = "Completed", Horses = horses },
                new Race { Name = "R2", Status = "Pending", Horses = horses },
                new Race { Name = "R3", Status = "InProgress", Horses = horses }
            };
            context.Races.AddOrUpdate(r => r.Name, races);
            context.SaveChanges();

            context.Bets.AddOrUpdate(new Bet { CustomerId = customers[0].Id, HorseId = horses[2].Id, RaceId = races[0].Id, Stake = 201 });
            context.SaveChanges();
            context.Bets.AddOrUpdate(new Bet { CustomerId = customers[0].Id, HorseId = horses[2].Id, RaceId = races[1].Id, Stake = 55 });
            context.SaveChanges();
            context.Bets.AddOrUpdate(new Bet { CustomerId = customers[0].Id, HorseId = horses[2].Id, RaceId = races[2].Id, Stake = 20 });
            context.SaveChanges();
            context.Bets.AddOrUpdate(new Bet { CustomerId = customers[1].Id, HorseId = horses[1].Id, RaceId = races[2].Id, Stake = 121 });
            context.SaveChanges();
            context.Bets.AddOrUpdate(new Bet { CustomerId = customers[1].Id, HorseId = horses[2].Id, RaceId = races[2].Id, Stake = 25 });
            context.SaveChanges();
            context.Bets.AddOrUpdate(new Bet { CustomerId = customers[2].Id, HorseId = horses[0].Id, RaceId = races[2].Id, Stake = 5 });
            context.SaveChanges();
            context.Bets.AddOrUpdate(new Bet { CustomerId = customers[2].Id, HorseId = horses[1].Id, RaceId = races[2].Id, Stake = 1000 });
            context.SaveChanges();
            context.Bets.AddOrUpdate(new Bet { CustomerId = customers[2].Id, HorseId = horses[2].Id, RaceId = races[2].Id, Stake = 4 });
            context.SaveChanges();
            context.Bets.AddOrUpdate(new Bet { CustomerId = customers[2].Id, HorseId = horses[1].Id, RaceId = races[0].Id, Stake = 51 });
            context.SaveChanges();
            context.Bets.AddOrUpdate(new Bet { CustomerId = customers[3].Id, HorseId = horses[3].Id, RaceId = races[0].Id, Stake = 21 });
            context.SaveChanges();
            context.Bets.AddOrUpdate(new Bet { CustomerId = customers[3].Id, HorseId = horses[2].Id, RaceId = races[1].Id, Stake = 44 });
            context.SaveChanges();
            context.Bets.AddOrUpdate(new Bet { CustomerId = customers[4].Id, HorseId = horses[3].Id, RaceId = races[1].Id, Stake = 121 });
            context.SaveChanges();
            context.Bets.AddOrUpdate(new Bet { CustomerId = customers[4].Id, HorseId = horses[3].Id, RaceId = races[1].Id, Stake = 211 });
            context.SaveChanges();



        }
    }
}
