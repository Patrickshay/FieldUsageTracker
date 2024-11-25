using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace FieldUsageTracker
{
    class CsvGenerator
    {
        public void GenerateCsv(string csvPath, List<FieldUsageResult> fieldUsageResults)
        {
            using (StreamWriter writer = new StreamWriter(csvPath))
            {
                // Write the header
                writer.WriteLine("FieldName,UsageCount");

                // Write each field usage result
                foreach (var field in fieldUsageResults)
                {
                    writer.WriteLine($"{field.FieldName},{field.UsageCount}");
                }
            }

            Console.WriteLine($"\nField usage report has been saved to: {Path.GetFullPath(csvPath)}");
        }
    }
}
