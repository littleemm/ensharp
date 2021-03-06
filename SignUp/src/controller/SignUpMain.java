package controller;
import javax.swing.*;
import java.awt.*;
import view.MainScreen;
import model.MemberDTO;
public class SignUpMain {
	private JFrame mainFrame;
	private MainScreen mainScreen;
	private DatabaseConnection connection;
	private SignUpAdministrator signUpAdministrator;
	private LoginAdministrator loginAdministrator;
	private MemberDTO memberDTO;
	
	public SignUpMain() {
		mainFrame = new JFrame();
		mainScreen = new MainScreen();
		connection = new DatabaseConnection(memberDTO);
		
		memberDTO = new MemberDTO("", "", "", "", "", "", "", "", "");
		signUpAdministrator = new SignUpAdministrator(mainScreen, memberDTO, connection);
		loginAdministrator = new LoginAdministrator(mainScreen, memberDTO, connection);
	}
	
	public void showSignUp() { // signup 프로그램 처음 시작 화면 
		mainFrame.setPreferredSize(new Dimension(1280, 745));
		mainFrame.setMinimumSize(new Dimension(1280, 745));
		mainFrame.setLayout(null);
		mainFrame.setLocationRelativeTo(null);
		mainFrame.setResizable(false);
		mainFrame.setTitle("EN#WATCH");
		mainFrame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		
		mainScreen.showMainScreen();
		
		mainFrame.add(mainScreen.mainStartingPanel);
		mainFrame.repaint();
		mainFrame.revalidate();
		moveToOtherPage(mainScreen.mainStartingPanel);
		mainFrame.setVisible(true);
		
	}
	
	private void moveToOtherPage(JPanel mainStartingPanel) {
		signUpAdministrator.showSignUpPage(mainFrame, mainStartingPanel, mainScreen.signupButton);
		loginAdministrator.showLoginPage(mainFrame, mainStartingPanel, mainScreen.loginButton);
		
	}
	
}
