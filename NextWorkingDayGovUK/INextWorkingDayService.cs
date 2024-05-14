using System.Collections.Generic;
using System;
using Models;
namespace Common.Interfaces
    {
    public interface INextWorkingDayService
        {
        IEnumerable<HolidayEvent> RetrieveHolidays(string region);
        DateTime GetNextWorkingDay(IEnumerable<HolidayEvent> holidays , DateTime date , int workingDays);
        }
    }
