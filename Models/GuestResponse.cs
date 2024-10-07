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

        public string Name { get; set; }
        public string Phone {  get; set; }
        public string Email { get; set; }
        //pode ser usado um ponto de interrogação a seguir ao bool para caso possa ser Null
        public bool WillAttend { get; set; }


        
    }
}
