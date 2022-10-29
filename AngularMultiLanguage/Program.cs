using AngularMultiLanguage.Data;
using AngularMultiLanguage.Data.Interfaces;
using AngularMultiLanguage.Data.Repo;
using AngularMultiLanguage.Filters;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);
{
    // Add services to the container.
    builder.Services.AddDbContext<MutltiLanDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default"))
    );
    builder.Services.AddScoped<IRepoWrapper, RepoWrapper>();
    builder.Services.AddControllers().
        AddNewtonsoftJson(x=> x.SerializerSettings.ReferenceLoopHandling= Newtonsoft.Json.ReferenceLoopHandling.Ignore);
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();

    #region Add localization
    builder.Services.Configure<RequestLocalizationOptions>(

        opt =>
        {
            var supportedCultures = new List<CultureInfo>
            {
           new CultureInfo("en"),
           new CultureInfo("ar"),
            };
            opt.DefaultRequestCulture = new Microsoft.AspNetCore.
            Localization.RequestCulture("en", "en");
            opt.SupportedCultures = supportedCultures;
            opt.SupportedUICultures = supportedCultures;
        });

    #endregion

    builder.Services.AddSwaggerGen(
        options =>
        {
            options.OperationFilter<APIlanguageHeader>();
        }
        );

}


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
