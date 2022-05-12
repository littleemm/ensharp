package view;
import javax.swing.*;
import java.awt.*;

public class CalculatorScreen {
	
	public JPanel inputPanel; 
	private JLabel beforeInput;
	private JLabel currentInput;
	
	public CalculatorScreen() {
		inputPanel = new JPanel();
		beforeInput = new JLabel("djdkhla");
		currentInput = new JLabel();
	}
	
	public void PrintCalculatorScreen() {
		inputPanel.setSize(400, 150);
		inputPanel.setLayout(new GridLayout(1, 1));
		
		beforeInput.setSize(400, 150);
		inputPanel.add(beforeInput);

		inputPanel.setBackground(Color.RED);
		inputPanel.setLocation(0, 80);
		inputPanel.setVisible(true);
	}
}
