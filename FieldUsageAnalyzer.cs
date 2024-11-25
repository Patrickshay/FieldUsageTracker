using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;

namespace FieldUsageTracker
{
    public class FieldUsageResult
    {
        public string FieldName { get; set; }
        public int UsageCount { get; set; }
    }

        public class FieldUsageAnalyzer(SqlConnection connection)
    {
            private readonly SqlConnection _connection = connection;

        // Analyze field usage by checking actual data in the Orders table
        public List<FieldUsageResult> AnalyzeFieldUsage()
            {
                // Initialize usage counts for each field
                var fieldUsage = new List<FieldUsageResult>
            {
                new() { FieldName = "OrderID", UsageCount = 0 },
                new() { FieldName = "CustomerName", UsageCount = 0 },
                new() { FieldName = "ProductDetails", UsageCount = 0 },
                new() { FieldName = "DiscountCode", UsageCount = 0 },
                new() { FieldName = "WarehouseLocation", UsageCount = 0 }
            };

                // SQL query to check non-NULL values for each field in Orders table
                string query = @"
                SELECT
                    COUNT(OrderID) AS OrderIDCount,
                    COUNT(CustomerName) AS CustomerNameCount,
                    COUNT(ProductDetails) AS ProductDetailsCount,
                    COUNT(DiscountCode) AS DiscountCodeCount,
                    COUNT(WarehouseLocation) AS WarehouseLocationCount
                FROM Orders;
            ";

                using (var command = new SqlCommand(query, _connection))
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        // Fetch usage counts from the result of the query
                        fieldUsage[0].UsageCount = reader.GetInt32(0); // OrderID
                        fieldUsage[1].UsageCount = reader.GetInt32(1); // CustomerName
                        fieldUsage[2].UsageCount = reader.GetInt32(2); // ProductDetails
                        fieldUsage[3].UsageCount = reader.GetInt32(3); // DiscountCode
                        fieldUsage[4].UsageCount = reader.GetInt32(4); // WarehouseLocation
                    }
                }

                return fieldUsage; // Return the results to Program.cs
            }
        }
  }


