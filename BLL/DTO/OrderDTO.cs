using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTO
{
    public class OrderDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Sum { get; set; }

        public DateTime Date { get; set; }
    }
}
