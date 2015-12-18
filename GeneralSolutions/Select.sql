SELECT item.Id, item.Number, item.Color, item.Weight, item.Price, item.IsAvailable, item.CategoryId, Category.Name as Category
FROM Item
LEFT JOIN Category on Category.Id = Item.CategoryId