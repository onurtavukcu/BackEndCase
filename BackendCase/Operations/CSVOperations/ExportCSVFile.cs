using System.Data;
using System.Text;

namespace BackendCase.Operations.CSVOperations
{
    public class ExportCSV<T> where T : class
    {
        private List<T> _list;
        private string _columnName;
        private string _parameter;

        public ExportCSV(List<T> list, string columnName = "", string parameter = "")
        {
            _list = list;
            _parameter = parameter;
            _columnName = columnName;
        }

        public byte[] ExportToCSV()
        {
            DataTable dataTable = ListToDataTable(_list, _columnName, _parameter);
            //Firstly we have to need to convert list to data table.

            string csvContent = DataTableToCSV(dataTable);
            //After that we create string with data. Data format type is CSV

            byte[] csvBytes = Encoding.UTF8.GetBytes(csvContent);
            // And we returned byte list because, CSV file also a text format we convert to CSV file in controller.

            return csvBytes;
        }
        private DataTable ListToDataTable(List<T> list, string columnName, string parameters)
        {
            DataTable table = new DataTable(typeof(T).Name);

            var properties = typeof(T).GetProperties();

            foreach (var property in properties)
            {
                table.Columns.Add(property.Name, property.PropertyType);
                //Firstly we get and add a columns.
            }

            foreach (var item in list)
            {
                var values = new object[properties.Length];
                for (int i = 0; i < properties.Length; i++)
                {
                    //We add a data row. But In case nned to be a manipulate row cell. We check column data and transform.
                    if (properties[i].Name == "gender")
                    {
                        string gender = (string)properties[i].GetValue(item);
                        string nationality = (string)typeof(T).GetProperty("nationality").GetValue(item);
                        values[i] = TransformGender(gender, nationality);
                    }
                    else
                    {
                        values[i] = properties[i].GetValue(item);
                    }
                }

                table.Rows.Add(values);
            }
            if (parameters != "")
            {
                // In cass needs to be a filtering data. For example nationality = "TUR"
                // or any other column and value
                return ListToDataTableWithFiltering(table, columnName, parameters);
            }
            return table;
        }

        private DataTable ListToDataTableWithFiltering(DataTable dataTable, string columnName, string parameters)
        {
            DataTable filteredTable = dataTable.Clone();

            foreach (DataRow row in dataTable.Rows)
            {
                if (row[columnName].ToString() == parameters)
                {
                    filteredTable.ImportRow(row);
                }
            }
            //if (filteredTable.Rows[1] == null)
            //{
            //    throw new ArgumentException("No Row Value Found!");
            //}

            return filteredTable;
        }

        private string DataTableToCSV(DataTable dataTable)
        {
            StringBuilder builder = new StringBuilder();

            foreach (DataColumn column in dataTable.Columns)
            {
                builder.Append(column.ColumnName);
                builder.Append(",");
            }
            builder.AppendLine();

            foreach (DataRow row in dataTable.Rows)
            {
                foreach (object item in row.ItemArray)
                {
                    builder.Append(item.ToString());
                    builder.Append(",");
                }
                builder.AppendLine();
            }

            return builder.ToString();
        }

        private string TransformGender(string gender, string nationality)
        {
            if (nationality == "TUR")
            {
                return gender == "Male" ? "Erkek" : gender == "Female" ? "Kadın" : gender;
            }
            else
            {
                return gender;
            }
        }
    }
}
