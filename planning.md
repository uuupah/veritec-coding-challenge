---
tags: -code
---

notes on building the veritec code challenge. imported from obsidian, so there may be some silliness.

---

## considerations
- encapsulation
- code class structure (interfaces, abstract classes etc if necssary)
- exception handling
- handling of user input errors #csharp-user-input-handling
- readable and maintainable
- coding design patterns
- separation of concerns
- ability to extend and handle changes in tax laws
- demonstrate your knowledge of .net by incorporating useful enterprise level techniques
- include assumptions

- money formatting
- standard c# class / variable naming best practices

## classes
- IOHandler
	- requestGrossIncome()
	- requestPayFreq()
	- displayResults(resultsData)
- ValidationHandler
	- validateGrossIncome
	- validatePayFreq
- CalcHandler
	- getResults(payrollDetails payrollDetails)
- TaxCode (tax / deduction abstract class)
	- getDeduction(decimal taxableIncome)

## models
- payrollDetails
	- get/set decimal salaryPackage
	- get/set character / enum payFreq
- resultsData
	- get/set decimal grossIncome
	- set decimal superRate
	- get decimal taxableIncome
	- get list\<deductionData> deductionArray
- deductionData
	- get/set integer deductionAmount
	- get string friendlyName
	- get returnType

## pseudocode
```
main()
  enum PayFreq
  {W,F,M}
  
  new IOHandler() io
  new CalcHandler() calc

  decimal grossIncome = io.requestGrossIncome()
  PayFreq payFreq = io.requestPayFreq()

  PayrollDetails payrollDetails = new PayrollDetails(grossIncome, payFreq)

  resultsData results = calc.getResults(payrollDetails) 

  io.displayResults(results)

IOHandler
  new validationHandler() validation

  requestGrossIncome()
    bool validInput = false
    while (!validInput)
	  // take input
      validInput = validation.validateGrossIncome(input)
      if (!validInput) 
        // return request for valid input

  // it might make sense to make this generic but its not hyper high priority 
  requestPayFreq()
    bool validInput = false
    while (!validInput)
	  // take input
      validInput = validation.validatePayFreq(input)
      if (!validInput) 
        // return request for valid input

  displayCalculationNotification()
    // simple out message

  displayResults(resultsData)
    // get data returned from resultsData
    // iterate through deductionArray

ValidationHandler
  validateGrossIncome()
	// return bool depending on result

  validatePayFreq()
	// return bool depending on result

CalcHandler
  List<TaxCode> taxCodes = new List<TaxCode>()
  
  taxCodes.add(new MedicareLevyCalc() medicareLevy)
  taxCodes.add(new BudgetRepairLevyCalc() budgetRepairLevy)
  taxCodes.add(new IncomeTaxCalc() incomeTax)

  getResults(payrollDetails payrollDetails)
    // perform all simple calcs    
    // use list.select to run getDeduction() on each entry in taxCodes,
    // return results to the deduction Array
    // bundle all results into a new resultsData object and return

```