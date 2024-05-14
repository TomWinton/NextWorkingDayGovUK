# NextWorkingDayGovUK
A Custom Action providing the next working day from a time and date you specify factoring in UK Bank Holidays. There's a solution folder with all the bits in and a sample flow if you just want to use as is. Otherwise, build it and add your own custom apis or chop it up or whatever. 

## What is it doing
This:
![image](https://github.com/TomWinton/NextWorkingDayGovUK/assets/46353068/3e36be69-80dc-4007-ab87-ccfdeacc84bb)



## Basics
### Inputs
Date: The Date To Start From
Region: Enum: england-and-wales,scotland,northern-ireland
WorkingDays: Int: Days to Add

### Outputs
Output: Date : A Date 10 working days from now based on the region selected 

### Logic
Retrieves www.gov.uk/bank-holidays.json , 
Returns 10 days onto the date specified + any days that are weekends or are dates inside the gov uk file for the region specified. 


