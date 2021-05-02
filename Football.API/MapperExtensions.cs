using AutoMapper;
using Football.API.Profiles;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Football.API
{
    public static class MapperExtensions
    {
        public static void AddMapper(this IServiceCollection services)
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new PlayerProfile());
                mc.AddProfile(new ContractProfile());
                mc.AddProfile(new MatchProfile());
                mc.AddProfile(new MatchBroadcastProfile());
                mc.AddProfile(new PlayerMatchProfile());
                mc.AddProfile(new TrainingProfile());
                mc.AddProfile(new PlayerTrainingProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
        }

    }
}
