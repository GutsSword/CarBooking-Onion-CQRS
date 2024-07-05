using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UdemyCarBook.Application.Features.CQRS.Commands.ContactCommands;
using UdemyCarBook.Application.Features.CQRS.Handlers.ContactHandlers;
using UdemyCarBook.Application.Features.CQRS.Queries.ContactQueries;

namespace UdemyCarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly CreateContactCommandHandler createContactCommandHandler;
        private readonly GetContactByIdQueryHandler getContactByIdQueryHandler;
        private readonly GetContactQueryHandler getContactQueryHandler;
        private readonly RemoveContactCommandHandler removeContactCommandHandler;
        private readonly UpdateContactCommandHandler updateContactCommandHandler;


        public ContactController(CreateContactCommandHandler createContactCommandHandler, GetContactByIdQueryHandler getContactByIdQueryHandler, GetContactQueryHandler getContactQueryHandler, RemoveContactCommandHandler removeContactCommandHandler, UpdateContactCommandHandler updateContactCommandHandler)
        {
            this.createContactCommandHandler = createContactCommandHandler;
            this.getContactByIdQueryHandler = getContactByIdQueryHandler;
            this.getContactQueryHandler = getContactQueryHandler;
            this.removeContactCommandHandler = removeContactCommandHandler;
            this.updateContactCommandHandler = updateContactCommandHandler;
        }

        [HttpGet]
        public async Task<IActionResult> ContactList()
        {
            var values = await getContactQueryHandler.Handle();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetContactById(int id)
        {
            var values = await getContactByIdQueryHandler.Handle(new GetContactByIdQuery(id));
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateContact(CreateContactCommand command)
        {
            await createContactCommandHandler.Handle(command);
            return Ok("Contact bilgisi eklendi.");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteContact(int id)
        {
            await removeContactCommandHandler.Handle(new RemoveContactCommand(id));
            return Ok("Contact bilgisi silindi.");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateContact(UpdateContactCommand command)
        {
            await updateContactCommandHandler.Handle(command);
            return Ok("Contact bilgisi güncellendi.");
        }
    }
}
