using Database;

namespace HabitTracker;

class Report
{
    static public void YearlyReport(List<DatabaseRecord> records, string year)
    {
        int pages = 0;
        int times = 0;
        bool found = false;

        foreach (var record in records)
        {
            if (record.Date.Contains(year))
            {
                found = true;
                pages += record.Amount;
                times++;
            }
        }
        if (found)
            Console.WriteLine($"In {year} you read books {times} times and read a total of {pages} pages.");
        else
            Console.WriteLine("No data found for the year entered.");
    }
}