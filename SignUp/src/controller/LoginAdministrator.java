package controller;

import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;

import javax.swing.JButton;
import javax.swing.JFrame;
import javax.swing.JPanel;

import model.MemberDTO;
import view.MainScreen;
import view.SignUpScreen;
import view.LoginedScreen;

public class LoginAdministrator {
	private MainScreen mainScreen;
	private LoginedScreen loginedScreen;
	private MemberDTO memberDTO;
	private DatabaseConnection connection;
	
	public LoginAdministrator(MainScreen mainScreen, MemberDTO memberDTO, DatabaseConnection connection) {
		this.mainScreen = mainScreen;
		this.memberDTO = memberDTO;
		this.connection = connection;
		
		loginedScreen = new LoginedScreen();
	}
	
	public void showLoginPage(JFrame mainFrame, JPanel mainStartingPanel, JButton loginButton) { // 실제 회원가입 페이지 
		loginButton.addActionListener(new ActionListener() { // 메인 페이지에서 signUp 버튼 누를 때 
			public void actionPerformed(ActionEvent e) {
				checkSuccessLogin(mainFrame, mainStartingPanel);
			}
		});
		
	}
	
	private String convertPasswordToString() { // password 값 받아오기 
		String password = "";
		char[] secret = mainScreen.passwordField.getPassword(); 

		for(char sign : secret){         
	         Character.toString(sign);   
	         password += (password.equals("")) ? ""+sign+"" : ""+sign+"";   
		}
		
		return password;
	}
	
	private void checkSuccessLogin(JFrame mainFrame, JPanel mainStartingPanel) {
		if(connection.isSuccessLogin(mainScreen.idField.getText(), convertPasswordToString())) {
			String name = connection.printName(mainScreen.idField.getText());
			changeMainToLoginPage(mainFrame, mainStartingPanel, name);
			loginedScreen.showLoginScreen(name);
		}
		
		else {
			mainScreen.popFrame("아이디 또는 비밀번호를 다시 입력하세요! ");
		}
		
	}
	
	private void changeMainToLoginPage(JFrame mainFrame, JPanel mainStartingPanel, String name) {
		mainScreen.initializeTextField();
		mainStartingPanel.setVisible(false);
		loginedScreen.showLoginScreen(name);
		
		mainFrame.add(loginedScreen.loginPagePanel);
		mainFrame.repaint();
		mainFrame.revalidate();
		mainFrame.setVisible(true);
	}
	
	
}
