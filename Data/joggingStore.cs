using MagicVilla.Models;

namespace MagicVilla.Data
{
    public static class joggingStore
    {
        public static List<Jogging> joggingList = new List<Jogging>
            {
                new Jogging{ID = new Guid("304a8891-acb3-476a-bc70-b0240a58fc56"),Date = new DateTime(2019,05,09,9,15,0), Distance= 10.5},
                new Jogging{ID = new Guid("44b4f123-82e1-4a15-a143-5bacdda5251d"),Date = new DateTime(2019,06,03,8,12,1), Distance= 12.5}
            };

        public static List<Users> usersList = new List<Users>
        {
            new Users{id = new Guid("304a8891-acb3-476a-bc70-b0240a512345"), Name ="Mahmoud", Role=Roles.Admin,},
            new Users{id = new Guid("304a8891-acb3-476a-bc70-b0240a554321"), Name="Ahmed", Role=Roles.UserManager},
            new Users{id = new Guid("304a8891-acb3-476a-bc70-000000000000"), Name="Mostafa", Role=Roles.User}
        };
    }
}
