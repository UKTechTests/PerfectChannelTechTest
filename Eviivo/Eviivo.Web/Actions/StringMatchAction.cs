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
        Func<StringMatchViewModel, T> OnComplete { get; set; }

        Func<T> OnFailed { get; set;}

        public T Execute(StringMatchViewModel model)
        {
            return OnComplete(new StringMatchViewModel());
        }
    }
}
