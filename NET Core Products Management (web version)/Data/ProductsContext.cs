using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace NET_Core_Products_Management__web_version_.Models
{
    public partial class ProductsContext : DbContext
    {
        public ProductsContext()
        {
        }

        public ProductsContext(DbContextOptions<ProductsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<SlMagazyn> SlMagazyn { get; set; }
        public virtual DbSet<TwStan> TwStan { get; set; }
        public virtual DbSet<TwTowar> TwTowar { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("data source=SESHBOY-PC; initial catalog=LocalDB; trusted_connection=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SlMagazyn>(entity =>
            {
                entity.HasKey(e => e.MagId);

                entity.ToTable("sl_Magazyn");

                entity.Property(e => e.MagId)
                    .HasColumnName("mag_Id")
                    .ValueGeneratedNever();

                entity.Property(e => e.MagAnalityka)
                    .HasColumnName("mag_Analityka")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.MagGlowny).HasColumnName("mag_Glowny");

                entity.Property(e => e.MagNazwa)
                    .IsRequired()
                    .HasColumnName("mag_Nazwa")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.MagOpis)
                    .HasColumnName("mag_Opis")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.MagPos).HasColumnName("mag_POS");

                entity.Property(e => e.MagPosadres)
                    .HasColumnName("mag_POSAdres")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.MagPosident).HasColumnName("mag_POSIdent");

                entity.Property(e => e.MagPosnazwa)
                    .HasColumnName("mag_POSNazwa")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.MagStatus)
                    .HasColumnName("mag_Status")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.MagSymbol)
                    .IsRequired()
                    .HasColumnName("mag_Symbol")
                    .HasMaxLength(3)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TwStan>(entity =>
            {
                entity.HasKey(e => new { e.StTowId, e.StMagId });

                entity.ToTable("tw_Stan");

                entity.Property(e => e.StTowId).HasColumnName("st_TowId");

                entity.Property(e => e.StMagId).HasColumnName("st_MagId");

                entity.Property(e => e.StStan)
                    .HasColumnName("st_Stan")
                    .HasColumnType("money");

                entity.Property(e => e.StStanMax)
                    .HasColumnName("st_StanMax")
                    .HasColumnType("money");

                entity.Property(e => e.StStanMin)
                    .HasColumnName("st_StanMin")
                    .HasColumnType("money");

                entity.Property(e => e.StStanRez)
                    .HasColumnName("st_StanRez")
                    .HasColumnType("money");
            });

            modelBuilder.Entity<TwTowar>(entity =>
            {
                entity.HasKey(e => e.TwId);

                entity.ToTable("tw__Towar");

                entity.Property(e => e.TwId)
                    .HasColumnName("tw_Id")
                    .ValueGeneratedNever();

                entity.Property(e => e.TwAkcyza).HasColumnName("tw_Akcyza");

                entity.Property(e => e.TwAkcyzaKwota)
                    .HasColumnName("tw_AkcyzaKwota")
                    .HasColumnType("money");

                entity.Property(e => e.TwAkcyzaZaznacz).HasColumnName("tw_AkcyzaZaznacz");

                entity.Property(e => e.TwCenaOtwarta).HasColumnName("tw_CenaOtwarta");

                entity.Property(e => e.TwCharakter)
                    .HasColumnName("tw_Charakter")
                    .HasColumnType("text");

                entity.Property(e => e.TwCzasDostawy).HasColumnName("tw_CzasDostawy");

                entity.Property(e => e.TwDniWaznosc).HasColumnName("tw_DniWaznosc");

                entity.Property(e => e.TwDodawalnyDoZw).HasColumnName("tw_DodawalnyDoZW");

                entity.Property(e => e.TwDomyslnaKategoria).HasColumnName("tw_DomyslnaKategoria");

                entity.Property(e => e.TwDostSymbol)
                    .HasColumnName("tw_DostSymbol")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.TwGlebokosc)
                    .HasColumnName("tw_Glebokosc")
                    .HasColumnType("money");

                entity.Property(e => e.TwIdFundPromocji).HasColumnName("tw_IdFundPromocji");

                entity.Property(e => e.TwIdGrupa).HasColumnName("tw_IdGrupa");

                entity.Property(e => e.TwIdKrajuPochodzenia).HasColumnName("tw_IdKrajuPochodzenia");

                entity.Property(e => e.TwIdOpakowanie).HasColumnName("tw_IdOpakowanie");

                entity.Property(e => e.TwIdPodstDostawca).HasColumnName("tw_IdPodstDostawca");

                entity.Property(e => e.TwIdProducenta).HasColumnName("tw_IdProducenta");

                entity.Property(e => e.TwIdRabat).HasColumnName("tw_IdRabat");

                entity.Property(e => e.TwIdTypKodu).HasColumnName("tw_IdTypKodu");

                entity.Property(e => e.TwIdUjm).HasColumnName("tw_IdUJM");

                entity.Property(e => e.TwIdVatSp).HasColumnName("tw_IdVatSp");

                entity.Property(e => e.TwIdVatZak).HasColumnName("tw_IdVatZak");

                entity.Property(e => e.TwIsFundPromocji).HasColumnName("tw_IsFundPromocji");

                entity.Property(e => e.TwJakPrzySp)
                    .IsRequired()
                    .HasColumnName("tw_JakPrzySp")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.TwJednMiary)
                    .IsRequired()
                    .HasColumnName("tw_JednMiary")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.TwJednMiarySprz)
                    .IsRequired()
                    .HasColumnName("tw_JednMiarySprz")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.TwJednMiaryZak)
                    .IsRequired()
                    .HasColumnName("tw_JednMiaryZak")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.TwJednStanMin)
                    .HasColumnName("tw_JednStanMin")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.TwJmsprzInna).HasColumnName("tw_JMSprzInna");

                entity.Property(e => e.TwJmzakInna).HasColumnName("tw_JMZakInna");

                entity.Property(e => e.TwKodTowaru)
                    .HasColumnName("tw_KodTowaru")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.TwKontrolaTw).HasColumnName("tw_KontrolaTW");

                entity.Property(e => e.TwLogo)
                    .HasColumnName("tw_Logo")
                    .HasMaxLength(50);

                entity.Property(e => e.TwMasa)
                    .HasColumnName("tw_Masa")
                    .HasColumnType("money");

                entity.Property(e => e.TwNazwa)
                    .IsRequired()
                    .HasColumnName("tw_Nazwa")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.TwObjetosc)
                    .HasColumnName("tw_Objetosc")
                    .HasColumnType("money");

                entity.Property(e => e.TwObrotMarza).HasColumnName("tw_ObrotMarza");

                entity.Property(e => e.TwOdwrotneObciazenie).HasColumnName("tw_OdwrotneObciazenie");

                entity.Property(e => e.TwOpis)
                    .HasColumnName("tw_Opis")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.TwPkwiU)
                    .HasColumnName("tw_PKWiU")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.TwPlu).HasColumnName("tw_PLU");

                entity.Property(e => e.TwPodstKodKresk)
                    .HasColumnName("tw_PodstKodKresk")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.TwPole1)
                    .HasColumnName("tw_Pole1")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.TwPole2)
                    .HasColumnName("tw_Pole2")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.TwPole3)
                    .HasColumnName("tw_Pole3")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.TwPole4)
                    .HasColumnName("tw_Pole4")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.TwPole5)
                    .HasColumnName("tw_Pole5")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.TwPole6)
                    .HasColumnName("tw_Pole6")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.TwPole7)
                    .HasColumnName("tw_Pole7")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.TwPole8)
                    .HasColumnName("tw_Pole8")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.TwProgKwotowyOo).HasColumnName("tw_ProgKwotowyOO");

                entity.Property(e => e.TwPrzezWartosc)
                    .IsRequired()
                    .HasColumnName("tw_PrzezWartosc")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.TwRodzaj)
                    .HasColumnName("tw_Rodzaj")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.TwSerwisAukcyjny).HasColumnName("tw_SerwisAukcyjny");

                entity.Property(e => e.TwSklepInternet).HasColumnName("tw_SklepInternet");

                entity.Property(e => e.TwSprzedazMobilna).HasColumnName("tw_SprzedazMobilna");

                entity.Property(e => e.TwStanMaks)
                    .HasColumnName("tw_StanMaks")
                    .HasColumnType("money");

                entity.Property(e => e.TwStanMin)
                    .HasColumnName("tw_StanMin")
                    .HasColumnType("money");

                entity.Property(e => e.TwSww)
                    .HasColumnName("tw_SWW")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.TwSymbol)
                    .IsRequired()
                    .HasColumnName("tw_Symbol")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.TwSzerokosc)
                    .HasColumnName("tw_Szerokosc")
                    .HasColumnType("money");

                entity.Property(e => e.TwUrzNazwa)
                    .HasColumnName("tw_UrzNazwa")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.TwUsuniety).HasColumnName("tw_Usuniety");

                entity.Property(e => e.TwUwagi)
                    .HasColumnName("tw_Uwagi")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.TwWagaEtykiet)
                    .HasColumnName("tw_WagaEtykiet")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.TwWww)
                    .HasColumnName("tw_WWW")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.TwWysokosc)
                    .HasColumnName("tw_Wysokosc")
                    .HasColumnType("money");

                entity.Property(e => e.TwZablokowany).HasColumnName("tw_Zablokowany");
            });
        }
    }
}
