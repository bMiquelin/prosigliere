# Blogging Platform API

This project is dedicated to the job challenge of Prosigliere:  
A simple RESTful API for managing a blog platform. The core functionality of this platform includes managing blog posts and their
associated comments.

## Setup

### Prerequisites
- **.NET SDK 9**: Install the .NET SDK from [here](https://dotnet.microsoft.com/pt-br/download/dotnet/9.0).
- **Git**: Ensure Git is installed to clone the repository.


### Steps to Run Locally
```bash
   git clone https://github.com/bMiquelin/prosigliere
   cd prosigliere
   dotnet tool install --global dotnet-ef
   dotnet ef database update
   dotnet run
```

The `db ef database update` will create a SQLite file for the database. EF could be further extended to a specific database engine.

The API will be available at http://localhost:5273.

## Features
1. List all blog posts
2. Create a new blog post
3. Retrieve a specific blog post
4. Add a new comment to a specific blog post

## Next steps if you had more time available
- Add serilog to log the calls
- Handle auth: post/comment & read/write permissions, rate limit
- Change default database engine from SQLite to something else that handles better high concurrency, scalability and security (Altough it was asked to be production ready, it was the choice for the sake of simplicity to run locally)
- Application telemetry and monitoring (application insights, elastic)
- Other optional features (likes/reactions, author, thumbnail upload, timestamps, RSS, content auto-mod)


## Test Calls

### 1. List all posts
> GET http://localhost:5273/api/posts

Example response:
```json
[
    {
        "id": "0b3dd288-dab9-4697-ab16-6b53d5d546af",
        "title": "This is the post title",
        "content": "This is the content of my first blog post.",
        "comments": []
    },
    {
        "id": "ee25ce78-b05c-44f7-8d9a-18a1b4a01c25",
        "title": "Bruno Miquelin",
        "content": "This is the post content for the API challenge.",
        "comments": [
            {
                "id": "f59d2bb9-f388-4c74-a8a7-1a37624c342b",
                "content": "Nice code!",
                "blogPostId": "ee25ce78-b05c-44f7-8d9a-18a1b4a01c25"
            }
        ]
    }
]
```

### 2. Create a new blog post

> POST http://localhost:5273/api/posts
```JSON
{
    "title": "A small title with less than 100 characters",
    "content": "The content can be very long."
}
```
Response:
```json
{
    "id": "d20dac2c-d64f-4727-8fff-dd9f5ff63a10",
    "title": "A small title with less than 100 characters",
    "content": "The content can be very long.",
    "comments": []
}
```

Obs: Frontend can pass the GUID in the payload, and it will result in error in case of duplicate

### 3. Get a specific blog post

> GET http://localhost:5273/api/posts/d20dac2c-d64f-4727-8fff-dd9f5ff63a10

Response:
```json
{
  "id": "d20dac2c-d64f-4727-8fff-dd9f5ff63a10",
  "title": "A small title with less than 100 characters",
  "content": "The content can be very long.",
  "comments": []
}
```

### 4. Add a comment to a blog post
> POST http://localhost:5273/api/posts/d20dac2c-d64f-4727-8fff-dd9f5ff63a10/comments
```json
{
    "content": "Very good!"
}
```