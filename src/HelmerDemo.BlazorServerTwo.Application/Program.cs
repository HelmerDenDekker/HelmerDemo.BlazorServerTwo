using HelmerDemo.BlazorServerTwo.Application.Components;
using HelmerDemo.BlazorServerTwo.Application.Features.Clock.MVVM;
using HelmerDemo.BlazorServerTwo.Application.Features.SharedTabs.NotifyChanged;
using HelmerDemo.BlazorServerTwo.Application.Features.Users;
using HelmerDemo.BlazorServerTwo.Application.JsInterop;
using R3;
using IMessageBoxStore = HelmerDemo.BlazorServerTwo.Application.Features.SharedTabs.NotifyChanged.IMessageBoxStore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddBlazorR3();

// TODO: Find the right scope for Blazor. Sometimes is better to use a (singleton)Factory and create a new instance fow hen you need a service.
// Scoped is one per instance / session.
builder.Services.AddScoped<IClockViewModel, ClockViewModel>();
builder.Services.AddSingleton<IMessageBoxStore, MessageBoxStore>();
builder.Services.AddScoped<IMessageBoxViewModel, MessageBoxViewModel>();
builder.Services.AddScoped<IEditMessageBoxViewModel, EditMessageBoxViewModel>();
builder.Services.AddScoped<ILocalStorageProvider, LocalStorageProvider>(); // TODO This might live too long for its purpose in UserSession.
builder.Services.AddScoped<IUserStateService, UserStateService>();

builder.Services.AddSingleton<IUserStateStore, UserStateStore>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
