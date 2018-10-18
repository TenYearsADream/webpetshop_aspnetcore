/*--------------------------------------
 * Project.......: WebPetShop
 * Author........: Ronaldo Torre
 * Date..........: Oct/2018
 * --------------------------------------
 */

namespace WebPetShop.Models.Utils
{
    public class EntityUtil
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public EntityUtil(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
