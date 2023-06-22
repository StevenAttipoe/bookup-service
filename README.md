# ASP.NET Core 7 API - Room Booking System
This is a sample ASP.NET Core 7 API project that implements a room booking system. The API provides various endpoints for users to sign up, authenticate, view available rooms, book rooms, and make payments. The project is built using modern best practices and technologies, including JWT authentication for secure user login.

## Getting Started
To run the project locally, follow these steps:

1. Clone the repository: git clone https://github.com/StevenAttipoe/bookup-service
2. Navigate to the project directory: cd bookup-service
3. Restore the project dependencies: dotnet restore
4. Update the database connection string in the appsettings.json file.
5. Apply database migrations: dotnet ef database update
6. Start the application: dotnet run
7. The API will be accessible at http://localhost:7169 or http://localhost:5257.
  
## API Endpoints
The API provides the following endpoints:

User Sign Up
POST /api/v1/user/signup: Allows users to create an account by providing their registration details.

User Authentication
POST /api/user/login: Authenticates users by validating their credentials and provides a JWT token for subsequent requests.

Room Listing
GET /api/user/rooms: Retrieves a list of available rooms for booking.

Room Booking
POST /api/user/booking: Allows users to book a room by providing the necessary details.

Payment
POST /api/user/payment: Accepts payment information to complete the room booking transaction.

## Authentication and Authorization
This API uses JWT (JSON Web Token) for authentication. Users are required to include their JWT token in the Authorization header of each protected request using the Bearer scheme.

## Database
The project uses a database to store user accounts, room information, and booking details. The default database provider is MySQL, but you can configure it to use a different provider by modifying the appsettings.json file.

## Dependencies
The project relies on the following major dependencies:

ASP.NET Core 7
Entity Framework Core
JWT Bearer Authentication
Swagger UI for API documentation
Testing
The project includes unit tests to ensure the correctness of various functionalities. To run the tests, execute the following command: dotnet test.

## Contributing
Contributions to this project are welcome! If you find any issues or have suggestions for improvements, please create a new issue or submit a pull request
