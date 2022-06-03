package controller;
import javax.swing.*;
import java.awt.*;
import view.MainScreen;

public class SignUpMain extends JFrame {
	private JFrame mainFrame;
	private MainScreen mainScreen;
	
	public SignUpMain() {
		mainFrame = new JFrame();
		mainScreen = new MainScreen();
	}
	
	public void showSignUp() {
		mainFrame.setBounds(200, 200, 1000, 800);
		mainFrame.setLayout(null);
		mainFrame.setLocationRelativeTo(null);
		mainFrame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		
		mainScreen.showMainScreen();
		
		mainFrame.add(mainScreen.mainPanel);
		
		mainFrame.setVisible(true);
	}
	
}
