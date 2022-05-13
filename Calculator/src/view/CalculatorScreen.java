package view;
import javax.swing.*;
import java.awt.*;

public class CalculatorScreen {
	
	public JPanel inputPanel; 
	public JLabel beforeInput;
	public JLabel currentInput;
	
	public CalculatorScreen() {
		inputPanel = new JPanel();
		beforeInput = new JLabel("djdkhla");
		currentInput = new JLabel("hi");
	}
	
	public void PrintCalculatorScreen() {
		inputPanel.setSize(400, 150);
		inputPanel.setLayout(new GridLayout(2, 1));
		
		beforeInput.setSize(400, 5);
		inputPanel.add(beforeInput);
		
		currentInput.setSize(400, 145);
		inputPanel.add(currentInput);
		
		inputPanel.setBackground(Color.PINK);
		inputPanel.setLocation(0, 80);
		inputPanel.setVisible(true);
	}
}
