# API Call Logs

## Test Case 1 - GetEmployeeList

<img width="1081" height="442" alt="employeelist" src="https://github.com/user-attachments/assets/52a58b9a-390a-4fa2-8a7a-2e02d17e64c9" />
---

## Test Case 2 - GetEmployeeDetails
<img width="1058" height="280" alt="employeedetails" src="https://github.com/user-attachments/assets/2544c802-b207-430a-a8a1-e338c5a32ae8" />

---

## Test Case 3 - GetTaskList

<img width="1092" height="496" alt="tasklist" src="https://github.com/user-attachments/assets/67260bd2-571d-4d1d-916d-de710436b81f" />

---

## Test Case 4 - Employee With Highest Number of Tasks

### Expected Tool Usage

1. GetEmployeeList
2. GetTaskList

### Reasoning

The agent must:

* Retrieve employees
* Retrieve tasks
* Count tasks per employee
* Determine the employee with the highest task count

<img width="1078" height="221" alt="outofsysprompttestcase" src="https://github.com/user-attachments/assets/5c8847eb-654c-4eb2-bd1a-6a230cb7aa42" />

---

## Tool Invocation Trace

The following trace demonstrates successful OpenAPI tool execution from Microsoft Foundry.

<img width="1587" height="862" alt="foundry-openapi-trace" src="https://github.com/user-attachments/assets/79dd9425-4d53-492c-9d1d-a0ebdeec10f8" />

### Observations

* Tool Type: OpenAPI
* Status: OK
* Execution: Completed
* Trace ID captured successfully
* API call completed through configured OpenAPI tool

This confirms successful function calling and tool execution within the HRMS AI Agent.
