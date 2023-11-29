using RenatuscapabaseLibrary.TableComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RenatuscapabaseLibrary
{
    public static class ColumnFactory
    {
        public static TableColumn CreateColumn()
        {
            ColumnDataType dataType = (ColumnDataType)ChooseDataType();
            int dataLength = ChooseDataLength();
            string columnName = ChooseColumnName();
            bool isNullable = IsNullable();
            bool isUnique = IsUnique();
            string? content = InputContent();

            if (content == "" && isNullable)
            {
                content = null;
            }
            else if (content == "" &&  dataType == ColumnDataType.Decimal)
            {
                content = "0";
            }

            return new(dataType, dataLength, columnName, isNullable, isUnique, content);
        }

        static int ChooseDataType()
        {
            Console.WriteLine("Choose datatype");
            int maxInt = Enum.GetNames(typeof(ColumnDataType)).Length;

            for (int i = 0; i < maxInt; i++)
            {
                Console.WriteLine($"[{i}] {Enum.GetNames(typeof(ColumnDataType))[i]}");

            }

            int choice = -1;
            while (choice < 0 || choice > maxInt)
            {
                Console.WriteLine("\t");
                choice = Convert.ToInt32(Console.ReadKey().KeyChar.ToString());
                Console.WriteLine();

                if (choice < 0 || choice > maxInt)
                {
                    Console.WriteLine("Please choose a valid datatype.");
                }
            }
            return choice;
        }

        static int ChooseDataLength()
        {
            Console.WriteLine("Please choose length of data.");
            string input = Console.ReadLine() ?? "250";
            return Convert.ToInt32(input);
        }

        static string ChooseColumnName()
        {
            Console.WriteLine("Enter column name. Only alphanumeric characters and underscore allowed.");
            return InputValidation.SanitiseName(Console.ReadLine() ?? "NewColumn");
        }

        static bool IsNullable()
        {
            Console.WriteLine("Is this value nullable? 0/1");
            string input = Console.ReadKey().KeyChar.ToString();
            Console.WriteLine();

            if (input == "1")
            {
                return true;
            }
            else
                return false;
        }

        static bool IsUnique()
        {
            Console.WriteLine("Is this value unique? 0/1");
            string input = Console.ReadKey().KeyChar.ToString();
            Console.WriteLine();
            if (input == "1")
            {
                return true;
            }
            else
                return false;
        }

        static string InputContent()
        {
            Console.WriteLine("Enter column content or null if allowed:");
            string input = Console.ReadLine() ?? "";
            return input;
        }
    }
}
