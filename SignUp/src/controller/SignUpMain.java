package controller;
import javax.swing.JFrame;
import javax.swing.JLabel;
import view.*;

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
		mainFrame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		
		mainScreen.showMainScreen();

		
		mainFrame.add(mainScreen.mainPanel);
		mainFrame.setVisible(true);
	}
	
}
