var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

//TODO register DbContext 


//TODO register DbContext initialiser


//TODO register product service



builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    //TODO create new scoped service provider and run initialise and seed of AppDbContextInitialiser    
}
// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
