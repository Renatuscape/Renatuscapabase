namespace RenatuscapabaseLibrary.TableComponents
{
    public class TableColumn
    {
        public ColumnDataType DataType { get; set; }
        public int DataLength { get; set; }
        public string ColumnName { get; set; }
        public string? Content { get; set; }
        public float NumericContent { get; set; }
        public bool IsNullable { get; set; }
        public bool IsUnique { get; set; }

        public TableColumn(ColumnDataType dataType, int dataLength, string columnName, bool isNullable = false, bool isUnique = false, string? content = null)
        {
            DataType = dataType;
            DataLength = dataLength;
            ColumnName = columnName;
            IsNullable = isNullable;
            IsUnique = isUnique;
            Content = content;

            if (Content == null & IsNullable == false)
            {
                throw new Exception("Content in this column cannot be null.");
            }

            if (DataType == ColumnDataType.Decimal)
            {
                if (float.TryParse(content, out var parsedNumber))
                {
                    NumericContent = parsedNumber;
                }
                else
                {
                    throw new Exception("Parse failed. This column must have a numeric datatype.");
                }
            }
        }

        public override string ToString()
        {
            return $"{ColumnName}: {Content} ({DataType} IS NULLABLE {IsNullable}, IS UNIQUE {IsUnique})";
        }
    }
}
