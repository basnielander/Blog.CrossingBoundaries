
/* Query fired by Entity Framework */
SELECT [o].[Id], [o].[Amount], [o].[OrderId], [o].[Price], [o].[ProductName], 
		[o.Order].[Id], [o.Order].[CustomerId], 
		[o.Order.Customer].[Id], [o.Order.Customer].[Name]
FROM [OrderItems] AS [o]
LEFT JOIN [Orders] AS [o.Order] ON [o].[OrderId] = [o.Order].[Id]
LEFT JOIN [Customers] AS [o.Order.Customer] ON [o.Order].[CustomerId] = [o.Order.Customer].[Id]