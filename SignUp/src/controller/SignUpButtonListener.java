package controller;
import javax.swing.*;
import java.awt.*;
import java.awt.event.*;

public class SignUpButtonListener {
	
	public SignUpButtonListener() {
		
	}
	
	public void showSignUpPage(JFrame mainFrame, JButton signupButton) { // 실제 회원가입 페이지 
		signupButton.addActionListener(new SignUpButtonListenerInMainPage(mainFrame));
	}
	
	private void moveToSignUpPage() {
		
	}
	
	private class SignUpButtonListenerInMainPage implements ActionListener {
		private SignUpButtonListenerInMainPage(JFrame mainFrame) {
			
		}
		
		public void actionPerformed(ActionEvent e) {
			JButton button = (JButton)e.getSource();
			
		}
	}
	
	
	
}
