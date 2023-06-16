## Company Management System (ASP.NET CRUD Operations)

This is a simple ASP.NET project that demonstrates CRUD (Create, Read, Update, Delete) operations for managing companies.

### Getting Started

Follow these steps to set up and run the project:

1. Clone or download the project to your local machine.

2. Navigate to the "ASPNETMVCCRUD" folder.

3. Open the project in Visual Studio.

4. In the "appsettings.json" file, set the connection string for your SQL Server. Modify the following section with your SQL Server information:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=YOUR_SERVER;Database=YOUR_DATABASE;Trusted_Connection=True;MultipleActiveResultSets=true"
}
```

Replace `YOUR_SERVER` with the name or address of your SQL Server and `YOUR_DATABASE` with the desired name for the database.

5. Build the solution to restore NuGet packages and compile the project.

6. Run the application using the debugging tool in Visual Studio.

7. The application will launch in your default web browser, and you can now use the CRUD operations to manage companies.

### Functionality

- **Create**: Click on the "Add Company" link to add a new company. Fill in the required details and click "Save" to create the company.

- **Read**: The homepage will display a list of all companies. Each company listing shows basic information such as name, address, contact details and No of employees.

- **Update**: Click on the "View" button next to a company to view its details. On the company view page, click "Edit" to update the company's information.

- **Delete**: On the company view page, click "Delete" to remove the company from the system.

### Technology Used

- ASP.NET MVC (Model-View-Controller) framework
- Entity Framework Core for data access
- Microsoft SQL Server for database management

Feel free to explore the project, make changes, and enhance the functionality according to your requirements. Enjoy!
