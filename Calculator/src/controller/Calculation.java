package controller;
import view.*;
import javax.swing.*;
import java.awt.*;
import java.awt.event.*;

public class Calculation extends JFrame{
	
	private JFrame mainFrame;
	public CalculatorButton calculatorButton;
	public CalculatorScreen calculatorScreen;
	
	public Calculation() {
		mainFrame = new JFrame("계산기");
		calculatorButton = new CalculatorButton();
		calculatorScreen = new CalculatorScreen();
	}
	
	public void ShowCalculatorMain() {
		mainFrame.setBounds(10, 10, 400, 590);
		mainFrame.setLayout(null);
		//mainFrame.setUndecorated(true);
		//mainFrame.setBackground(new Color(0,0,0,230));
		calculatorButton.PrintMainPanel();
		calculatorButton.PrintLogButtonPanel();
		calculatorScreen.PrintCalculatorScreen();
		
		mainFrame.add(calculatorButton.logButtonPanel);
		mainFrame.add(calculatorScreen.inputPanel);
		mainFrame.add(calculatorButton.buttonPanel);
		
		CalculateWithButton();
		
		mainFrame.setVisible(true);
	}
	
	private void CalculateWithButton() {
		for (int i=0;i<12;i++) {
			calculatorButton.valueButton[i].addActionListener(new ActionListener() {
				public void actionPerformed(ActionEvent e) {
					JButton button = (JButton)e.getSource();
					for (int j=0;j<12;j++) {
					if(button.getText().equals(calculatorButton.screenValue[j]))
						calculatorScreen.currentInput.setText(calculatorButton.screenValue[j]);
					}
				}
			});
		}
	}
	
}
