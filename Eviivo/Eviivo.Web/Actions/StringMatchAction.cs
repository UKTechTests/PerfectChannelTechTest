using Eviivo.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eviivo.Web.Actions
{
    class StringMatchAction<T> where T : class
    {
        public Func<StringMatchViewModel, T> OnComplete { get; set; }

        public Func<T> OnFailed { get; set;}

        public T Execute(StringMatchViewModel model)
        {
            var output = new Domain.Class1().Match(model.Text, model.SubText);

            if (output.Any())
            {
                model.Output = output;
            }
            else
            {
                model.ErrorMessage = "Some error";
            }
            return OnComplete(model);
        }
    }
}
