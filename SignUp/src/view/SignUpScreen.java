package view;
import javax.swing.*;
import java.awt.*;
import javax.swing.border.*;

public class SignUpScreen extends BasicScreen {
	public Panel signupPanel;
	public JPanel buttonPanel;
	
	private Image background;
	private JButton backButton;
	private JButton signupButton;
	private JTextField idField;
	private JTextField passwordField;
	private JTextField passwordConfirmField;
	private JTextField birthField;
	private JTextField emailFrontField;
	private JTextField emailBackField;
	private JTextField numberField;
	private JTextField detailAddressField;
	
	public SignUpScreen() {
		signupPanel = new Panel();
		background = new ImageIcon(MainScreen.class.getResource("../image/signupPage.png")).getImage();
		
		backButton = new JButton(new ImageIcon(MainScreen.class.getResource("../image/backButton.png")));
		signupButton = new JButton(new ImageIcon(MainScreen.class.getResource("../image/signupButton.png")));
	}
	
	public void showSignUpScreen() {
		signupPanel.setLayout(null);
		signupPanel.setSize(1250, 700);
		signupPanel.setVisible(true);
	}
	
	public void showButtonPanel() { // 버튼 패널 생성 (메인 패널에 버튼을 집어넣으면 안보임) 
		buttonPanel.setSize(1250, 700); 
		buttonPanel.setLocation(0,0);
		buttonPanel.setBackground(new Color(255, 0,0,0));
		buttonPanel.setLayout(null);
		
		signupButton.setSize(200, 53);
		signupButton.setLocation(597, 476);
		
		backButton.setSize(200, 50);
		backButton.setLocation(817, 542);
		
		paintButton(backButton);
		paintButton(signupButton);
		
		buttonPanel.add(backButton);
		buttonPanel.add(signupButton);
		buttonPanel.setVisible(true);
	}
	
	public void showLoginTextField() {
	
	}
	
	private class Panel extends JPanel { // 패널에 배경 그려주는 클래스 
		public void paint(Graphics g) { 
			//super.paint(g);
			g.drawImage(background, 0, 0, null);		
		}
	}
}
