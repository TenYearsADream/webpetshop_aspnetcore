/*--------------------------------------
 * Project.......: WebPetShop
 * Author........: Ronaldo Torre
 * Date..........: Oct/2018
 * --------------------------------------
 */
namespace WebPetShop.Models.People
{
    public class PersonType
    {
        public enum Address
        {
            Comercial = 0,
            Residencial = 1,
            Entrega = 2,
            Outros = 3
        }

        public enum Contact
        {
            phone = 0,
            cell = 1,
            mail = 2,
            skype = 3,
            whatsapp= 4
        }

        public enum Gender
        {
            female = 0,
            male = 1
        }

        public enum Type
        {
            physical = 0,
            juridical = 1
        }

        public string GetLabel(string define, int id)
        {
            string pross = null;

            if ((!string.IsNullOrEmpty(define) && define != "") &&(!string.IsNullOrEmpty(id.ToString())))
            {
                if (define == "Type")
                {
                    if (id == 0)
                    {
                        pross = "F";
                    }
                    else if (id == 1)
                    {
                        pross = "J";
                    }
                    else
                    {
                        pross = null;
                    }
                }
                else if (define == "Gender")
                {
                    if (id == 0)
                    {
                        pross = "Feminino";
                    }
                    else if (id == 1)
                    {
                        pross = "Masculino";
                    }
                    else
                    {
                        pross = null;
                    }
                }
                else if(define == "Contact")
                {
                    if(id == 0)
                    {
                        pross = "Telefone";
                    }
                    else if (id == 1)
                    {
                        pross = "E-mail";
                    }
                    else if (id == 2)
                    {
                        pross = "Skype";
                    }
                    else if (id == 3)
                    {
                        pross = "Whatsapp";
                    }
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