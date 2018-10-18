using System.Collections.Generic;

namespace WebPetShop.Generic
{
    /*--------------------------------------
     * Project.......: WebPetShop
     * Author........: Ronaldo Torre
     * Date..........: Oct/2018
     * --------------------------------------
     */
    public interface IManager<E> where E : class
    {
        bool Insert(E entity);
        bool Update(E entity);
        bool Delete(E entity);
        E GetById(int id);
        E GetByName(string name);
        List<E> GetAll();
    }

}