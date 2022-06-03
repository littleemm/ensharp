package view;
import javax.swing.*;
import java.awt.*;
import javax.swing.border.*;

public class SignUpScreen extends BasicScreen {
	public JPanel signUpPagePanel;
	private JPanel textPanel;
	private Panel signupPanel;
	private JPanel buttonPanel;
	
	private Image background;
	public JButton backButton;
	public JButton signupButton;
	private JTextField [] informationField;
	private JPasswordField passwordField;
	private JPasswordField passwordCheckField;
	private JLabel emailSign;
	
	public SignUpScreen() {
		signupPanel = new Panel();
		signUpPagePanel = new JPanel();
		buttonPanel = new JPanel();
		textPanel = new JPanel();
		background = new ImageIcon(MainScreen.class.getResource("../image/signupPage.png")).getImage();
		
		backButton = new JButton(new ImageIcon(MainScreen.class.getResource("../image/backButton.png")));
		signupButton = new JButton(new ImageIcon(MainScreen.class.getResource("../image/signupButton.png")));
		
		informationField = new JTextField[11];
		for (int fieldIndex = 0;fieldIndex<11;fieldIndex++) {
			informationField[fieldIndex] = new JTextField(){public void setBorder(Border border) {}};
		}
		passwordField = new JPasswordField(){public void setBorder(Border border) {}};
		passwordCheckField = new JPasswordField(){public void setBorder(Border border) {}};
		
		emailSign = new JLabel("@");
	}
	
	public void showSignUpScreen() {
		signUpPagePanel.setSize(new Dimension(1280, 745));
		signUpPagePanel.setLocation(0,0);
		signUpPagePanel.setLayout(null);
		showSignUpBackground();
		showButtonPanel();
		showInformationTextField();
		signUpPagePanel.add(buttonPanel);
		signUpPagePanel.add(textPanel);
		signUpPagePanel.add(signupPanel);
		signUpPagePanel.setVisible(true);
	}
	
	private void showSignUpBackground() {
		signupPanel.setLayout(null);
		signupPanel.setSize(1280, 745);
		signupPanel.setVisible(true);
	}
	
	private void showButtonPanel() { // 버튼 패널 생성 (메인 패널에 버튼을 집어넣으면 안보임) 
		buttonPanel.setSize(1280, 745); 
		buttonPanel.setLocation(0,0);
		buttonPanel.setOpaque(false);
		buttonPanel.setBackground(new Color(255, 0,0,0));
		buttonPanel.setLayout(null);
		
		signupButton.setSize(200, 53);
		signupButton.setLocation(678, 653);
		
		backButton.setSize(200, 50);
		backButton.setLocation(437, 653);
		
		paintButton(backButton);
		paintButton(signupButton);
		
		buttonPanel.add(backButton);
		buttonPanel.add(signupButton);
		buttonPanel.setVisible(true);
	}
	
	private void showInformationTextField() {
		textPanel.setSize(1250, 710);
		textPanel.setLocation(0, 0);
		textPanel.setOpaque(false);
		textPanel.setLayout(null);
		
		informationField[0].setSize(150, 30);
		informationField[0].setLocation(195, 50); // 이름 
		informationField[1].setSize(150, 30);
		informationField[1].setLocation(195, 115); // 아이디 
		
		passwordField.setSize(150, 30); 
		passwordField.setLocation(195, 180); // 비밀번호 
		passwordCheckField.setSize(150, 30);
		passwordCheckField.setLocation(195, 245); // 비밀번호 확인 
		
		informationField[2].setSize(150, 30);
		informationField[2].setLocation(195, 305); // 생년월일8글자 
		
		informationField[3].setSize(150, 30);
		informationField[3].setLocation(195, 370); // 이메일 아이디 
		emailSign.setLocation(370, 375);
		emailSign.setSize(20, 20);
		informationField[4].setSize(150, 30);
		informationField[4].setLocation(400, 370); // 이메일 뒷 주소 
		
		informationField[5].setSize(90, 30);
		informationField[5].setLocation(195, 435); // 전화번호 
		informationField[6].setSize(90, 30);
		informationField[6].setLocation(290, 435);
		informationField[7].setSize(90, 30);
		informationField[7].setLocation(385, 435);
		
		informationField[8].setSize(150, 30);
		informationField[8].setLocation(195, 500); // 우편번호 
		informationField[9].setSize(350, 30);
		informationField[9].setLocation(195, 550); // 주소 
		informationField[10].setSize(150, 30);
		informationField[10].setLocation(195, 585); // 상세주소 
		
		
		for (int fieldIndex = 0;fieldIndex<11;fieldIndex++) {
			textPanel.add(informationField[fieldIndex]);
		}
		textPanel.add(passwordField);
		textPanel.add(passwordCheckField);
		textPanel.add(emailSign);
		textPanel.setVisible(true);
	}
	
	private class Panel extends JPanel { // 패널에 배경 그려주는 클래스 
		public void paint(Graphics g) { 
			//super.paint(g);
			g.drawImage(background, 0, 0, null);		
		}
	}
}
