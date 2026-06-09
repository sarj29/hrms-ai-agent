# HRMS API Tool Map

| Tool Name                     | API Endpoint              | Method | Category          | Approval Required |
| ----------------------------- | ------------------------- | ------ | ----------------- | ----------------- |
| Get Employee Profile          | /employees/{id}           | GET    | Read              | No                |
| Search Employees              | /employees/search         | GET    | Read              | No                |
| Check Leave Balance           | /leave/balance/{id}       | GET    | Read              | No                |
| View Attendance               | /attendance/{id}          | GET    | Read              | No                |
| View Payslip                  | /payroll/payslip/{id}     | GET    | Read              | No                |
| Search HR Policies            | /policies                 | GET    | Read              | No                |
| Submit Leave Request          | /leave/request            | POST   | Write             | No                |
| Cancel Leave Request          | /leave/cancel             | POST   | Write             | No                |
| Attendance Correction Request | /attendance/correction    | POST   | Write             | No                |
| Update Contact Details        | /employees/update-contact | PUT    | Write             | No                |
| Approve Leave Request         | /leave/approve            | POST   | Approval Required | Yes               |
| Reject Leave Request          | /leave/reject             | POST   | Approval Required | Yes               |
| Update Salary                 | /payroll/update-salary    | PUT    | Approval Required | Yes               |
| Change Job Role               | /employees/change-role    | PUT    | Approval Required | Yes               |
| Delete Employee               | /employees/delete         | DELETE | Risky             | Yes               |
| Bulk Employee Update          | /employees/bulk-update    | PUT    | Risky             | Yes               |
| Process Payroll               | /payroll/process          | POST   | Risky             | Yes               |

---

## API Design Notes

### Authentication

* OAuth 2.0
* JWT Tokens
* Role-based access control

### Roles

Employee:

* View own profile
* Apply leave
* View attendance

Manager:

* Team visibility
* Leave approvals

HR:

* Employee management
* Payroll management

Admin:

* Full access
