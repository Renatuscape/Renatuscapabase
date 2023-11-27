namespace RenatuscapabaseLibrary
{
    public class TableColumn
    {
        public ColumnDataType DataType { get; set; }
        public string ColumnName { get; set; }
        public string? Content { get; set; }
        public float NumericContent { get; set; }
        public bool IsNullable { get; set; }
        public bool IsUnique { get; set; }

        public TableColumn(ColumnDataType dataType, string columnName, bool isNullable, bool isUnique, string? content)
        {
            DataType = dataType;
            ColumnName = columnName;
            IsNullable = isNullable;
            IsUnique = isUnique;
            Content = content;

            if (Content == null & IsNullable == false)
            {
                throw new Exception("Content in this column cannot be null.");
            }

            if (DataType == ColumnDataType.Int || DataType == ColumnDataType.Float || DataType == ColumnDataType.Decimal)
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
    }
}
