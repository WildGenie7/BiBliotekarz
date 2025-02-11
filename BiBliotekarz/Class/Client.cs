namespace BiBliotekarz.Class
{
    public class Client
    {
        public int ClientID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PESEL { get; set; }
        public string TelephoneNumber { get; set; }
        public string HomeAddress { get; set; }

        public Client(string name, string surname, string pesel, string telephoneNumber, string homeAddress)
        {
            Name = name;
            Surname = surname;
            PESEL = pesel;
            TelephoneNumber = telephoneNumber;
            HomeAddress = homeAddress;
        }
        public Client(int clientID, string name, string surname, string pesel, string telephoneNumber, string homeAddress)
        {
            ClientID = clientID;
            Name = name;
            Surname = surname;
            PESEL = pesel;
            TelephoneNumber = telephoneNumber;
            HomeAddress = homeAddress;
        }
    }
}
