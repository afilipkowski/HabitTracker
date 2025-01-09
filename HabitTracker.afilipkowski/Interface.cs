using System.Globalization;
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
        Console.WriteLine("5. Exit the app");
    }

    static public bool HandleInput(DatabaseHandler db)
    {
        int choice;
        while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 5)
        {
            Console.WriteLine("Invalid input. Select an option from the menu.");
        }
        switch (choice)
        {
            case 1:
                List<DatabaseRecord> records = db.GetAllRecords();
                if (records.Count == 0)
                    Console.WriteLine("No records found");
                else
                {
                    foreach (var record in records)
                    {
                        Console.WriteLine($"{record.Id}. Pages read: {record.Amount}; Date: {record.Date}");
                    }
                }
                return false;
            case 2:
                string? date = GetDate();
                int amount = GetAmount();
                db.InsertRecord(date, amount);
                return false;
            case 3:
                return false;
            case 4:
                int id;
                int currentRecords = db.GetCount();
                Console.WriteLine("Enter ID of the record you want to remove.");
                while (!int.TryParse(Console.ReadLine(), out id) || id > currentRecords || id <= 0)
                {
                    Console.WriteLine("Invalid input. Enter correct ID");
                }
                db.DeleteRecord(id);
                return false;
            case 5:
                return true;
            default:
                return false;
        }

    }
    static private string? GetDate()
    {
        string dateInput;
        Console.WriteLine("Enter the date (dd-mm-yyyy):");
        dateInput = Console.ReadLine();
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

}
