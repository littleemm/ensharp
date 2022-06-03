package view;
import javax.swing.*;
import javax.swing.border.*;
import java.awt.*;


public class MainScreen {
	public Panel mainPanel = new Panel();
	public JPanel buttonPanel = new JPanel();
	public JPanel loginPanel = new JPanel();
	private Image background;
	public JButton loginButton;
	public JButton signupButton;
	public JButton idFindingButton;
	public JButton passwordFindingButton;
	public JTextField idField;
	public JPasswordField passwordField;
	
	public MainScreen() {
		mainPanel = new Panel();
		buttonPanel = new JPanel();
		loginPanel = new JPanel();
		background = new ImageIcon(MainScreen.class.getResource("../image/mainBackground2.png")).getImage();
		
		loginButton = new JButton(new ImageIcon(MainScreen.class.getResource("../image/loginButton.png")));
		signupButton = new JButton(new ImageIcon(MainScreen.class.getResource("../image/signupButton.png")));
		idFindingButton = new JButton(new ImageIcon(MainScreen.class.getResource("../image/idFindingButton.png")));
		passwordFindingButton = new JButton(new ImageIcon(MainScreen.class.getResource("../image/pwFindingButton.png")));
		
		idField = new JTextField() {public void setBorder(Border border) {}};
		passwordField = new JPasswordField() {public void setBorder(Border border) {}};
	}
	
	public void showMainScreen() { // 배경 사진만 보여주는 패널 생성 
		mainPanel.setLayout(null);
		mainPanel.setSize(1250, 700);
		//mainPanel.setMinimumSize(new Dimension(1250, 700));
		//mainPanel.repaint();
		//mainPanel.revalidate();


		mainPanel.setVisible(true);
	}
	
	public void showButtonPanel() { // 버튼 패널 생성 (메인 패널에 버튼을 집어넣으면 안보임) 
		buttonPanel.setSize(1250, 700); 
		buttonPanel.setLocation(0,0);
		buttonPanel.setBackground(new Color(255, 0,0,0));
		buttonPanel.setLayout(null);
		
		loginButton.setSize(200, 90);
		loginButton.setLocation(597, 338);
		
		signupButton.setSize(200, 53);
		signupButton.setLocation(597, 476);
		
		idFindingButton.setSize(200, 50);
		idFindingButton.setLocation(596, 541);
		
		passwordFindingButton.setSize(200, 50);
		passwordFindingButton.setLocation(817, 542);
		
		paintButton(loginButton);
		paintButton(signupButton);
		paintButton(idFindingButton);
		paintButton(passwordFindingButton);
		
		
		buttonPanel.add(loginButton);
		buttonPanel.add(signupButton);
		buttonPanel.add(idFindingButton);
		buttonPanel.add(passwordFindingButton);
		buttonPanel.setVisible(true);
	}
	
	public void showLoginTextField() {
		loginPanel.setSize(500, 500);
		loginPanel.setLocation(213, 313);
		loginPanel.setLayout(null);
		
		idField.setSize(300, 50);
		idField.setLocation(10, 12);
		passwordField.setSize(300, 50);
		passwordField.setLocation(10, 90);
		
		loginPanel.add(idField);
		loginPanel.add(passwordField);
		loginPanel.setVisible(true);
	}
	
	private void paintButton(JButton button) {
		button.setOpaque(false);
		//loginButton.setContentAreaFilled(false);
		button.setBorderPainted(false);
		button.setFocusPainted(false);
	}
	
	private class Panel extends JPanel { // 패널에 배경 그려주는 클래스 
		public void paint(Graphics g) { 
			//super.paint(g);
			g.drawImage(background, 0, 0, null);		
		}
	}
	
	
}
