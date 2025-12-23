//using Azure.Data.Tables;
//using Azure.Identity;
//using Azure.Storage.Blobs;


//var builder = WebApplication.CreateBuilder(args);

//// Add services to the container.

//// Blob Service
//builder.Services.AddSingleton(sp =>
//{
//    var connectionString = builder.Configuration["BlobStorage:ConnectionString"];
//    return new BlobServiceClient(connectionString);
//});

//// Table Service

//builder.Services.AddSingleton(sp =>
//{
//    var connectionString = builder.Configuration["BlobStorage:ConnectionString"];
//    return new TableServiceClient(connectionString);
//});

//builder.Host.ConfigureHostConfiguration(config =>
//{
//    config.AddAzureKeyVault(
//        new Uri("https://fileuploadkeyvault12.vault.azure.net/"),
//        new DefaultAzureCredential()
//    );
//});


//// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

//var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

//app.UseHttpsRedirection();

//app.UseAuthorization();

//app.MapControllers();

//app.Run();


using Azure.Identity;
using Azure.Storage.Blobs;
using Azure.Data.Tables;
using Azure.Extensions.AspNetCore.Configuration.Secrets;

var builder = WebApplication.CreateBuilder(args);

// ?? Azure Key Vault (CORRECT)
builder.Host.ConfigureHostConfiguration(config =>
{
    config.AddAzureKeyVault(
        new Uri("https://fileuploadkeyvault12.vault.azure.net/"),
        new DefaultAzureCredential());
});

// ?? Blob Service
builder.Services.AddSingleton(sp =>
{
    var connectionString = builder.Configuration["BlobStorage:ConnectionString"];
    return new BlobServiceClient(connectionString);
});

// ?? Table Service
builder.Services.AddSingleton(sp =>
{
    var connectionString = builder.Configuration["BlobStorage:ConnectionString"];
    return new TableServiceClient(connectionString);
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
