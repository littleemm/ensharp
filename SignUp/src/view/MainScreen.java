package view;
import javax.swing.*;
import java.awt.*;


public class MainScreen {
	public Panel mainPanel = new Panel();
	public JPanel buttonPanel = new JPanel();
	private Image background;
	public JButton loginButton;
	public JButton signupButton;
	public JButton idFindingButton;
	public JButton passwordFindingButton;
	public JTextField idField;
	public JTextField passwordField;
	
	public MainScreen() {
		mainPanel = new Panel();
		buttonPanel = new JPanel();
		background = new ImageIcon(MainScreen.class.getResource("../image/mainBackground2.png")).getImage();
		
		loginButton = new JButton(new ImageIcon(MainScreen.class.getResource("../image/loginButton.png")));
		signupButton = new JButton(new ImageIcon(MainScreen.class.getResource("../image/signupButton.png")));
		idFindingButton = new JButton(new ImageIcon(MainScreen.class.getResource("../image/idFindingButton.png")));
		passwordFindingButton = new JButton(new ImageIcon(MainScreen.class.getResource("../image/pwFindingButton.png")));
		
		idField = new JTextField();
		passwordField = new JTextField();
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
		buttonPanel.setOpaque(true); // 투명색 패
		buttonPanel.setLayout(null);
		
		loginButton.setSize(200, 90);
		//loginButton.setMinimumSize(new Dimension(400, 150));
		loginButton.setLocation(597, 338);
		
		loginButton.setOpaque(false);
		//loginButton.setContentAreaFilled(false);
		loginButton.setBorderPainted(false);
		loginButton.setFocusPainted(false);
		
		buttonPanel.add(loginButton);
		buttonPanel.setVisible(true);
	}
	
	private class Panel extends JPanel { // 패널에 배경 그려주는 클래스 
		public void paint(Graphics g) { 
			//super.paint(g);
			g.drawImage(background, 0, 0, null);		
		}
	}
	
	
}
