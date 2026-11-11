var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

List<Course> courses = new List<Course>
{
    new Course { Id = 1, Code = "CS101", Title = "Computer Science I", Credits = 3, Instructor = "Dr. Smith" },
    new Course { Id = 2, Code = "CS201", Title = "Data Structures", Credits = 3, Instructor = "Dr. Johnson" },
    new Course { Id = 3, Code = "CS250", Title = "Database Systems", Credits = 4, Instructor = "Dr. Brown" },
    new Course { Id = 4, Code = "CS301", Title = "Software Engineering", Credits = 3, Instructor = "Dr. Wilson" },
    new Course { Id = 5, Code = "CS350", Title = "Web Development", Credits = 3, Instructor = "Dr. Davis" }
};

//get all courses
app.MapGet("/courses", () => courses);

//get specific course
app.MapGet("/courses/{id:int}", (int id) =>
{
    var course = courses.FirstOrDefault(c => c.Id == id);
    return course is null ? Results.NotFound() : Results.Ok(course);
});

//post a course
app.MapPost("/api/courses", (Course course) =>
{
    if (string.IsNullOrWhiteSpace(course.Code) ||
        string.IsNullOrWhiteSpace(course.Title) ||
        string.IsNullOrWhiteSpace(course.Instructor) ||
        course.Credits < 1 || course.Credits > 6)
    {
        return Results.BadRequest("Invalid course information.");
    }

    courses.Add(course);
    return Results.Created($"/api/courses/{course.Id}", course);
});

//edit a course
app.MapPut("/api/courses/{id}", (int id, Course updatedCourse) =>
{
    var course = courses.FirstOrDefault(c => c.Id == id);

    if (course == null)
    {
        return Results.NotFound();
    }

    if (string.IsNullOrWhiteSpace(updatedCourse.Code) ||
        string.IsNullOrWhiteSpace(updatedCourse.Title) ||
        string.IsNullOrWhiteSpace(updatedCourse.Instructor) ||
        updatedCourse.Credits < 1 || updatedCourse.Credits > 6)
    {
        return Results.BadRequest("Invalid course information.");
    }

    course.Code = updatedCourse.Code;
    course.Title = updatedCourse.Title;
    course.Credits = updatedCourse.Credits;
    course.Instructor = updatedCourse.Instructor;

    return Results.Ok(course);
});

//delete a course
app.MapDelete("/courses/{id}", (int id) =>
{
    var course = courses.FirstOrDefault(c => c.Id == id);

    if (course == null)
    {
        return Results.NotFound();
    }

    courses.Remove(course);

    return Results.NoContent();
});

app.Run();