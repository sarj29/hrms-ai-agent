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

var tasks = new List<TaskItem>//mutable collections
{
    new()
    {
        Id = 1,
        EmployeeId = 1,
        Title = "Prepare HRMS Report",
        Status = "In Progress"
    },

    new()
    {
        Id = 2,
        EmployeeId = 1,
        Title = "Attend Standup Meeting",
        Status = "Completed"
    },

    new()
    {
        Id = 3,
        EmployeeId = 3,
        Title = "FY2026 Trend Summary Report Approval",
        Status = "Completed"
    }
};

var attendances = new List<Attendance>//mutable collections
{
    new ()
    {
        Id = 1,
        EmployeeId = 1,
        Date = new DateOnly(2026,6,1),
        Status = "Present"
    },

    new ()
    {
        Id = 2,
        EmployeeId = 2,
        Date = new DateOnly(2026,6,1),
        Status = "Absent"
    },

    new ()
    {
        Id = 3,
        EmployeeId = 3,
        Date = new DateOnly(2026,6,1),
        Status = "Present"
    },
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

//POST/TASKS
app.MapPost("/tasks", (CreateTaskDto createTask) =>
{
    var id = tasks.Any() ? tasks.Max(t => t.Id) + 1 : 1;

    var task = new TaskItem{
        Id = id,
        EmployeeId = createTask.EmployeeId,
        Title = createTask.Title,
        Status = "Pending"
    };

    tasks.Add(task);

    return Results.Created($"/tasks/{task.Id}", task);
}).WithName("CreateTask");

//PUT/TASKS/ID
app.MapPut("/tasks/{id}/assign", (int id, AssignTaskDto assign) =>
{
    var task = tasks.FirstOrDefault(t => t.Id == id);

    if(task is null) return Results.NotFound();

    task.EmployeeId = assign.EmployeeId;
    return Results.Ok(task);


}).WithName("AssignTask");

//PUT/TASKS/STATUS
app.MapPut("/tasks/{id}/status", (int id, UpdateTaskStatusDto updateStatus) =>
{
    var task = tasks.FirstOrDefault(t => t.Id == id);

    if (task is null) return Results.NotFound($"Task {id} not found.");

    task.Status = updateStatus.Status;
    return Results.Ok(task);
}).WithName("UpdateTaskStatus");


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

//POST/ATTENDANCE/
app.MapPost("/attendances", (MarkAttendanceDto mark) =>
{
    var id = attendances.Any() ? attendances.Max(a => a.Id) + 1: 1;

    var record = new Attendance
    {
        Id = id,
        EmployeeId = mark.EmployeeId,
        Date = DateOnly.Parse(mark.Date),
        Status = mark.Status
    };

    attendances.Add(record);

    return Results.Created( $"/attendance/{record.Id}", record);
}).WithName("MarkAttendance");

app.MapDelete("/tasks/{id}", (int id) =>
{
    tasks.RemoveAll(task => task.Id == id);

    return Results.NoContent();
}
);



app.Run();

record Employee(
    int Id,
    string Name,
    string Department,
    string Role
);

class TaskItem
{
    public int Id { get; set; }
    public int EmployeeId { get; set; }
    public string Title { get; set; } = "";
    public string Status { get; set; } = "";
}

class Attendance
{
    public int Id { get; set; }
    public int EmployeeId { get; set; }
    public DateOnly Date { get; set; }
    public string Status { get; set; } = "";
}

record CreateTaskDto(
    int EmployeeId,
    string Title
);

record AssignTaskDto(
    int EmployeeId
);

record UpdateTaskStatusDto(
    string Status
);

record MarkAttendanceDto(
    int EmployeeId,
    string Date,
    string Status
);

