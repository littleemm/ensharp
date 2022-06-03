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
		mainFrame.setPreferredSize(new Dimension(1250, 700));
		mainFrame.setMinimumSize(new Dimension(1250, 700));
		mainFrame.setLayout(null);
		mainFrame.setLocationRelativeTo(null);
		mainFrame.setResizable(false);
		mainFrame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		
		mainScreen.showMainScreen();
		mainScreen.showButtonPanel();
		mainScreen.showLoginTextField();
		
		mainFrame.add(mainScreen.mainPanel);
		mainFrame.add(mainScreen.buttonPanel);
		mainFrame.add(mainScreen.loginPanel);
		
		mainFrame.repaint();
		mainFrame.revalidate();
		mainFrame.setVisible(true);
	}
	
}
