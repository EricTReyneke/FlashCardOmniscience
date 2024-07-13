using Business.DynamicModelReflector.DataOperations;
using Business.DynamicModelReflector.Helpers;
using Business.DynamicModelReflector.Interfaces;
using Business.DynamicModelReflector.ModelReflectors;
using Business.DynamicModelReflector.QueryBuilders;
using Data.FlashCardImmortals.DataOperations;
using Data.FlashCardImmortals.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();

builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession(options =>
{
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
    options.IdleTimeout = TimeSpan.FromMinutes(20);
});

#region Injections
//Data Operations Service
builder.Services.AddScoped<IDataOperations, SqlDataOperations>();
builder.Services.AddScoped<IDataOperationHelper, SqlDataOperationHelper>();
builder.Services.AddScoped<IQueryBuilder, SqlQueryBuilder>();
builder.Services.AddScoped<IModelReflector, SqlModelReflector>();

//Domain Specific Data Operations
builder.Services.AddScoped<IFlashcardsDataOperations, OpsFlashcardsDataOperations>();
builder.Services.AddScoped<IMainCategoriesDataOperations, OpsMainCategoriesDataOperations>();
builder.Services.AddScoped<ISubCategoriesDataOperations, OpsSubCategoriesDataOperations>();
builder.Services.AddScoped<IUsersDataOperations, OpsUsersDataOperations>();
#endregion

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseSession();

app.UseAuthorization();

app.MapRazorPages();

app.Run();