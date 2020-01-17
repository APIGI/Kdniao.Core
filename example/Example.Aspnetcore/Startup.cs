using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Kdniao.Core;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace Example.Aspnetcore
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

            services.AddKdniao(options =>
            {
                options.EBusinessID = "test1596820";
                options.AppKey = "e4d81345-4b85-4cf7-81d7-6a0ab8f0fa19";
                options.IsSandBox = true;
            });

            #region Swagger
            //ע��Swagger������������һ���Ͷ��Swagger �ĵ�
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Kdniao.Core ���� API ",
                    Version = "v1",
                    TermsOfService = new Uri("https://github.com/wannvmi/Kdniao.Core"),
                    Description = "Kdniao.Core �ǻ���.NET Core�����ݿ����ٷ�API�ĵ������Ŀ�ƽ̨SDK����",
                    Contact = new OpenApiContact
                    {
                        Name = "wannvmi",
                        Url = new Uri("https://github.com/wannvmi/"),
                        Email = "996198546@qq.com"
                    },
                    License = new OpenApiLicense
                    {

                    }
                });

                // ����SWAGER JSON��UI��ע��·����
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, $"{Assembly.GetExecutingAssembly().GetName().Name}.xml"));

                options.DescribeAllParametersInCamelCase();

                // enable swagger Annotations
                options.EnableAnnotations();
            });
            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            #region Swagger
            //�����м����������Swagger��ΪJSON�ս��
            app.UseSwagger();
            //�����м�������swagger-ui��ָ��Swagger JSON�ս��
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("swagger/v1/swagger.json", "ȫ�� API");
                options.RoutePrefix = "";//·�����ã�����Ϊ�գ���ʾֱ�ӷ��ʸ��ļ���
                //·�����ã�����Ϊ�գ���ʾֱ���ڸ�������localhost:8001�����ʸ��ļ�,ע��localhost:8001/swagger�Ƿ��ʲ����ģ�
                //���ʱ��ȥlaunchSettings.json�а�"launchUrl": "swagger/index.html"ȥ���� Ȼ��ֱ�ӷ���localhost:8001/index.html����
            });
            #endregion

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
