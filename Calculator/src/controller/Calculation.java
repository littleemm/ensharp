package controller;
import view.*;
import javax.swing.*;
import java.awt.*;

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
		
		mainFrame.setVisible(true);
	}
	
}
