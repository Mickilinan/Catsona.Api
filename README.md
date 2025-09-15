# Catsona API


This is the backend API for **Catsona**, a personality quiz app that helps users discover their inner cat persona based on their answers to fun and quirky questions.


## Tech Stack

- **.NET 9 (ASP.NET Core Web API)**
- **Entity Framework Core (EF Core)** with **SQLite**
- **Clean architecture**: Services, DTOs, Endpoints, and Models
- **Postman** for testing


## What This Does


The API exposes endpoints to:
- Get a list of quiz questions
- Submit answers
- Calculate which cat persona fits best
- Return quiz results based on user submissions


## How to Run Locally


1. Clone the repo
```bash
git clone https://github.com/YOUR_USERNAME/Catsona.Api.git
```


2. Navigate to the project directory
```bash
cd Catsona.Api
```


3. Restore dependencies
```bash
dotnet restore
```


4. Apply EF Core migrations (if needed)
```bash
dotnet ef database update
```


5. Run the project
```bash
dotnet run
```


The API will be available on `https://localhost:port` (check `launchSettings.json`).


## Work in Progress


This is a solo project, guided with the help of AI tools like Cursor and ChatGPT, but fully coded and structured by me. The goal is to build both backend and frontend from scratch to deepen my fullstack experience.


## Frontend


Frontend will be built in a separate repo using:
- **React + TypeScript**
- **Tailwind CSS**
- **Axios / Fetch** for API calls
- **React Hook Form + Zod** for form validation


Stay tuned for the frontend repo!


