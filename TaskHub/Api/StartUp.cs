using Api.Filters;
using Api.Middleware;
using Api.ModelBinders;
using Api.Services.Tasks;
using Api.Services.Tasks.Interfaces;
using Api.UseCases.Tasks;
using Api.UseCases.Users;
using Api.UseCases.Users.Interfaces;
using Dal;
using Logic;
using Microsoft.OpenApi.Models;

namespace Api;

/// <summary>
/// Конфигурация приложения
/// </summary>
public sealed class Startup
{
    /// <summary>
    /// Конфигурация приложения
    /// </summary>
    private IConfiguration Configuration { get; }

    /// <summary>
    /// Окружение приложения
    /// </summary>
    private IWebHostEnvironment Environment { get; }

    public Startup(IConfiguration configuration, IWebHostEnvironment env)
    {
        Configuration = configuration;
        Environment = env;
    }

    /// <summary>
    /// Регистрация сервисов
    /// </summary>
    /// <param name="services">Коллекция сервисов</param>
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();
        services.Configure<Microsoft.AspNetCore.Mvc.ApiBehaviorOptions>(options =>
        {
            options.SuppressModelStateInvalidFilter = true;
        });
        services.AddDal();
        services.AddLogic();
        
        services.AddScoped<IManageUserUseCase, ManageUserUseCase>();

        services.AddScoped<CreateTaskUseCase>();
        services.AddScoped<GetTasksUseCase>();
        services.AddScoped<GetTaskUseCase>();
        services.AddScoped<SetTaskTitleUseCase>();
        services.AddScoped<DeleteTaskUseCase>();
        services.AddScoped<DeleteTasksUseCase>();

        services.AddScoped<StudentInfoHeadersFilter>();
        services.AddScoped<RequestLoggingFilter>();
        services.AddScoped<ValidateCreateTaskRequestFilter>();
        services.AddScoped<ValidateSetTaskTitleRequestFilter>();

        services.AddScoped<ITaskService, TaskService>();

        services.AddCors(options =>
        {
            options.AddDefaultPolicy(builder =>
            {
                builder
                    .SetIsOriginAllowed(_ => true)
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials();
            });
        });

        services.AddEndpointsApiExplorer();

        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "TaskHub Api",
                Version = "v1"
            });
        });
    }

    /// <summary>
    /// Конфигурация middleware пайплайна
    /// </summary>
    /// <param name="app">Построитель приложения</param>
    public void Configure(IApplicationBuilder app)
    {
        if (Environment.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "TaskHub API v1");
            });
        }

        //app.UseMiddleware<StudentInfoMiddleware>();
        //app.UseMiddleware<ResponseTimeMiddleware>();

        app.UseRouting();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}