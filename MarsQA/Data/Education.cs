using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsQA.Data
{
    public class Education
    {
        public string instituteName {  get; set; } = String.Empty;
        public string country { get; set; } = String.Empty;

        public String title { get; set; } = String.Empty;
        public string degree { get; set; } = String.Empty ;
        public String yearOfGraduation { get; set; } = String.Empty;
    }
}
