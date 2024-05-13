# User Management System

## Description
This project is a user management system built using .NET 7 for the server-side logic, Vue.js 2, HTML, CSS, and Bootstrap for the client-side interface, and MySQL for the database management system. It allows users to perform CRUD operations on user data, including adding, updating, removing, and viewing a list of users.

## Technologies Used
- **Server-side:** .NET 7, C#
- **Client-side:** Vue.js 2, HTML, CSS, Bootstrap
- **Database:** MySQL

## Features
- **Add User:** Allow users to add new users to the system.
- **Update User:** Allow users to update existing user information.
- **Remove User:** Allow users to delete user records.
- **View List of Users:** Display a list of users with basic details.

## Prerequisites
To run this project locally, ensure that you have the following installed:
- .NET SDK and Visual Studio for server-side development.
- MySQL Server for database management.
- DBeaver or similar tool for database administration.

## Installation
To set up and run the project locally, follow these steps:

1. Clone the repository: `git clone https://github.com/nadhirahh/BE-User.git`
2. Navigate to the project directory: `cd BE-User`
3. Install dependencies for the server-side: .net sdk, entity framework core and mysql framework core with the extensions
4. Install dependencies for the client-side: Uses CDN (Does not require any installation)
5. Update the database schema by running migrations:
   `dotnet ef migrations add InitialCreate`
   `dotnet ef database update`
6. Run the application: `dotnet run`


## Configuration
- **Server-side Configuration:**
- Ensure that .NET SDK and Visual Studio are installed.
- **Client-side Configuration:**
- Ensure that Node.js and npm are installed.
- **Database Configuration:**
- Install MySQL Server and configure connection settings in `appsettings.json`.
- Use DBeaver or similar tool to administer the MySQL database.

## Usage
1. Use the provided user interface to add, update, remove, and view the list of users.
2. Use Vue Select for selecting multiple skillsets per user.

## Development
- **Server-side Development:** Contributions to the server-side codebase are welcome. Fork the repository, make your changes, and submit a pull request.
- **Client-side Development:** Contributions to the client-side codebase are welcome. Fork the repository, make your changes, and submit a pull request.
- **Database Development:** Contributions to the database schema or queries are welcome. Fork the repository, make your changes, and submit a pull request.

## Contact
For any questions or support regarding this project, please contact Hidayatul Nadhirah at nadhirahh97@gmail.com.

## License
--


