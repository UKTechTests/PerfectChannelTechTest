using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eviivo.Web.Models
{
    public class StringMatchViewModel
    {
        [Display(Name = "Text")]
        [DataType(DataType.Text)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "You need to enter some text.")]
        public string Text { get; set; }

        [Display(Name = "Subtext")]
        [DataType(DataType.Text)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "You need to enter some text.")]
        public string SubText { get; set; }
    }
}
