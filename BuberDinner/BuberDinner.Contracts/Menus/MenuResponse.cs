namespace BuberDinner.Contracts.Menus;

public record MenuResponse (
    string Id,
    string Name,
    string Description,
    float? AverageRating,
    List<MenuSectionResponse> Sections,
    string HostId,
    List<string> DinnerIds,
    List<string> MenuReviewIds,
    DateTime CreatedTime,
    DateTime UpdatedTime
);
public record MenuSectionResponse (
    string Id,
    string Name,
    string Description,
    List<MenuItemResponse> Items
);
public record MenuItemResponse (
    string Id,
    string Name,
    string Description
);