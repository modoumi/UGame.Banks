using Serilog;
using StackExchange.Redis;
using TinyFx;
using TinyFx.Logging;
using UGame.Banks.Service;
using UGame.Banks.Service.Services;
using UGame.Banks.Service.Services.SyncOrders;
using Xxyy.Banks.DAL;

var builder = AspNetHost.CreateBuilder();

builder.Services.AddSingleton<MessageService>();
builder.Services.AddSingleton<OrderService>();
builder.Services.AddSingleton<UGame.Banks.Letspay.BankProxy>();
builder.Services.AddSingleton<UGame.Banks.Tejeepay.BankProxy>();
builder.Services.AddSingleton<UGame.Banks.Hubtel.BankProxy>();
builder.Services.AddSingleton<UGame.Banks.Tejeepay.Service.VerifyOrderService>();
builder.Services.AddSingleton<UGame.Banks.Letspay.Service.VerifyOrderService>();
builder.Services.AddSingleton<UGame.Banks.Hubtel.PaySvc.VerifyOrderService>();
builder.Services.AddSingleton(sp =>
{
    Func<string, IVerifyOrder> getVeiryOrderFunc = bankId =>
    {
        return bankId switch
        {
            "tejeepay" => sp.GetService<UGame.Banks.Tejeepay.Service.VerifyOrderService>(),
            "letspay" => sp.GetService<UGame.Banks.Letspay.Service.VerifyOrderService>(),
            "hubtel" => sp.GetService<UGame.Banks.Hubtel.PaySvc.VerifyOrderService>(),
            _ => throw new ArgumentException($"δ֪�Ĳ���bankid��{nameof(bankId)}")
        };
    };
    return getVeiryOrderFunc;
});

// Add services to the container.
builder.AddAspNetEx();
//builder.Host.UseBanksServer();

var app = builder.Build();
// Configure the HTTP request pipeline.
app.UseAspNetEx();

app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
