package Model;
import java.sql.Connection; 
import java.sql.DriverManager; 
import java.sql.ResultSet; 
import java.sql.SQLException; 
import java.sql.Statement; 
public class LogDAO { 
	static final String JDBC_DRIVER = "com.mysql.jdbc.Driver"; 
	static final String DB_URL = "jdbc:mysql://localhost:3306/databasename?useSSL=false";
	static final String USERNAME = "root"; 
	static final String PASSWORD = "0000";
	
	Connection connection;
	Statement statement;
	
	public LogDAO() {  
		try {
		Class.forName(JDBC_DRIVER); 
		connection = DriverManager.getConnection(DB_URL,USERNAME,PASSWORD);
		} catch(ClassNotFoundException e) {
			
		} catch(SQLException e) {
			
		}
	}
	
	public void InsertLog(LogDTO logDTO) {
		String query = "INSERT INTO log(history, time)Value('{0}', '{1}')";
		try {
			statement.executeUpdate(String.format(query, logDTO.getHistory(), logDTO.getTime()));
		} catch (SQLException e) {
			e.printStackTrace();
		}
	}
	
	public void TruncateLog() {
		String query = "TRUNCATE TABLE log";
		try {
			statement.executeUpdate(query);
		} catch(SQLException e) {
			e.printStackTrace();
		}
	}
	
	public void SelectLog() {
		String query = "SELECT * FROM log";
		try {
			statement.executeUpdate(query);
		} catch(SQLException e) {
			e.printStackTrace();
		}
	}
}
	

