
//var sessionFactory = new SessionFactory();

//var customer = new Customer { FirstName = "Murphy", Surname = "Ochuba", PhoneNumber = "0123456789" };
//var session = sessionFactory.Session;
//sessionFactory.Session.Save(customer);
//sessionFactory.Commit(session);



using CCSARestaurant.DB;
using CCSARestaurant.DB.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<SessionFactory>();
builder.Services.AddScoped<CustomerRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
