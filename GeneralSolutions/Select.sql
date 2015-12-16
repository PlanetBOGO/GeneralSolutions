SELECT item.Number, item.Color, item.Weight, item.Price, item.IsAvailable, Category.Name as Category
FROM Item
LEFT JOIN Category on Category.Id = Item.CategoryId