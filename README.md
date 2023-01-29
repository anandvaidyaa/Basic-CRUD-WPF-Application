# Basic-CRUD-WPF-Application
C# WPF CRUD Application
This is a C# WPF application that demonstrates CRUD (Create, Read, Update, and Delete) operations using SQL Express. Utilizes a local SQL Express database to store and retrieve data.

## Getting Started
These instructions will get you a copy of the project up and running on your local machine for development and testing purposes.

### Prerequisites
Visual Studio
SQL Express
Installing:
- Clone or download the repository to your local machine.
- Open the solution file (.sln) in Visual Studio.
- Build the solution by going to Build > Build Solution.
- Run the application by going to Debug > Start without debugging.
#### Setting up the SQL Express Database
- Install SQL Express on your local machine.
- Open SQL Server Management Studio and connect to your local instance of SQL Express.
- Create a new database and name it "CRUD_DB".
- Run the provided SQL script file to create the necessary tables and sample data.
- Update the connection string in the application's configuration file (App.config) to match your SQL Express instance and database name.
#### Functionality
The application allows users to perform the following CRUD operations on a "Person" entity:

- Create: Users can add new Person records to the database by inputting the person's name, email, and phone number.
- Read: Users can view a list of all Person records in the database, as well as view individual records in detail.
- Update: Users can update existing Person records by editing the name, email, and phone number.
- Delete: Users can delete existing Person records from the database.
Built With
- C# - Programming language
- WPF - Windows Presentation Foundation
- SQL Express - Database management system
Note
#### Please note that this is a basic example for demonstration purpose, for production use, please consider adding more validations, error handling and better UI/UX.
