﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Model.ViewModels.OrderCommodityViewModels
{
    public class OrderCommodityViewModel
    {
        public int CommodityId { get; set; }
        public int OrderId { get; set; }
        [Display(Name = "Confirmed")]
        public bool IsConfirmeds { get; set; }
        [Display(Name ="Commodity Name")]
        public string CommodityName{get;set;}

        [Required(ErrorMessage = "The Amount field is required.")]
        [Display(Name = "Amount")]
        [Range(1, 999, ErrorMessage = "Amount  range {0} ... {1}")]
        public int Amount { get; set; }
    }

}
