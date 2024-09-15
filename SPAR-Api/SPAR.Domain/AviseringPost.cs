using Bogus;

namespace SPAR.Domain;

public record AviseringPost(
    PersonId PersonId,
    Sekretessmarkering Sekretessmarkering,
    DateTime SekretessDatum,
    bool SekretessDatumSpecified,
    JaNej SkyddadFolkbokforing,
    DateTime SkyddadFolkbokforingDatum,
    bool SkyddadFolkbokforingDatumSpecified,
    DateTime SenasteAndringSPAR,
    bool SenasteAndringSPARSpecified,
    string SummeradInkomst,
    string InkomstAr,
    IEnumerable<Namn> Namn,
    IEnumerable<Persondetaljer> Persondetaljer,
    IEnumerable<Folkbokföring> Folkbokforing,
    IEnumerable<Folkbokföringsadress> Folkbokforingsadress,
    IEnumerable<SärskildPostadress> SarskildPostadress,
    IEnumerable<Utlandsadress> Utlandsadress,
    IEnumerable<Kontaktadress> Kontaktadress,
    IEnumerable<Relation> Relation,
    IEnumerable<Fastighet> Fastighet
)
{
    public static IEnumerable<AviseringPost> CreateFakes() => new Faker<AviseringPost>()
        .CustomInstantiator(f => new AviseringPost(
            PersonId.Fake(),
            Sekretessmarkering.Fake(),
            f.Date.Past(),
            true,
            f.PickRandom<JaNej>(),
            f.Date.Past(),
            true,
            f.Date.Past(),
            true,
            f.Random.String2(5, 5),
            f.Random.String2(5, 5),
            [Domain.Namn.Fake()],
            [Domain.Persondetaljer.Fake()],
            [Folkbokföring.Fake()],
            [Folkbokföringsadress.Fake()],
            [SärskildPostadress.Fake()],
            [Domain.Utlandsadress.Fake()],
            [Domain.Kontaktadress.Fake()],
            [Domain.Relation.Fake()],
            [Domain.Fastighet.Fake()]
        ))
        .Generate(1);
}

public record PersonId(string IdNummer, string Typ)
{
    public static PersonId Create(string idNummer, string typ) => new(idNummer, typ);
    public static PersonId Fake() => new Faker<PersonId>()
        .CustomInstantiator(f => new PersonId(f.Random.String2(10, 10), f.Random.String2(5, 5)));
}

public record Sekretessmarkering(SekretessSattAvSPAR sattAvSPAR, bool sattAvSPARSpecified, JaNej Value)
{
    public static Sekretessmarkering Create(SekretessSattAvSPAR sattAvSpar, bool sattAvSparSpecified, JaNej value) => new(sattAvSpar, sattAvSparSpecified, value);
    public static Sekretessmarkering Fake() => new Faker<Sekretessmarkering>()
        .CustomInstantiator(f => new Sekretessmarkering(
            f.PickRandom<SekretessSattAvSPAR>(),
            true,
            f.PickRandom<JaNej>()
        ));
}

public record Namn(
    DateTime DatumFrom,
    DateTime DatumTill,
    string Aviseringsnamn,
    string Fornamn,
    int Tilltalsnamn,
    bool TilltalsnamnSpecified,
    string Mellannamn,
    string Efternamn
)
{
    public static Namn Create(DateTime datumFrom, DateTime datumTill, string aviseringsnamn, string fornamn, int tilltalsnamn, bool tilltalsnamnSpecified, string mellannamn, string efternamn) =>
        new(datumFrom, datumTill, aviseringsnamn, fornamn, tilltalsnamn, tilltalsnamnSpecified, mellannamn, efternamn);
    public static Namn Fake() => new Faker<Namn>()
        .CustomInstantiator(f => new Namn(
            f.Date.Past(),
            f.Date.Past(),
            f.Random.String2(5, 5),
            f.Random.String2(5, 5),
            f.Random.Int(),
            true,
            f.Random.String2(5, 5),
            f.Random.String2(5, 5)
        ));
}

public record Persondetaljer(
    DateTime DatumFrom,
    DateTime DatumTill,
    Sekretessmarkering Sekretessmarkering,
    JaNej SkyddadFolkbokforing,
    bool SkyddadFolkbokforingSpecified,
    string AvregistreringsorsakKod,
    string Avregistreringsdatum,
    string Avlidendatum,
    string AntraffadDodDatum,
    DateTime Fodelsedatum,
    bool FodelsedatumSpecified,
    string FodelselanKod,
    string Fodelseforsamling,
    Kön Kon,
    bool KonSpecified,
    JaNej SvenskMedborgare,
    bool SvenskMedborgareSpecified,
    IEnumerable<Hänvisning> Hanvisning,
    string SnStatus,
    string SnTilldelningsdatum,
    string SnPreliminartVilandeforklaringsdatum,
    string SnFornyelsedatum,
    string SnVilandeorsak,
    string SnVilandeforklaringsdatum,
    string SnAvlidendatum
)
{
    public static Persondetaljer Create(DateTime datumFrom, DateTime datumTill, Sekretessmarkering sekretessmarkering, JaNej skyddadFolkbokforing, bool skyddadFolkbokforingSpecified, string avregistreringsorsakKod, string avregistreringsdatum, string avlidendatum, string antraffadDodDatum, DateTime fodelsedatum, bool fodelsedatumSpecified, string fodelselanKod, string fodelseforsamling, Kön kon, bool konSpecified, JaNej svenskMedborgare, bool svenskMedborgareSpecified, IEnumerable<Hänvisning> hanvisning, string snStatus, string snTilldelningsdatum, string snPreliminartVilandeforklaringsdatum, string snFornyelsedatum, string snVilandeorsak, string snVilandeforklaringsdatum, string snAvlidendatum) =>
        new(datumFrom, datumTill, sekretessmarkering, skyddadFolkbokforing, skyddadFolkbokforingSpecified, avregistreringsorsakKod, avregistreringsdatum, avlidendatum, antraffadDodDatum, fodelsedatum, fodelsedatumSpecified, fodelselanKod, fodelseforsamling, kon, konSpecified, svenskMedborgare, svenskMedborgareSpecified, hanvisning, snStatus, snTilldelningsdatum, snPreliminartVilandeforklaringsdatum, snFornyelsedatum, snVilandeorsak, snVilandeforklaringsdatum, snAvlidendatum);
    public static Persondetaljer Fake() => new Faker<Persondetaljer>()
        .CustomInstantiator(f => new Persondetaljer(
            f.Date.Past(),
            f.Date.Past(),
            Sekretessmarkering.Fake(),
            f.PickRandom<JaNej>(),
            true,
            f.Random.String2(5, 5),
            f.Random.String2(5, 5),
            f.Random.String2(5, 5),
            f.Random.String2(5, 5),
            f.Date.Past(),
            true,
            f.Random.String2(5, 5),
            f.Random.String2(5, 5),
            f.PickRandom<Kön>(),
            true,
            f.PickRandom<JaNej>(),
            true,
            [Hänvisning.Fake()],
            f.Random.String2(5, 5),
            f.Random.String2(5, 5),
            f.Random.String2(5, 5),
            f.Random.String2(5, 5),
            f.Random.String2(5, 5),
            f.Random.String2(5, 5),
            f.Random.String2(5, 5)
        ));
}

public record Folkbokföring(DateTime DatumFrom, DateTime DatumTill, string FolkbokfordLanKod, string FolkbokfordKommunKod, Hemvist Hemvist, bool HemvistSpecified, DateTime Folkbokforingsdatum, bool FolkbokforingsdatumSpecified, string DistriktKod)
{
    public static Folkbokföring Fake() => new Faker<Folkbokföring>()
        .CustomInstantiator(f => new Folkbokföring(
            f.Date.Past(),
            f.Date.Past(),
            f.Random.String2(5, 5),
            f.Random.String2(5, 5),
            f.PickRandom<Hemvist>(),
            true,
            f.Date.Past(),
            true,
            f.Random.String2(5, 5)
        ));
}

public record Folkbokföringsadress(SvenskAdress SvenskAdress)
{
    public static Folkbokföringsadress Fake() => new Faker<Folkbokföringsadress>()
        .CustomInstantiator(f => new Folkbokföringsadress(SvenskAdress.Fake()));
}

public record SärskildPostadress(object Item)
{
    public static SärskildPostadress Fake() => new Faker<SärskildPostadress>()
        .CustomInstantiator(f => new SärskildPostadress(f.Random.String2(10, 10)));
}

public record Utlandsadress(InternationellAdress InternationellAdress)
{
    public static Utlandsadress Fake() => new Faker<Utlandsadress>()
        .CustomInstantiator(f => new Utlandsadress(InternationellAdress.Fake()));
}

public record Kontaktadress(object Item)
{
    public static Kontaktadress Fake() => new Faker<Kontaktadress>()
        .CustomInstantiator(f => new Kontaktadress(f.Random.String2(10, 10)));
}

public record Relation(
    DateTime DatumFrom,
    DateTime DatumTill,
    Relationstyp Relationstyp,
    string IdNummer,
    string Fornamn,
    string Mellannamn,
    string Efternamn,
    DateTime Fodelsetid,
    bool FodelsetidSpecified,
    string AvregistreringsorsakKod,
    string Avregistreringsdatum,
    string Avlidendatum)
{
    public static Relation Fake() => new Faker<Relation>()
        .CustomInstantiator(f => new Relation(
            f.Date.Past(),
            f.Date.Past(),
            f.PickRandom<Relationstyp>(),
            f.Random.String2(5, 5),
            f.Random.String2(5, 5),
            f.Random.String2(5, 5),
            f.Random.String2(5, 5),
            f.Date.Past(),
            true,
            f.Random.String2(5, 5),
            f.Random.String2(5, 5),
            f.Random.String2(5, 5)
        ));
}

public record Fastighet(
    string Taxeringsenhetsnummer,
    string LanKod,
    string KommunKod,
    string FastighetKod,
    string Taxeringsar,
    string Taxeringsvarde,
    IEnumerable<FastighetDel> FastighetDel)
{
    public static Fastighet Fake() => new Faker<Fastighet>()
        .CustomInstantiator(f => new Fastighet(
            f.Random.String2(5, 5),
            f.Random.String2(5, 5),
            f.Random.String2(5, 5),
            f.Random.String2(5, 5),
            f.Random.String2(4, 4, "0123456789"),
            f.Random.String2(5, 5, "0123456789"),
            [Domain.FastighetDel.Fake()]
        ));
}

public record Hänvisning(string IdNummer, HänvisningTyp Typ, bool TypSpecified)
{
    public static Hänvisning Create(string idNummer, HänvisningTyp typ, bool typSpecified) => new(idNummer, typ, typSpecified);

    public static Hänvisning Fake() => new Faker<Hänvisning>()
        .CustomInstantiator(f => new Hänvisning(
            f.Random.String2(5, 5),
            f.PickRandom<HänvisningTyp>(),
            true
        ));
}

public record SvenskAdress(DateTime DatumFrom, DateTime DatumTill, string CareOf, string Utdelningsadress1, string Utdelningsadress2, string PostNr, string Postort)
{
    public static SvenskAdress Fake() => new Faker<SvenskAdress>()
        .CustomInstantiator(f => new SvenskAdress(
            f.Date.Past(),
            f.Date.Past(),
            f.Random.String2(5, 5),
            f.Random.String2(5, 5),
            f.Random.String2(5, 5),
            f.Random.String2(5, 5, "0123456789"),
            f.Random.String2(5, 5)
        ));
}

public record InternationellAdress(DateTime DatumFrom, DateTime DatumTill, string Utdelningsadress1, string Utdelningsadress2, string Utdelningsadress3, string Land)
{
    public static InternationellAdress Fake() => new Faker<InternationellAdress>()
        .CustomInstantiator(f => new InternationellAdress(
            f.Date.Past(),
            f.Date.Past(),
            f.Random.String2(5, 5),
            f.Random.String2(5, 5),
            f.Random.String2(5, 5),
            f.Random.String2(5, 5)
        ));
}

public record FastighetDel(string Taxeringsidentitet, string FastighetBeteckning, string AndelstalTaljare, string AndelstalNamnare)
{
    public static FastighetDel Fake() => new Faker<FastighetDel>()
        .CustomInstantiator(f => new FastighetDel(
            f.Random.String2(5, 5),
            f.Random.String2(5, 5),
            f.Random.String2(5, 5),
            f.Random.String2(5, 5)
        ));
}