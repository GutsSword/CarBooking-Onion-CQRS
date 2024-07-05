using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UdemyCarBook.Application.Features.CQRS.Commands.BrandCommands;
using UdemyCarBook.Application.Features.CQRS.Commands.CategoryCommands;
using UdemyCarBook.Application.Features.CQRS.Handlers.BrandHandlers;
using UdemyCarBook.Application.Features.CQRS.Handlers.CategoryHandlers;
using UdemyCarBook.Application.Features.CQRS.Queries.BrandQueries;
using UdemyCarBook.Application.Features.CQRS.Queries.CategoryQueries;

namespace UdemyCarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly CreateCategoryCommandHandler createCategoryCommandHandler;
        private readonly GetCategoryByIdQueryHandler getCategoryByIdQueryHandler;
        private readonly GetCategoryQueryHandler getCategoryQueryHandler;
        private readonly RemoveCategoryCommandHandler removeCategoryCommandHandler;
        private readonly UpdateCategoryCommandHandler updateCategoryCommandHandler;

        public CategoryController(CreateCategoryCommandHandler createCategoryCommandHandler, GetCategoryByIdQueryHandler getCategoryByIdQueryHandler, GetCategoryQueryHandler getCategoryQueryHandler, RemoveCategoryCommandHandler removeCategoryCommandHandler, UpdateCategoryCommandHandler updateCategoryCommandHandler)
        {
            this.createCategoryCommandHandler = createCategoryCommandHandler;
            this.getCategoryByIdQueryHandler = getCategoryByIdQueryHandler;
            this.getCategoryQueryHandler = getCategoryQueryHandler;
            this.removeCategoryCommandHandler = removeCategoryCommandHandler;
            this.updateCategoryCommandHandler = updateCategoryCommandHandler;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategory()
        {
            var values = await getCategoryQueryHandler.Handle();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            var values = await getCategoryByIdQueryHandler.Handle(new GetCategoryByIdQuery(id));
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryCommand Category)
        {
            await createCategoryCommandHandler.Handle(Category);
            return Ok("Category başarıyla eklendi.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryCommand command)
        {
            await updateCategoryCommandHandler.Handle(command);
            return Ok($"{command.CategoryId} numaralı Category başarıyla güncellendi.");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            await removeCategoryCommandHandler.Handle(new RemoveCategoryCommand(id));
            return Ok("Category başarıyla silindi.");
        }
    }
}
