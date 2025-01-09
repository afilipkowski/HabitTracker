using Database;

namespace HabitTracker;
class Program
{
    static void Main(string[] args)
    {
        bool endApp = false;
        var db = new DatabaseHandler();
        while (!endApp)
        {
            UserInterface.DisplayMenu();
            endApp = UserInterface.HandleInput(db);
            Console.ReadKey();
        }
        Console.WriteLine("Goodbye!");
        

    }
}











