package view;
import javax.swing.*;
import java.awt.*;


public class MainScreen {
	public Panel mainPanel = new Panel();
	private Image background;
	
	public MainScreen() {
		mainPanel = new Panel();
		background =new ImageIcon(MainScreen.class.getResource("../image/overwatch_main.png")).getImage();
	}
	
	public void showMainScreen() {
		mainPanel.setLayout(null);
		mainPanel.setBounds(0, 0, 1000, 800);
	}
	
	private class Panel extends JPanel {
		public void paint(Graphics g) {//그리는 함수
			super.paint(g);
			g.drawImage(background, 0, 0, null);		
		}
	}
	
	
}
