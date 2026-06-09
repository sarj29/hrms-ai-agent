# HRMS AI Agent

An AI-powered Human Resource Management System (HRMS) Assistant built using ASP.NET Core Minimal APIs, OpenAPI, and Microsoft Foundry.

This project demonstrates:

* Function Calling
* OpenAPI Tool Integration
* Read Tools
* Write Tools
* Risky Tools
* Confirmation Flow
* Error Handling
* Tool Safety Classification
* Business-Friendly Responses
* AI Agent Development using Microsoft Foundry

---

# Project Objectives

The HRMS AI Agent enables users to:

* Retrieve employee information
* Retrieve task information
* Retrieve attendance information
* Create tasks
* Assign tasks
* Update task status
* Mark attendance
* Delete tasks safely with confirmation

The project demonstrates how Large Language Models can interact with APIs through OpenAPI specifications and tool calling.

---

# Technology Stack

* ASP.NET Core Minimal API (.NET 9)
* Microsoft.AspNetCore.OpenApi
* Microsoft Foundry
* OpenAPI 3.0
* REST APIs
* C#

---

# Available Tools

## Read Tools

| Tool                 | Purpose                     | Classification |
| -------------------- | --------------------------- | -------------- |
| GetEmployeeList      | Retrieve all employees      | Read           |
| GetEmployeeDetails   | Retrieve employee details   | Read           |
| GetTaskList          | Retrieve all tasks          | Read           |
| GetTaskDetails       | Retrieve task details       | Read           |
| GetAttendanceList    | Retrieve attendance records | Read           |
| GetAttendanceDetails | Retrieve attendance details | Read           |

---

## Write Tools

| Tool             | Purpose                      | Classification |
| ---------------- | ---------------------------- | -------------- |
| CreateTask       | Create a new task            | Write          |
| AssignTask       | Assign a task to an employee | Write          |
| UpdateTaskStatus | Update task progress         | Write          |
| MarkAttendance   | Record employee attendance   | Write          |

---

## Risky Tools

| Tool       | Purpose                   | Classification |
| ---------- | ------------------------- | -------------- |
| DeleteTask | Permanently delete a task | Risky          |

---

# Tool Safety Classification

## Read Tools

Read tools:

* Retrieve information only
* Do not modify data
* Do not require confirmation
* Execute immediately

---

## Write Tools

Write tools:

* Modify data
* Require user confirmation
* Must be logged
* Must display a summary before execution

---

## Risky Tools

Risky tools:

* May permanently remove data
* Require explicit confirmation

---

# Confirmation Flow

All write and risky operations require confirmation before execution.

---

# OpenAPI Integration

OpenAPI documentation is generated using:

```csharp
builder.Services.AddOpenApi();

app.MapOpenApi();
```

OpenAPI specification:

```text
/openapi/v1.json
```

This specification is imported into Microsoft Foundry and exposed as callable tools.

---

# Business-Friendly Responses

The agent converts API responses into professional, human-readable responses.

### Raw API Response

```json
{
  "id": 1,
  "employeeId": 2,
  "title": "Prepare HRMS Report",
  "status": "Pending"
}
```

### User-Friendly Response

```text
Here are the details for Task 1:

Task ID: 1
Title: Prepare HRMS Report
Assigned to Employee ID: 2 (Arjun)
Status: Completed
If you need more details or actions for this task, please let me know!
```

---

# Empty Result Handling

The agent gracefully handles missing data. The agent never invents data when records are unavailable.

---

# Raw JSON Avoidance

The agent avoids displaying raw JSON whenever possible.

Instead of:

```json
{
  "employeeId": 1,
  "status": "Present"
}
```

The assistant responds with:

```text
Attendance has been successfully recorded for Employee 1.
```

---

# Error Handling

The project implements structured error handling for:

* Validation errors
* Empty results
* Connection failures
* API configuration issues
* HTTP status code errors
* Localhost access issues

---

# Agent & Tool Execution Evidence

<img width="1638" height="838" alt="agent" src="https://github.com/user-attachments/assets/a7f9f2f3-f290-4282-af99-a65b9cbc8cdd" />

<img width="1587" height="862" alt="foundry-openapi-trace" src="https://github.com/user-attachments/assets/90546f15-b8c2-4ba6-bbe0-d9064d54b578" />
