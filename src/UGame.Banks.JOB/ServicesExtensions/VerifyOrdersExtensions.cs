using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UGame.Banks.Service.Services;

namespace UGame.Banks.JOB.ServicesExtensions
{
    public static class VerifyOrdersExtensions
    {
        public static IServiceCollection AddVerifyOrderService(this IServiceCollection services)
        {
            services.AddSingleton<MessageService>();
            services.AddSingleton<OrderService>();
            services.AddSingleton<UGame.Banks.Letspay.BankProxy>();
            services.AddSingleton<UGame.Banks.Tejeepay.BankProxy>();
            services.AddSingleton<UGame.Banks.Hubtel.BankProxy>();
            services.AddSingleton<UGame.Banks.Tejeepay.Service.VerifyOrderService>();
            services.AddSingleton<UGame.Banks.Letspay.Service.VerifyOrderService>();
            services.AddSingleton<UGame.Banks.Hubtel.PaySvc.VerifyOrderService>();
            services.AddSingleton(sp =>
            {
                Func<string, UGame.Banks.Service.Services.SyncOrders.IVerifyOrder> getVeiryOrderFunc = bankId =>
                {
                    return (bankId switch
                    {
                        "tejeepay" => sp.GetService<UGame.Banks.Tejeepay.Service.VerifyOrderService>(),
                        "letspay" => sp.GetService<UGame.Banks.Letspay.Service.VerifyOrderService>(),
                        "hubtel" => sp.GetService<UGame.Banks.Hubtel.PaySvc.VerifyOrderService>(),
                        _ => throw new ArgumentException($"未知的参数bankid：{nameof(bankId)}")
                    })!;
                };
                return getVeiryOrderFunc;
            });
            return services;
        }
    }
}
