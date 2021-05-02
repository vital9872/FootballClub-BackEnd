using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FCManagement_BackEnd.Dto.User
{
    public class EditUserDto : ControllerBase
    {
        public string PrevUserName { get; set; }
        public string UserName { get; set; }
        public string Role { get; set; }
    }
}
