using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.BusinessModels
{
    class Summary
    {
        public Summary()
        {

        }

        public Summary(decimal discount)
        {
            _discount = discount;
        }

        private decimal _discount = 0;
        public decimal Discount { get { return _discount; } }

        public decimal GetSum(decimal [] val)
        {
            decimal sum = 0;

            foreach(var s in val)
            {
                sum += s;
            }

            DayOfWeek wednesday = DayOfWeek.Wednesday;

            if (_discount != 0 && DateTime.Now.DayOfWeek == wednesday)
            {
                sum = sum * _discount;
            }

            return sum;
        }
    }
}
