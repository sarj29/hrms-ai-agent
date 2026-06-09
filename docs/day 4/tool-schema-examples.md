# Tool Schema Examples

## 1. Get Employee Profile

### Input Schema

```json
{
  "employee_id": "string"
}
```

### Output Schema

```json
{
  "employee_id": "EMP001",
  "name": "John Doe",
  "department": "Engineering",
  "designation": "Software Engineer",
  "email": "john@company.com"
}
```

---

## 2. Check Leave Balance

### Input Schema

```json
{
  "employee_id": "string"
}
```

### Output Schema

```json
{
  "annual_leave": 12,
  "sick_leave": 5,
  "casual_leave": 4
}
```

---

## 3. Submit Leave Request

### Input Schema

```json
{
  "employee_id": "string",
  "leave_type": "annual",
  "start_date": "YYYY-MM-DD",
  "end_date": "YYYY-MM-DD",
  "reason": "string"
}
```

### Output Schema

```json
{
  "request_id": "LR123",
  "status": "submitted",
  "approval_required": true
}
```

---

## 4. Approve Leave Request

### Input Schema

```json
{
  "manager_id": "string",
  "request_id": "string"
}
```

### Output Schema

```json
{
  "request_id": "LR123",
  "status": "approved",
  "approved_by": "MGR001"
}
```

---

## 5. Update Employee Contact Details

### Input Schema

```json
{
  "employee_id": "string",
  "phone": "string",
  "address": "string"
}
```

### Output Schema

```json
{
  "employee_id": "EMP001",
  "status": "updated",
  "updated_fields": [
    "phone",
    "address"
  ]
}
```
