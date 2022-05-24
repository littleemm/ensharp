package controller;
import utility.Constant;

import java.util.regex.Pattern;
import java.text.*;
import java.awt.Color;
import java.awt.Component;
import java.awt.Font;
import java.awt.GridBagConstraints;
import java.awt.GridBagLayout;
import java.awt.event.*;
import javax.swing.*;
import java.math.*;
import model.CalculationLogDTO;
import model.CalculationDTO;
import view.CalculatorButton;
import view.CalculatorScreen;
import view.LogPage;

public class ButtonActionListener {
	private String inputText; // 현재 눌린 값  
	private String inputTextBefore;
	private String inputTextAll; // 연산자가 입력되기 전까지 입력된 숫자 전체 
	private String beforeInputTextAll; // 숫자 + 연산자가 저장되어 있는, 이전에 입력된 값 
	private String firstNumber;
	private String operator;
	private String secondNumber;
	private String secondNegate;
	private Boolean shift;
	
	private CalculatorScreen calculatorScreen;
	private CalculatorButton calculatorButton;
	private Calculation calculation;
	private LogPage logPage;
	private CalculationLogDTO logDTO;
	
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
	
	private GridBagLayout layout;
	private GridBagConstraints constraint;
	private ButtonActionListener listener;
	
	private int count;
	
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
		font = new Font("맑은 고딕", Font.BOLD, 38);
		fontToSmall = new Font("맑은 고딕 Bold", Font.BOLD, 30);
		logButtonImage = new ImageIcon("src/image/logButton.png");
		logPage = new LogPage();
		logDTO = new CalculationLogDTO("3+4=", "7");
		inputTextBefore = "";
		inputText = "";
		operator = "";
		firstNumber = "";
		secondNumber = "";
		secondNegate = "";
		shift = false;
		count = 0;
		format = NumberFormat.getInstance();
		decimalPoint = new DecimalFormat("#,###,###,###,###,###.################");
		decimalPointSmall = new DecimalFormat("###,###");
		basicNumber = new DecimalFormat("################.################");
		
		layout = new GridBagLayout();
		constraint = new GridBagConstraints();
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
		calculatorButton.logButton.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				JButton button = (JButton)e.getSource();
					mainFrame.setLayout(layout);
					mainFrame.setVisible(true);
					logPage.PrintLogList(logDTO);
					calculatorButton.buttonPanel.setVisible(false);
					//calculatorScreen.inputPanel.setVisible(false);
					//calculatorButton.logButtonPanel.setVisible(false);
					//gridBagInsert(mainFrame, calculatorButton.logButtonPanel, 0, 0, 0, 1, 1);
					//gridBagInsert(mainFrame, calculatorScreen.inputPanel, 0, 1, 0, 2, 3);
					gridBagInsert(mainFrame, logPage.logPanel, 0, 5, 0, 5, 5);
			}
		});
		
		mainFrame.addKeyListener(new NumberKeyListener());
		mainFrame.setFocusable(true);
		mainFrame.requestFocus();
	}
	
	private void gridBagInsert(JFrame mainFrame, Component component, int x, int y, int width, int height, int y1) {
        constraint.fill= GridBagConstraints.BOTH;
        constraint.weightx=1;
	    constraint.weighty=y1;
        constraint.gridx = x;
        constraint.gridy = y;
        constraint.gridwidth = width;
        constraint.gridheight = height;
        layout.setConstraints(component, constraint);
        mainFrame.add(component);
        mainFrame.setVisible(true);
}
	
	private class NumberKeyListener extends KeyAdapter {
		public void keyPressed(KeyEvent e) {
			int key = e.getKeyCode();
			int keyForInput = key - 48;
			String keyCodeText = Integer.toString(key);
			
			if (keyCodeText.equals(Constant.SHIFT_CODE)) {
				shift = true;
			}
			if (shift && keyCodeText.equals(Constant.NUMBER8_CODE)) {
				keyCodeText = Constant.MULTIPLY_CODE;
				recognizeOperator(keyCodeText);
				shift = false;
				return;
			}
			else if (shift && keyCodeText.equals(Constant.EQUALSIGN_CODE)) {
				keyCodeText = Constant.ADD_CODE;
				recognizeOperator(keyCodeText);
				shift = false;
				return;
			}
			shift = false;
			numberInput(Integer.toString(keyForInput));
			recognizeOperator(keyCodeText);
			recognizeClearSign(keyCodeText);
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
		
		if (beforeInputOperatorPart.equals("=") || firstNumber.equals(Constant.WARNING_DIVIDE_0) || firstNumber.equals(Constant.WARNING_DIVIDE_EMPTY)) {
			inputTextAll = "0";
			firstNumber = "";
			beforeInputTextAll = "";
			operator = "";
			secondNegate = "";
			calculatorScreen.beforeInput.setText(beforeInputTextAll);
			calculatorScreen.beforeInput.setHorizontalAlignment(JLabel.RIGHT);
			//calculatorScreen.inputPanel.add(calculatorScreen.beforeInput);
		}
	
		for (int i=0;i<12;i++) {
			if((text.equals(calculatorButton.screenValue[i])) && isNumber()) {
				inputTextBefore = inputText;
				inputText = text; // 현재 눌린 숫자 
				System.out.println(inputText);
				if (inputText.equals("+/-")) {
					ShowPositiveOrNegative();
				}
				else if (inputTextAll.equals("0")) {
					ShowFirstInput();
				}
				else if (inputText.equals(".")) {
					showPeriod();
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
		
		if ((text.equals(Constant.SPACE_CODE_CHANGED) || text.equals(Constant.F9_CODE_CHANGED)) && isNumber()) { // 키보드로 스페이스(부호키) 입력됐을 경우 
			inputText = text;
			ShowPositiveOrNegative();
		}
		
		if((text.equals(Constant.PERIOD_CODE)) && isNumber()) {
			inputText = text;
			if (inputTextAll.equals("0")) {
				ShowFirstInput();
			}
			else {
				inputText = ".";
				inputTextAll += inputText;
			}
		}
		
		System.out.println(inputTextAll);
		System.out.println("beforeInputtextAll:" + beforeInputTextAll);
		// 큰 숫자 부분 
		if (beforeInputTextAll.length() > 0 && beforeInputTextAll.substring(0, 1).equals("n") || secondNegate.length() - secondNegate.replace(String.valueOf('n'), "").length() > 0) {
			calculatorScreen.currentInput.setHorizontalAlignment(JLabel.RIGHT);
			calculatorScreen.beforeInput.setText(beforeInputTextAll);
			if (inputTextAll != "0" && inputTextAll.length() - inputTextAll.replace(String.valueOf('.'), "").length() == 1) {
				calculatorScreen.currentInput.setText(decimalPoint.format(new BigDecimal(inputTextAll.substring(0, inputTextAll.indexOf(".")))) + inputTextAll.substring(inputTextAll.indexOf(".")));
			}
			else if (inputTextAll != "0") {
				calculatorScreen.currentInput.setText(decimalPoint.format(new BigDecimal(inputTextAll)));
			}
		}
		else {
			if (inputTextAll.length() - inputTextAll.replace(String.valueOf('.'), "").length() == 1) {
				calculatorScreen.currentInput.setText(decimalPoint.format(new BigDecimal(inputTextAll.substring(0, inputTextAll.indexOf(".")))) + inputTextAll.substring(inputTextAll.indexOf(".")));
				calculatorScreen.beforeInput.setText(beforeInputTextAll);
			}
			else {
				calculatorScreen.currentInput.setText(decimalPoint.format(new BigDecimal(inputTextAll))); 
			}
		}
		
		calculatorScreen.currentInput.setFont(font); 
		if (inputTextAll.length() > 14) {
			calculatorScreen.currentInput.setFont(fontToSmall);
		}
		calculatorScreen.currentInput.setHorizontalAlignment(JLabel.RIGHT); // 오른쪽에서부터 숫자 시작 
		//calculatorScreen.inputPanel.add(calculatorScreen.currentInput);
		count++;
	}
	
	private class OperationButtonListener implements ActionListener { // 연산자 버튼 
		public void actionPerformed(ActionEvent e) {
			JButton button = (JButton)e.getSource();
			String buttonText = button.getText();
			
			recognizeOperator(buttonText);
		}
	}
	
	private void recognizeOperator(String text) {
		String operatorPattern = "^[+×÷-]{1}$";
		String equalSignPattern = "^[=]{1}$";
		boolean regex = Pattern.matches(operatorPattern, text);
		boolean regexEqual = Pattern.matches(equalSignPattern, text);
	
		//if (inputText.equals("+") || inputText.equals("-") || inputText.equals("×") || inputText.equals("÷")) { // 정규식 !!!!
		//	return;
		//} 

		//if(beforeInputTextAll.length() > 0 && beforeInputTextAll.substring(beforeInputTextAll.length() - 1).equals("=")) {
		//	beforeInputTextAll = "";
		//} 왜 필요한걸까 
		
		if(inputTextAll.equals(Constant.WARNING_DIVIDE_0) || inputTextAll.equals(Constant.WARNING_DIVIDE_EMPTY) || inputTextAll.equals(Constant.WARNING_OVERFLOW)) {
			if (text.equals("=")) {
				beforeInputTextAll = "";
				inputTextAll = "0";
				operator = "";
				inputText = "";
				secondNegate = "";
				calculatorScreen.beforeInput.setText(beforeInputTextAll);
				calculatorScreen.beforeInput.setHorizontalAlignment(JLabel.RIGHT);
				calculatorScreen.currentInput.setText(inputTextAll);
				return;
			}
			else {
				return;
			}
		}
		
		if(regex || text.equals(Constant.MULTIPLY_CODE) || text.equals(Constant.ADD_CODE) 
				|| text.equals(Constant.SUBTRACT_CODE) || text.equals(Constant.DIVIDE_CODE)) {
			
			if(text.equals(Constant.MULTIPLY_CODE)) {
				text = "×";
			}
			else if (text.equals(Constant.ADD_CODE)) {
				text ="+";
			}
			else if (text.equals(Constant.SUBTRACT_CODE)) {
				text = "-";
			}
			else if (text.equals(Constant.DIVIDE_CODE)) {
				text = "÷";
			}
			
			AddOperator(text);
		}
		else if (regexEqual || text.equals(Constant.ENTER_CODE_MAC) || text.equals(Constant.ENTER_CODE_WINDOW) || text.equals(Constant.EQUALSIGN_CODE)) {
			text = "=";
			IdentifyEqualSign(text);
		}
		
		inputText = text;
		calculatorScreen.beforeInput.setHorizontalAlignment(JLabel.RIGHT);
		//calculatorScreen.inputPanel.add(calculatorScreen.beforeInput);
		
		if(beforeInputTextAll.substring(beforeInputTextAll.length()-1).equals("=")) {
			if (inputTextAll.length() > 14) {
				calculatorScreen.currentInput.setFont(fontToSmall);
			}
			
			if (inputTextAll.equals(Constant.WARNING_DIVIDE_0) || inputTextAll.equals(Constant.WARNING_DIVIDE_EMPTY) 
					|| inputTextAll.length() - inputTextAll.replace(String.valueOf('e'), "").length() == 1) {
				calculatorScreen.currentInput.setText(inputTextAll);
			}
			else if (inputTextAll.equals(Constant.WARNING_OVERFLOW)) {
				calculatorScreen.currentInput.setText(inputTextAll);
				calculatorScreen.beforeInput.setText(beforeInputTextAll);
			}
			else {
				inputTextAllBig = new BigDecimal(inputTextAll).stripTrailingZeros();
				calculatorScreen.currentInput.setText(decimalPoint.format(inputTextAllBig));
			}
			calculatorScreen.currentInput.setHorizontalAlignment(JLabel.RIGHT);
			//calculatorScreen.inputPanel.add(calculatorScreen.currentInput);
			
			if (inputTextAll != "0") {
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
			
			if (inputTextAll.equals(Constant.WARNING_DIVIDE_0) || inputTextAll.equals(Constant.WARNING_DIVIDE_EMPTY)) {
				calculatorScreen.currentInput.setText(inputTextAll);
			}
			else if (inputTextAll.substring(0,1).equals("n")) {
				int signCount = inputTextAll.length() - inputTextAll.replace(String.valueOf("n"), "").length();
				if (signCount % 2 == 0) {
					calculatorScreen.currentInput.setText(inputTextAll);
				}
			}
			else {
				inputTextAllBig = new BigDecimal(inputTextAll).stripTrailingZeros();
				calculatorScreen.currentInput.setText(decimalPoint.format(inputTextAllBig));
			}
			
			calculatorScreen.currentInput.setHorizontalAlignment(JLabel.RIGHT);
			//calculatorScreen.inputPanel.add(calculatorScreen.currentInput);
			inputTextAll = "0";
		}
	}
	
	private class ClearButtonListener implements ActionListener { // 지우기 버튼 
		public void actionPerformed(ActionEvent e) {
			JButton button = (JButton)e.getSource();
			String buttonText = button.getText();
			
			recognizeClearSign(buttonText);
		}
	}
	
	private void recognizeClearSign(String text) {
		if(text.equals("C") || text.equals(Constant.ESC_CODE) || text.equals(Constant.SPACE_CODE)) { // 작은 글씨까지 삭제 
			beforeInputTextAll = "";
			inputTextAll = "0";
			operator = "";
			secondNegate = "";
			calculatorScreen.beforeInput.setText(beforeInputTextAll);
			calculatorScreen.currentInput.setText(decimalPoint.format(Double.parseDouble(inputTextAll)));
			calculatorScreen.beforeInput.setFont(beforeFont);
		}
		else if ((text.equals("CE") || text.equals(Constant.DELETE_CODE)) && beforeInputTextAll.substring(beforeInputTextAll.length() - 1).equals("=")) { // 현재 입력값만 삭제 
			beforeInputTextAll = "";
			inputTextAll = "0";
			operator = "";
			secondNegate = "";
			calculatorScreen.beforeInput.setText(beforeInputTextAll);
			calculatorScreen.currentInput.setText(decimalPoint.format(Double.parseDouble(inputTextAll)));
			calculatorScreen.beforeInput.setFont(beforeFont);
		}
		else if (text.equals("CE") || text.equals(Constant.DELETE_CODE)) {
			inputTextAll = "0";
			calculatorScreen.currentInput.setText(decimalPoint.format(Double.parseDouble(inputTextAll)));
		}
		else if (text.equals("⌫") || text.equals(Constant.BACKSPACE_CODE)) { // 현재 입력값에서 하나씩 삭제 
			inputTextAll = inputTextAll.substring(0, inputTextAll.length() - 1);
			if (inputTextAll.length() == 0) {
				inputTextAll = "0";
			}
			calculatorScreen.currentInput.setText(decimalPoint.format(Double.parseDouble(inputTextAll)));
		}
		calculatorScreen.beforeInput.setHorizontalAlignment(JLabel.RIGHT);
		//calculatorScreen.inputPanel.add(calculatorScreen.beforeInput);
		//calculatorScreen.inputPanel.add(calculatorScreen.currentInput);
	}
	
	private boolean isNumber() {
		String input = inputTextAll.substring(0, inputTextAll.length()); // 연산자 전까지의 숫자 
		int numberCount = 0;
		if (inputTextAll.length() - inputTextAll.replace(String.valueOf('.'), "").length() == 1 && inputTextAll.substring(0,1).equals("0")) {
			numberCount = -1;
		}
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

		String operatorPattern = "^[+×÷=-]{1}$";
		Boolean regex = Pattern.matches(operatorPattern, inputTextBefore);
		String sign = inputTextAll.substring(0,1); // 부호 
		if(count == 0 && inputTextAll.equals("0")) {
			beforeInputTextAll = "0";
		}
		
		if (beforeInputTextAll.length() > 0 && ((count == 0 && inputTextAll.equals("0")) || beforeInputTextAll.substring(0, 1).equals("n"))) { // negate는 계산기 처음 시작할 때 아무 값도 안눌렀을 때 기능함 
			beforeInputTextAll = String.format("negate(%s)", beforeInputTextAll);
			firstNumber = "0";
		}
		else if (beforeInputTextAll.length() > 0 && operator.length() > 0 && (inputTextBefore.equals("+/-") || regex)) {
			System.out.println("now" + inputTextAll);
			if (secondNegate.length() == 0) {
				secondNegate = String.format("negate(%s)", firstNumber);
				beforeInputTextAll += secondNegate;
			}
			else {
				String beforeSecondNegate = secondNegate;
				secondNegate = String.format("negate(%s)", secondNegate);
				beforeInputTextAll = beforeInputTextAll.replace(beforeSecondNegate, secondNegate);
			}
			
			
			if((secondNegate.length() - secondNegate.replace(String.valueOf('n'), "").length()) % 2 == 0) {
				secondNumber = firstNumber;
			}
			else {
				secondNumber = String.format("-%s", firstNumber);
			}
			
			inputTextAll = secondNumber;
		}
		else if(sign.equals("-")) { // 부호 버튼 (+) 처리 
			inputTextAll = inputTextAll.substring(1);
		}
		else {  // 부호 버튼 (-) 처리 
			String conversion = "-";
			conversion += inputTextAll;
			inputTextAll = conversion;
		}
	}
	
	private void showPeriod() {
		System.out.println("text:" + inputTextBefore);
		if(inputTextBefore.equals(".")) {
			return;
		}
		
		if (inputTextBefore.equals("+/-")) {
			beforeInputTextAll = beforeInputTextAll.replace(secondNegate, "");
			inputTextAll = "0.";
			secondNumber = "0";
			secondNegate = "";
		}
		//inputTextAll = "";
		else {
		inputTextAll += inputText;
		}
	}
	
	private void ShowFirstInput() {
		if (inputText.equals(".") || inputText.equals(Constant.PERIOD_CODE)) {  // 소수점 입력 처리 
			inputText = ".";
			inputTextAll += inputText; 
			System.out.println("period!");
		}
		else { 
			inputTextAll = "";
			inputTextAll += inputText; 
		} 
	}
	
	private void IdentifyEqualSign(String text) {
		System.out.println("operator:" + operator);
		System.out.println(beforeInputTextAll);
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
			AddOperator(text);
		}
	}
	
	private void AddOperator(String text) { // 수행된 값을 바탕으로 오른쪽에 연산자 추가  
		if (beforeInputTextAll.length() > 0) { // 숫자 + 연산자 조합의 입력값이 존재할 경우 
			if (inputText == "+" || inputText == "-" || inputText == "×" || inputText == "÷" || inputText == "=") {
				inputTextAll = "";
			}
			secondNumber = inputTextAll;
			System.out.println(secondNumber);
			
			System.out.println("before" + beforeInputTextAll);
			System.out.println("inputAll" + inputTextAll);
			System.out.println(firstNumber);
			System.out.println("second" + secondNumber);
			
			String operatorBefore = beforeInputTextAll.substring(beforeInputTextAll.length() - 1); 
			if (text.equals("=") && secondNumber.equals("") && (operatorBefore.equals("+") || operatorBefore.equals("-") 
					|| operatorBefore.equals("×") || operatorBefore.equals("÷"))) {
				secondNumber = firstNumber;
				beforeInputTextAll = firstNumber;
				beforeInputTextAll += operatorBefore;
				inputTextAll = firstNumber;
				//IdentifyEqualSign(text);
				//return;
			}
			calculation = new Calculation(firstNumber, secondNumber, operator, inputTextAll, beforeInputTextAll);
			
			CalculationDTO calculationDTO = calculation.StartCalculatingBasic();
			inputTextAll = calculationDTO.getInput();
			firstNumber = calculationDTO.getFirstNumber();
	
			if(text.equals("=")) {
				secondBig = new BigDecimal(secondNumber).stripTrailingZeros();
				if (secondNumber.length() - secondNumber.replace(String.valueOf('.'), "").length() == 1) {
					secondNumber = secondBig.toPlainString().replaceAll(",", "");	
				}
				else {
					secondNumber = format.format(secondBig).replaceAll(",", "");
				}
				beforeInputTextAll += secondNumber; 
				beforeInputTextAll += "="; 
			}
			else {
				operator = text;
				
				if(inputTextAll.equals(Constant.WARNING_DIVIDE_0) || inputTextAll.equals(Constant.WARNING_DIVIDE_EMPTY) ) {
					
				}
				else {
				String inputTextAllTemporary = inputTextAll;
				inputTextAllBig = new BigDecimal(inputTextAll).stripTrailingZeros();
				if (inputTextAll.length() - inputTextAll.replace(String.valueOf('.'), "").length() == 1) {
					inputTextAll = inputTextAllBig.toPlainString().replaceAll(",", "");	
				}
				else {
					inputTextAll = format.format(inputTextAllBig).replaceAll(",", "");
				}
				
				beforeInputTextAll = inputTextAll;
				beforeInputTextAll += text;	
				inputTextAll = inputTextAllTemporary;
				}
			}
			
			calculatorScreen.beforeInput.setText(beforeInputTextAll);
			calculatorScreen.beforeInput.setFont(beforeFont);
			
			System.out.println(beforeInputTextAll);
			System.out.println(inputTextAll);
			System.out.println(firstNumber);
		}
		else {
			operator = text;
			
			if(inputTextAll.substring(0,1).equals("n")) {
				
			}
			
			if (!inputTextAll.substring(0, 1).equals("n")) {
				firstNumber = inputTextAll;
				inputTextAllBig = new BigDecimal(inputTextAll).stripTrailingZeros();
				inputTextAll = inputTextAllBig.toPlainString().replaceAll(",", "");	
			}
			
			System.out.println("input!" + inputTextAll);
			
			beforeInputTextAll = inputTextAll; 
			beforeInputTextAll += operator; 
			
			System.out.println("before!" + beforeInputTextAll);
			
			inputTextAll = firstNumber;
			inputText = operator; // 나중에 마지막 입력 버튼 값을 알아야하는 때를 위해 저장 
			
			calculatorScreen.beforeInput.setText(beforeInputTextAll);
			calculatorScreen.beforeInput.setFont(beforeFont);
			//inputTextAll = "0"; // 입력값 초기화 
		}
	}
	
	private class MouseButtonListener implements MouseListener {
		public void mouseEntered(MouseEvent e) {
			JButton button = (JButton)e.getSource();
			if (button.getText().equals(".")) {
				button.setOpaque(true);
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
			if (button.getText().equals(".")) {
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
