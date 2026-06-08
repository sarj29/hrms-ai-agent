//Swashbuckle is an open-source library that automatically generates interactive API documentation for ASP.NET Core applications-- DEPRECATED FROM .NET 9 ONWARDS

var builder = WebApplication.CreateBuilder(args);

//AddEndpointsApiExplorer = extension method in ASP.NET Core that discovers and exposes metadata for Minimal APIs. 
//This metadata acts as a bridge, allowing API documentation tools like Swagger (Swashbuckle),to see endpoint routes, parameters, and return types.
//used to explicitly scan, parse, and serve metadata for those lightweight endpoints.
//builder.Services.AddEndpointsApiExplorer();

builder.Services.AddOpenApi();

var app = builder.Build();

app.MapOpenApi();

//Employee = Core Domain Model representing internal business logic or a database entity.
//creates a fixed size array(Employee[]) - cannot use .add()/.remove() later
//explicit constructor - new Employee(...)

//whereas List<EmployeeDto> is resizeable
// modern [ ... ] syntax. This allows the compiler to optimize memory allocation behind the scenes.

var employees = new[]
{
    new Employee(1, "Sreya Raj", "IT", "Developer"),
    new Employee(2,"Arjun", "HR", "Manager"),
    new Employee(3, "Anu", "Finance", "Analyst")
};

var tasks = new[]
{
    new TaskItem(1,1, "Prepare HRMS Report", "In Progress"),
    new TaskItem(2, 1, "Attend Standup Meeting", "Completed"),
    new TaskItem(3, 2, "Review Leave Requests", "Pending")
};

var attendances = new[]
{
    new Attendance(1, 1, new DateOnly(2026,06,01), "Present"),
    new Attendance(2, 1, new DateOnly(2026,06,02), "Present"),
    new Attendance(3, 2, new DateOnly(2026,06,01), "Absent"),
    new Attendance(4, 2, new DateOnly(2026,06,02), "Present"),
};

//GET/EMPLOYEES
app.MapGet("/employees", () => employees).WithName("GetEmployeeList").WithSummary("Returns all employees");

//GET/EMPLOYEES/ID
app.MapGet("/employees/{id}", (int id) =>
{
    return employees.FirstOrDefault(e => e.Id == id);
}).WithName("GetEmployeeDetails").WithSummary("Returns employee details");


//GET/TASKS
app.MapGet("/tasks", () => tasks).WithName("GetTasksList").WithSummary("Returns all tasks");

//GET/TASKS/ID
app.MapGet("/tasks/{id}", (int id) =>
{
    return tasks.FirstOrDefault(t => t.Id == id);
}).WithName("GetTaskDetails").WithSummary("Returns task details");

//GET/ATTENDANCE
app.MapGet("/attendances", ()=> attendances).WithName("GetAttendanceList")
   .WithSummary("Returns attendance records");

//GET/ATTENDANCE/ID
app.MapGet("/attendances/{id}", (int id) =>
{
    return attendances.FirstOrDefault(a => a.Id == id);
})
.WithName("GetAttendanceDetails")
.WithSummary("Returns attendance details");

app.Run();

record Employee(
    int Id,
    string Name,
    string Department,
    string Role
);

record TaskItem(
    int Id,
    int EmployeeId,
    string Title,
    string Status
);

record Attendance(
    int Id,
    int EmployeeId,
    DateOnly Date,
    string Status
);
