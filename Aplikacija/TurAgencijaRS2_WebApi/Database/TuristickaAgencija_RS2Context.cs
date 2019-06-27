using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TurAgencijaRS2_WebApi.Database
{
    public partial class TuristickaAgencija_RS2Context : DbContext
    {
        public TuristickaAgencija_RS2Context()
        {
        }

        public TuristickaAgencija_RS2Context(DbContextOptions<TuristickaAgencija_RS2Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Drzave> Drzave { get; set; }
        public virtual DbSet<Gradovi> Gradovi { get; set; }
        public virtual DbSet<Grupe> Grupe { get; set; }
        public virtual DbSet<KontaktPodaci> KontaktPodaci { get; set; }
        public virtual DbSet<Kontinenti> Kontinenti { get; set; }
        public virtual DbSet<Korisnici> Korisnici { get; set; }
        public virtual DbSet<Ponude> Ponude { get; set; }
        public virtual DbSet<PrevoznaSredstva> PrevoznaSredstva { get; set; }
        public virtual DbSet<Putovanja> Putovanja { get; set; }
        public virtual DbSet<PutovanjaGrupe> PutovanjaGrupe { get; set; }
        public virtual DbSet<Recenzije> Recenzije { get; set; }
        public virtual DbSet<Regije> Regije { get; set; }
        public virtual DbSet<Rezervacije> Rezervacije { get; set; }
        public virtual DbSet<Smjestaji> Smjestaji { get; set; }
        public virtual DbSet<StatusiRezervacija> StatusiRezervacija { get; set; }
        public virtual DbSet<StatusiTurista> StatusiTurista { get; set; }
        public virtual DbSet<StatusiVodica> StatusiVodica { get; set; }
        public virtual DbSet<Turisti> Turisti { get; set; }
        public virtual DbSet<Zaduzenja> Zaduzenja { get; set; }
        public virtual DbSet<Zaposlenici> Zaposlenici { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.;Database=TuristickaAgencija_RS2;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity<Drzave>(entity =>
            {
                entity.HasKey(e => e.DrzavaId);

                entity.Property(e => e.Naziv)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Kontinent)
                    .WithMany(p => p.Drzave)
                    .HasForeignKey(d => d.KontinentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Drzave_Kontinenti");
            });

            modelBuilder.Entity<Gradovi>(entity =>
            {
                entity.HasKey(e => e.GradId);

                entity.Property(e => e.Naziv)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Regija)
                    .WithMany(p => p.Gradovi)
                    .HasForeignKey(d => d.RegijaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Gradovi_Regije");
            });

            modelBuilder.Entity<Grupe>(entity =>
            {
                entity.HasKey(e => e.GrupaId);

                entity.Property(e => e.NazivGrupe)
                    .IsRequired()
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<KontaktPodaci>(entity =>
            {
                entity.HasKey(e => e.KorisnikId);

                entity.Property(e => e.KorisnikId).ValueGeneratedNever();

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.Telefon).HasMaxLength(20);

                entity.HasOne(d => d.Korisnik)
                    .WithOne(p => p.KontaktPodaci)
                    .HasForeignKey<KontaktPodaci>(d => d.KorisnikId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_KontaktPodaci");
            });

            modelBuilder.Entity<Kontinenti>(entity =>
            {
                entity.HasKey(e => e.KontinentId);

                entity.Property(e => e.Naziv)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Korisnici>(entity =>
            {
                entity.HasKey(e => e.KorisnikId);

                entity.HasIndex(e => e.KorisnickoIme)
                    .HasName("UQ_KorisnickoIme")
                    .IsUnique();

                entity.Property(e => e.Adresa).HasMaxLength(30);

                entity.Property(e => e.DatumKreiranja).HasColumnType("datetime");

                entity.Property(e => e.DatumRodjenja).HasColumnType("datetime");

                entity.Property(e => e.Ime)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.Jmbg)
                    .HasColumnName("JMBG")
                    .HasMaxLength(13);

                entity.Property(e => e.KorisnickoIme)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.LozinkaHash)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LozinkaSalt)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Prezime)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.Spol)
                    .IsRequired()
                    .HasMaxLength(1);

                entity.HasOne(d => d.Grad)
                    .WithMany(p => p.Korisnici)
                    .HasForeignKey(d => d.GradId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Korisnici_Gradovi");
            });

            modelBuilder.Entity<Ponude>(entity =>
            {
                entity.HasKey(e => e.PonudaId);

                entity.Property(e => e.DatumIzmjene).HasColumnType("datetime");

                entity.Property(e => e.DatumPocetka).HasColumnType("datetime");

                entity.Property(e => e.DatumZavrsetka).HasColumnType("datetime");

                entity.Property(e => e.NazivPonude)
                    .IsRequired()
                    .HasMaxLength(70);
            });

            modelBuilder.Entity<PrevoznaSredstva>(entity =>
            {
                entity.HasKey(e => e.PrevoznoSredstvoId);

                entity.Property(e => e.Naziv)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Putovanja>(entity =>
            {
                entity.HasKey(e => e.PutovanjeId);

                entity.Property(e => e.Cijena).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.DatumIzmjene).HasColumnType("datetime");

                entity.Property(e => e.DatumKreiranja).HasColumnType("datetime");

                entity.Property(e => e.DatumPolaska).HasColumnType("datetime");

                entity.Property(e => e.DatumPovratka).HasColumnType("datetime");

                entity.Property(e => e.Opis).IsRequired();

                entity.Property(e => e.Popust).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.Grad)
                    .WithMany(p => p.Putovanja)
                    .HasForeignKey(d => d.GradId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Putovanja_Gradovi");

                entity.HasOne(d => d.Ponuda)
                    .WithMany(p => p.Putovanja)
                    .HasForeignKey(d => d.PonudaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Putovanja_Ponude");

                entity.HasOne(d => d.PrevoznoSredstvo)
                    .WithMany(p => p.Putovanja)
                    .HasForeignKey(d => d.PrevoznoSredstvoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Putovanja_PrevoznaSredstva");
            });

            modelBuilder.Entity<PutovanjaGrupe>(entity =>
            {
                entity.HasKey(e => e.PutovanjeGrupaId);

                entity.Property(e => e.DatumPutovanja).HasColumnType("datetime");

                entity.HasOne(d => d.Grupa)
                    .WithMany(p => p.PutovanjaGrupe)
                    .HasForeignKey(d => d.GrupaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PutovanjaGrupe_Grupe");

                entity.HasOne(d => d.Korisnik)
                    .WithMany(p => p.PutovanjaGrupe)
                    .HasForeignKey(d => d.KorisnikId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PutovanjaGrupe_Zaposlenici");

                entity.HasOne(d => d.Putovanje)
                    .WithMany(p => p.PutovanjaGrupe)
                    .HasForeignKey(d => d.PutovanjeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PutovanjaGrupe_Putovanja");
            });

            modelBuilder.Entity<Recenzije>(entity =>
            {
                entity.HasKey(e => e.RecenzijaId);

                entity.Property(e => e.DatumKomentara).HasColumnType("datetime");

                entity.Property(e => e.Komentar)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Rezervacija)
                    .WithMany(p => p.Recenzije)
                    .HasForeignKey(d => d.RezervacijaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Recenzije_Rezervacije");
            });

            modelBuilder.Entity<Regije>(entity =>
            {
                entity.HasKey(e => e.RegijaId);

                entity.Property(e => e.Naziv)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Drzava)
                    .WithMany(p => p.Regije)
                    .HasForeignKey(d => d.DrzavaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Regije_Drzave");
            });

            modelBuilder.Entity<Rezervacije>(entity =>
            {
                entity.HasKey(e => e.RezervacijaId);

                entity.Property(e => e.DatumRezervacije).HasColumnType("datetime");

                entity.Property(e => e.UkupanIznos).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.Korisnik)
                    .WithMany(p => p.Rezervacije)
                    .HasForeignKey(d => d.KorisnikId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Rezervacije_Turisti");

                entity.HasOne(d => d.Putovanje)
                    .WithMany(p => p.Rezervacije)
                    .HasForeignKey(d => d.PutovanjeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Rezervacije_Putovanja");

                entity.HasOne(d => d.Smjestaj)
                    .WithMany(p => p.Rezervacije)
                    .HasForeignKey(d => d.SmjestajId)
                    .HasConstraintName("FK_Rezervacije_Smjestaji");

                entity.HasOne(d => d.StatusRezervacije)
                    .WithMany(p => p.Rezervacije)
                    .HasForeignKey(d => d.StatusRezervacijeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Rezervacije_StatusiRezervacija");
            });

            modelBuilder.Entity<Smjestaji>(entity =>
            {
                entity.HasKey(e => e.SmjestajId);

                entity.Property(e => e.CijenaNoc).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Naziv)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.WebStranica).HasMaxLength(50);

                entity.HasOne(d => d.Grad)
                    .WithMany(p => p.Smjestaji)
                    .HasForeignKey(d => d.GradId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Smjestaji_Gradovi");
            });

            modelBuilder.Entity<StatusiRezervacija>(entity =>
            {
                entity.HasKey(e => e.StatusRezervacijeId);

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<StatusiTurista>(entity =>
            {
                entity.HasKey(e => e.StatusTuristaId);

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<StatusiVodica>(entity =>
            {
                entity.HasKey(e => e.StatusVodicaId);

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Turisti>(entity =>
            {
                entity.HasKey(e => e.KorisnikId);

                entity.Property(e => e.KorisnikId).ValueGeneratedNever();

                entity.Property(e => e.Indeks)
                    .IsRequired()
                    .HasMaxLength(15);

                entity.HasOne(d => d.Grupa)
                    .WithMany(p => p.Turisti)
                    .HasForeignKey(d => d.GrupaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Turisti_Grupe");

                entity.HasOne(d => d.Korisnik)
                    .WithOne(p => p.Turisti)
                    .HasForeignKey<Turisti>(d => d.KorisnikId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_turisti");

                entity.HasOne(d => d.StatusTurista)
                    .WithMany(p => p.Turisti)
                    .HasForeignKey(d => d.StatusTuristaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Turisti_StatusiTurista");
            });

            modelBuilder.Entity<Zaduzenja>(entity =>
            {
                entity.HasKey(e => e.ZaduzenjeId)
                    .HasName("ZaduzenjePK");

                entity.Property(e => e.Opis).HasMaxLength(100);

                entity.HasOne(d => d.Putovanje)
                    .WithMany(p => p.Zaduzenja)
                    .HasForeignKey(d => d.PutovanjeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Zaduzenja_Putovanje_FK");

                entity.HasOne(d => d.Zaposlenik)
                    .WithMany(p => p.Zaduzenja)
                    .HasForeignKey(d => d.ZaposlenikId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Zaduzenja_Zaposlenik_FK");
            });

            modelBuilder.Entity<Zaposlenici>(entity =>
            {
                entity.HasKey(e => e.KorisnikId);

                entity.Property(e => e.KorisnikId).ValueGeneratedNever();

                entity.Property(e => e.DatumZaposljavanja).HasColumnType("datetime");

                entity.HasOne(d => d.Korisnik)
                    .WithOne(p => p.Zaposlenici)
                    .HasForeignKey<Zaposlenici>(d => d.KorisnikId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_zaposlenici");

                entity.HasOne(d => d.StatusVodica)
                    .WithMany(p => p.Zaposlenici)
                    .HasForeignKey(d => d.StatusVodicaId)
                    .HasConstraintName("FK_Zaposlenici_StatusiVodica");
            });
        }
    }
}
