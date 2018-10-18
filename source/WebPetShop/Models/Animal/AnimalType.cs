/*--------------------------------------
 * Project.......: WebPetShop
 * Author........: Ronaldo Torre
 * Date..........: Oct/2018
 * --------------------------------------
 */
namespace WebPetShop.Models.Animals
{
    public class AnimalType
    {
        public enum Animals
        {
            Dog = 0,
            Birds = 1,
            Bunny = 2,
            Cat = 3,
            Fish = 4
        }

        public enum Situation
        {
            Sale = 1,
            Adoption = 2
        }

        public string GetLabel(string define, int id)
        {
            string pross = null;

            if ((!string.IsNullOrEmpty(define) && define != "") && (!string.IsNullOrEmpty(id.ToString())))
            {
                if (define == "Animals")
                {
                    if (id == 1)
                    {
                        pross = "Cachorro";
                    }
                    else if (id == 2)
                    {
                        pross = "Coelho";
                    }
                    else if (id == 3)
                    {
                        pross = "Gato";
                    }
                    else if (id == 4)
                    {
                        pross = "Pássaros";
                    }
                    else if (id == 5)
                    {
                        pross = "Peixe";
                    }
                    else
                    {
                        pross = null;
                    }
                }
                else if(define == "Situation")
                {
                    if (id == 1)
                        pross = "Venda";
                    else if (id == 2)
                        pross = "Adoção";
                    else
                    {
                        pross = null;
                    }
                }
                
                return pross;
            }
            else
            {
                return null;
            }
        }

    }

}
