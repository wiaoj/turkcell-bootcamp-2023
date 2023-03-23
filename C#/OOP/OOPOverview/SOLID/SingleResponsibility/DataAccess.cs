using System.Data.SqlClient;

namespace SingleResponsibility;
public class DataAccess {
    private readonly SqlConnection sqlConnection = default!;

    public DataAccess(String connectionString) {
        this.sqlConnection = new(connectionString);
    }

    public Int32 ExecuteNonQuery(String commandText, Dictionary<String, Object> parameters) {
        SqlCommand sqlCommand = this.createCommand(commandText, parameters);
        sqlCommand.Connection.Open();
        Int32 rowsAffected = sqlCommand.ExecuteNonQuery();
        sqlCommand.Connection.Close();
        return rowsAffected;

    }

    private SqlCommand createCommand(String commandText, Dictionary<String, Object> parameters) {
        SqlCommand sqlCommand = this.sqlConnection.CreateCommand();
        sqlCommand.CommandText = commandText;
        this.addParametersToCommand(sqlCommand, parameters);
        return sqlCommand;
    }

    private void addParametersToCommand(SqlCommand sqlCommand, Dictionary<String, Object> parameters) {
        foreach(KeyValuePair<String, Object> parameter in parameters) {
            parameters.Add(parameter.Key, parameter.Value);
        }
    }
}