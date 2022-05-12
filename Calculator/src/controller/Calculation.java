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
		mainFrame.setBounds(10, 10, 400, 600);
		mainFrame.setLayout(new GridLayout(3, 1));
		calculatorButton.PrintMainPanel();
		
		mainFrame.add(calculatorScreen.inputPanel);
		mainFrame.add(calculatorButton.buttonPanel);
		
		mainFrame.setVisible(true);
	}
	
}
