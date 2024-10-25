using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace PartyInvites.Models
{
    public class GuestResponse
    {
        /* Em Java
        public string name;
        public string getName()
        {
            return name;
        }

        public void setName(string name)
        {
            this.name = name;
        }*/

        [Required(ErrorMessage ="Please write your name on the form so we know who you are")]
        //estas validações têm de estar antes
        [StringLength(100, ErrorMessage = "Sorry, your name cannot have more than 100 chars, but please write more than 3 chars", MinimumLength = 3)] //número máximo de caracteres para o campo
        public string Name { get; set; }

        [Required]
        [Phone]
        public string Phone {  get; set; }

        [Required,EmailAddress]
        public string Email { get; set; }
        //pode ser usado um ponto de interrogação a seguir ao bool para caso possa ser Null
        public bool? WillAttend { get; set; }

        public string IsAttending {
            get { 
                switch(WillAttend)
                {
                    case null:
                        return "Maybe";
                    case true:
                        return "Yes";
                    case false:
                        return "No";
                }
            }
        }



    }
}
