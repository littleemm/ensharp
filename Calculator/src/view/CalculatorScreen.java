package view;
import javax.swing.*;
import java.awt.*;

public class CalculatorScreen {
	
	public JPanel inputPanel; 
	public JLabel beforeInput;
	public JLabel currentInput;
	
	public CalculatorScreen() {
		inputPanel = new JPanel();
		beforeInput = new JLabel();
		currentInput = new JLabel();
	}
	
	public void PrintCalculatorScreen() {
		inputPanel.setSize(430, 150);
		inputPanel.setLayout(null);
		
		beforeInput.setSize(430, 10);
		beforeInput.setLocation(0, 40);
		inputPanel.add(beforeInput);
		
		currentInput.setSize(430, 145);
		currentInput.setLocation(0, 15);
		inputPanel.add(currentInput);
		
		//inputPanel.setBackground(Color.PINK);
		inputPanel.setLocation(0, 30);
		inputPanel.setVisible(true);
	}
}
