using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tutorial.Persistence
{
    public class Context : IdentityDbContext<Usuario>
    {




        public Context() : base("OracleDbContext", throwIfV1Schema: false) { }


        public DbSet<ISEO> Iseos { get; set; }

        public DbSet<Viagem> Viagens { get; set; }

        public DbSet<Alocacao> Alocacoes { get; set; }

        public DbSet<Setor> Setores { get; set; }

        public DbSet<Funcao> Funcoes { get; set; }

        public DbSet<Cavalo> Cavalos { get; set; }

        public DbSet<Endereco> Enderecos { get; set; }

        public DbSet<Viatura> Viaturas { get; set; }

        public DbSet<DispensaMedica> DispensaMedicas { get; set; }

        public DbSet<Dispensa> Dispensas { get; set; }

        public DbSet<TrocaDeServico> TrocaDeServico { get; set; }


        public DbSet<ServicoAdicional> ServicoAdicionais { get; set; }

        public DbSet<Chamada> Chamada { get; set; }

        public DbSet<ChamadaVTR> ChamadaVTR { get; set; }

        public DbSet<ChamadaMontado> ChamadaMontado { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("CASA");
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<IdentityUser>()
                .ToTable("Usuarios")
                .Property(p => p.Id)
                .HasColumnName("UsuarioId");

            modelBuilder.Entity<Usuario>()
                .HasRequired(s => s.endereco)
                .WithRequiredPrincipal(a => a.Usuario)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Usuario>()
               .ToTable("Usuarios")
               .Property(p => p.Id)
               .HasColumnName("UsuarioId");

            modelBuilder.Entity<IdentityUserRole>()
               .ToTable("UsuariorPapel");

            modelBuilder.Entity<IdentityUserLogin>()
               .ToTable("Logins");

            modelBuilder.Entity<IdentityUserClaim>()
               .ToTable("Claims");

            modelBuilder.Entity<IdentityRole>()
               .ToTable("Papeis");

            modelBuilder
            .Properties()
            .Where(p => p.PropertyType == typeof(string))
            .Configure(p => p.IsUnicode(false));

            modelBuilder
           .Properties()
           .Where(p => p.PropertyType == typeof(string) &&
                      p.GetCustomAttributes(typeof(MaxLengthAttribute), false).Length == 0)
           .Configure(p => p.HasMaxLength(256));


            modelBuilder.Entity<ChamadaVTR>()
           .HasRequired(b => b.Chamada)
           .WithMany(b => b.chamadaVTR)
           .WillCascadeOnDelete(true);

            modelBuilder.Entity<ChamadaMontado>()
           .HasRequired(b => b.Chamada)
           .WithMany(b => b.ChamadaMontado)
           .WillCascadeOnDelete(true);

        }


        public static Context Create()
        {
            return new Context();
        }





    }
}