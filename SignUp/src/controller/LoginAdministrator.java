package controller;

import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;

import javax.swing.JButton;
import javax.swing.JFrame;
import javax.swing.JPanel;

import model.MemberDTO;
import view.MainScreen;
import view.SignUpScreen;

public class LoginAdministrator {
	private MainScreen mainScreen;
	private MemberDTO memberDTO;
	private DatabaseConnection connection;
	
	public LoginAdministrator(MainScreen mainScreen, MemberDTO memberDTO, DatabaseConnection connection) {
		this.mainScreen = mainScreen;
		this.memberDTO = memberDTO;
		this.connection = connection;
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
			changeMainToLoginPage(mainFrame, mainStartingPanel);
		}
		
		else {
			mainScreen.popFrame("아이디 또는 비밀번호를 다시 입력하세요! ");
		}
		
	}
	
	private void changeMainToLoginPage(JFrame mainFrame, JPanel mainStartingPanel) {
		mainScreen.initializeTextField();
		mainStartingPanel.setVisible(false);
		
		mainFrame.repaint();
		mainFrame.revalidate();
		mainFrame.setVisible(true);
	}
	
	
}
