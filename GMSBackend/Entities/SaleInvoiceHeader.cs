﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GMSBackend.Entities
{
    public class SaleInvoiceHeader
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ID { get; set; }

        public DateTime InvDate { get; set; }

        public long AccountID { get; set; }

        public long? VisitorID { get; set; }

        public short InvType { get; set; }

        public double? Price { get; set; }

        public double? Reduction { get; set; }

        public string Memo { get; set; }    

        public DateTime CreateDate { get; set; }

        public bool IsDeleted { get; set; }
    }
}
