using CRUD.Infra.IoC;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

/// - Ioc(Contexto, Serviços(application), Repositorios(Infra))
///
builder.Services.AddInfrastructure(builder.Configuration);

/// - API / Swagger
/// 
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

WebApplication app = builder.Build();

/// - Middlewares
/// 
if (app.Environment.IsDevelopment())
{
    // Aplicar migrações automaticamente em dev
    //using var scope = app.Services.CreateScope();
    //var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    //db.Database.Migrate();

    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();