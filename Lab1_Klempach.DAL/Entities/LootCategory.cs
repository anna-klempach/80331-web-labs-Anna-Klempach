﻿using System;
using System.Collections.Generic;
using System.Text;

namespace WebLabs_Klempach.DAL.Entities
{
    public class LootCategory
    {
        public string LootCategoryName { get; set; }
        public int LootCategoryId { get; set; }
        public List<Loot> LootList { get; set; }
    }
}
