using ParadisePromotions.Core.Interfaces.IServices;
using ParadisePromotions.Core.Interfaces;
using ParadisePromotions.Core.Repositories;
using ParadisePromotions.Core.Services;
using ParadisePromotions.Data;
using Microsoft.EntityFrameworkCore;
using ParadisePromotions.Core.Interfaces.ICodes;
using ParadisePromotions.Core.Repositories.Codes;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.OpenApi.Models;
using ParadisePromotions.Core.Interfaces.IReportsRepositories;
using ParadisePromotions.Core.Interfaces.IServices.IReportsServices;
using ParadisePromotions.Core.Repositories.ReportsRepositories;
using ParadisePromotions.Core.Services.ReportsServices;

var builder = WebApplication.CreateBuilder(args);
// Load environment variables from the .env file
DotNetEnv.Env.Load();

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("PARADISE_PROMOTIONS_DB");
builder.Services.AddDbContext<DBContextClass>(options =>
options.UseSqlServer(connectionString));

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
builder.Services.AddScoped<INotesHistoryRepository, NotesHistoryRepository>();
builder.Services.AddScoped<INotesHistoryService, NotesHistoryService>();
builder.Services.AddScoped<IParsRepository, ParsRepository>();
builder.Services.AddScoped<IParsService, ParsService>();
builder.Services.AddScoped<IBonusRepository, BonusRepository>();
builder.Services.AddScoped<IBonusService, BonusService>();
builder.Services.AddScoped<ITimeZonesRepository, TimeZonesRepository>();
builder.Services.AddScoped<ITimeZonesService, TimeZonesService>();
builder.Services.AddScoped<ITouchLogRepository, TouchLogRepository>();
builder.Services.AddScoped<ITouchLogService, TouchLogService>();
builder.Services.AddScoped<IChargeBackRepository, ChargeBackRepository>();
builder.Services.AddScoped<IChargeBackService, ChargeBackService>();
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

// Reports
builder.Services.AddScoped<IBuyingHistoryRepository, BuyingHistoryRepository>();
builder.Services.AddScoped<IBuyingHistoryService, BuyingHistoryService>();
builder.Services.AddScoped<ILastDispositionRepository, LastDispositionRepository>();
builder.Services.AddScoped<ILastDispositionService, LastDispositionService>();
builder.Services.AddScoped<INextCallBackRepository, NextCallBackRepository>();
builder.Services.AddScoped<INextCallBackService, NextCallBackService>();

//Middleware 
var jwtKey = builder.Configuration["Jwt:JWT_KEY"];
builder.Services.AddAuthentication(cfg => {
    cfg.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    cfg.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    cfg.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x => {
    x.RequireHttpsMetadata = false;
    x.SaveToken = false;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(
            Encoding.UTF8
            .GetBytes(jwtKey)
        ),
        ValidateIssuer = false,
        ValidateAudience = false,
        ClockSkew = TimeSpan.Zero
    };
});


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddSwaggerGen(option =>
{
    option.SwaggerDoc("v1", new OpenApiInfo { Title = "Paradise Promotions API", Version = "v1" });
    option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter a valid token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    option.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[]{}
        }
    });
});

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
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
