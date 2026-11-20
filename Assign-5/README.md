# Student Course API

REST API developed using C# and ASP.NET Core 10. Allows users to view, add, update, and delete courses. Also includes basic HTML and JavaScript webpage that displays available courses.

## Setup 

1. Install .NET 10 SDK
2. Open a terminal in the project directory.
3. Run the following commands:

dotnet restore
dotnet build
dotnet run

4. Open in browser:

`http://localhost:5057/`

## API Endpoints

| Method | Endpoint | Description |
GET - /courses - Retrieve all courses 
GET - /courses/{id} - Retrieve a course by ID 
POST - /courses - Add a new course 
PUT - /courses/{id} - Update an existing course 
DELETE - /courses/{id} - Delete an existing course 

## Test Examples

Use postman to test the API.

### GET All Courses

http://localhost:5057/courses

Returns a JSON array containing all available courses.

### GET Course by ID

http://localhost:5057/courses/1

Returns the course with ID 1, or HTTP 404 if it does not exist.

### POST a New Course

POST http://localhost:5057/courses - {"id":6,"code":"CS400","title":"Advanced Programming","credits":3,"instructor":"Dr. Smith"}


Returns HTTP 201 Created if successful.

### PUT Update a Course

PUT http://localhost:5057/courses/1 - {"id":1,"code":"CS101","title":"Introduction to Programming","credits":4,"instructor":"Dr. Johnson"}


Returns HTTP 200 OK if successful or HTTP 404 if the course does not exist.

### DELETE a Course

DELETE http://localhost:5057/courses/1

Returns HTTP 204 No Content if successful or HTTP 404 if the course does not exist.

## Screenshots

### Course Webpage

Insert a screenshot showing the HTML webpage displaying the course