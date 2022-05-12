package view;
import javax.swing.*;
import java.awt.*;

public class CalculatorScreen {
	
	public JPanel inputPanel; 
	private JTextField beforeInput;
	private JTextField currentInput;
	
	public CalculatorScreen() {
		inputPanel = new JPanel();
		beforeInput = new JTextField();
		currentInput = new JTextField();
	}
	
	public void PrintCalculatorScreen(String input) {
		inputPanel.setSize(400, 300);
		inputPanel.setLayout(new GridLayout(2, 1));
		
		beforeInput.setSize(400, 150);
		inputPanel.add(beforeInput);
		
		currentInput.setSize(400, 150);
		inputPanel.add(currentInput);
		
		inputPanel.setVisible(true);
	}
}
