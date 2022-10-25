using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Entities.UserEntity
{
    public class UserApp:IdentityUser
    {
        public Enums.User.Gender Gender  { get; set; }
    }
}
