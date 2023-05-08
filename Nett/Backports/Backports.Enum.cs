using System;

namespace Nett.Backports
{
    internal static partial class Backports
    {
        public static bool HasFlag(this Enum e, Enum flag)
        {
            if (flag == null)
            {
                throw new ArgumentNullException(nameof(flag));
            }

            if (!e.GetType().IsAssignableFrom(flag.GetType()))
            {
                throw new ArgumentException(
                    $"{e.GetType().FullName}: Attempt to check flags with incompatible type {flag.GetType().FullName}", 
                    nameof(flag)
                );
            }

            return e.GetTypeCode() switch
            {
                TypeCode.SByte or TypeCode.Int16 or TypeCode.Int32 or TypeCode.Int64 
                    => (Convert.ToInt64(e) & Convert.ToInt64(flag)) != 0,
                
                TypeCode.Byte or TypeCode.UInt16 or TypeCode.UInt32 or TypeCode.UInt64
                    => (Convert.ToInt64(e) & Convert.ToInt64(flag)) != 0,
                
                _ => throw new Exception($"{e.GetType().FullName}: unsupported enum type code.")
            };
        }
    }
}
