package controller;
import model.*;
import java.awt.Color;
import java.awt.Font;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.awt.event.MouseEvent;
import java.awt.event.MouseListener;
import javax.swing.JButton;
import javax.swing.JLabel;
import view.*;

public class ButtonActionListener {
	private String inputText;
	private String inputTextAll;
	private String beforeInputTextAll;
	private CalculatorScreen calculatorScreen;
	private CalculatorButton calculatorButton;
	private Calculation calculation;
	private Color buttonColor;
	private Color equalButtonColor;
	private Font font;
	private Font beforeFont;
	private Font fontToSmall;
	
	private String firstNumber;
	private String secondNumber;
	private String operationSign;
	
	public ButtonActionListener(String inputText, String inputTextAll, String beforeInputTextAll, CalculatorScreen calculatorScreen, CalculatorButton calculatorButton) {
		this.inputText = inputText;
		this.inputTextAll = inputTextAll;
		this.beforeInputTextAll = beforeInputTextAll;
		this.calculatorButton = calculatorButton;
		this.calculatorScreen = calculatorScreen;
		
		//calculation = new Calculation(inputTextAll, beforeInputTextAll);
		buttonColor = new Color(208, 205, 205);
		equalButtonColor = new Color(176, 160, 229);
		beforeFont = new Font("맑은 고딕 Bold", Font.BOLD, 10);
		font = new Font("맑은 고딕 Bold", Font.BOLD, 40);
		fontToSmall = new Font("맑은 고딕 Bold", Font.BOLD, 30);
		operationSign = "";
	}
	
	public void ListenButtonAction() { // 버튼 리스너 
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
	}
	
	private class NumberButtonListener implements ActionListener { // 숫자 및 부호, 소수점 버튼 
		public void actionPerformed(ActionEvent e) {
			JButton button = (JButton)e.getSource();
			for (int i=0;i<12;i++) {
				if(button.getText().equals(calculatorButton.screenValue[i]) && isNumber()) {
					inputText = calculatorButton.screenValue[i]; // 현재 눌린 숫자 
					
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
				if (inputTextAll.length() > 15) {
					calculatorScreen.currentInput.setFont(fontToSmall);
				}
				calculatorScreen.currentInput.setHorizontalAlignment(JLabel.RIGHT); // 오른쪽에서부터 숫자 시작 
				calculatorScreen.inputPanel.add(calculatorScreen.currentInput);
				
				if (operationSign.length() == 0) {
					firstNumber = inputTextAll;
				}
				else {
					secondNumber = inputTextAll;
				}
		}

	}
	
	private class OperationButtonListener implements ActionListener { // 연산자 버튼 
		public void actionPerformed(ActionEvent e) {
			JButton button = (JButton)e.getSource();
			String operator = button.getText();
			if (inputText.equals("+") || inputText.equals("-") || inputText.equals("×") || inputText.equals("÷")) {
				// 피연산자를 입력하지 않은채 연산자를 입력하면 버튼이 먹히지 않음 
			}
			else if(operator.equals("+")) {
				operationSign = operator;
				CheckBeforeInputLength(operator);
				AddOperator(operator);
			}
			else if (operator.equals("-")) {
				operationSign = operator;
				CheckBeforeInputLength(operator);
				AddOperator(operator);
			}
			else if (operator.equals("×")) {
				operationSign = operator;
				CheckBeforeInputLength(operator);
				AddOperator(operator);
			}
			else if (operator.equals("÷")) {
				operationSign = operator;
				CheckBeforeInputLength(operator);
				AddOperator(operator);
			}
			else if (operator.equals("=")) {
				operationSign = operator;
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
	
	private class ClearButtonListener implements ActionListener { // 지우는 버튼 
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
	
	private void CheckBeforeInputLength(String operator) { // 전에 계산한 값의 길이를 확인 
		if (beforeInputTextAll.length() > 0) { // 숫자 + 연산자 조합의 입력값이 존재할 경우 
			calculation = new Calculation(firstNumber, secondNumber, inputTextAll, beforeInputTextAll);
			System.out.println(beforeInputTextAll);
			System.out.println(inputTextAll);
			
			CalculationDTO calculationDTO = calculation.CalculateWithOperator(operator);
			
			inputTextAll = calculationDTO.getInput();
			beforeInputTextAll = calculationDTO.getBeforeInput();
			firstNumber = calculationDTO.getFirstNumber();
			
			System.out.println(beforeInputTextAll);
			System.out.println(inputTextAll);
			System.out.println(firstNumber);
		}
	}
	
	private boolean isNumber() {
		String input = inputTextAll.substring(0, inputTextAll.length()-1); // 연산자 전까지의 숫자 
		int numberCount = 0;
		for (int i=0;i<input.length();i++) {
			if (input.charAt(i) >= '0' && input.charAt(i) <= '9') {
				numberCount++;
			}
		}
		if (numberCount >= 16) {
			return false;
		}
		
		return true;
	}
	
	private void AddOperator(String operator) { // 수행된 값을 바탕으로 오른쪽에 연산자 추가  
		beforeInputTextAll = inputTextAll; // 첫번째 피연산자를 옮겨주기 
		beforeInputTextAll += operator; 
		inputText = operator; // 나중에 마지막 입력 버튼 값을 알아야하는 때를 위해 저장 
		calculatorScreen.beforeInput.setText(beforeInputTextAll);
		calculatorScreen.beforeInput.setFont(beforeFont);
		inputTextAll = "0"; // 입력값 초기화 
	}
	
	private void AddEqualSign() {
		inputText = "="; // 나중에 마지막 입력 버튼 값을 알아야하는 때를 위해 저장 
		calculatorScreen.beforeInput.setText(beforeInputTextAll);
		calculatorScreen.beforeInput.setFont(beforeFont);
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
}
