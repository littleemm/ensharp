package controller;
import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.PreparedStatement;
import java.sql.Statement;
import java.sql.ResultSet;
import java.sql.SQLException;
import model.MemberDTO;
import utility.Constant;

public class DatabaseConnection {
	private Connection connection;
	private Statement statement;
	private ResultSet result;
	private MemberDTO memberDTO;
	
	public DatabaseConnection(MemberDTO memberDTO) {
		this.memberDTO = memberDTO;
		
		try {
			String url = "jdbc:mysql://localhost/younglim_signup?serverTimezone=Asia/Seoul";
			String id = "root";
			String password = "0000";
			Class.forName("com.mysql.cj.jdbc.Driver");
			connection = DriverManager.getConnection(url,id,password);
			statement = connection.createStatement();
		}catch (Exception e) {
			e.printStackTrace();
		}
	}
	
	public void succeedSignUp(MemberDTO memberDTO) {
		String query = String.format(Constant.INSERT_QUERY, memberDTO.getName(), memberDTO.getId(), 
				memberDTO.getPassword(), memberDTO.getBirth(), memberDTO.getEmail(), memberDTO.getPhoneNumber(), 
				memberDTO.getZipCode(), memberDTO.getAddress(), memberDTO.getDetailAddress());
		System.out.println(query);
		
		try {
			statement.executeUpdate(query);
		} catch (SQLException e) {
			e.printStackTrace();
		}
	
	}
	
	
	public Boolean isSuccessLogin(String id, String password) {
		String query = String.format(Constant.SELECT_PASSWORD_QUERY, id);
		
		try {
			result = statement.executeQuery(query);
			
			while(result.next()) {
				if(password.equals(result.getString("password"))) {
					return true;
				}
				
				else {
					return false;
				}
			}
		} catch(Exception e) {
			return false;
		}
		
		return false;
	}
	
	
}
