package view;
import java.awt.*;
import javax.swing.*;

public class CalculatorButton extends JPanel {
	private String [] calculatorValue = {"CE", "C", "x", "÷", "7", "8", "9", "X", "4", "5", "6", "-", "1", "2", "3", "+", "+/-", "0", ".","="};
	public String [] screenValue = {"7", "8", "9", "4", "5", "6", "1", "2", "3", "+/-", "0", "."};
	public JPanel buttonPanel;
	public JPanel logButtonPanel;
	public JButton [] clearButton;
	public JButton [] operationButton;
	public JButton [] valueButton;
	public JButton logButton;
	
	public CalculatorButton() {
		buttonPanel = new JPanel();
		logButtonPanel = new JPanel();
		clearButton = new JButton[3];
		operationButton = new JButton[5];
		valueButton = new JButton[12];
		logButton = new JButton("O");
	}
	
	public void PrintMainPanel() {
		buttonPanel.setSize(400, 300);
		buttonPanel.setLayout(new GridLayout(5, 4, 1, 1));
		
		
		for (int i=0;i<3;i++) {
			clearButton[i] = new JButton(calculatorValue[i]);
			buttonPanel.add(clearButton[i]);
		}
		
		operationButton[0] = new JButton(calculatorValue[3]);
		buttonPanel.add(operationButton[0]);
		
		for (int i=4;i<7;i++) {
			valueButton[i-4] = new JButton(calculatorValue[i]);
			buttonPanel.add(valueButton[i-4]);
		}
		
		operationButton[1] = new JButton(calculatorValue[7]);
		buttonPanel.add(operationButton[1]);
		
		for (int i=8;i<11;i++) {
			valueButton[i+3-8] = new JButton(calculatorValue[i]);
			buttonPanel.add(valueButton[i+3-8]);
		}
		
		operationButton[2] = new JButton(calculatorValue[11]);
		buttonPanel.add(operationButton[2]);
		
		for (int i=12;i<15;i++) {
			valueButton[i+6-12] = new JButton(calculatorValue[i]);
			buttonPanel.add(valueButton[i+6-12]);
		}
		
		operationButton[3] = new JButton(calculatorValue[15]);
		buttonPanel.add(operationButton[3]);
		
		for (int i=16;i<19;i++) {
			valueButton[i+9-16] = new JButton(calculatorValue[i]);
			buttonPanel.add(valueButton[i+9-16]);
		}
		
		operationButton[4] = new JButton(calculatorValue[19]);
		buttonPanel.add(operationButton[4]);
		
		buttonPanel.setLocation(0, 260);
		buttonPanel.setVisible(true);
	}
	
	public void PrintLogButtonPanel() {
		logButtonPanel.setSize(400, 50);
		logButtonPanel.setLayout(null);
		
		logButton.setLocation(10, 10);
		logButtonPanel.add(logButton);
		
		logButtonPanel.setBackground(Color.YELLOW);
		logButtonPanel.setLocation(0, 1);
		logButtonPanel.setVisible(true);
	}
}
