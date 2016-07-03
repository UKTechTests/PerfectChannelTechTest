using System.Collections.Generic;

namespace Eviivo.Domain
{
    public interface IStringMatch
    {
        IList<int> Match(string text, string subtext);
    }
}