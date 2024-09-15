using SPAR.Domain;

namespace SPAR.Application.PersonalData.Models;

public record PersonSökRequest(Identifieringsinformation Identifieringsinformation, PersonsökningFråga PersonsokningFraga);