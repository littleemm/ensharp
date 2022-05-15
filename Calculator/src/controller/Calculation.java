package controller;
import view.*;
import javax.swing.*;
import java.awt.*;
import java.awt.event.*;

public class Calculation extends JFrame{
	
	private JFrame mainFrame;
	private Font font;
	private Font beforeFont;
	private String beforeInputTextAll;
	private String inputTextAll;
	private String inputText;
	public CalculatorButton calculatorButton;
	public CalculatorScreen calculatorScreen;
	private Color buttonColor;
	private Color equalButtonColor;
	private GridBagLayout layout;
	private GridBagConstraints constraint;
		
	
	public Calculation() {
		mainFrame = new JFrame("계산기");
		beforeFont = new Font("맑은 고딕 Bold", Font.BOLD, 10);
		font = new Font("맑은 고딕 Bold", Font.BOLD, 40);
		beforeInputTextAll = "";
		inputTextAll = "0";
		inputText = "";
		layout = new GridBagLayout();
		constraint = new GridBagConstraints();
		buttonColor = new Color(208, 205, 205);
		equalButtonColor = new Color(176, 160, 229);
		calculatorButton = new CalculatorButton();
		calculatorScreen = new CalculatorScreen();
	}
	
	public void ShowCalculatorMain() {
		
		mainFrame.setBounds(20, 20, 430, 600);
		mainFrame.setLayout(layout);
		mainFrame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		//mainFrame.setUndecorated(true);
		//mainFrame.setBackground(new Color(0,0,0,230));
		calculatorButton.PrintMainPanel();
		calculatorButton.PrintLogButtonPanel();
		calculatorScreen.PrintCalculatorScreen();
		
		gridBagInsert(calculatorButton.logButtonPanel, 0, 0, 0, 1, 1);
		gridBagInsert(calculatorScreen.inputPanel, 0, 1, 0, 2, 3);
		gridBagInsert(calculatorButton.buttonPanel, 0, 5, 0, 5, 5);

		
		calculatorScreen.currentInput.setText(inputTextAll); // label에 입력된 숫자 넣기 
		calculatorScreen.currentInput.setFont(font); 
		calculatorScreen.currentInput.setHorizontalAlignment(JLabel.RIGHT); // 오른쪽에서부터 숫자 시작 
		calculatorScreen.inputPanel.add(calculatorScreen.currentInput);
		
		for (int i=0;i<12;i++) {
			calculatorButton.valueButton[i].addActionListener(new NumberButtonListener());
			calculatorButton.valueButton[i].addMouseListener(new MouseButtonListener());
		}
		
		for (int i=0;i<5;i++) {
			calculatorButton.operationButton[i].addActionListener(new OperationButtonListener());
			calculatorButton.operationButton[i].addMouseListener(new MouseButtonListener());
		}
		
		for (int i=0;i<3;i++) {
			calculatorButton.clearButton[i].addActionListener(new ClearButtonListener());
			calculatorButton.clearButton[i].addMouseListener(new MouseButtonListener());
		}
		
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
	
	private class NumberButtonListener implements ActionListener {
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
					else if (beforeInputTextAll.length() > 0 && beforeInputTextAll.substring(beforeInputTextAll.length() - 1).equals("=")) {
						beforeInputTextAll = "";
						inputTextAll = "";
						inputTextAll += inputText;
						calculatorScreen.beforeInput.setHorizontalAlignment(JLabel.RIGHT); 
						calculatorScreen.beforeInput.setText(beforeInputTextAll);
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
	
	private class OperationButtonListener implements ActionListener {
		public void actionPerformed(ActionEvent e) {
			JButton button = (JButton)e.getSource();
			String operator = button.getText();
			if (inputText.equals("+") || inputText.equals("-") || inputText.equals("×") || inputText.equals("÷")) {
				// 피연산자를 입력하지 않은채 연산자를 입력하면 버튼이 먹히지 않음 
			}
			else if(operator.equals("+")) {
				CheckBeforeInputLength(operator);
				AddOperator(operator);
			}
			else if (operator.equals("-")) {
				CheckBeforeInputLength(operator);
				AddOperator(operator);
			}
			else if (operator.equals("×")) {
				CheckBeforeInputLength(operator);
				AddOperator(operator);
			}
			else if (operator.equals("÷")) {
				CheckBeforeInputLength(operator);
				AddOperator(operator);
			}
			else if (operator.equals("=")) {
				CheckBeforeInputLength(operator);
				AddEqualSign();
			}
			
			calculatorScreen.beforeInput.setHorizontalAlignment(JLabel.RIGHT);
			calculatorScreen.inputPanel.add(calculatorScreen.beforeInput);
			
			if(operator.equals("=")) {
				calculatorScreen.currentInput.setText(inputTextAll);
				calculatorScreen.currentInput.setHorizontalAlignment(JLabel.RIGHT);
				calculatorScreen.inputPanel.add(calculatorScreen.currentInput);
			}
		}
		
	}
	
	private class ClearButtonListener implements ActionListener {
		public void actionPerformed(ActionEvent e) {
			JButton button = (JButton)e.getSource();
			if(button.getText().equals("C")) { // 작은 글씨까지 삭제 
				beforeInputTextAll = "";
				inputTextAll = "0";
				calculatorScreen.beforeInput.setText(beforeInputTextAll);
				calculatorScreen.currentInput.setText(inputTextAll);
				calculatorScreen.beforeInput.setFont(beforeFont);
			}
			else if (button.getText().equals("CE") && beforeInputTextAll.substring(beforeInputTextAll.length() - 1).equals("=")) { // 현재 입력값만 삭제 
				beforeInputTextAll = "";
				inputTextAll = "0";
				calculatorScreen.beforeInput.setText(beforeInputTextAll);
				calculatorScreen.currentInput.setText(inputTextAll);
				calculatorScreen.beforeInput.setFont(beforeFont);
			}
			else if (button.getText().equals("CE")) {
				inputTextAll = "0";
				calculatorScreen.currentInput.setText(inputTextAll);
			}
			else if (button.getText().equals("x")) { // 현재 입력값에서 하나씩 삭제 
				inputTextAll = inputTextAll.substring(0, inputTextAll.length() - 1);
				if (inputTextAll.length() == 0) {
					inputTextAll = "0";
				}
				calculatorScreen.currentInput.setText(inputTextAll);
			}
			calculatorScreen.beforeInput.setHorizontalAlignment(JLabel.RIGHT);
			calculatorScreen.inputPanel.add(calculatorScreen.beforeInput);
			
		}
	}
	
	private class MouseButtonListener implements MouseListener {
		public void mouseEntered(MouseEvent e) {
			JButton button = (JButton)e.getSource();
			for (int j=0;j<20;j++) {
				if (button.getText().equals("=")) {
					button.setOpaque(true);
					button.setBackground(equalButtonColor);
				}
				else if(button.getText().equals(calculatorButton.calculatorValue[j])) {
				button.setOpaque(true);
				button.setBackground(buttonColor);
			}
			}
		}
		public void mouseExited(MouseEvent e) {
			JButton button = (JButton)e.getSource();
			for (int j=0;j<20;j++) {
				if(button.getText().equals(calculatorButton.calculatorValue[j])) {
					calculatorButton.PaintColor();
				}
			}
		}
		public void mousePressed(MouseEvent e) {
		}
		public void mouseReleased(MouseEvent e) {
		}
		public void mouseClicked(MouseEvent e) {
		}
	}
	
	private void CheckBeforeInputLength(String operator) { // 전에 계산한 값의 길이를 확인 
		if (beforeInputTextAll.length() > 0) {
			inputTextAll = CalculateWithOperator(operator);
		}
	}
	
	private void AddOperator(String operator) { // 수행된 값을 바탕으로 오른쪽에 기호 추가 
		beforeInputTextAll = inputTextAll;
		beforeInputTextAll += operator;
		inputText = operator; // 나중에 마지막 입력 버튼 값을 알아야하는 때를 위해 저장 
		calculatorScreen.beforeInput.setText(beforeInputTextAll);
		calculatorScreen.beforeInput.setFont(beforeFont);
	}
	
	private void AddEqualSign() {
		inputText = "="; // 나중에 마지막 입력 버튼 값을 알아야하는 때를 위해 저장 
		calculatorScreen.beforeInput.setText(beforeInputTextAll);
		calculatorScreen.beforeInput.setFont(beforeFont);
	}
	
	private String CalculateWithOperator(String equalSign) { // 사칙연산 
		double result = 0.0;
		double beforeInputNumber = Double.parseDouble(beforeInputTextAll.substring(0,beforeInputTextAll.length()-1));
		double inputNumber = Double.parseDouble(inputTextAll);
		String operator = beforeInputTextAll.substring(beforeInputTextAll.length() - 1);
		
		if (operator.equals("+")) {
			result = beforeInputNumber + inputNumber;
		}
		else if (operator.equals("-")) {
			result = beforeInputNumber - inputNumber;
		}
		else if (operator.equals("×")) {
			result = beforeInputNumber * inputNumber;
		}
		else if (operator.equals("÷")) {
			result = beforeInputNumber / inputNumber;
		}
		
		if (equalSign.equals("=")) {
			beforeInputTextAll += inputTextAll;
			beforeInputTextAll += "=";
		}
		String resultString = Double.toString(result);
		if (resultString.substring(resultString.length() - 1).equals("0")) {
			resultString = Integer.toString((int)result);
		}
		
		return resultString;
	}
	
	
}
