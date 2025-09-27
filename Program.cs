using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddOpenApi();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp", policy =>
    {
        policy.WithOrigins("http://localhost:5173")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

builder.Services.AddDbContext<QuizDbContext>(options =>
options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<QuizService>();

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseCors("AllowReactApp");


// API endpoints
app.MapGet("/", () => Results.Text("Catsona API är igång!"));
app.MapGet("/api/quiz", (QuizService quizService) => Results.Json(quizService.GetQuiz()));
app.MapPost("/api/quiz/submit", (SubmissionDto submission, QuizService quizService) => 
    Results.Json(quizService.CalculateResult(submission)));
app.MapGet("/api/catpersonas", (QuizService quizService) => Results.Json(quizService.GetCatPersonas()));

app.Run();


