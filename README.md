# The Safest Bank
System focused on **security** and **privacy**. Built with Clean Architecture.

# Technological stack for The Safest Bank:

## Server:

- .NET 8
- Microsoft.EntityFrameworkCore - ORM.
- Npgsql.EntityFrameworkCore.PostgreSQL - PostgreSQL provider for Entity Framework Core.
- Konscious.Security.Cryptography - Argon2id hashing algorithm provider.
- Session management - Cookies.

## Client:

- React 18
- Babel - JavaScript compiler.
- TypeScript
- react-router-dom - Routing

## Database:

- PostgreSQL

## Reverse proxy:

- NGINX

# Key architectural decisions:

- **Authentication and authorization** are being implemented using **cookies** with **session**.
- **NGINX** as a proxy, brute-force attack blocker and request delayer.
- **Passwords** are stored as 10 combinations of 1/3 password's characters **hashes** created using the **Argon2id** algorithm, each password is salted. When a user attempts to log in, it gets the password mask from the server, and it have to provide the current password' letter combination. The combination changes after the successful login.
- After 3 unsuccessful login attempts, the user is **blocked** for until he will reset the password.
- Whole communication via **HTTPS**.
- Password strenth estimation using Shannon entropy formula.
- **Passwords** can only be changed by **accessing the URL provided in an email** sent by the server which is valid for a limited time.
- **Sensitive data** will only be **revealed** once the user clicks the **responsible for that button**.
- Everything will is **Dockerized**.
- Content-Security-Policy applied by NGINX to prevent XSS attacks.
- Header "Server" has been removed to prevent information disclosure.

# How to run:

### 1. Clone the repository:

### 2. Run the following command in the root directory:

```docker
docker-compose up
```

### 3. Open the browser and go to:

```
localhost
```

### 4. Available accounts:

#### 1. Sebastian

- Client Number: 123456789012
- Password: 1234QWER!@#$qwer
- Email: sekula.sebastian.kontakt@gmail.com

#### 2. John

- Client Number: 223456789012
- Password: ZXCV!@#$qwer1234
- Email: bob.bobkins@gmail.com

#### 3. Jane

- Client Number: 323456789012
- Password: !QAZ@WSX1qaz2wsx
- Email: scotty123@gmail.com

### 5. Reset password link:

Shows in the console after running the docker-compose command.

# Architecture:

![Architecture](/screenshots/architecture.svg)

# Screenshots:

![Login](/screenshots/login.png "Login")
![Password](/screenshots/password.png "Password")
![Home](/screenshots/user-panel.png "Home")
![Transaction](/screenshots/transaction.png "Transaction")
![Client page](/screenshots/client-site.png "Client page")
![Hidden](/screenshots/showed-hidden.png "Hidden")
