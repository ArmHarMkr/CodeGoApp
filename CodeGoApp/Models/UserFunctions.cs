using CodeGoApp.Areas.Identity.Data;

namespace CodeGoApp.Models;

public class UserFunctions : AppUser
{
    public string GetId () { return Id; }
    public string GetName() { return FirstName + " " + LastName; }
    public string GetEmail(){return Email; }
    public string GetPhoneNumber(){return PhoneNumber;}
    public string[] GetUserLanguages()
    {
        return Languages.Split(",");
    }
}
