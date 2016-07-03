using Eviivo.Domain;
using Eviivo.Web.Models;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eviivo.Web.Actions
{
    public class StringMatchAction<T> where T : class
    {
        private ILogger logger;
        private IStringMatch stringMatch;

        public StringMatchAction(ILogger logger, IStringMatch stringMatch)
        {
            this.stringMatch = stringMatch;
            this.logger = logger;
        }

        public Func<StringMatchViewModel, T> OnComplete { get; set; }

        public Func<T> OnFailed { get; set;}

        public T Execute(StringMatchViewModel model)
        {
            try
            {
                var output = stringMatch.Match(model.Text, model.SubText);

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
            catch(Exception ex)
            {
                logger.Log(LogLevel.Fatal, "Error getting substring positions", ex);
                return OnFailed();
            }
        }
    }
}
