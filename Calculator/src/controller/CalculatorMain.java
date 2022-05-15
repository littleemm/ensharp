package controller;
import view.*;
import javax.swing.*;
import java.awt.*;
import java.awt.event.*;

public class CalculatorMain extends JFrame{
	
	private JFrame mainFrame;
	private Font font;
	private Font beforeFont;
	private String beforeInputTextAll;
	private String inputTextAll;
	private String inputText;
	public CalculatorButton calculatorButton;
	public CalculatorScreen calculatorScreen;
	private GridBagLayout layout;
	private GridBagConstraints constraint;
	private ButtonActionListener listener;
	
	public CalculatorMain() {
		mainFrame = new JFrame("계산기");
		beforeFont = new Font("맑은 고딕 Bold", Font.BOLD, 10);
		font = new Font("맑은 고딕 Bold", Font.BOLD, 40);
		beforeInputTextAll = "";
		inputTextAll = "0";
		inputText = "";
		layout = new GridBagLayout();
		constraint = new GridBagConstraints();
		calculatorButton = new CalculatorButton();
		calculatorScreen = new CalculatorScreen();
		listener = new ButtonActionListener(inputText, inputTextAll, beforeInputTextAll, calculatorScreen, calculatorButton);
	}
	
	public void ShowCalculatorMain() {
		
		mainFrame.setBounds(20, 20, 430, 600);
		mainFrame.setLayout(layout);
		mainFrame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		
		calculatorButton.PrintMainPanel();
		calculatorButton.PrintLogButtonPanel();
		calculatorScreen.PrintCalculatorScreen();
		
		gridBagInsert(calculatorButton.logButtonPanel, 0, 0, 0, 1, 1);
		gridBagInsert(calculatorScreen.inputPanel, 0, 1, 0, 2, 3);
		gridBagInsert(calculatorButton.buttonPanel, 0, 5, 0, 5, 5);
		
		listener.ListenButtonAction();
		
		calculatorScreen.currentInput.setText(inputTextAll); // label에 입력된 숫자 넣기 
		calculatorScreen.currentInput.setFont(font); 
		calculatorScreen.currentInput.setHorizontalAlignment(JLabel.RIGHT); // 오른쪽에서부터 숫자 시작 
		calculatorScreen.inputPanel.add(calculatorScreen.currentInput);
		
		
		mainFrame.setVisible(true);
	}
	
	private void gridBagInsert(Component component, int x, int y, int width, int height, int y1) {
	        constraint.fill= GridBagConstraints.BOTH;
	        constraint.weightx=1;
		    constraint.weighty=y1;
	        constraint.gridx = x;
	        constraint.gridy = y;
	        constraint.gridwidth = width;
	        constraint.gridheight = height;
	        layout.setConstraints(component, constraint);
	        mainFrame.add(component);
	}
	
}
