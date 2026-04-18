using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_task.Models
{
    internal class Order
    {
        public int Id { get; set; }
        public String Address { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
