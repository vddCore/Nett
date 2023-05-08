using System.Collections.Generic;

namespace Nett.Collections
{
    internal interface IGetChildren<T>
    {
        IEnumerable<T> GetChildren();
    }
}
