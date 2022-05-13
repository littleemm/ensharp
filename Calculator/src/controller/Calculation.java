package controller;
import view.*;
import javax.swing.*;
import java.awt.*;
import java.awt.event.*;

public class Calculation extends JFrame{
	
	private JFrame mainFrame;
	private JLabel miniLabel;
	private Font font;
	private Font beforeFont;
	private String beforeInputTextAll;
	private String inputTextAll;
	private String inputText;
	private String inputOperation;
	public CalculatorButton calculatorButton;
	public CalculatorScreen calculatorScreen;
	
	public Calculation() {
		mainFrame = new JFrame("계산기");
		miniLabel = new JLabel();
		beforeFont = new Font("맑은 고딕 Bold", Font.BOLD, 10);
		font = new Font("맑은 고딕 Bold", Font.BOLD, 40);
		beforeInputTextAll = "";
		inputTextAll = "0";
		inputText = "";
		inputOperation = "";
		calculatorButton = new CalculatorButton();
		calculatorScreen = new CalculatorScreen();
	}
	
	public void ShowCalculatorMain() {
		mainFrame.setBounds(10, 10, 430, 510);
		mainFrame.setLayout(null);
		mainFrame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		//mainFrame.setUndecorated(true);
		//mainFrame.setBackground(new Color(0,0,0,230));
		calculatorButton.PrintMainPanel();
		calculatorButton.PrintLogButtonPanel();
		calculatorScreen.PrintCalculatorScreen();
		
		mainFrame.add(calculatorButton.logButtonPanel);
		mainFrame.add(calculatorScreen.inputPanel);
		mainFrame.add(calculatorButton.buttonPanel);
		
		calculatorScreen.currentInput.setText(inputTextAll); // label에 입력된 숫자 넣기 
		calculatorScreen.currentInput.setFont(font); 
		calculatorScreen.currentInput.setHorizontalAlignment(JLabel.RIGHT); // 오른쪽에서부터 숫자 시작 
		calculatorScreen.inputPanel.add(calculatorScreen.currentInput);
		
		for (int i=0;i<12;i++) {
			calculatorButton.valueButton[i].addActionListener(new numberButtonListener());
			calculatorButton.valueButton[i].addMouseListener(new MouseButtonListener());
		}
		
		for (int i=0;i<4;i++) {
			calculatorButton.operationButton[i].addActionListener(new operationButtonListener());
			calculatorButton.operationButton[i].addMouseListener(new MouseButtonListener());
		}
		
		for (int i=0;i<3;i++) {
			calculatorButton.clearButton[i].addActionListener(new clearButtonListener());
			calculatorButton.clearButton[i].addMouseListener(new MouseButtonListener());
		}
		
		mainFrame.setVisible(true);
	}
	
	private class numberButtonListener implements ActionListener {
		public void actionPerformed(ActionEvent e) {
			JButton button = (JButton)e.getSource();
			for (int j=0;j<12;j++) {
				if(button.getText().equals(calculatorButton.screenValue[j])) {
					inputText = calculatorButton.screenValue[j]; // 현재 눌린 숫자 
					if(inputText.equals("+/-") && inputTextAll.substring(0,1).equals("-")) { // 부호 버튼 (+) 처리 
						inputTextAll = inputTextAll.substring(1);
					}
					else if (inputText.equals("+/-")) {  // 부호 버튼 (-) 처리 
						String conversion = "-";
						conversion += inputTextAll;
						inputTextAll = conversion;
					}
					else if (inputTextAll.equals("0") && inputText.equals(".")) {  // 소수점 입력 처리 
						inputTextAll += inputText; 
					}
					else if (inputTextAll.equals("0"))  { // 아직 아무것도 입력되지 않은 상태 
						inputTextAll = "";
						inputTextAll += inputText; 
					} // 연산 기호가 입력되기 전까지는 숫자를 연속적으로 표현해야한다. 
					else if (beforeInputTextAll.length() > 0 && inputTextAll.equals(beforeInputTextAll.substring(0,beforeInputTextAll.length() - 1))) {
						inputTextAll = "";
						inputTextAll += inputText;
					}
					else { // 입력 중 
						inputTextAll += inputText; 
					}
				}
			}
				calculatorScreen.currentInput.setText(inputTextAll); // label에 입력된 숫자 넣기 
				calculatorScreen.currentInput.setFont(font); 
				calculatorScreen.currentInput.setHorizontalAlignment(JLabel.RIGHT); // 오른쪽에서부터 숫자 시작 
				calculatorScreen.inputPanel.add(calculatorScreen.currentInput);
		}

	}
	
	private class operationButtonListener implements ActionListener {
		public void actionPerformed(ActionEvent e) {
			JButton button = (JButton)e.getSource();
			String operator = button.getText();
			if(operator.equals("+")) {
				if (beforeInputTextAll.length() > 0) {
				inputTextAll = CalculateWithOperator();
				}
				AddOperator(operator);
			}
			else if (operator.equals("-")) {
				if (beforeInputTextAll.length() > 0) {
					inputTextAll = CalculateWithOperator();
					}
				AddOperator(operator);
			}
			else if (operator.equals("X")) {
				if (beforeInputTextAll.length() > 0) {
					inputTextAll = CalculateWithOperator();
					}
				AddOperator(operator);
			}
			else if (operator.equals("÷")) {
				if (beforeInputTextAll.length() > 0) {
					inputTextAll = CalculateWithOperator();
					}
				AddOperator(operator);
			}
			calculatorScreen.beforeInput.setHorizontalAlignment(JLabel.RIGHT);
			calculatorScreen.inputPanel.add(calculatorScreen.beforeInput);
		
		}
		
	}
	
	private class clearButtonListener implements ActionListener {
		public void actionPerformed(ActionEvent e) {
			JButton button = (JButton)e.getSource();
			if(button.getText().equals("C")) { // 작은 글씨까지 삭제 
				beforeInputTextAll = "";
				inputTextAll = "0";
				calculatorScreen.beforeInput.setText(beforeInputTextAll);
				calculatorScreen.currentInput.setText(inputTextAll);
				calculatorScreen.beforeInput.setFont(beforeFont);
			}
			else if (button.getText().equals("CE")) { // 현재 입력값만 삭제 
				inputTextAll = "0";
				calculatorScreen.currentInput.setText(inputTextAll);
			}
			else if (button.getText().equals("x")) { // 현재 입력값에서 하나씩 삭제 
				inputTextAll = inputTextAll.substring(0, inputTextAll.length() - 1);
				calculatorScreen.currentInput.setText(inputTextAll);
			}
			calculatorScreen.beforeInput.setHorizontalAlignment(JLabel.RIGHT);
			calculatorScreen.inputPanel.add(calculatorScreen.beforeInput);
			
		}
	}
	
	private class MouseButtonListener implements MouseListener {
		public void mouseEntered(MouseEvent e) {
			JButton button = (JButton)e.getSource();
			for (int j=0;j<20;j++)
			if(button.getText().equals(calculatorButton.calculatorValue[j])) {
				button.setOpaque(true);
				button.setBackground(Color.GRAY);
			}
		}
		public void mouseExited(MouseEvent e) {
			JButton button = (JButton)e.getSource();
			for (int j=0;j<20;j++)
				if(button.getText().equals(calculatorButton.calculatorValue[j])) {
					calculatorButton.PaintColor();
				}
		}
		public void mousePressed(MouseEvent e) {
			
		}
		public void mouseReleased(MouseEvent e) {
			
		}
		public void mouseClicked(MouseEvent e) {
			
		}

	}
	
	private void AddOperator(String operator) {
		beforeInputTextAll = inputTextAll;
		beforeInputTextAll += operator;
		calculatorScreen.beforeInput.setText(beforeInputTextAll);
		calculatorScreen.beforeInput.setFont(beforeFont);
	}
	
	private String CalculateWithOperator() {
		double result = 0.0;
		System.out.println(beforeInputTextAll);
		System.out.println(inputTextAll);
		double beforeInputNumber = Double.parseDouble(beforeInputTextAll.substring(0,beforeInputTextAll.length()-1));
		double inputNumber = Double.parseDouble(inputTextAll);
		String operator = beforeInputTextAll.substring(beforeInputTextAll.length() - 1);
		System.out.println(beforeInputNumber);
		System.out.println(inputNumber);
		System.out.println(operator);
		if (operator.equals("+")) {
			result = beforeInputNumber + inputNumber;
		}
		else if (operator.equals("-")) {
			result = beforeInputNumber - inputNumber;
		}
		else if (operator.equals("X")) {
			result = beforeInputNumber * inputNumber;
		}
		else if (operator.equals("÷")) {
			result = beforeInputNumber / inputNumber;
		}
		
		String resultString = Double.toString(result);
		if (resultString.substring(resultString.length() - 1).equals("0")) {
			resultString = Integer.toString((int)result);
		}
		
		return resultString;
	}
	
}
