# Error Handling Notes

## Objective

The HRMS AI Agent must handle tool failures gracefully and provide meaningful feedback without generating incorrect information.

---

## Error Handling Strategy

When a tool call succeeds:

* Display retrieved information.
* Summarize results clearly.

When a tool call fails:

* Explain the failure.
* Identify the probable cause.
* Suggest corrective action.
* Avoid generating fabricated data.

---

## Error Categories

### Connection Errors

Cause:

* API server offline
* Network issue
* Endpoint inaccessible

Example Response:

"The HRMS API could not be reached. Verify that the API service is running and accessible."

---

### Localhost Access Error

Cause:

* Cloud-hosted agent attempting to access localhost

Example Response:

"The configured API endpoint uses localhost. Cloud-based agents cannot access services running on a local machine."

Resolution:

* Deploy API publicly
* Use ngrok tunnel
* Update OpenAPI server URL

---

## API Endpoint

During testing, the local ASP.NET Core API was exposed using ngrok.

Public Endpoint:

https://angles-refinery-squall.ngrok-free.dev

Example API Routes:

* GET /employees
* GET /employees/{id}
* GET /tasks
* GET /tasks/{id}

The ngrok URL was used to allow Microsoft Foundry to access the locally hosted API.

### Validation Errors

Cause:

* Missing parameters
* Incorrect schema
* Invalid request format

Example Response:

"The request failed validation. Verify required parameters and OpenAPI schema definitions."

---

### HTTP 404 Not Found

Cause:

* Endpoint missing
* Route mismatch

Example Response:

"The requested API endpoint was not found."

---

### HTTP 500 Internal Server Error

Cause:

* Server-side exception

Example Response:

"The HRMS API encountered an internal error. Check server logs for details."

---

## Hallucination Prevention

The agent must never generate employee or task information when tool execution fails.

All responses must be based on actual tool results.

---

## Debug Information Included

During development, the following details may be displayed:

* Tool Name
* Error Type
* Endpoint
* HTTP Status Code
* Error Message
* Suggested Fix

Example:

Tool: GetEmployeeList

Error Type: ValidationError

Endpoint:
http://localhost:5256/employees

Suggested Fix:
Use a public endpoint instead of localhost.
