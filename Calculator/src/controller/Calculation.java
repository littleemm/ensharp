package controller;
import model.*;

public class Calculation {
	private String inputTextAll;
	private String beforeInputTextAll;
	private String firstNumber;
	private String secondNumber;
	
	public Calculation(String firstNumber, String secondNumber, String inputTextAll, String beforeInputTextAll) {
		this.firstNumber = firstNumber;
		this.secondNumber = secondNumber;
		this.inputTextAll = inputTextAll;
		this.beforeInputTextAll = beforeInputTextAll;
	}
	
	public CalculationDTO CalculateWithOperator(String equalSign) { // 사칙연산 
		CalculationDTO calculationDTO = new CalculationDTO("", "", "");
		System.out.println(firstNumber);
		double result = 0.0;
		double beforeInputNumber = 0.0;
		String operator = beforeInputTextAll.substring(beforeInputTextAll.length() - 1);
		char beforeOperator = beforeInputTextAll.charAt(firstNumber.length());
		System.out.println(beforeOperator);
		if(operator == "=" && beforeOperator != '+' && beforeOperator != '-' && beforeOperator != '×' && beforeOperator != '÷') {
			beforeInputNumber = Double.parseDouble(beforeInputTextAll.substring(0,beforeInputTextAll.length()-1));
		}
		double inputNumber = Double.parseDouble(inputTextAll);
		double secondNumberDouble = Double.parseDouble(secondNumber);
		
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
		else if (operator.equals("=")) {
			result = isBeforeInputOperationEqualSign(beforeOperator, inputNumber, secondNumberDouble, beforeInputNumber);
		}

		if (equalSign.equals("=") && operator != "=") {
		
			beforeInputTextAll += inputTextAll;
			beforeInputTextAll += "=";
		}
		String resultString = Double.toString(result);
		if (resultString.substring(resultString.length() - 1).equals("0")) {
			resultString = Integer.toString((int)result);
		}
		System.out.println(resultString);

		calculationDTO.setInput(resultString);
		calculationDTO.setBeforeInput(beforeInputTextAll);
		calculationDTO.setFirstNumber(Double.toString(inputNumber));
		
		return calculationDTO;
	}
	
	private double isBeforeInputOperationEqualSign(char beforeOperator, double inputNumber, double secondNumberDouble, double beforeInputNumber) {
		if (beforeInputNumber == 0.0) {
			return findOperationSign(beforeOperator, inputNumber, secondNumberDouble);
		}
		else {
			return inputNumber;
		}
	}
	
	private double findOperationSign(char beforeOperator, double inputNumber, double secondNumberDouble) {
		switch(beforeOperator) {
		case ('+'): {
			return inputNumber + secondNumberDouble;
		}
		case ('-'): {
			return inputNumber - secondNumberDouble;
		}
		case ('×'): {
			return inputNumber * secondNumberDouble;
		}
		case ('÷'): {
			return inputNumber / secondNumberDouble;
		}
		default: {
			return 0.0;
		}
		}
	}
}
