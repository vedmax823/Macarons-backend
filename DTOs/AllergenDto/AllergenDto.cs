namespace DonMacaron.DTOs.AllergenDto;

public record class AllergenDto
(
    Guid Id,
    string Name,
    string Link,
    DateTimeOffset CreatedAt,
    DateTimeOffset UpdatedAt
);
