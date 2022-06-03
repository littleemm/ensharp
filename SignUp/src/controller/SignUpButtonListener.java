package controller;
import javax.swing.*;
import java.awt.*;
import java.awt.event.*;
import view.SignUpScreen;
import view.MainScreen;
public class SignUpButtonListener {
	private SignUpScreen signUpScreen;
	private MainScreen mainScreen;
	
	public SignUpButtonListener(MainScreen mainScreen) {
		mainScreen = this.mainScreen;
		signUpScreen = new SignUpScreen();
	}
	
	public void showSignUpPage(JFrame mainFrame, JPanel mainStartingPanel, JButton signupButton) { // 실제 회원가입 페이지 
		
		signupButton.addActionListener(new ActionListener() { // 메인 페이지에서 signUp 버튼 누를 때 
			public void actionPerformed(ActionEvent e) {
				changeMainToSignUpPage(mainFrame, mainStartingPanel);
			}
		});
		
		signUpScreen.backButton.addActionListener(new ActionListener() { // 회원가입 페이지에서 back 버튼 누를 때 
			public void actionPerformed(ActionEvent e) {
				changeSignUpPageToMain(mainFrame, mainStartingPanel);
			}
		});
	}
	
	private void changeMainToSignUpPage(JFrame mainFrame, JPanel mainStartingPanel) {
		//mainScreen.initializeTextField();
		mainStartingPanel.setVisible(false);
		signUpScreen.showSignUpScreen();
		

		mainFrame.add(signUpScreen.signUpPagePanel);
		mainFrame.repaint();
		mainFrame.revalidate();
		mainFrame.setVisible(true);
	}
	
	private void changeSignUpPageToMain(JFrame mainFrame, JPanel mainStartingPanel) {
		//signUpScreen.initializeTextField();
		signUpScreen.signUpPagePanel.setVisible(false);
	
		
		mainStartingPanel.setVisible(true);
		mainFrame.repaint();
		mainFrame.revalidate();
		mainFrame.setVisible(true);
	}
	
	
}
