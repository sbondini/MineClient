﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataRepository.Models
{
    public class ObjectState
    {
        public int Id { get; set; }
     
        [Column(TypeName = "varchar")]
        [StringLength(20)]
        public string State { get; set; }
    }
}