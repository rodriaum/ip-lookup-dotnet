/*
 * MIT License
 * 
 * This software is provided under the MIT License, a permissive license that allows for the use, copying, modification, 
 * merging, publishing, distribution, sublicensing, and sale of copies of the software, as long as the original 
 * permission and disclaimer are included in all copies or substantial portions of the software.
 * 
 * For more details about the MIT License and its terms, please refer to:
 * https://github.com/rodriaum/IP-Address-Lookup?tab=MIT-1-ov-file#readme
 * 
 * This project is an IP address lookup system developed in C#.
 * 
 * Copyright (c) 2024 Rodrigo Ferreira
 */

using IP_Address_Lookup.src.Objects;
using ProxyCheck.Objects;
using System.Reflection;

namespace ProxyCheck.Util
{
    public class Utils
    {

        public static DialogResult MessageBox(string message, string extra = "")
        {
            return System.Windows.Forms.MessageBox.Show((message + (!string.IsNullOrEmpty(extra) && Constant.DebugMode ? $"\n\n{extra}" : "")), (Constant.DebugMode ? "Debug" : "Ops"));
        }
        public static StatusResult? GetStatusByName(string name)
        {
            foreach (StatusResult status in Enum.GetValues(typeof(StatusResult)))
            {
                if (status.ToString().ToLower() == name)
                {
                    return status;
                }
            }

            return null;
        }

        public static Dictionary<string, object?> GetProperties(object obj)
        {
            var dictionary = new Dictionary<string, object?>();

            try
            {
                var type = obj.GetType();
                PropertyInfo[] properties = type.GetProperties();

                foreach (var property in properties)
                {
                    var value = property.GetValue(obj);
                    if (value != null && IsComplexType(property.PropertyType))
                    {
                        dictionary[property.Name] = GetProperties(value);
                    }
                    else
                    {
                        dictionary[property.Name] = value;
                    }
                }
            }
            catch (Exception) { }

            return dictionary;
        }

        public static List<string> FormatProperties(Dictionary<string, object?> properties, int indentLevel = 0, bool isSubClass = false)
        {
            List<string> list = new List<string>();
            string indent = new string(' ', indentLevel * 4);

            foreach (var property in properties)
            {
                if (property.Value is Dictionary<string, object?> subProperties)
                {
                    list.Add($"{indent}{property.Key}:");
                    list.AddRange(FormatProperties(subProperties, indentLevel + 1, true));
                }
                else
                {
                    string prefix = isSubClass ? "- " : "";
                    list.Add($"{indent}{prefix}{property.Key}: {property.Value}");
                }
            }

            return list;
        }

        public static bool IsComplexType(Type type)
        {
            return type.IsClass && type != typeof(string);
        }
    }
}