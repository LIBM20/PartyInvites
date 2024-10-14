namespace PartyInvites.Models
{
    //NEVER DO THIS !!!!
    //This is only for academic/demonstration purposes
    public class Repository
    {
        private static List<GuestResponse> responses = new List<GuestResponse>();
        
        /*public static IEnumerable<GuestResponse> Responses //Isto é uma propriedade, é equivalente ao get e set do java, posso ter código associado em vez de fazer só return
        {
            get { return responses; }
        }*/

        public static IEnumerable<GuestResponse> Responses => responses; //versão abreviada da propriedade em cima

        public static void AddResponse(GuestResponse response) => responses.Add(response);
    }
}
