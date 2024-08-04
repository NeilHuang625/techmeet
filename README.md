# techmeet-client

## Brief Introduction
TechMeet is a web project that provides a platform for organisers to post information about IT-
themed events. This information can include images, text, or links. 

This system consists of three main components: the front end, the back end, and the database. For the front end, the system uses Vite to create a React framework. The back end is built using ASP.NET Core and C# to create the server and APIs, adopting the Model-View-Controller (MVC) pattern to
manage the back-end files. The database uses SQL Server and employs Transact-SQL for data operations.

## One thing I am very proud of
Studying C# is very challenging, but after these days of learning, I have discovered its advantages compared to other languages. It has comprehensive development tools and packages, like EF Core, and it manages and inspects code well, saving a lot of time in finding bugs. Moreover, Azure is very powerful; I use Azure Blob Storage for my images, which is very handy. I am proud of myself for not being intimidated by C#, facing the challenges, and ultimately discovering the strength of the ASP.NET ecosystem.

## Basic & Advanced features
The project supports basic CRUD operations for events. Regarding the screen theme, users can choose between light and dark modes, enhancing the user experience. The project supports user authentication and renders appropriate functionalities, preventing unauthorized users from accessing pages that require authentication. The forms have validation functionality.

## How to run the project
### Backend:
Execute Database Migration: This project uses Entity Framework Core.

Install project dependencies: dotnet restore
### Frontend:
I did not set up a separate .env file, so it is very straightforward:
Clone the repository:

Navigate to the project directory:

Install dependencies: npm install

npm run dev