using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Dto
{
    public class Statistic
    {
        public DateTime SDate { get; set; }
        public DateTime EDate { get; set; }
        public List<CategoryPercent> Parts { get; set; }
    }

    public class CategoryPercent
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public double Percentage { get; set; }
    }
}
