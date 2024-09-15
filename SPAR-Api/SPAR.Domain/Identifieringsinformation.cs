namespace SPAR.Domain;

public record Identifieringsinformation(
    int KundNrLeveransMottagare,
    int KundNrSlutkund,
    long UppdragId,
    string SlutAnvandarId,
    IEnumerable<SlutAnvändarUtökadBehörighet> SlutAnvandarUtokadBehorighet
);