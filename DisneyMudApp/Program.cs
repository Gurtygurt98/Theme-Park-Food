using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Hosting.StaticWebAssets;
using MudBlazor;
using MudBlazor.Services;
using SQL_API.Data;
var builder = WebApplication.CreateBuilder(args);

StaticWebAssetsLoader.UseStaticWebAssets(builder.Environment, builder.Configuration);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddTransient<ISQLDataAccess,SQLDataAccess>();
builder.Services.AddTransient<IFestivalData, FestivalData>();
builder.Services.AddTransient<IMenuData, MenuData>();
builder.Services.AddTransient<IFoodData, FoodData>();
builder.Services.AddTransient<IParkData, ParkData>();
builder.Services.AddTransient<IAllergyData, AllergyData>();
builder.Services.AddTransient<IFestivalData, FestivalData>();
builder.Services.AddTransient<ILocationData, LocationData>();
builder.Services.AddTransient<IAreaData, AreaData>();
builder.Services.AddTransient<ITagData, TagData>();
builder.Services.AddMudServices();
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

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();