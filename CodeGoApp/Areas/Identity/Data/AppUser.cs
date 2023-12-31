﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace CodeGoApp.Areas.Identity.Data;

// Add profile data for application users by adding properties to the AppUser class
public class AppUser : IdentityUser
{
    [PersonalData]
    public string FirstName { get; set; }   

    [PersonalData]
    public string LastName { get; set; }

    public string Languages { get; set; } 
    public DateTime UserCreatedTime { get; set; } = DateTime.Now;

}

