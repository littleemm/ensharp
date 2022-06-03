package controller;
import javax.swing.*;
import java.awt.*;
import java.awt.event.*;
import view.SignUpScreen;

public class SignUpButtonListener {
	private SignUpScreen signUpScreen;
	private JPanel signUpPanel;
	
	public String statement;
	
	public SignUpButtonListener() {
		signUpScreen = new SignUpScreen();
		signUpPanel = new JPanel();
		statement = "FAIL";
	}
	
	public void showSignUpPage(JFrame mainFrame, JPanel mainStartingPanel, JButton signupButton) { // 실제 회원가입 페이지 
		signupButton.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				changeMainToSignUpPage(mainFrame, mainStartingPanel);
			}
		});
	}
	
	private void changeMainToSignUpPage(JFrame mainFrame, JPanel mainStartingPanel) {
		mainStartingPanel.setVisible(false);
		signUpScreen.showSignUpScreen();
		
		mainFrame.add(signUpScreen.signUpPagePanel);
		mainFrame.repaint();
		mainFrame.revalidate();
		mainFrame.setVisible(true);
	}
	
	
}
