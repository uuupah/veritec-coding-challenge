# Veritec Coding Challenge
A c# cli app to convert a gross salary package to a pay packet breakdown. 

## Getting Started
Ensure that you have the dotnet sdk installed from here: https://dotnet.microsoft.com/en-us/download/dotnet/6.0

Clone the program to your local system, navigate into the project directory in your terminal, and run
```dotnet run```

## Example Output
```
Enter your salary package amount: 220000
Enter your pay frequency (W for weekly, F for fortnightly, M for monthly): F

Calculating salary details...

Gross package: $220,000.00
Superannuation: $19,086.76

Taxable Income: $200,913.24

Deductions:
Medicare Levy: 4019
Budget Repair Levy: 419
Income Tax: 64062

Net Income: $132,413.24
Pay Packet: $5,078.86 per fortnight

Press any key to end...
```

## Assumptions
- This system assumes that the tasks will not be repeated and by extension, will not benefit from multithreading for bulk tasks.
- The system assumes the three pay frequency options will not change, and will throw exceptions if unfamiliar pay frequency options are used.

## Code Considerations
- As tax and income laws tend to change fairly regularly, maintainability is important, as well as the ability to add or modify existing tax laws. To avoid difficult to navigate and ugly code, tax codes extend a generic [`TaxCode.cs`](src/taxCode/TaxCode.cs) class. This allows developers to remove this tax code from all calculation, or add a new tax code to all calculations, simply by modifying the constructor in the [`SalaryCalcs.cs`](src/util/SalaryCalcs.cs) class.
- The system relies on [`DeductionData.cs`](src/model/DeductionData.cs) and [`PayrollDetails.cs`](src/model/PayrollDetails.cs) to bundle values that will be used in tandem for easier data transport. This (and especially [`PayrollDetails.cs`](src/model/PayrollDetails.cs)'s constructor) ensures that the right data is passed into the requisite classes.
- The [`PayFreq.cs`](src/model/PayFreq.cs) uses some less-than-user-friendly values, which could benefit from being converted to more literal names (weekly, fortnightly, monthly). This was not implemented as it would require some code refactoring and modification, and was deemed low priority.

## Extension
- The system can account for income rule and tax code changes in two ways. 
  - For simple calculations, like taxable income and superannuation contribution, changes can be made directly in [`SalaryCalcs.cs`](src/util/SalaryCalcs.cs). 
  - Tax code additions and removals can be made in the [`SalaryCalcs.cs`](src/util/SalaryCalcs.cs) constructor.
  - Tax code changes and implementing new tax codes can be done by extending the [`TaxCode.cs`](src/taxCode/TaxCode.cs) abstract class.
