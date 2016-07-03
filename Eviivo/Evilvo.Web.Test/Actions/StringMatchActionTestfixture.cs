using Microsoft.VisualStudio.TestTools.UnitTesting;
using FakeItEasy;
using NLog;
using Eviivo.Domain;
using Eviivo.Web.Actions;
using Eviivo.Web.Models;
using System.Collections.Generic;

namespace Evilvo.Web.Test
{
    [TestClass]
    public class StringMatchActionTestfixture
    {
        [TestMethod]
        public void Ensure_Action_Returns_Oncomplete()
        {
            var logger = A.Fake<ILogger>();
            var stringMatch = A.Fake<IStringMatch>();

            A.CallTo(() => stringMatch.Match(null, null)).WithAnyArguments().Returns(new List<int>() { 1, 2, 3 });

            var action = new StringMatchAction<dynamic>(logger, stringMatch)
            {
                OnComplete = (m) => new { success = true, model = m},
                OnFailed = () => new { success = false }
            }.Execute(new StringMatchViewModel()
            {
                SubText = "test",
                Text = "test test"
            });
            //Assert.IsTrue(action != null);
            //Assert.IsNotNull(action);
            //Assert.IsTrue(action.success);
            //Assert.IsTrue(action.model.Output.Count() == 3);
        }
    }
}
