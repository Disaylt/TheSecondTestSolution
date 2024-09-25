using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TheSecondTestSolution.Application.Behavoirs;
using FluentValidation;
using TheSecondTestSolution.Application.Services;
using TheSecondTestSolution.Application.Utilities;

namespace TheSecondTestSolution.Application
{
    public static class ApplicationLayerRegistration
    {
        public static void AddApplicationLayer(this IServiceCollection collection)
        {
            collection.AddSingleton<ITopicService, TopicService>();
            collection.AddSingleton<ITopicMapper, TopicMapper>();

            collection.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            collection.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());

                cfg.AddOpenBehavior(typeof(ValidatorBehavior<,>));
                cfg.AddOpenBehavior(typeof(TransactionBehavior<,>));
            });
        }
    }
}
