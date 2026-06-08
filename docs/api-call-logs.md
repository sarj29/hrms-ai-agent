# API Call Logs

## Test Case 1 - GetEmployeeList

![GetEmployeeList](../screenshots/getEmployeeList-log.png)

---

## Test Case 2 - GetEmployeeDetails

![GetEmployeeDetails](../screenshots/getEmployeeDetails-log.png)

---

## Test Case 3 - GetTaskList

![GetTaskList](../screenshots/getTaskList-log.png)

---

## Test Case 4 - Employee With Highest Number of Tasks

### User Prompt

```text
Which employee has the highest number of tasks assigned?
```

### Expected Tool Usage

1. GetEmployeeList
2. GetTaskList

### Reasoning

The agent must:

* Retrieve employees
* Retrieve tasks
* Count tasks per employee
* Determine the employee with the highest task count

![HighestTaskCount](../screenshots/highest-task-count.png)

---

## Tool Invocation Trace

The following trace demonstrates successful OpenAPI tool execution from Microsoft Foundry.

### Evidence

![OpenAPI Trace](../screenshots/foundry-openapi-trace.png)

### Observations

* Tool Type: OpenAPI
* Status: OK
* Execution: Completed
* Trace ID captured successfully
* API call completed through configured OpenAPI tool

This confirms successful function calling and tool execution within the HRMS AI Agent.
