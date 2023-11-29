namespace RenatuscapabaseLibrary.TableComponents
{
    public class TableColumn
    {
        public ColumnDataType DataType { get; set; }
        public int DataLength { get; set; }
        public string ColumnName { get; set; }
        public string? DefaultContent { get; set; }
        public decimal NumericContent { get; set; }
        public bool IsNullable { get; set; }
        public bool IsUnique { get; set; }

        public TableColumn(ColumnDataType dataType, int dataLength, string columnName, bool isNullable = false, bool isUnique = false, string? defaultContent = null)
        {
            DataType = dataType;
            DataLength = dataLength;
            ColumnName = columnName;
            IsNullable = isNullable;
            IsUnique = isUnique;
            DefaultContent = defaultContent;

            if (DefaultContent == null & IsNullable == false)
            {
                throw new Exception("Content in this column cannot be null.");
            }

            if (!string.IsNullOrWhiteSpace(DefaultContent))
            {
                if (DataType == ColumnDataType.Decimal)
                {
                    if (decimal.TryParse(defaultContent, out var parsedNumber))
                    {
                        NumericContent = parsedNumber;
                    }
                    else
                    {
                        throw new Exception("Parse failed. This column must have a numeric datatype.");
                    }
                }
            }
            else
            {
                defaultContent = null;
            }

        }

        public override string ToString()
        {
            return $"{ColumnName}: {DataType} IS NULLABLE {IsNullable}, IS UNIQUE {IsUnique}), {DefaultContent}";
        }
    }
}
