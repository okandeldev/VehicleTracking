
using System.Text;

namespace Core.Shared
{
    public static class StringExtention
    {
        public static string ToSnakeCase(this string str)
        {

            if (str == null)
            {
                throw new ArgumentNullException(nameof(str));
            }
            if (str.Length < 2)
            {
                return str;
            }
            var sb = new StringBuilder();
            sb.Append(char.ToLowerInvariant(str[0]));
            for (int i = 1; i < str.Length; ++i)
            {
                char c = str[i];
                if (char.IsUpper(c) && !char.IsUpper(str[i + 1]))
                {
                    sb.Append('_');
                    sb.Append(char.ToLowerInvariant(c));
                }
                else
                {
                    sb.Append(c);
                }
            }
            return sb.ToString().ToLower();
        }

        public static string ToCamelCase(this string str)
        {
            if (str == null)
            {
                throw new ArgumentNullException(nameof(str));
            }
            if (str.Length < 2)
            {
                return str;
            }

            return Char.ToLowerInvariant(str[0]) + str.Substring(1);



        }

    }
}
