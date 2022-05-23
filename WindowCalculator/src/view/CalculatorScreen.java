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
		inputPanel.setLayout(new GridLayout(2,1));
		
		beforeInput.setSize(410, 10);
		beforeInput.setLocation(0, 40);
		beforeInput.setHorizontalAlignment(JLabel.RIGHT);
		inputPanel.add(beforeInput);
		
		currentInput.setSize(410, 90);
		currentInput.setLocation(0, 15);
		currentInput.setHorizontalAlignment(JLabel.RIGHT);
		inputPanel.add(currentInput);
		

		//inputPanel.setLocation(0, 30);
		inputPanel.setBackground(Color.yellow);
		inputPanel.setVisible(true);
	}
}
