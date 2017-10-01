using System.IO;
using System.Linq;
using System.Globalization;
using System.Data.SqlClient;

namespace NameGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            var lines = File.ReadLines("Words.txt").ToArray();
            var strings = File.ReadLines("Words.txt").ToArray();
            var rows = File.ReadLines("Names.txt").ToArray();
            var items = File.ReadLines("Names.txt").ToArray();

            for (var i = 0; i < lines.Length; i++)
            {
                var suffix = string.Empty;

                if (i % 3 == 0)  { suffix = "Ltd."; } else
                if (i % 5 == 0)  { suffix = "Inc."; } else
                if (i % 7 == 0)  { suffix = "Gmbh."; } else
                if (i % 11 == 0) { suffix = "Group"; }

                lines[i] = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(lines[i].ToLower());
                lines[i] = $"{lines[i]} {lines[lines.Length - i - 1]} {suffix}";
            }

            for (var i = 0; i < lines.Length; i++)
            {
                var suffix = string.Empty;

                if (i % 3 == 0) { suffix = "Inc."; } else
                if (i % 5 == 0) { suffix = "Ltd."; } else
                if (i % 7 == 0) { suffix = "Group"; } else
                if (i % 11 == 0) { suffix = "Gmbh."; }
                
                strings[i] = $"{strings[strings.Length - i - 1]} {strings[i]} {suffix}";
                strings[i] = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(strings[i].ToLower());
            }

            for (var i = 0; i < rows.Length; i++)
            {
                var suffix = string.Empty;

                if (i % 3 == 0) { suffix = "Limited"; } else
                if (i % 5 == 0) { suffix = "Corp."; } else
                if (i % 7 == 0) { suffix = "HQ"; } else
                if (i % 11 == 0) { suffix = "Unlimited"; }

                rows[i] = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(rows[i].ToLower());
                rows[i] = $"{rows[i]} {rows[rows.Length - i - 1]} {suffix}";
            }

            var res = lines.Concat(strings).Concat(rows).ToArray();

            var connection = new SqlConnection("Server=huron;Database=TEK.Core.Big;Integrated Security=false;uid=sa;password=stalker45");
            var sqlCommand = new SqlCommand { Connection = connection };

            connection.Open();

            foreach(var item in res)
            {
                var newItem = item.Replace("'", " ");

                sqlCommand.CommandText = $"insert into Companies (Name) values ('{newItem}')";
                try
                {
                    sqlCommand.ExecuteNonQuery();
                }
                catch
                {
                    continue;
                }
            }

            connection.Close();

            return;
        }
    }
}