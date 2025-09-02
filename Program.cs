var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
// builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
//     app.MapOpenApi();
// }

// app.UseHttpsRedirection();




var quiz = new
{
    question = "Vad gör din katt helst en regnig dag?",
    options = new[]
    {
        "Sover på tangentbordet",
        "Stirrar ut genom fönstret",
        "Jagar laserpekare",
        "Gömmer sig i en låda"
    }
};


app.MapGet("/", () => Results.Text("KattKompass API är igång!"));
app.MapGet("/api/quiz", () => Results.Json(quiz));

app.Run();


