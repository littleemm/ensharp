package controller;
import javax.swing.*;
import java.awt.*;
import view.MainScreen;

public class SignUpMain {
	private JFrame mainFrame;
	private JPanel mainStartingPanel;
	private MainScreen mainScreen;
	private databaseConnection connection;
	private SignUpButtonListener signUpButtonListener;
	
	public SignUpMain() {
		mainFrame = new JFrame();
		mainStartingPanel = new JPanel();
		mainScreen = new MainScreen();
		connection = new databaseConnection();
		
		signUpButtonListener = new SignUpButtonListener();
	}
	
	public void showSignUp() { // signup 프로그램 처음 시작 화면 
		mainFrame.setPreferredSize(new Dimension(1280, 745));
		mainFrame.setMinimumSize(new Dimension(1280, 745));
		mainFrame.setLayout(null);
		mainFrame.setLocationRelativeTo(null);
		mainFrame.setResizable(false);
		mainFrame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		
		mainScreen.showMainScreen();
		mainScreen.showButtonPanel();
		mainScreen.showLoginTextField();
		
		mainStartingPanel.setSize(new Dimension(1280, 745));
		mainStartingPanel.setLayout(null);
		mainStartingPanel.add(mainScreen.mainPanel);
		mainStartingPanel.add(mainScreen.buttonPanel);
		mainStartingPanel.add(mainScreen.loginPanel);
		
		mainFrame.add(mainStartingPanel);
		mainFrame.repaint();
		mainFrame.revalidate();
		moveToOtherPage(mainStartingPanel);
		mainFrame.setVisible(true);
		
	}
	
	private void moveToOtherPage(JPanel mainStartingPanel) {
		signUpButtonListener.showSignUpPage(mainFrame, mainStartingPanel, mainScreen.signupButton);
	}
	
}
