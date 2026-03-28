using DACS.Models;
using Microsoft.EntityFrameworkCore;
using DACS.Services; // OpenAIService, FAQService
using DACS.Hubs;     // ChatHub
using Microsoft.AspNetCore.Authentication.Cookies;
using DACS.Models.Services;

var builder = WebApplication.CreateBuilder(args);

// =====================
// 1. Cấu hình kết nối CSDL
// =====================
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// =====================
// 2. Cấu hình xác thực Cookie
// =====================
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Account/Login";
        options.LogoutPath = "/Account/Logout";
        options.AccessDeniedPath = "/Account/AccessDenied";
    });

// =====================
// 3. Cấu hình Session
// =====================
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

// =====================
// 4. Đăng ký dịch vụ khác
// =====================
builder.Services.AddHttpClient();
builder.Services.AddScoped<OpenAIService>();    // Dịch vụ AI OpenAI
builder.Services.AddScoped<FAQService>();       // Dịch vụ FAQ
builder.Services.AddHttpContextAccessor();
builder.Services.AddSignalR();

// =====================
// 5. Thêm MVC
// =====================
builder.Services.AddControllersWithViews();

var app = builder.Build();

// =====================
// 6. Middleware pipeline
// =====================
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseSession();
app.UseAuthentication();
app.UseAuthorization();

// =====================
// 7. Map route + SignalR
// =====================
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapHub<ChatHub>("/chatHub");

app.Run();
