# Technological stack for The Safest Bank:

## Server:
- .NET 8
- Microsoft.EntityFrameworkCore - PostgreSQL provider.
- Microsoft.AspNetCore.Identity - User management and sending emails.
- Konscious.Security.Cryptography - Argon2id hashing algorithm provider.
- System.Net.HttpCookie - Cookie management.
- zxcvbn-core - Password strength estimation.

## Client:
- React 18
- TypeScript
- zxcvbn - Password strength estimation
- react-router-dom - Routing

## Database:
- PostgreSQL

# Key architectural decisions:
- **Authentication and authorization** are implemented using **cookies**.
- **NGINX** as a reverse proxy, brute-force attack blocker and request delayer.
- **Passwords** are stored as 'x' combinations of 'y' character **hashes** created using the **Argon2id** algorithm. When a user attempts to log in, they send the server the current 'y' character combination required. The server then hashes this combination and compares it with the stored hash. If there is a match, the user is authenticated.
- **HTTPS** is used to encrypt the data sent between the client and the server.
- **CSRF** protection is implemented using a token that is sent to the client when he logs in and is required by the server when the client wants to perform a POST, PUT or DELETE request.
- **zxcvbn** will be used for **password strength** estimation while a new password is being set.
- **Passwords** can only be changed by **accessing the URL provided in an email** sent by the server. The URL is valid for 1 hour.
- **Sensitive data** will only be **revealed** once the user clicks the **"Show" button**.


## TO CHECK - IDENTITY TUTORIAL, MASKED PASSWORDS TUTORIAL.