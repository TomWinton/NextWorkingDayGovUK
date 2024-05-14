# NextWorkingDayGovUK
A Custom Action providing the next working day from a time and date you specify factoring in UK Bank Holidays (uses: https://www.api.gov.uk/gds/bank-holidays/#bank-holidays). There's a solution folder with all the bits in and a sample flow if you just want to use as is. Otherwise, build it and add your own custom apis or chop it up or whatever. 

## What is it doing
This:
![image](https://github.com/TomWinton/NextWorkingDayGovUK/assets/46353068/bf5a8b3e-4604-4929-8979-302790355a4c)




## Basics
### Inputs
(DateTime) Date: The Date To Start From

(Enum, string) Region: england-and-wales,scotland,northern-ireland

(Int) WorkingDays: Days to Add

### Outputs.
(Date) Output: A Date <WorkingDays> from now ignoring weekends and bank holidays within <Region>

### Logic
Retrieves www.gov.uk/bank-holidays.json , 
Adds <WorkingDays> days onto the date specified + any days that are weekends or are dates inside the gov uk file for the region specified. 


