﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeIngredientSystem.Entities
{
    public class Admin
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string NewPassword { get; set; }
        public string SecurityQuestion { get; set; }
        public string SecurityAnswer { get; set; }
    }
}
