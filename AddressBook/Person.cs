namespace Contacts
{
    internal class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        //zorgen dat in de combobox de naam te zien is
        public override string ToString()
        {
            return LastName + " " + FirstName;
        }
    }
}
