using Lorem.Core.Dtos.ResponseDtos;
using Lorem.Core.Entities;
using Lorem.Core.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Lorem.Api.ValidateFilter
{
    public class NotFoundFilter<T> : IAsyncActionFilter where T : EntityBase
    {
        private readonly IService<T> _service;

        public NotFoundFilter(IService<T> service)
        {
            _service = service;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var idValue = context.ActionArguments.Values.FirstOrDefault();
            if (idValue == null)
            {
                await next.Invoke();
                return;
            }
            var id = (int)idValue;
            var anyentity = await _service.AnyAsync(x => x.Id == id);
            if (anyentity)
            {
                await next.Invoke();
                return;
            }
            context.Result = new NotFoundObjectResult(CustomResponseDto<T>.Fail(404, $"{typeof(T).Name} ({id}) bulunamadı."));
        }
    }
}
