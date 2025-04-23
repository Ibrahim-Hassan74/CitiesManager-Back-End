# 🌐 Cities API – ASP.NET Core Backend

This is the backend API for managing city data. Built using **ASP.NET Core**, following **Clean Architecture**, and includes robust features such as **JWT Authentication**, **API Versioning**, and **Entity Framework Core**.

---

## 📦 Tech Stack

- ASP.NET Core 8
- Entity Framework Core
- Clean Architecture
- JWT Authentication
- API Versioning
- Swagger (OpenAPI)
- SQL Server

---

## 🧱 Project Structure (Clean Architecture)

```
📦 CitiesApi
┣ 📂 Application
┃ ┗ 📂 Interfaces, DTOs, Services
┣ 📂 Domain
┃ ┗ 📂 Entities, Enums
┣ 📂 Infrastructure
┃ ┗ 📂 Data, Auth, Repositories
┣ 📂 API (Web Layer)
┃ ┗ 📂 Controllers, Middleware, Versioning
┗ 📂 Shared
   ┗ 📂 Common Utilities
```

---

## 🔐 Authentication

Authentication is handled via **JWT Tokens**.  
Upon login, the API returns:

- `accessToken`: short-lived token
- `refreshToken`: long-lived token

### 🔄 Token Refresh Flow

1. Client stores both tokens in `localStorage`.
2. If an API call fails due to expired `accessToken`, the frontend sends a request to `/auth/refresh` with both tokens.
3. If valid, the API responds with updated tokens.
4. Tokens are replaced in `localStorage`.

---

## 📌 API Versioning

The API supports **versioning** through URL path:

---

## 🛠 Technologies Used

- ASP.NET Core
- JWT Bearer Authentication
- Entity Framework Core
- Clean Architecture Principles
- API Versioning

---

## ▶️ Getting Started

1. Clone the repository
2. Restore NuGet packages
3. Set up your connection string in `appsettings.json`
4. Run the project

---

## 📗 Example Endpoints

- `GET /api/v1/cities` – Get all cities
- `POST /api/v1/cities` – Add a city
- `PUT /api/v1/cities/{id}` – Update a city
- `DELETE /api/v1/cities/{id}` – Delete a city
- `GET /api/v1/cities/search/{query}` – Search cities by name

---

### 🔗 Test the API with Frontend

You can test this API using a simple frontend template I built with **JavaScript** and **Tailwind CSS** (no frontend framework used).

👉 [Test with Frontend](https://github.com/Ibrahim-Hassan74/CitiesManager-Front-End)

---

## 🙌 Author

Built with ❤️ by [Ibrahim Hassan]
