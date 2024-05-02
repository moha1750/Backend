using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BackendTeamwork.Entities
{
    public class Payment
    {

        public Guid Id { get; set; }
        [Required]
        public int Amount { get; set; }
        public string? Method { get; set; }
        public DateTime Date { get; set; }
        public Guid UserId { get; set; }
    }

}