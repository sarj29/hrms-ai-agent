# HRMS Tool Safety Rules

## Rule 1: Read Operations

Read operations may execute immediately.

Examples:

* Check leave balance
* View attendance
* Search employee profile

No confirmation required.

---

## Rule 2: Write Operations

Write operations require explicit confirmation.

Example:

User:
"Apply leave for June 15"

Agent:
"I can submit a leave request for June 15. Would you like me to proceed?"

Only execute after confirmation.

---

## Rule 3: Approval Required Operations

Agent must verify approval authority.

Examples:

* Approve leave
* Reject leave
* Change salary

Checks:

* User role
* Approval permissions
* Audit logging

---

## Rule 4: Risky Operations

Agent must:

1. Verify identity.
2. Verify permissions.
3. Request confirmation.
4. Log action.
5. Execute only after approval.

Examples:

* Delete employee
* Process payroll
* Bulk updates

---

## Rule 5: Data Privacy

Never expose:

* Passwords
* Authentication tokens
* Bank account details
* Personal identifiers beyond authorization scope

---

## Rule 6: Audit Logging

Every write action must log:

* User ID
* Timestamp
* Tool used
* Input parameters
* Result
* Approval status

---

## Rule 7: Error Handling

If tool execution fails:

* Explain failure
* Do not fabricate results
* Suggest next steps

Example:

"Payroll service is currently unavailable. Please try again later."

---

## Rule 8: Human Escalation

Escalate when:

* Multiple failures occur
* Authorization unclear
* Sensitive employee dispute
* Policy conflict detected
