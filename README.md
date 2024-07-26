# Developer Task: Modules Implementation

## Objective
The objective of this project is to develop specified modules using ASP.NET Core MVC, EF Core, and MSSQL as part of a backend system. The focus is on functionality over design, utilizing the default template for UI elements.

## Modules to be Implemented

### 1. Department/Sub-Departments Module
#### Description
This module manages departments and sub-departments, allowing for a multi-level hierarchical structure.

#### Features
- Departments can contain multiple sub-departments.
- Sub-departments can further contain sub-departments, creating a multi-level hierarchy.
- Functionality to select a department/sub-department and display:
  - A list of all sub-departments within the selected department/sub-department.
  - A list of all parent departments up to the top-level for the selected department/sub-department.

#### Fields
- **Department Name**: Name of the department.
- **Department Logo**: Logo for the department.
- **Department Parent**: DropDown menu to select the parent departments, validating the Parent department cannot be itself.

### 2. Reminder Module
#### Description
This module allows users to set reminders that trigger email notifications at specified times.

#### Features
- Set reminders with a title and specific date-time for sending an email notification.
- Integrate with Mailtrap & Hangfire background jobs to schedule & send the reminder email on the Selected date-time. To try it, just create a reminder and set the date-time to the next minute and you will recieve a reminder email.
- Validtion Atrribute to ensure that the date-time is in the future, aslo the UI is showing only future date-time

#### Fields
- **Title**: Title of the reminder.
- **Date-Time**: Date and time for sending the email notification.
- **Recipient Email Address**: The reminder reciever email address, you can place your email here.
- **HangfireJobId**: The Hangfire Id of the scheduled job.

## Getting Started

### Prerequisites
- [.NET 8](https://dotnet.microsoft.com/download)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)
- [Visual Studio](https://visualstudio.microsoft.com/) or [Visual Studio Code](https://code.visualstudio.com/)

### Installation
1. Clone the repository:
    ```sh
    git clone https://github.com/Rami-Yusf/RingoMedia.ModulesTask.git
    cd your-repo-name
    ```

2. Restore the dependencies:
    ```sh
    dotnet restore
    ```

3. Update the database connection string in `appsettings.json` if needed, I'm using the default SQL Server LocalDB:
    ```json
    "ConnectionStrings": {
        "DefaultConnection": "Server=your_server;Database=your_database;User Id=your_user;Password=your_password;"
    }
    ```

5. Run the application, the Database will be created automatically with some seeding data, you will have 2 main tables Reminders & Departments, the rest of tables is for the Hangfire server storage:
    ```sh
    dotnet run
    ```

## Usage
- Visit `http://localhost:5228` in your browser.
- Navigate to the Departments from top menu to manage departments.
- Navigate to the Reminders from top menu to set and manage reminders.

## Project Structure
- **Controllers**: Contains the controllers for handling HTTP requests.
- **Models**: Contains the models used in the application.
- **Views**: Contains the Razor views for the UI.
- **Services**: Contains Services and its interfaces with the business logic.
