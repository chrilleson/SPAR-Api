namespace SPAR.Domain;

public record PersonsökningFråga(IEnumerable<object> Items, IEnumerable<ItemsChoice> ItemsElementName);