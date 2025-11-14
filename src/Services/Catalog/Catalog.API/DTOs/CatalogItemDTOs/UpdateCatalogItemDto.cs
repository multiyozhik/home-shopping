namespace Catalog.API.DTOs.CatalogItemDTOs;

public record UpdateCatalogItemDto(
    Guid Id,
    string? Title, 
    string? ShortDescription, 
    string? FullDescription,
    string? ImageUrl,
    Brand? Brand,
    Category? Category,
    decimal Price);