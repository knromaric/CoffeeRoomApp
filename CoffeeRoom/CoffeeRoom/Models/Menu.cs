﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeRoom.Models
{
    public class Menu
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public List<SubMenu> SubMenus { get; set; }
    }
}
