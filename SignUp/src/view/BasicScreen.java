package view;

import javax.swing.JButton;

public class BasicScreen {
	public BasicScreen() {
		
	}
	
	protected void paintButton(JButton button) {
		button.setOpaque(false);
		//loginButton.setContentAreaFilled(false);
		button.setBorderPainted(false);
		button.setFocusPainted(false);
	}
}
