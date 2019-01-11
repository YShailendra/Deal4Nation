using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Products.Context;
using Products.Repository.Brand;
using Products.Repository.Category;
using Products.Repository.Deal;
using Products.Repository.Offer;
using Products.Repository.Store;
using Products.Repository.User;
using Products.Repository.UserInteraction;
using Products.Repository.Ads;
using Products.Repository.Image;
using Newtonsoft.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Cors.Internal;
using System.Buffers;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc.Formatters;

namespace Products
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
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            //using Dependency Injection
            services.AddSingleton<IUserRepository, UserRepository>();
            services.AddSingleton<IDealRepository, DealRepository>();
            services.AddSingleton<IStoreRepository, StoreRepository>();
            services.AddSingleton<IOfferRepository, OfferRepository>();
            services.AddSingleton<ICategoryRepository, CategoryRepository>();
            services.AddSingleton<IBrandRepository, BrandRepository>();
            services.AddSingleton<IUserInteractionRepository, UserInteractionRepository>();
            services.AddSingleton<IAdsRepository, AdsRepository>();
            services.AddSingleton<IImageRepository, ImageRepository>();
            services.AddMvc(options=>{
            //this is to remove refrence loop of data model
            options.OutputFormatters.Clear();
            options.OutputFormatters.Add(new JsonOutputFormatter(new JsonSerializerSettings()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            }, ArrayPool<char>.Shared));
            }).AddJsonOptions(options => options.SerializerSettings.ContractResolver = new DefaultContractResolver());
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors(builder => builder
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials());
            app.UseMvc();
        }
    }
}
