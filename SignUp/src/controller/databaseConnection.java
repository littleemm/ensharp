package controller;
import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.PreparedStatement;
import java.sql.ResultSet;

public class databaseConnection {
	private Connection connection;
	private PreparedStatement statement;
	private ResultSet result;
	
	public databaseConnection() {
		try {
			String url = "jdbc:mysql://localhost/younglim_signup?serverTimezone=Asia/Seoul";
			String id = "root";
			String password = "0000";
			Class.forName("com.mysql.cj.jdbc.Driver");
			connection = DriverManager.getConnection(url,id,password);
		}catch (Exception e) {
			e.printStackTrace();
		}
	}
	
	public int login(String userID, String userPassword) {
		String SQL = "SELECT userPassword FROM USER WHERE userID = ?";
		try {
			statement = connection.prepareStatement(SQL);
			statement.setString(1, userID);
			result = statement.executeQuery();
			if(result.next()) {
				if(result.getString(1).contentEquals(userPassword)) {
					return 1;
				}
				else
					return 0;
			}
			return -1;
			
		} catch (Exception e) {
			e.printStackTrace();
		}
		return -2;
	}
	
	
}
