using Lorem.Core.Dtos.ResponseDtos;
using Lorem.Service.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using System.Text.Json;

namespace Lorem.Api.Middlewares
{
    public static class UseCustomExeptionHandler
    {

        public static void UseCustomException(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(config =>
            {
                config.Run(async context =>
                {
                    // Ayarla: Yanıt içeriğinin türünü "application/json" olarak belirle
                    context.Response.ContentType = "application/json";

                    // IExceptionHandlerFeature özelliğini al
                    var exceptionFeature = context.Features.Get<IExceptionHandlerFeature>();

                    // Duruma göre HTTP durum kodunu belirle
                    var statusCode = exceptionFeature.Error switch
                    {
                        ClientSideException => 400, // İstemci tarafında oluşan hata ise 400 Bad Request
                        NotFoundException => 404,    // Kaynak bulunamadı hatası ise 404 Not Found
                        _ => 500                    // Diğer hata durumlarında 500 Internal Server Error
                    };

                    // HTTP durum kodunu yanıtla beraber ayarla
                    context.Response.StatusCode = statusCode;

                    // Hata mesajını içeren özel yanıt nesnesini oluştur
                    var response = CustomResponseDto<NoContent>.Fail(statusCode, exceptionFeature.Error.Message);

                    // Özel yanıt nesnesini JSON formatına dönüştürüp yanıt olarak gönder
                    await context.Response.WriteAsync(JsonSerializer.Serialize(response));
                });
            });
        }

    }
}
