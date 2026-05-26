using CoreLearn.Models;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//builder.Services.AddControllersWithViews();
builder.Services.AddMvc();

//******************************************************
// Add Application Service to the Container. 
//******************************************************
//builder.Services.Add(new ServiceDescriptor(typeof(IStudentRepository),new StudentRepository()));// by default singleton
//builder.Services.Add(new ServiceDescriptor(typeof(IStudentRepository),typeof(StudentRepository),ServiceLifetime.Singleton));//singleton
//builder.Services.Add(new ServiceDescriptor(typeof(IStudentRepository),typeof(StudentRepository),ServiceLifetime.Transient));//Transient
//builder.Services.Add(new ServiceDescriptor(typeof(IStudentRepository),typeof(StudentRepository),sServiceLifetime.Scoped));//Scoped

//******************************************************
// Extension Methods for Registration 
//******************************************************
//**************************
// Singleton
//**************************
builder.Services.AddSingleton<IStudentRepository, StudentRepository>();
builder.Services.AddSingleton<SomeOtherService>();
// builder.Services.AddSingleton(typeof(IStudentRepository),typeof(StudentRepository));
// builder.Services.AddTransient<IStudentRepository, StudentRepository>();
// builder.Service.AddTransient(typeof(IStudentRepository),typeof(StudentRepository));
// builder.Services.AddScoped<IStudentRepository, StudentRepository>();
// builder.Services.AddScoped(typeof(IStudentRepository),typeof(StudentRepository));
var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
