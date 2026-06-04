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
//*************************************************************************************
// Configuring the Custom Route Constraint Service Using AddRouting Method Start
//*************************************************************************************
// builder.Services.AddRouting(options =>
// {
//     options.ConstraintMap.Add("alphanumeric",typeof(AlphaNumericConstraint));
// });
//Configuring the Custom Route Constraint service using Configure Method
// builder.Services.Configure<RouteOptions> (routeOtions =>
// {
//     routeOtions.ConstraintMap.Add("alphanumeric",typeof(AlphaNumericConstraint));
// });
//*************************************************************************************
// Configuring the Custom Route Constraint Service Using AddRouting Method End
//*************************************************************************************
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
//-----------------------------------
//Convention-Based Rounting start
//-----------------------------------
app.MapControllerRoute(
    name:"StudentAll",
    pattern:"Student/GetAllStudents",
    defaults: new{controller ="Student",action="Index"}
);

app.MapControllerRoute(
    name:"StudentIndex",
    pattern:"StudentDetails/{ID}",
    defaults: new{controller ="Student",action="GetStudentsByName"}
);

//-----------------------------------
//Convention-Based Rounting end
//-----------------------------------


app.Run();
