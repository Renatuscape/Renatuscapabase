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
            bool isNullable = true;
            bool isUnique = true;
            string? content = null;

            return new(dataType, dataLength, columnName, isNullable, isUnique, content);
        }

        static int ChooseDataType()
        {
            Console.WriteLine("Choose datatype");
            int maxInt = Enum.GetNames(typeof(ColumnDataType)).Length;

            for (int i = 0; i < maxInt; i++)
            {
                Console.WriteLine($"{Enum.GetNames(typeof(ColumnDataType))[i]}");
                
            }

            int choice = -1;
            while (choice < 0 || choice > maxInt)
            {
                Console.WriteLine("\t");
                choice = Convert.ToInt32(Console.ReadKey().KeyChar.ToString());
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
    }
}
