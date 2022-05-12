package view;
import javax.swing.*;
import java.awt.*;

public class CalculatorScreen {
	
	public JPanel inputPanel; 
	private JLabel beforeInput;
	private JLabel currentInput;
	
	public CalculatorScreen() {
		inputPanel = new JPanel();
		beforeInput = new JLabel();
		currentInput = new JLabel();
	}
	
	public void PrintCalculatorScreen() {
		inputPanel.setSize(400, 300);
		inputPanel.setLayout(new GridLayout(2, 1));
		
		beforeInput.setSize(400, 150);
		inputPanel.add(beforeInput);
		
		currentInput.setSize(400, 150);
		inputPanel.add(currentInput);
		
		inputPanel.setVisible(true);
	}
}
