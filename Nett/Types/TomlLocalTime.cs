using System;
using System.Globalization;
using System.Text;

namespace Nett
{
    public sealed class TomlLocalTime : TomlValue<TimeSpan>
    {
        internal TomlLocalTime(ITomlRoot root, TimeSpan value)
            : base(root, value)
        {
        }

        public override string ReadableTypeName
            => "Local Time";

        public override TomlObjectType TomlType
            => TomlObjectType.LocalTime;

        public override void Visit(ITomlObjectVisitor visitor)
            => visitor.Visit(this);

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append(Value.Hours.ToString("D2"));
            sb.Append(":");
            sb.Append(Value.Minutes.ToString("D2"));
            sb.Append(":");
            sb.Append(Value.Seconds.ToString("D2"));

            if (Value.Milliseconds != 0)
            {
                sb.Append(".");
                sb.Append(Value.Milliseconds.ToString("D7"));
            }

            return sb.ToString();
        }

        internal static TomlValue Parse(ITomlRoot root, string value)
        {
            return new TomlLocalTime(root, TimeSpan.Parse(value));
        }

        internal override TomlObject CloneFor(ITomlRoot root)
            => new TomlLocalTime(root, this.Value);
    }
}
