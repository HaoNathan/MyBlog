using System.Reflection;
using Autofac;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MyBlog.BLL.Profiles;
using MyBlog.MODEL;

namespace MyBlog
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
            services.AddControllers();
            services.AddDbContext<MyBlogContext>(option => option.UseMySQL(
                Configuration.GetConnectionString("Default")
            ));
            var config = new MapperConfiguration(e => e.AddProfile(new MappingProfile()));
            var mapper = config.CreateMapper();
            services.AddSingleton(mapper);
        }

        public void ConfigureContainer(ContainerBuilder containerBuilder)
        {
            Assembly service = Assembly.Load("MyBlog.DAL");
            Assembly iService = Assembly.Load("MyBlog.IDAL");
            Assembly manager = Assembly.Load("MyBlog.BLL");
            Assembly iManager = Assembly.Load("MyBlog.IBLL");

            containerBuilder.RegisterAssemblyTypes(service, iService)
                .Where(t => t.FullName.EndsWith("Service") && !t.IsAbstract) //类名以service结尾，且类型不能是抽象的　
                .InstancePerLifetimeScope() //生命周期，
                .AsImplementedInterfaces()
                .PropertiesAutowired();

            containerBuilder.RegisterAssemblyTypes(manager, iManager)
                .Where(t => t.FullName.EndsWith("Manager") && !t.IsAbstract) //类名以service结尾，且类型不能是抽象的　
                .InstancePerLifetimeScope() //生命周期，
                .AsImplementedInterfaces()
                .PropertiesAutowired(); 
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
