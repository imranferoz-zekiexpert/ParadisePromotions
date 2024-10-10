using ParadisePromotions.Core.Interfaces.IServices;
using ParadisePromotions.Core.Interfaces;
using ParadisePromotions.Core.Repositories;
using ParadisePromotions.Core.Services;
using ParadisePromotions.Data;
using Microsoft.EntityFrameworkCore;
using ParadisePromotions.Core.Interfaces.ICodes;
using ParadisePromotions.Core.Repositories.Codes;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<DBContextClass>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("ParadisePromotionsDb")));

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IProductsRepository, ProductsRepository>();
builder.Services.AddScoped<IProductsService, ProductsService>();
builder.Services.AddScoped<ICustomersRepository, CustomersRepository>();
builder.Services.AddScoped<ICustomersService, CustomersService>();
builder.Services.AddScoped<IInvoiceDetailsRepository, InvoiceDetailsRepository>();
builder.Services.AddScoped<IInvoiceDetailsService, InvoiceDetailsService>();
builder.Services.AddScoped<IBlankSalesRepository, BlankSalesRepository>();
builder.Services.AddScoped<IBlankSalesService, BlankSalesService>();
builder.Services.AddScoped<IInvoicesRepository, InvoicesRepository>();
builder.Services.AddScoped<IInvoicesService, InvoicesService>();
builder.Services.AddScoped<IInventoryRepository, InventoryRepository>();
builder.Services.AddScoped<IInventoryService, InventoryService>();
builder.Services.AddScoped<IQryBlankSalePrintGreenSheetMainRepository, QryBlankSalePrintGreenSheetMainRepository>();
builder.Services.AddScoped<IQryBlankSalePrintGreenSheetMainService, QryBlankSalePrintGreenSheetMainService>();
// Setup Code 
builder.Services.AddScoped<IZipRepository, ZipRepository>();
builder.Services.AddScoped<ISaleTypeRepository, SaleTypeRepository>();
builder.Services.AddScoped<IProductColorRepository, ProductColorRepository>();
builder.Services.AddScoped<IColorsRepository, ColorsRepository>();
builder.Services.AddScoped<IPrintLocationRepository, PrintLocationRepository>();
builder.Services.AddScoped<IPaymentMethodRepository, PaymentMethodRepository>();
builder.Services.AddScoped<ICyclesRepository, CyclesRepository>();
builder.Services.AddScoped<IDispositionRepository, DispositionRepository>();
builder.Services.AddScoped<IReturnTypeRepository, ReturnTypeRepository>();
builder.Services.AddScoped<ILevelsRepository, LevelsRepository>();
builder.Services.AddScoped<ISetupCodesService, SetupCodesService>();


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    // Enable Swagger in production with a custom path if needed.
    app.UseSwagger(c =>
    {
        c.RouteTemplate = "swagger/{documentName}/swagger.json";
    });
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
        c.RoutePrefix = "swagger";  // Change the URL if you want.
    });
}

app.UseCors(builder => builder
 .AllowAnyOrigin()
 .AllowAnyMethod()
 .AllowAnyHeader());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
