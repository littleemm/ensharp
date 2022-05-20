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
		inputPanel.setSize(420, 100);
		inputPanel.setLayout(null);
		
		beforeInput.setSize(410, 10);
		beforeInput.setLocation(0, 40);
		beforeInput.setHorizontalAlignment(JLabel.RIGHT);
		inputPanel.add(beforeInput);
		
		currentInput.setSize(410, 145);
		currentInput.setLocation(0, 15);
		currentInput.setHorizontalAlignment(JLabel.RIGHT);
		inputPanel.add(currentInput);
		

		//inputPanel.setLocation(0, 30);
		inputPanel.setVisible(true);
	}
}
