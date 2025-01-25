# HabitTracker

HabitTracker is a simple CLI-based app that can be used to log occurences of a habit and store them in a database. In this case the logged habit is reading and the unit is a page.

# Tech stack
- C#
- ADO.NET
- SQLite

# Features
- The app uses SQLite database to store data.
- The user can interact with the database through command line interface.
- Available operations include inserting, updating, deleting and viewing the data.
- The user can also generate a report, that displays units and occurences of the habit in the selected year.

# Database schema
The application creates an SQLite database (database.db) with the following schema:
| Column  | Type    | Description                      |
|---------|---------|----------------------------------|
| id      | INTEGER | Primary key, auto-incremented.   |
| date    | TEXT    | Date of the habit (dd-MM-yyyy).  |
| amount  | INT     | Number of pages read.            |

# Running the application
To run the application you need to have .NET installed on your machine.

1. Clone the repository:
    ```
    git clone https://github.com/afilipkowski/CodeReviews.Console.Calculator
    cd HabitTracker.afilipkowski/HabitTracker.afilipkowski
    ```
2. Build the project:
    ```
    dotnet build
    ```
3. Run the application:
    ```
    dotnet run
    ```


