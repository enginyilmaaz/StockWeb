﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Stock.Web.Models.Category
{
    public class CreateCategoryViewModel
    {
        [Required]
        [DisplayName("Kategori Adı")]
        public string CategoryName { get; set; }
    }
}