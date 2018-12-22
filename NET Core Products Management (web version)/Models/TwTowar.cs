using System;
using System.Collections.Generic;

namespace NET_Core_Products_Management__web_version_.Models
{
    public partial class TwTowar
    {
        public int TwId { get; set; }
        public bool TwZablokowany { get; set; }
        public int TwRodzaj { get; set; }
        public string TwSymbol { get; set; }
        public string TwNazwa { get; set; }
        public string TwOpis { get; set; }
        public int? TwIdVatSp { get; set; }
        public int? TwIdVatZak { get; set; }
        public bool? TwJakPrzySp { get; set; }
        public string TwJednMiary { get; set; }
        public string TwPkwiU { get; set; }
        public string TwSww { get; set; }
        public int? TwIdRabat { get; set; }
        public int? TwIdOpakowanie { get; set; }
        public bool? TwPrzezWartosc { get; set; }
        public int? TwIdPodstDostawca { get; set; }
        public string TwDostSymbol { get; set; }
        public int? TwCzasDostawy { get; set; }
        public string TwUrzNazwa { get; set; }
        public int? TwPlu { get; set; }
        public string TwPodstKodKresk { get; set; }
        public int? TwIdTypKodu { get; set; }
        public bool TwCenaOtwarta { get; set; }
        public bool? TwWagaEtykiet { get; set; }
        public bool TwKontrolaTw { get; set; }
        public decimal? TwStanMin { get; set; }
        public string TwJednStanMin { get; set; }
        public int? TwDniWaznosc { get; set; }
        public int? TwIdGrupa { get; set; }
        public string TwWww { get; set; }
        public bool TwSklepInternet { get; set; }
        public string TwPole1 { get; set; }
        public string TwPole2 { get; set; }
        public string TwPole3 { get; set; }
        public string TwPole4 { get; set; }
        public string TwPole5 { get; set; }
        public string TwPole6 { get; set; }
        public string TwPole7 { get; set; }
        public string TwPole8 { get; set; }
        public string TwUwagi { get; set; }
        public byte[] TwLogo { get; set; }
        public bool TwUsuniety { get; set; }
        public decimal? TwObjetosc { get; set; }
        public decimal? TwMasa { get; set; }
        public string TwCharakter { get; set; }
        public string TwJednMiaryZak { get; set; }
        public bool TwJmzakInna { get; set; }
        public string TwKodTowaru { get; set; }
        public int? TwIdKrajuPochodzenia { get; set; }
        public int? TwIdUjm { get; set; }
        public string TwJednMiarySprz { get; set; }
        public bool TwJmsprzInna { get; set; }
        public bool TwSerwisAukcyjny { get; set; }
        public int? TwIdProducenta { get; set; }
        public bool TwSprzedazMobilna { get; set; }
        public bool? TwIsFundPromocji { get; set; }
        public int? TwIdFundPromocji { get; set; }
        public int? TwDomyslnaKategoria { get; set; }
        public decimal? TwWysokosc { get; set; }
        public decimal? TwSzerokosc { get; set; }
        public decimal? TwGlebokosc { get; set; }
        public decimal? TwStanMaks { get; set; }
        public bool TwAkcyza { get; set; }
        public bool TwAkcyzaZaznacz { get; set; }
        public decimal? TwAkcyzaKwota { get; set; }
        public bool TwObrotMarza { get; set; }
        public bool TwOdwrotneObciazenie { get; set; }
        public int TwProgKwotowyOo { get; set; }
        public bool TwDodawalnyDoZw { get; set; }
    }
}
