using Common.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using Models;

namespace Tasks
    {
    public class NextWorkingDayService : INextWorkingDayService
        {

        private string url = "https://www.gov.uk/bank-holidays.json";

        public NextWorkingDayService()
            {
            }
        public IEnumerable<HolidayEvent> RetrieveHolidays(string region)
            {
            using (HttpClient client = new HttpClient())
                {
                HttpResponseMessage response = client.GetAsync(url).Result;
                response.EnsureSuccessStatusCode();
                string content = response.Content.ReadAsStringAsync().Result;
                HolidayData holidayData = JsonConvert.DeserializeObject<HolidayData>(content);
                switch (region)
                    {
                    case "england-and-wales":
                        return holidayData.EnglandAndWales.Events;
                    case "scotland":
                        return holidayData.Scotland.Events;
                    case "northern-ireland":
                        return holidayData.NorthernIreland.Events;
                    default:
                        throw new ArgumentException("Invalid division name: " + region);
                    }
                }
            }
        public DateTime GetNextWorkingDay(IEnumerable<HolidayEvent> holidays , DateTime date , int workingDays)
            {
            HashSet<DateTime> holidayDates = new HashSet<DateTime>(holidays.Select(h => h.Date));
            int daysAdded = 0;

            while (workingDays > 0)
                {
                date = date.AddDays(1);
                if (date.DayOfWeek != DayOfWeek.Saturday && date.DayOfWeek != DayOfWeek.Sunday && !holidayDates.Contains(date.Date))
                    {
                    daysAdded++;
                    if (daysAdded == workingDays)
                        {
                        break; // If the required number of working days has been added, exit the loop
                        }
                    }
                }
            return date;
            }
        }
    }
