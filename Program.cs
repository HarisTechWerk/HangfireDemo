using Hangfire;

var builder = WebApplication.CreateBuilder(args);

// 1. Connection string (update for local or Azure SQL)
var connectionString = builder.Configuration.GetConnectionString("HangfireConnection")
    ?? "Server=DEVHARIS\\SQLEXPRESS;Database=Hangfire;Trusted_Connection=True;TrustServerCertificate=True;";


// 2. Add Hangfire services
builder.Services.AddHangfire(config =>
{
    config.UseSqlServerStorage(connectionString);
});

// 3. Add Hangfire server
builder.Services.AddHangfireServer();

// 4. Add Controllers if using MVC or Web API
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// 5. If needed, enable Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


// 6. Configure request pipeline
app.UseRouting();

// 7. If using Authorization, add UseAuthorization() here

// 8. Use Hangfire dashboard
app.UseHangfireDashboard();
app.MapHangfireDashboard();
app.MapControllers();


// 10. Schedule recurring job
app.Lifetime.ApplicationStarted.Register(() =>
{
    using var scope = app.Services.CreateScope();
    var recurringJobManager = scope.ServiceProvider.GetRequiredService<IRecurringJobManager>();

    // Every minute for demo; in real scenarios, use Cron.Daily, etc.
    recurringJobManager.AddOrUpdate("my-daily-job",
        () => Console.WriteLine($"Recurring job running at {DateTime.Now}"),
        Cron.Minutely);

    RecurringJob.AddOrUpdate("test-job", () => Console.WriteLine("Hello, Hangfire!"), Cron.Minutely);

    RecurringJob.AddOrUpdate("daily-job",
    () => Console.WriteLine("This job runs daily!"),
    Cron.Daily);

    RecurringJob.AddOrUpdate("hourly-job",
        () => Console.WriteLine("This job runs hourly!"),
        Cron.Hourly);


});

app.Run();
