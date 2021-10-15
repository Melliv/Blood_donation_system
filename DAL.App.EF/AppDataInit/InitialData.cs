using System;

namespace DAL.App.EF.AppDataInit
{
    public static class InitialData
    {
        public static readonly (string roleName, string displayName)[] Roles =
        {
            ("Admin", "Administrators"),
            ("User", "User"),
        };

        public static readonly (string name, string password, string firstName, string lastName, DateTime DOB, string[] roles)[] Users =
        {
            ("admin@bloody.ee", "Foo.bar1", "Admin", "Bloody", DateTime.Parse("2000-01-01"), new []{"admin"}),
            ("user@bloody.ee", "Foo.bar1", "User", "Bloody", DateTime.Parse("2000-01-01"), new string[0]),
        };
        
        public static readonly (string firstName, string lastName, string identificationCode, string comments)[] Persons =
        {
            ("Laine", "Kuusk", "15413523647", "test1"),
            ("Andrus", "Pael", "6574584583", "test2"),
            ("Jüri", "Paat", "3856735735756", "test3"),
            ("Jüri", "Praam", "5674584867956", "test4"),
            ("Jüri", "Sukk", "4634758468746", "test5"),
            ("Jaanus", "Põder", "67856957807347", "test6"),
            ("Karl", "Saabas", "35469469835", "test7"),
            ("Juku", "Orav", "9464237358", "test8"),
            ("Margit", "Kala", "6494637576", "test9"),
            ("Anni", "Koobas", "568495638946", "test10")
        };
        
        public static readonly (string[] personTypeValue, string[] secondaryPersonTypeValue, string[] culture)[] PersonTypes =
        {
            (new [] {"Patient", "Patsient"}, new [] {"Customer", "Klient"} , new [] {"en-US", "et"}),
            (new [] {"Doctor", "Doktor"}, new [] {"Worker", "Töötaja"} , new [] {"en-US", "et"})
        };

        public static readonly string[] BloodGroups = {"0-", "0+", "A-", "A+", "B-", "B+", "AB-", "AB+"};
        
        public static readonly (string[] contactTypeValue, string[] culture)[] ContactTypes =
        {
            (new [] {"Email", "Email"}, new [] {"et", "en-US",}),
            (new [] {"Skype", "Skype" }, new [] {"et", "en-US",}),
            (new [] {"Telefon", "Phone"}, new [] {"et", "en-US",})
        };

    }
    
}