# Bug Reports – UKG Library Platform

This document captures all critical and high-priority issues identified during manual testing of the Library Management System.

---

## Summary of Issues

- Login possible without credentials, no login validations
- Sign Up button does not redirect to page
- Forgot password link does not redirect to page
- Edit user link on users page does not work
- Delete user link on users page does not work
- Delete book does not work - after confirmation
- Edit get book request does not save changes
- Create get book request BookId dropdown contains authors instead of book names

---

## 1. Login Without Credentials

**Description:**  
User is able to log in to the platform without entering valid credentials.

**Environment:** test  
**Severity:** Critical  
**Priority:** High  

**Steps to Reproduce:**
1. Open the login page
2. Click the **Sign In** button

**Expected Result:**  
User should see an error for missing or invalid credentials.

**Actual Result:**  
User is logged into the system without validation.

**Screenshots:** —  

---

## 2. Sign Up Button Does Not Redirect

**Description:**  
Sign Up button does not redirect the user to the Sign Up page.

**Environment:** test  
**Severity:** High  
**Priority:** High  

**Steps to Reproduce:**
1. Open the login page
2. Click the **Sign Up** button

**Expected Result:**  
User should be redirected to the Sign Up page with the form visible.

**Actual Result:**  
User remains on the Login page, nothing loads.

**Screenshots:** —  

---

## 3. Forgot Password Link Does Not Work

**Description:**  
Forgot Password link does not redirect the user to the Forgot Password page.

**Environment:** test  
**Severity:** High  
**Priority:** High  

**Steps to Reproduce:**
1. Open the login page
2. Click the **Forgot Password** link

**Expected Result:**  
User should be redirected to a page with password recovery options.

**Actual Result:**  
No redirection occurs, the link is unresponsive.

**Screenshots:** —  

---

## 4. Edit User Link Not Working

**Description:**  
Edit link on the Users page does not open the Edit User form.

**Environment:** test  
**Severity:** Medium  
**Priority:** High  

**Steps to Reproduce:**
1. Navigate to the Login page
2. Log in with valid credentials
3. Go to the Users page
4. Click the **Edit** link for any user

**Expected Result:**  
User is redirected to the Edit form populated with that user's data.

**Actual Result:**  
Nothing happens. No form is displayed, no navigation occurs.

**Screenshots:** —  