using Blazor.Components;
using BlazorPro.BlazorSize;
using Google.Apis.YouTube.v3;
using GradeProject.Components;
using GradeProject.Components.Account;
using GradeProject.Data;
using GradeProject.Services;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Radzen;
using Stripe;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddRadzenComponents();
builder.Services.AddCascadingAuthenticationState();
builder.Services.AddScoped<IdentityUserAccessor>();
builder.Services.AddScoped<IdentityRedirectManager>();
builder.Services.AddScoped<AuthenticationStateProvider, IdentityRevalidatingAuthenticationStateProvider>();
builder.Services.AddScoped<ICSharpExecutorService, CSharpExecutorService>();
builder.Services.AddScoped<ILessonService, LessonService>();
builder.Services.AddScoped<IQuizService, QuizService>();
builder.Services.AddScoped<IQuizLoaderService, QuizLoaderService>();
builder.Services.AddScoped<INavigationService, NavigationService>();
builder.Services.AddSingleton<ProblemService>();
builder.Services.AddCommandLine();
builder.Services.AddTransient<IForumService,ForumService>();
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<UserProfileService>();
builder.Services.AddMediaQueryService();
builder.Services.AddSingleton<YouTubeApiService>();

StripeConfiguration.ApiKey = "sk_test_51PbRIKEMmORADTdsXcajjZYaAMxmuNC9XpZySpTAzY4S3lp1Y4quN3UVGGE9a7Rq4rbwz1XMiTREzM9QigWrcHqJ00b1WVwkZI";

builder.Services.AddAuthentication(options =>
    {
        options.DefaultScheme = IdentityConstants.ApplicationScheme;
        options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
    })
    .AddIdentityCookies();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
//builder.Services.AddDbContextFactory<ApplicationDbContext>(options =>
//    options.UseSqlServer(connectionString));

//builder.Services.AddDbContext<ApplicationDbContext>(options =>
//    options.UseSqlite(connectionString));
builder.Services.AddDbContextFactory<ApplicationDbContext>(options =>
        options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddIdentityCore<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddSignInManager()
    .AddDefaultTokenProviders();

builder.Services.AddSingleton<IEmailSender<ApplicationUser>, IdentityNoOpEmailSender>();

var app = builder.Build();
StripeConfiguration.ApiKey = app.Configuration.GetValue<string>("StripeAPIKey");
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();
app.UseCommandLine(Environment.UserDomainName);
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

// Add additional endpoints required by the Identity /Account Razor components.
app.MapAdditionalIdentityEndpoints();
app.UseStatusCodePagesWithRedirects("/notfound");

using(var scope = app.Services.CreateScope())
{
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    
    var roles = new string[] { "Admin", "Premium" };
    foreach (var role in roles)
    {
        if (!roleManager.Roles.Any(r => r.Name == role))
        {
            roleManager.CreateAsync(new IdentityRole(role)).Wait();
        }
    }
}

using (var scope = app.Services.CreateScope())
{
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
    string Email = "peter.odrobinak@outlook.sk";
    string Password = "Peter9871.";

    if(userManager.FindByEmailAsync(Email).Result == null)
    {
        ApplicationUser user = new ApplicationUser();
        user.FullName = "Peter Odrobinak";
        user.Gender = "Male";
        user.UserName = Email;
        user.Email = Email;
        user.EmailConfirmed = true;

        IdentityResult result = userManager.CreateAsync(user, Password).Result;

        if (result.Succeeded)
        {
            userManager.AddToRoleAsync(user, "Admin").Wait();
        }
    }
}
app.Run();