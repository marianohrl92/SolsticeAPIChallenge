using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SolsticeAPIChallenge.Models;
using SolsticeAPIChallenge.Models.Repository;


namespace SolsticeAPIChallenge.Controllers
{
    public class ContactController : ControllerBase
    {
        private readonly IDataRepository<Contact> _dataRepository;

        public ContactController(IDataRepository<Contact> dataRepository)
        {
            _dataRepository = dataRepository;
        }

        // GET: api/contact/GetAllContacts
        [HttpGet]
        [Route("api/contact/GetAllContacts")]
        public IActionResult GetAllContacts()
        {
            IEnumerable<Contact> Contacts = _dataRepository.GetAllContacts();

            return Ok(Contacts);
        }

        // GET: api/Contact/GetContactByID/5
        [HttpGet]
        [Route("api/contact/GetContactByID/{ContactId}")]
        public IActionResult GetContactByID(long ContactId)
        {
            Contact contact = _dataRepository.GetContactById(ContactId);

            if (contact == null)
            {
                return NotFound("The Contact record couldn't be found.");
            }

            return Ok(contact);
        }

        // GET: api/Contact/GetAllContactsByStateOrAddress/value
        [HttpGet]
        [Route("api/contact/GetAllContactsByStateOrAddress/{value}")]
        public IActionResult GetAllContactsByStateOrAddress(string value)
        {
            List<Contact> contacts = _dataRepository.GetAllContactsByStateOrAddress(value);

            if (contacts == null)
            {
                return NotFound("No Contact record could be found.");
            }

            return Ok(contacts);
        }

        // GET: api/Contact/GetContactByEmailOrPhone/value
        [HttpGet]
        [Route("api/contact/GetContactByEmailOrPhone/{value}")]
        public IActionResult GetContactByEmailOrPhone(string value)
        {
            Contact contacts = _dataRepository.GetContactByEmailOrPhone(value);

            if (contacts == null)
            {
                return NotFound("No Contact record could be found.");
            }

            return Ok(contacts);
        }

        // PUT: api/contact/PutUpdateContact/Contact
        [HttpPut]
        [Route("api/contact/PutUpdateContact")]
        public IActionResult PutUpdateContact([FromBody]Contact contact)
        {
            if (contact.ContactId == 0)
            {
                return BadRequest("Contact is null.");
            }

            Contact contactToUpdate = _dataRepository.GetContactById(contact.ContactId);
            if (contactToUpdate == null)
            {
                return NotFound("The Contact record couldn't be found.");
            }

            Contact ContactUpdated = new Contact();

            ContactUpdated = _dataRepository.Update(contactToUpdate, contact);

            if (ContactUpdated != null)
            {
                return Ok(ContactUpdated);
            }
            else
            {
                return BadRequest("No contact Found to update.");
            };
        }


        // POST: api/contact/PostNewContact/Contact
        [HttpPost]
        [Route("api/contact/PostNewContact")]
        public IActionResult PostNewContact([FromBody]Contact contact)
        {
            Contact ContactCreated = new Contact();

            if (!(contact.ContactId == 0))
            {
                return BadRequest("ContactId should be empty.");
            }

            ContactCreated = _dataRepository.PostNewContact(contact);

            if (ContactCreated != null)
            {
                return Ok(ContactCreated);
            }
            else
            {
                return BadRequest("No contact created.");
            };
        }

        [HttpDelete]
        [Route("api/contact/DeleteContact/{value}")]
        public IActionResult DeleteContact(long value)
        {
            Contact contact = _dataRepository.GetContactById(value);
            if (contact == null)
            {
                return NotFound("The contact record couldn't be found.");
            }
            _dataRepository.Delete(contact);
            return Ok("Contact with ContactId " + contact.ContactId + " deleted successfully.");
        }
    }
}