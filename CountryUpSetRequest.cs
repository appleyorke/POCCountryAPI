using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IRIExcelWEBAPI.Model
{
    public class CountryUpSetRequest
    {
        public int CountryId { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
    }


}
