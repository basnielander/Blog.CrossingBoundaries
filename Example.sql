

/* Query fired by Entity Framework, containing Where statements for product- and customername */
SELECT [t].[Id], [t].[Id0], 
	[orderItem.Order.OrderItems].[Amount], [orderItem.Order.OrderItems].[Id] AS [Id1], [orderItem.Order.OrderItems].[Price], 
	[orderItem.Order.OrderItems].[ProductName], [orderItem.Order.OrderItems].[OrderId]
FROM [OrderItems] AS [orderItem.Order.OrderItems]
INNER JOIN (
	SELECT [orderItem0].[Id], [orderItem.Order0].[Id] AS [Id0]
	FROM [OrderItems] AS [orderItem0]
	LEFT JOIN [Orders] AS [orderItem.Order0] ON [orderItem0].[OrderId] = [orderItem.Order0].[Id]
	LEFT JOIN [Customers] AS [orderItem.Order.Customer0] ON [orderItem.Order0].[CustomerId] = [orderItem.Order.Customer0].[Id]
	WHERE ((0 = 1) OR ((CHARINDEX(@__customerName_0, [orderItem.Order.Customer0].[Name]) > 0) OR (@__customerName_0 = N''))) 
	AND ((CHARINDEX(@__productName_1, [orderItem0].[ProductName]) > 0) OR (@__productName_1 = N''))) AS [t] 
		ON [orderItem.Order.OrderItems].[OrderId] = [t].[Id0]
ORDER BY [t].[Id], [t].[Id0]