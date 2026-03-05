# Library Management System

![.NET](https://img.shields.io/badge/-.NET-blue?logo=.net&logoColor=white)

## 📝 Description

LibraryManagementSystem is a comprehensive full-stack application designed to modernize and streamline the administration of library resources. Leveraging the power of the .NET ecosystem, the platform features a robust backend built with Web API for high-performance data management and a dynamic, responsive frontend powered by Blazor. This system provides an all-in-one solution for managing book catalogs, tracking lending history, and organizing member information, delivering a seamless and efficient experience for both administrators and users.

## 🛠️ Tech Stack

- 🔷 .NET


## 📦 Key Dependencies

```
AutoMapper: 15.0.1
MediatR: 13.0.0
Microsoft.Extensions.Configuration.Abstractions: 9.0.8
Microsoft.EntityFrameworkCore: 9.0.8
```

## 📁 Project Structure

```
.
├── Application
│   ├── Application.csproj
│   ├── Contracts
│   │   └── Interfaces
│   │       ├── IBook.cs
│   │       ├── IBorrow.cs
│   │       ├── ICategory.cs
│   │       ├── IGenericRepository.cs
│   │       ├── IMembers.cs
│   │       ├── IReservation.cs
│   │       └── IUnitOfWork.cs
│   ├── Dtos
│   │   └── Books
│   │       ├── BookDto.cs
│   │       ├── BorrowRecordDto.cs
│   │       ├── CategoryDto.cs
│   │       ├── MemberDto.cs
│   │       └── ReservationDto.cs
│   ├── Extension
│   │   └── ServiceExtensions.cs
│   ├── Features
│   │   ├── Book
│   │   │   ├── Commands
│   │   │   │   ├── AddBookCommand.cs
│   │   │   │   ├── DeleteBookCommand.cs
│   │   │   │   └── UpdateBookCommand.cs
│   │   │   ├── Handlers
│   │   │   │   ├── AddBookHandler.cs
│   │   │   │   ├── DeleteBookHandler.cs
│   │   │   │   ├── GetAllBooksHandler.cs
│   │   │   │   ├── GetBookByIdHandler.cs
│   │   │   │   └── UpdateBookHandler.cs
│   │   │   └── Queries
│   │   │       ├── GetAllBooksQuery.cs
│   │   │       └── GetBookByIdQuerry.cs
│   │   ├── BorrowingRecord
│   │   │   ├── Command
│   │   │   │   ├── AddRecordCommand.cs
│   │   │   │   ├── DeleteRecordCommand.cs
│   │   │   │   └── UpdateRecordCommand.cs
│   │   │   ├── Handler
│   │   │   │   ├── AddRecordHandler.cs
│   │   │   │   ├── DeleteRecordHandler.cs
│   │   │   │   ├── GetAllRecordsHandler.cs
│   │   │   │   ├── GetRecordByIdHandler.cs
│   │   │   │   └── UpdateRecordHandler.cs
│   │   │   └── Query
│   │   │       ├── GetAllRecordsQuery.cs
│   │   │       └── GetRecordByIdQuery.cs
│   │   ├── Categories
│   │   │   ├── Command
│   │   │   │   ├── CreateCategoryCommand.cs
│   │   │   │   ├── DeleteCategoryCommand.cs
│   │   │   │   └── UpdateCategoryCommand.cs
│   │   │   ├── Handler
│   │   │   │   ├── CreateCategoryHandler.cs
│   │   │   │   ├── DeleteCategoryHandler.cs
│   │   │   │   ├── GetAllCategoriesHandler.cs
│   │   │   │   ├── GetCategoryByIdHandler.cs
│   │   │   │   └── UpdateCategoryHandler.cs
│   │   │   └── Query
│   │   │       ├── GetAllCategoriesQuery.cs
│   │   │       └── GetCategoryByIdQuery.cs
│   │   ├── Members
│   │   │   ├── Command
│   │   │   │   ├── CreateMemberCommand.cs
│   │   │   │   ├── DeleteMemberCommand.cs
│   │   │   │   └── UpdateMemberCommand.cs
│   │   │   ├── Handler
│   │   │   │   ├── AddMemberHandler.cs
│   │   │   │   ├── DeleteMemberHandler.cs
│   │   │   │   ├── GetAllMembersHandler.cs
│   │   │   │   ├── GetMemberByIdHandler.cs
│   │   │   │   └── UpdateMemberHandler.cs
│   │   │   └── Query
│   │   │       ├── GetAllMembersQuery.cs
│   │   │       └── GetMemberByIdQuery.cs
│   │   └── Reservation
│   │       ├── Command
│   │       │   ├── AddReservationCommand.cs
│   │       │   ├── CancelReservationCommand.cs
│   │       │   └── CompleteReservationCommand.cs
│   │       ├── Handler
│   │       │   ├── AddReservationHandler.cs
│   │       │   ├── CancelReservationHandler.cs
│   │       │   ├── CompleteReservationHandler.cs
│   │       │   ├── GetAllReservationsQueryHandler.cs
│   │       │   ├── GetReservationByIdQueryHandler.cs
│   │       │   ├── GetReservationsByBookHandler.cs
│   │       │   └── GetReservationsByMemberHandler.cs
│   │       └── Query
│   │           ├── GetAllReservationsQuery.cs
│   │           ├── GetReservationByBookQuery.cs
│   │           ├── GetReservationByIdQuery.cs
│   │           └── GetReservationsByMemberQuery.cs
│   ├── Mappings
│   │   └── MappingProfile.cs
│   └── Services
│       └── ServiceResponse.cs
├── Domain
│   ├── Domain.csproj
│   └── Entities
│       ├── Book.cs
│       ├── BorrowingRecords.cs
│       ├── Category.cs
│       ├── Member.cs
│       └── Reservation.cs
├── Infrastructure
│   ├── DataAccess
│   │   └── ApplicationDbContext.cs
│   ├── Implementation
│   │   └── Repositories
│   │       ├── BookRepository.cs
│   │       ├── BorrowRepository.cs
│   │       ├── CategoryRepository.cs
│   │       ├── GenericRepository.cs
│   │       ├── MemberRepository.cs
│   │       ├── ReservationRepository.cs
│   │       └── UnitOfWork.cs
│   ├── Infrastructure.csproj
│   │ 
│   └── Services
│       └── DependencyInjection.cs
├── LibarayManagementSystemUi
│   ├── App.razor
│   ├── Layout
│   │   ├── MainLayout.razor
│   │   ├── MainLayout.razor.css
│   │   ├── NavMenu.razor
│   │   └── NavMenu.razor.css
│   ├── LibraryManagementSystemUi.csproj
│   ├── Pages
│   │   ├── Book
│   │   │   ├── AddBooks.razor
│   │   │   ├── BookIndex.razor
│   │   │   ├── DeleteBook.razor
│   │   │   └── EditBooks.razor
│   │   ├── BorrowBookRecord
│   │   │   ├── AddBorrowRecord.razor
│   │   │   ├── BorrowIndex.razor
│   │   │   ├── DeleteBorrowRecord.razor
│   │   │   └── EditBorrowRecord.razor
│   │   ├── Category
│   │   │   ├── AddCategory.razor
│   │   │   ├── CategoryIndex.razor
│   │   │   ├── DeleteCategory.razor
│   │   │   └── EditCategory.razor
│   │   ├── Counter.razor
│   │   ├── Home.razor
│   │   ├── Member
│   │   │   ├── AddMember.razor
│   │   │   ├── DeleteMember.razor
│   │   │   ├── EditMember.razor
│   │   │   └── Index.razor
│   │   ├── Reservation
│   │   │   ├── AddReservation.razor
│   │   │   └── ReservationIndex.razor
│   │   └── Weather.razor
│   ├── Program.cs
│   ├── Properties
│   │   └── launchSettings.json
│   ├── Services
│   │   ├── BookService.cs
│   │   ├── BorrowBookService.cs
│   │   ├── CategoryService.cs
│   │   ├── MemberService.cs
│   │   └── ReservationService.cs
│   ├── _Imports.razor
│   └── wwwroot
│       ├── css
│       │   └── app.css
│       ├── favicon.png
│       ├── icon-192.png
│       ├── index.html
│       └── sample-data
│           └── weather.json
├── LibraryManagementSystem
│   ├── Controllers
│   │   ├── BooksController.cs
│   │   ├── BorrowBookRecordController.cs
│   │   ├── CategoryController.cs
│   │   ├── MemberController.cs
│   │   ├── ReservationController.cs
│   │   └── WeatherForecastController.cs
│   ├── LibraryManagementSystem.csproj
│   ├── LibraryManagementSystem.http
│   ├── Program.cs
│   ├── Properties
│   │   └── launchSettings.json
│   ├── WeatherForecast.cs
│   ├── appsettings.Development.json
│   └── appsettings.json
└── LibraryManagementSystem.sln
```

## 🛠️ Development Setup

### .NET Setup
1. Install [.NET SDK](https://dotnet.microsoft.com/)
2. Restore dependencies: `dotnet restore`
3. Build the project: `dotnet build`
4. Run the project: `dotnet run`


## 👥 Contributing

Contributions are welcome! Here's how you can help:

1. **Fork** the repository
2. **Clone** your fork: `git clone https://github.com/Sehar-1207/LibraryManagementSystem/edit/master/README.md.git`
3. **Create** a new branch: `git checkout -b feature/your-feature`
4. **Commit** your changes: `git commit -am 'Add some feature'`
5. **Push** to your branch: `git push origin feature/your-feature`
6. **Open** a pull request

Please ensure your code follows the project's style guidelines and includes tests where applicable.

---
*This README was generated with ❤️ by Sehar Ajmal*
