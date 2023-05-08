using System.Text;

namespace Nett.Backports
{
    internal static partial class Backports
    {
        public static StringBuilder Clear(this StringBuilder sb)
        {
            sb.Length = 0;
            return sb;
        }
    }
}
