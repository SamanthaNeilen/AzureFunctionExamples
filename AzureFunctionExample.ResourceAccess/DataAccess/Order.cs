﻿using System.ComponentModel.DataAnnotations;

namespace AzureFunctionExample.ResourceAccess.DataAccess
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        public int PersonID { get; set; }
        
        public string OrderNumber { get; set; }

        public int Status { get; set; }

        public virtual Person Person { get; set; }
    }
}
