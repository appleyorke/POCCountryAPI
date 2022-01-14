using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IRIExcelWEBAPI.Model
{
    [Table("Country", Schema = "dbo")]
    public class Country
    {
        [Key]
        public int CountryId { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
    }
}
