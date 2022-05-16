package controller;

import java.awt.Color;
import java.awt.Font;
import java.awt.event.*;
import javax.swing.*;

import model.CalculationDTO;
import view.CalculatorButton;
import view.CalculatorScreen;

public class ButtonActionListener {
	private String inputText; // 현재 눌린 값  
	private String inputTextAll; // 연산자가 입력되기 전까지 입력된 숫자 전체 
	private String beforeInputTextAll; // 숫자 + 연산자가 저장되어 있는, 이전에 입력된 값 
	private String firstNumber;
	private String operator;
	private String secondNumber;
	
	private CalculatorScreen calculatorScreen;
	private CalculatorButton calculatorButton;
	private Calculation calculation;
	
	private Color buttonColor;
	private Color equalButtonColor;
	private Font font;
	private Font beforeFont;
	private Font fontToSmall;
	
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
		operator = "";
		firstNumber = "";
		secondNumber = "";
	}
	
	public void ListenButtonAction() { // 버튼 리스너 
		for (int i=0;i<12;i++) { // 피연산자 버튼 
			calculatorButton.valueButton[i].addActionListener(new NumberButtonListener());
			calculatorButton.valueButton[i].addMouseListener(new MouseButtonListener());
		}
		
		for (int i=0;i<5;i++) { // 연산자 버튼 
			calculatorButton.operationButton[i].addActionListener(new OperationButtonListener());
			calculatorButton.operationButton[i].addMouseListener(new MouseButtonListener());
		}
		
		for (int i=0;i<3;i++) { // 지우기 버튼 
			calculatorButton.clearButton[i].addActionListener(new ClearButtonListener());
			calculatorButton.clearButton[i].addMouseListener(new MouseButtonListener());
		}
	}
	
	private class NumberButtonListener implements ActionListener {
		public void actionPerformed(ActionEvent e) {
			JButton button = (JButton)e.getSource();
			int beforeLength = beforeInputTextAll.length();
			String beforeInputNumberPart = "";
			String beforeInputOperatorPart = "";
			
			if (beforeLength > 0) {
				beforeInputNumberPart = beforeInputTextAll.substring(0,beforeInputTextAll.length() - 1);
				beforeInputOperatorPart = beforeInputTextAll.substring(beforeInputTextAll.length() - 1);
			}
			
			if(secondNumber.length() > 0) {
				firstNumber = "";
				operator = "";
				secondNumber = "";
			}
			
			for (int i=0;i<12;i++) {
				if(button.getText().equals(calculatorButton.screenValue[i]) && isNumber()) {
					inputText = button.getText(); // 현재 눌린 숫자 
					
					if (inputText.equals("+/-")) {
						ShowPositiveOrNegative();
					}
					else if (inputTextAll.equals("0")) {
						ShowFirstInput();
					}
					else if (beforeLength > 0 && inputTextAll.equals(beforeInputNumberPart)) {
						inputTextAll = "";
						inputTextAll += inputText;
					}
					else if (beforeLength > 0 && beforeInputOperatorPart.equals("=")) {
						beforeInputTextAll = "";
						inputTextAll = "0";
						ShowFirstInput();
						calculatorScreen.beforeInput.setHorizontalAlignment(JLabel.RIGHT); 
						calculatorScreen.beforeInput.setText(beforeInputTextAll);
					}
					else { 
						inputTextAll += inputText; 
					}
				}
			}
			
			// 큰 숫자 부분 
			calculatorScreen.currentInput.setText(inputTextAll); 
			calculatorScreen.currentInput.setFont(font); 
			if (inputTextAll.length() > 15) {
				calculatorScreen.currentInput.setFont(fontToSmall);
			}
			calculatorScreen.currentInput.setHorizontalAlignment(JLabel.RIGHT); // 오른쪽에서부터 숫자 시작 
			calculatorScreen.inputPanel.add(calculatorScreen.currentInput);
			
			if(operator.length() > 0) {
				secondNumber = inputTextAll;
			}
		}
	}
	
	private class OperationButtonListener implements ActionListener {
		public void actionPerformed(ActionEvent e) {
			JButton button = (JButton)e.getSource();
			
			if (inputText.equals("+") || inputText.equals("-") || inputText.equals("×") || inputText.equals("÷")) {
				return;
			}
			
			switch(button.getText().charAt(0)) {
			case ('+') : {
				AddOperator(button);
				break;
			}
			case ('-') : {
				AddOperator(button);
				break;
			}
			case ('×') : {
				AddOperator(button);
				break;
			}
			case ('÷') : {
				AddOperator(button);
				break;
			}
			case ('=') : {
				IdentifyEqualSign(button);
				break;
			}
			}
			
			calculatorScreen.beforeInput.setHorizontalAlignment(JLabel.RIGHT);
			calculatorScreen.inputPanel.add(calculatorScreen.beforeInput);
			
			if(beforeInputTextAll.substring(beforeInputTextAll.length()-1).equals("=")) {
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
	
	private void ShowPositiveOrNegative() {
		String sign = inputTextAll.substring(0,1); // 부호 
		
		if(sign.equals("-")) { // 부호 버튼 (+) 처리 
			inputTextAll = inputTextAll.substring(1);
		}
		else {  // 부호 버튼 (-) 처리 
			String conversion = "-";
			conversion += inputTextAll;
			inputTextAll = conversion;
		}
	}
	
	private void ShowFirstInput() {
		if (inputText.equals(".")) {  // 소수점 입력 처리 
			inputTextAll += inputText; 
		}
		else { 
			inputTextAll = "";
			inputTextAll += inputText; 
		} 
	}
	
	private void IdentifyEqualSign(JButton button) {

		if (operator.length() > 0 && beforeInputTextAll.substring(beforeInputTextAll.length() - 1).equals("=")) {
			calculation = new Calculation(firstNumber, secondNumber, operator, inputTextAll, beforeInputTextAll);
			CalculationDTO calculationDTO = calculation.CalculateAgain();
			beforeInputTextAll = calculationDTO.getBeforeInput();
			inputTextAll = calculationDTO.getInput();
			firstNumber = calculationDTO.getFirstNumber();
			
			calculatorScreen.beforeInput.setText(beforeInputTextAll);
			calculatorScreen.beforeInput.setFont(beforeFont);
		}
		else {
			AddOperator(button);
		}
	}
	
	private void AddOperator(JButton button) { // 수행된 값을 바탕으로 오른쪽에 연산자 추가  
		if (beforeInputTextAll.length() > 0) { // 숫자 + 연산자 조합의 입력값이 존재할 경우 
			calculation = new Calculation(firstNumber, secondNumber, operator, inputTextAll, beforeInputTextAll);
			System.out.println(beforeInputTextAll);
			System.out.println(inputTextAll);
			System.out.println(firstNumber);
			System.out.println(secondNumber);
			
			inputTextAll = calculation.StartCalculatingBasic();
			
			beforeInputTextAll += secondNumber; 
			beforeInputTextAll += "="; 
			
			calculatorScreen.beforeInput.setText(beforeInputTextAll);
			calculatorScreen.beforeInput.setFont(beforeFont);
			
			System.out.println(beforeInputTextAll);
			System.out.println(inputTextAll);
			System.out.println(firstNumber);
		}
		else {
			operator = button.getText();
			firstNumber = inputTextAll;
			beforeInputTextAll = inputTextAll; 
			beforeInputTextAll += operator; 
			
			inputText = operator; // 나중에 마지막 입력 버튼 값을 알아야하는 때를 위해 저장 
			
			calculatorScreen.beforeInput.setText(beforeInputTextAll);
			calculatorScreen.beforeInput.setFont(beforeFont);
			inputTextAll = "0"; // 입력값 초기화 
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
}
