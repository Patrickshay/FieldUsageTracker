Field Usage Tracker (FUT)

Overview
Field Usage Tracker (FUT) is a tool designed to analyze and track unused fields in a database or application. It aligns with the Field Usage Optimization Metric (FUOM), enabling developers and data architects to optimize their data models by identifying redundant fields, improving efficiency, and reducing storage costs.

Features
•	Tracks field usage across a database or application.
•	Generates detailed reports on unused or underutilized fields.
•	Provides CSV export functionality for easy report sharing.
•	Helps optimize data models by highlighting redundant fields.

Technology Stack
•	Programming Language: C#
•	Frameworks: .NET Core
•	Database Support: SQL Server
•	Other Tools: GitHub'

Installation
1.	Clone the repository: 
2.	git clone https://github.com/Patrickshay/FieldUsageTracker.git
3.	Navigate to the project directory: 
4.	Change the appsettings.Json with your SSMS configuration as given in my configuration or else it will throw exception
5.	Build the project
6.	Run and check if the CSV file is generated or not. (It should be generated)

Usage
1.	Run the Application:
2.	Run FieldUsageTracker
3.	CSV Report Generation:
o	The tool automatically generates a CSV report with field usage data.
o	Report is saved as FieldUsageReport.csv in the project directory.
4.	Customizing Input Data:
o	Modify the usageResults list in Program.cs to include customized data from database

Example Report
The CSV report includes:
•	FieldName: Name of the field.
•	UsageCount: The number of times the field was accessed or updated.

Example:
FieldName	              UsageCount
OrderID	                8
CustomerName	          8
ProductDetails	        8
DiscountCode	          6
WarehouseLocation	      1

Author
Pratikshay Awadhoot



