package controller;
import utility.Constant;
import utility.Exception;
import java.text.*;
import java.awt.Color;
import java.awt.Font;
import java.awt.event.*;
import javax.swing.*;
import java.math.*;
import java.nio.file.spi.FileSystemProvider;

import javax.swing.AbstractButton;

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
	private ImageIcon logButtonImage;
	
	private BigDecimal firstBig;
	private BigDecimal secondBig;
	private BigDecimal inputTextAllBig;
	private BigDecimal beforeInputTextAllBig;
	
	private NumberFormat format;
	private DecimalFormat decimalPoint;
	private DecimalFormat decimalPointSmall;
	private DecimalFormat basicNumber;
	
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
		font = new Font("맑은 고딕", Font.BOLD, 40);
		fontToSmall = new Font("맑은 고딕 Bold", Font.BOLD, 30);
		logButtonImage = new ImageIcon("src/image/logButton.png");
		operator = "";
		firstNumber = "";
		secondNumber = "";
		decimalPoint = new DecimalFormat("#,###,###,###,###,###.################");
		decimalPointSmall = new DecimalFormat("###,###");
		basicNumber = new DecimalFormat("################.################");
	}
	
	public void ListenButtonAction(JFrame mainFrame) { // 버튼 리스너 
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
		calculatorButton.logButton.addMouseListener(new MouseButtonListener());
		
		mainFrame.addKeyListener(new NumberKeyListener());
		mainFrame.setFocusable(true);
		mainFrame.requestFocus();
	}
	
	private class NumberKeyListener extends KeyAdapter {
		public void keyPressed(KeyEvent e) {
			int key = e.getKeyCode();
			int keyForInput = key - 48;
			String keyText = KeyEvent.getKeyText(key);
			String keyCodeText = Integer.toString(key);
			System.out.println(keyCodeText);
			System.out.println(keyText);
			numberInput(Integer.toString(keyForInput));
			
		}
		public void keyReleased(KeyEvent e) {
			
		}
		public void keyTyped(KeyEvent e) {
			
		}
	}
	
	private class NumberButtonListener implements ActionListener { // 숫자 버튼 
		public void actionPerformed(ActionEvent e) {
			JButton button = (JButton)e.getSource();
			String buttonText = button.getText();
			
			numberInput(buttonText);
		}
	}
	
	private void numberInput(String text) {
		int beforeLength = beforeInputTextAll.length();
		String beforeInputNumberPart = "";
		String beforeInputOperatorPart = "";
		
		
		if (beforeLength > 0) {
			beforeInputNumberPart = beforeInputTextAll.substring(0,beforeInputTextAll.length() - 1);
			beforeInputOperatorPart = beforeInputTextAll.substring(beforeInputTextAll.length() - 1);
		}
		
		if (beforeInputOperatorPart.equals("=")) {
			inputTextAll = "0";
			beforeInputTextAll = "";
		}
	
		for (int i=0;i<12;i++) {
			if((text.equals(calculatorButton.screenValue[i]) || text.equals(Constant.SPACE_CODE))&& isNumber()) {
				inputText = text; // 현재 눌린 숫자 
				System.out.println(inputText);
				if (inputText.equals("+/-") || inputText.equals(Constant.SPACE_CODE)) {
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
		System.out.println(inputTextAll);
		// 큰 숫자 부분 
		calculatorScreen.currentInput.setText(decimalPoint.format(Double.parseDouble(inputTextAll))); 
		calculatorScreen.currentInput.setFont(font); 
		if (inputTextAll.length() > 14) {
			calculatorScreen.currentInput.setFont(fontToSmall);
		}
		calculatorScreen.currentInput.setHorizontalAlignment(JLabel.RIGHT); // 오른쪽에서부터 숫자 시작 
		calculatorScreen.inputPanel.add(calculatorScreen.currentInput);
	}
	
	private class OperationButtonListener implements ActionListener { // 연산자 버튼 
		public void actionPerformed(ActionEvent e) {
			JButton button = (JButton)e.getSource();
			
			if (inputText.equals("+") || inputText.equals("-") || inputText.equals("×") || inputText.equals("÷")) { // 정규식 !!!!
				return;
			} 
			
			switch(button.getText().charAt(0)) { // 통일 (한줄로 가능) !!!!!
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
			inputText = button.getText();
			calculatorScreen.beforeInput.setHorizontalAlignment(JLabel.RIGHT);
			calculatorScreen.inputPanel.add(calculatorScreen.beforeInput);
			
			if(beforeInputTextAll.substring(beforeInputTextAll.length()-1).equals("=")) {
				if (inputTextAll.length() > 14) {
					calculatorScreen.currentInput.setFont(fontToSmall);
				}
				calculatorScreen.currentInput.setText(inputTextAll);
				calculatorScreen.currentInput.setHorizontalAlignment(JLabel.RIGHT);
				calculatorScreen.inputPanel.add(calculatorScreen.currentInput);
				if(inputTextAll != "0") {
					inputTextAll = inputTextAll.replaceAll(",", "");
				}
			}
			else {
				if (inputTextAll.length() > 14) {
					calculatorScreen.currentInput.setFont(fontToSmall);
				}
				if (beforeInputTextAll.substring(0, 1) != "0" && inputTextAll.equals("0")) {
					inputTextAll = decimalPoint.format(Double.parseDouble(beforeInputTextAll.substring(0, beforeInputTextAll.length() - 1)));
				}
				calculatorScreen.currentInput.setText(inputTextAll);
				calculatorScreen.currentInput.setHorizontalAlignment(JLabel.RIGHT);
				calculatorScreen.inputPanel.add(calculatorScreen.currentInput);
				inputTextAll = "0";
			}
		}
	}
	
	private class ClearButtonListener implements ActionListener { // 지우기 버튼 
		public void actionPerformed(ActionEvent e) {
			JButton button = (JButton)e.getSource();
			if(button.getText().equals("C")) { // 작은 글씨까지 삭제 
				beforeInputTextAll = "";
				inputTextAll = "0";
				calculatorScreen.beforeInput.setText(beforeInputTextAll);
				calculatorScreen.currentInput.setText(decimalPoint.format(Double.parseDouble(inputTextAll)));
				calculatorScreen.beforeInput.setFont(beforeFont);
			}
			else if (button.getText().equals("CE") && beforeInputTextAll.substring(beforeInputTextAll.length() - 1).equals("=")) { // 현재 입력값만 삭제 
				beforeInputTextAll = "";
				inputTextAll = "0";
				calculatorScreen.beforeInput.setText(beforeInputTextAll);
				calculatorScreen.currentInput.setText(decimalPoint.format(Double.parseDouble(inputTextAll)));
				calculatorScreen.beforeInput.setFont(beforeFont);
			}
			else if (button.getText().equals("CE")) {
				inputTextAll = "0";
				calculatorScreen.currentInput.setText(decimalPoint.format(Double.parseDouble(inputTextAll)));
			}
			else if (button.getText().equals("⌫")) { // 현재 입력값에서 하나씩 삭제 
				inputTextAll = inputTextAll.substring(0, inputTextAll.length() - 1);
				if (inputTextAll.length() == 0) {
					inputTextAll = "0";
				}
				calculatorScreen.currentInput.setText(decimalPoint.format(Double.parseDouble(inputTextAll)));
			}
			calculatorScreen.beforeInput.setHorizontalAlignment(JLabel.RIGHT);
			calculatorScreen.inputPanel.add(calculatorScreen.beforeInput);
		}
	}
	
	private boolean isNumber() {
		String input = inputTextAll.substring(0, inputTextAll.length()); // 연산자 전까지의 숫자 
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
			secondNumber = inputTextAll;
			System.out.println(secondNumber);
			calculation = new Calculation(firstNumber, secondNumber, operator, inputTextAll, beforeInputTextAll);
			
			System.out.println(beforeInputTextAll);
			System.out.println(inputTextAll);
			System.out.println(firstNumber);
			System.out.println(secondNumber);
			
			CalculationDTO calculationDTO = calculation.StartCalculatingBasic();
			inputTextAll = calculationDTO.getInput();
			firstNumber = calculationDTO.getFirstNumber();
			
			if(button.getText().equals("=")) {
				beforeInputTextAll += secondNumber; 
				beforeInputTextAll += "="; 
			}
			else {
				operator = button.getText();
				beforeInputTextAll = inputTextAll;
				beforeInputTextAll += button.getText();
				
			}
			
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
	private class LogButtonListener implements ActionListener {
		public void actionPerformed(ActionEvent e) {
			JButton button = (JButton)e.getSource();
			if (button.getIcon().equals(logButtonImage)) {
				
			}
		}
	}
	
	private class MouseButtonListener implements MouseListener {
		public void mouseEntered(MouseEvent e) {
			JButton button = (JButton)e.getSource();
			if (button.getIcon() == logButtonImage) {
				button.setOpaque(true);
				System.out.println("hi");
				button.setBackground(buttonColor);
			}
			for (int i=0;i<20;i++) {
				if (button.getText().equals("=")) {
					button.setOpaque(true);
					button.setBackground(equalButtonColor);
				}
				else if(button.getText().equals(calculatorButton.calculatorValue[i])) {
				button.setOpaque(true);
				button.setBackground(buttonColor);
			}	
			}
			
		}
		public void mouseExited(MouseEvent e) {
			JButton button = (JButton)e.getSource();
			if (button.getIcon() == logButtonImage) {
				calculatorButton.PaintColor();
			}
			for (int i=0;i<20;i++) {
				if(button.getText().equals(calculatorButton.calculatorValue[i])) {
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
