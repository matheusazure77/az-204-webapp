using sqlapp.Services;

var connectionString = "Endpoint=https://webapp-config.azconfig.io;Id=R41t-l0-s0:wkew/Z2SNYqotKPRu0Z5;Secret=Dy93q7PDgqCr7HKeL/HshnL2BrExCpb0pANcNksb9vQ=";

var builder = WebApplication.CreateBuilder(args);

builder.Host.ConfigureAppConfiguration(app => {
    app.AddAzureAppConfiguration(connectionString);
});

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddTransient<IProductService, ProductService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
