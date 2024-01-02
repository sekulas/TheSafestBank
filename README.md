# Technological stack for The Safest Bank:

## Server:
- .NET 8
- Microsoft.EntityFrameworkCore - ORM.
- Npgsql.EntityFrameworkCore.PostgreSQL - PostgreSQL provider for Entity Framework Core.
- Konscious.Security.Cryptography - Argon2id hashing algorithm provider.
- System.Net.HttpCookie - Cookie management.
- zxcvbn-core - Password strength estimation with common passwords validation.
- SendGrid - Email sending.

## Client:
- React 18
- Babel - JavaScript compiler.
- TypeScript
- zxcvbn - Password strength estimation with common passwords validation.
- react-router-dom - Routing

## Database:
- PostgreSQL

# Key architectural decisions:
- **Authentication and authorization** are implemented using **cookies**.
- **NGINX** as a proxy, brute-force attack blocker and request delayer.
- **Passwords** are stored as 'x' combinations of 'y' characters **hashes** created using the **Argon2id** algorithm, each password is salted. When a user attempts to log in, it gets the password mask from the server, and it have to provide the current password' letter combination. The combination changes after the successful login.
- After 'x' unsuccessful login attempts, the user is **blocked** for 'y' minutes.
- **HTTPS** is used to encrypt the data sent between the client and the **NGINX**. The **NGINX** and the server communicates via **HTTP**.
- **CSRF** protection is implemented using a token that is sent to the client when he logs in and is required by the server when the client wants to perform a POST, PUT or DELETE request.
- **zxcvbn** will be used for **password strength** estimation while a new password is being set.
- **Passwords** can only be changed by **accessing the URL provided in an email** sent by the server which is valid for a limited time.
- **Sensitive data** will only be **revealed** once the user clicks the **responsible for that button**.
- Everything will be **Dockerized**.
- Content-Security-Policy will be used to prevent XSS attacks.
- Header "Server" will be removed to prevent information disclosure.