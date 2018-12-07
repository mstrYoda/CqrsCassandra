using System.Reflection;
using Cassandra;
using CqrsCassandra.Application.Commands;
using CqrsCassandra.Domain;
using CqrsCassandra.Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CqrsCassandra.Application
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            
            services.AddMediatR(typeof(ShipmentCommandHandler).GetTypeInfo().Assembly);

            services.AddTransient<IShipmentCommandRepository, ShipmentCommandRepository>();
            services.AddTransient<ShipmentService>();
            
            Cluster cluster = Cluster
                .Builder()
                .AddContactPoints(new string[] { "" })
                .WithCompression(CompressionType.LZ4)
                .WithLoadBalancingPolicy(new DCAwareRoundRobinPolicy("west"))
                .Build();
            
            ISession session = cluster.Connect();

            services.AddSingleton<ISession>(session);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
