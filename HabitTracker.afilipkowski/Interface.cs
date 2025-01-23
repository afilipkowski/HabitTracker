using System.Globalization;
using System.Xml.Serialization;
using Database;

namespace HabitTracker;

static class UserInterface
{
    static public void DisplayMenu()
    {
        Console.Clear();
        Console.WriteLine("Welcome to the Habit Tracker app!");
        Console.WriteLine("Choose an option:");
        Console.WriteLine("---------------------------------");
        Console.WriteLine("1. Display all records");
        Console.WriteLine("2. Add a new record");
        Console.WriteLine("3. Update a record");
        Console.WriteLine("4. Delete a record");
        Console.WriteLine("5. Generate a report");
        Console.WriteLine("6. Exit the app");
    }

    static public bool HandleInput(DatabaseHandler db)
    {
        int choice;
        string date;
        int amount;
        int id;
        while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 6)
        {
            Console.WriteLine("Invalid input. Select an option from the menu.");
        }
        switch (choice)
        {
            case 1:
                DisplayRecords(db);
                return false;
            case 2:
                date = GetDate();
                if (date != "0")
                {
                    amount = GetAmount();
                    db.InsertRecord(date, amount);
                }
                return false;
            case 3:
                Console.WriteLine("Existing records:");
                DisplayRecords(db);
                Console.WriteLine("Enter ID of the record you want to update or enter '0' to return to the menu.");
                id = GetID(db);
                if (id != 0)
                {
                    date = GetDate();
                    amount = GetAmount();
                    db.UpdateRecord(id, date, amount);
                }
                return false;
            case 4:
                Console.WriteLine("Existing records:");
                DisplayRecords(db);
                Console.WriteLine("Enter ID of the record you want to remove or enter '0' to return to the menu.");
                id = GetID(db);
                if (id != 0)
                {
                    db.DeleteRecord(id);
                }
                return false;
            case 5:
                Console.WriteLine("Enter the year for which the report should be displayed.");
                date = Console.ReadLine();
                while (!DateTime.TryParseExact(date, "yyyy", new CultureInfo("en-US"), DateTimeStyles.None, out _))
                {
                    Console.WriteLine("Invalid input. Enter the year for which the report should be displayed..");
                    date = Console.ReadLine();
                }
                Report.YearlyReport(db.GetAllRecords(), date);
                return false;
            case 6:
                return true;
            default:
                return false;
        }
    }

    static private string GetDate()
    {
        string dateInput;
        Console.WriteLine("Enter the date (dd-mm-yyyy) or enter '0' to return to the menu.:");
        dateInput = Console.ReadLine();
        if (dateInput == "0")
        {
            return dateInput;
        }
        while (!DateTime.TryParseExact(dateInput, "dd-MM-yyyy", new CultureInfo("en-US"), DateTimeStyles.None, out _))
        {
            Console.WriteLine("Invalid input. Enter the date in the correct format.");
            dateInput = Console.ReadLine();
        }
        return dateInput;
    }

    static private int GetAmount()
    {
        int amount;
        Console.WriteLine("Enter the number of read pages");
        while (!int.TryParse(Console.ReadLine(), out amount))
        {
            Console.WriteLine("Invalid input. Enter a number.");
        }
        return amount;
    }

    static private int GetID(DatabaseHandler db)
    {
        int id;
        while (!int.TryParse(Console.ReadLine(), out id) || !db.RecordExists(id))
        {
            if (id == 0)
            {
                return 0;
            }
            Console.WriteLine("Invalid input. Enter correct ID");
        }
        return id;
    }

    static private void DisplayRecords(DatabaseHandler db)
    {
        var records = db.GetAllRecords();
        if (records.Count == 0)
            Console.WriteLine("No records found");
        else
        {
            foreach (var record in records)
            {
                Console.WriteLine($"{record.Id}. Pages read: {record.Amount}; Date: {record.Date}");
            }
        }
    }
}