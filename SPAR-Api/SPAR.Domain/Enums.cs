namespace SPAR.Domain;

public enum SlutAnvändarUtökadBehörighet
{
    Relationer,
    Medborgarskap,
    Taxering,
    Sekretess
}

public enum ItemsChoice
{
    IdNummer,
    DistriktKod,
    DistriktKodFrom,
    DistriktKodTom,
    Fodelsedatum,
    FodelsedatumFrom,
    FodelsedatumTom,
    FonetiskSokning,
    FornamnSokArgument,
    KommunKod,
    Kon,
    LanKod,
    MellanEfternamnSokArgument,
    NamnSokArgument,
    PostNr,
    PostNrFrom,
    PostNrTom,
    PostortSokArgument,
    UtdelningsadressSokArgument
}

public enum JaNej
{
    JA,
    NEJ
}

public enum SekretessSattAvSPAR
{
    JA,
}

public enum Kön
{
    MAN,
    KVINNA
}

public enum HänvisningTyp
{
    Till,
    Fran
}

public enum Hemvist
{
    Skrivenpåadressen,
    Påkommunenskriven,
    Utankänthemvist
}

public enum Relationstyp
{
    VÅRDNADSHAVARE,
    MAKEMAKAREGISTRERADPARTNER,
}