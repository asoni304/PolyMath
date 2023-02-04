PolyMath

PolyMath is a web application consisting of a backend API built using ASP.NET Core 3 and a frontend using MVC .NET. The purpose of PolyMath is to provide a platform for users to add, post, update, and delete articles and their genres.
Backend API

The backend API is built using ASP.NET Core 3 and it provides a RESTful interface for managing articles and genres. The API supports the following operations:

    Adding articles
    Posting articles
    Updating articles
    Deleting articles
    Adding genres
    Posting genres
    Updating genres
    Deleting genres

The database used for storing the articles and genres is a Microsoft SQL Server database.
Frontend

The frontend of PolyMath is built using MVC .NET and it consumes the backend API to display the articles and genres to the user. The frontend also provides a user-friendly interface for adding, updating, and deleting articles and genres. The frontend uses JavaScript, HTML, and CSS to implement its functionality.
Getting Started

To get started with PolyMath, you will need to have the following prerequisites installed on your machine:

    .NET Core 3.1 SDK
    SQL Server
    A text editor of your choice (e.g. Visual Studio Code, Visual Studio)

Once you have these prerequisites installed, follow these steps to set up PolyMath:

    Clone the PolyMath repository to your local machine: git clone https://github.com/soni304/PolyMath.git
    Navigate to the PolyMath directory: cd PolyMath
    Restore the required packages: dotnet restore
    Create the database: dotnet ef database update
    Run the application: dotnet run

The frontend will be available at http://localhost:5000 and the backend API will be available at http://localhost:5000/api.
Contributing

If you would like to contribute to PolyMath, please follow these guidelines:

    Fork the repository.
    Create a branch for your changes (e.g. feature/new_feature).
    Make the necessary changes.
    Test your changes thoroughly.
    Commit your changes.
    Submit a pull request.

License

PolyMath is released under the MIT license. Please see the LICENSE file for more information
