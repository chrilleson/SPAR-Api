using SPAR.Domain;

namespace SPAR.Application.PersonalData.Models;

public record PersonSökResponse(PersonsökningFråga PersonsokningFraga, IEnumerable<object> Items)
{
    public static PersonSökResponse Create(PersonsökningFråga personsokningFraga, IEnumerable<object> items) => new(personsokningFraga, items);
};