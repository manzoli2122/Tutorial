namespace Tutorial.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Tutorial.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<Tutorial.Persistence.Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Tutorial.Persistence.Context context)
        {

            var cavalos = new List<Cavalo>
            {
                new Cavalo {Ativo = true , Numero = 100 ,  Nome = "Carson",   Nascimento =  DateTime.Parse("2010-09-01") },
                new Cavalo {Ativo = true , Numero = 101 , Nome = "Meredith", Nascimento =  DateTime.Parse("2012-09-11") },
                new Cavalo {Ativo = true , Numero = 102 , Nome = "Arturo",   Nascimento =  DateTime.Parse("2013-09-01") },
                new Cavalo {Ativo = true , Numero = 103 , Nome = "Gytis",    Nascimento =  DateTime.Parse("2012-09-01") },
                new Cavalo {Ativo = true , Numero = 104 , Nome = "Yan",      Nascimento =  DateTime.Parse("2012-09-01") },
                new Cavalo {Ativo = true , Numero = 105 , Nome = "Peggy",    Nascimento =  DateTime.Parse("2011-09-01") },
                new Cavalo {Ativo = true , Numero = 106 , Nome = "Laura",    Nascimento =  DateTime.Parse("2013-09-01") },
                new Cavalo {Ativo = true , Numero = 107 , Nome = "Brasil",    Nascimento =  DateTime.Parse("2013-08-01") },
                new Cavalo {Ativo = true , Numero = 108 , Nome = "Damasco",    Nascimento =  DateTime.Parse("2013-07-01") },
                new Cavalo {Ativo = true , Numero = 109 , Nome = "Estank",    Nascimento =  DateTime.Parse("2013-06-01") },
                new Cavalo {Ativo = true , Numero = 110 , Nome = "Furacão",    Nascimento =  DateTime.Parse("2013-05-01") },
                new Cavalo {Ativo = true , Numero = 111 , Nome = "Germanico",    Nascimento =  DateTime.Parse("2013-04-01") },
                new Cavalo {Ativo = true , Numero = 112 , Nome = "Inconfidente",    Nascimento =  DateTime.Parse("2013-03-01") },
                new Cavalo {Ativo = true , Numero = 113 , Nome = "Jubileu",    Nascimento =  DateTime.Parse("2013-02-01") },
                new Cavalo {Ativo = true , Numero = 114 , Nome = "Nocaute",    Nascimento =  DateTime.Parse("2013-01-01") },
                new Cavalo {Ativo = true , Numero = 115 , Nome = "Opera",    Nascimento =  DateTime.Parse("2013-09-01") },
                new Cavalo {Ativo = true , Numero = 116 , Nome = "Nino",     Nascimento =  DateTime.Parse("2005-08-11") }
            };

            cavalos.ForEach(s => context.Cavalos.AddOrUpdate(p => p.ID, s));
            context.SaveChanges();







            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
