package view;

import java.awt.BorderLayout;
import java.awt.Dimension;

import javax.swing.JButton;
import javax.swing.JFrame;
import javax.swing.JLabel;
import javax.swing.JPanel;

public class BasicScreen {
	private JFrame frame;
	private JPanel panel;
	private JLabel label;
	
	public BasicScreen() {
		frame = new JFrame();
		panel = new JPanel();
		label = new JLabel();
	}
	
	protected void paintButton(JButton button) {
		button.setOpaque(false);
		//loginButton.setContentAreaFilled(false);
		button.setBorderPainted(false);
		button.setFocusPainted(false);
	}
	
	public void popFrame(String text) {
		frame.setSize(300, 100);
		frame.setLayout(new BorderLayout());
		frame.setLocationRelativeTo(null);
		frame.setResizable(false);
		
		panel.setPreferredSize(new Dimension(300, 100));
		panel.setLayout(new BorderLayout());
		
		label.setPreferredSize(new Dimension(300, 100));
		label.setText(text);
		label.setHorizontalAlignment(JLabel.CENTER);

		
		panel.add(label, BorderLayout.CENTER);
		frame.add(panel, BorderLayout.CENTER);
		frame.setVisible(true);
	}
}
