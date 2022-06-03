package view;
import javax.swing.*;
import java.awt.*;
import javax.swing.border.*;

public class LoginedScreen {
	public JPanel loginPagePanel;
	private Panel loginBackgroundPanel;
	private JPanel namePanel;
	private JLabel nameLabel;
	private Image background;
	
	public LoginedScreen() {
		loginPagePanel = new JPanel();
		loginBackgroundPanel = new Panel();
		namePanel = new JPanel();
		nameLabel = new JLabel();
		background = new ImageIcon(MainScreen.class.getResource("../image/tracer.png")).getImage();
	}
	
	public void showLoginScreen(String name) {
		loginPagePanel.setSize(new Dimension(1280, 745));
		loginPagePanel.setLocation(0,0);
		loginPagePanel.setLayout(null);
		
		showLoginBackground();
		showName(name);
		
		loginPagePanel.add(namePanel);
		loginPagePanel.add(loginBackgroundPanel);
		loginPagePanel.setVisible(true);
	}
	
	private void showLoginBackground() {
		loginBackgroundPanel.setLayout(null);
		loginBackgroundPanel.setSize(1280, 745);
		loginBackgroundPanel.setVisible(true);
	}
	
	private void showName(String name) {
		namePanel.setSize(500, 500);
		namePanel.setLocation(50, 50);
		namePanel.setOpaque(false);
		namePanel.setBackground(new Color(255, 0,0,0));
		namePanel.setLayout(null);
		
		nameLabel.setSize(500, 500);
		nameLabel.setText(name);
		
		namePanel.add(nameLabel);
		namePanel.setVisible(true);
	}
	
	private class Panel extends JPanel { // 패널에 배경 그려주는 클래스 
		public void paint(Graphics g) { 
			//super.paint(g);
			g.drawImage(background, 0, 0, null);		
		}
	}

}
