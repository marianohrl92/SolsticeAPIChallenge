using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolsticeAPIChallenge.Models.Repository
{
    public interface IDataRepository<TEntity>
    {
        IEnumerable<TEntity> GetAllContacts();
        TEntity GetContactById(long ContactId);
        List<TEntity> GetAllContactsByStateOrAddress(string ContactId);
        TEntity GetContactByEmailOrPhone(string ContactId);
        TEntity PostNewContact(TEntity entity);
        TEntity Update(TEntity dbEntity, TEntity entity);
        void Delete(TEntity entity);
    }
}