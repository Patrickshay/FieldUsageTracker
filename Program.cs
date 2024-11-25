using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace FieldUsageTracker
{
    class Program
    {
        static void Main(string[] args)
        {
            // Load configuration from appsettings.json
            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            string connectionString = configuration.GetConnectionString("DefaultConnection");

            try
            {
                Console.WriteLine("Connecting to the database...");
                using (SqlConnection connection = new(connectionString))
                {
                    connection.Open();
                    Console.WriteLine("Database connection successful!");

                    // Retrieve and analyze data
                    FieldUsageAnalyzer analyzer = new(connection);
                    var usageResults = analyzer.AnalyzeFieldUsage();

                    // Display results
                    Console.WriteLine("\nField Usage Results:");
                    foreach (var result in usageResults)
                    {
                        Console.WriteLine($"Field: {result.FieldName}, Usage Count: {result.UsageCount}");
                    }

                    Console.WriteLine("\nFields with Low Usage (Usage < 2):");
                    foreach (var result in usageResults)
                    {
                        if (result.UsageCount < 2)
                        {
                            Console.WriteLine($"Field: {result.FieldName} is potentially redundant.");
                        }
                    }

                    // Saving a CSV file in local
                    string csvPath = "FieldUsageReport.csv";

                    // Create an instance of CsvGenerator and generate the CSV
                    var csvGenerator = new CsvGenerator();
                    csvGenerator.GenerateCsv(csvPath, usageResults);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}
