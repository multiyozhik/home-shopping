namespace Catalog.Application.Models.CatalogItemModels;

public record CreateCatalogItemModel(
    string? Title,
    string? ShortDescription,
    string? FullDescription, 
    string? ImageUrl,
    Brand? Brand, 
    Category? Category,
    decimal Price);