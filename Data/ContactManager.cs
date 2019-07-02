using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolsticeAPIChallenge.Models;
using SolsticeAPIChallenge.Models.Repository;

namespace SolsticeAPIChallenge.Data.ContactManager
{
    public class ContactManager : IDataRepository<Contact>
    {
        readonly Models.ContactContext _ContactContext;

        public ContactManager(ContactContext context)
        {
            _ContactContext = context;
        }

        public IEnumerable<Contact> GetAllContacts()
        {
            return _ContactContext.Contacts.ToList();
        }

        public Contact GetContactById(long ContactId)
        {
            return _ContactContext.Contacts
                  .FirstOrDefault(e => e.ContactId == ContactId);
        }

        public List<Contact> GetAllContactsByStateOrAddress(string value)
        {
            return _ContactContext.Contacts.Where(s => s.City.ToLower().Contains(value.ToLower()) || s.Country.ToLower().Contains(value.ToLower())).ToList<Contact>();
        }


        public Contact GetContactByEmailOrPhone(string value)
        {
            return _ContactContext.Contacts.FirstOrDefault(s => s.Email.ToLower().Contains(value.ToLower()) || s.PerPhoneNumber.ToString().Contains(value.ToLower()) || s.WorkPhoneNumber.ToString().Contains(value.ToLower()));
        }



        public Contact PostNewContact(Contact entity)
        {
            Contact NewContact = new Contact();

            NewContact = _ContactContext.Contacts.Add(entity).Entity;
            _ContactContext.SaveChanges();

            return NewContact;
        }

        public Contact Update(Contact contact, Contact entity)
        {
            contact.Name = entity.Name;
            contact.Company = entity.Company;
            contact.Image = entity.Image;
            contact.Email = entity.Email;
            contact.Birthdate = entity.Birthdate;
            contact.PerPhoneNumber = entity.PerPhoneNumber;
            contact.WorkPhoneNumber = entity.WorkPhoneNumber;
            contact.Street = entity.Street;
            contact.City = entity.City;
            contact.Country = entity.Country;


            _ContactContext.SaveChanges();

            return contact;
        }

        public void Delete(Contact employee)
        {
            _ContactContext.Contacts.Remove(employee);
            _ContactContext.SaveChanges();
        }


    }
}
