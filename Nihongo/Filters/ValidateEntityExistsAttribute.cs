using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using Nihongo.Entites.Models;
using Nihongo.Entites.Nihongo;
using System.Linq;
using System.Threading.Tasks;

namespace Nihongo.Api.Filters
{
    public class ValidateEntityExistsAttribute<T> : IAsyncActionFilter where T : class, IEntity
    {
        private readonly NihongoContext _context;

        public ValidateEntityExistsAttribute(NihongoContext context)
        {
            this._context = context;
        }
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (context.ActionArguments.ContainsKey("id"))
            {
                var id = (int)context.ActionArguments["id"];
                var entity = await _context.Set<T>().Where(x => x.Id.Equals(id)).FirstOrDefaultAsync();
                if (entity == null)
                {
                    context.Result = new NotFoundObjectResult($"Entity with id ${id} does not exist");
                }
                else
                {
                    context.HttpContext.Items.Add("entity", entity);
                    await next();
                }
            }
            else
            {
                context.Result = new BadRequestObjectResult("Bad id parameter");
            }
        }
    }
}
