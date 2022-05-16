package controller;
import model.*;

public class Calculation {
	String operator;
	String firstNumber;
	String secondNumber;
	String inputTextAll;
	String beforeInputTextAll;
	
	public Calculation(String firstNumber, String secondNumber, String operator, String inputTextAll, String beforeInputTextAll) {
		this.operator = operator;
		this.firstNumber = firstNumber;
		this.secondNumber = secondNumber;
		this.inputTextAll = inputTextAll;
		this.beforeInputTextAll = beforeInputTextAll;
	}
	
	public String StartCalculatingBasic() {
		double result = 0.0;
		double firstNumberDouble = Double.parseDouble(firstNumber);
		double secondNumberDouble = Double.parseDouble(secondNumber);

		switch(operator.charAt(0)) {
		case ('+') : {
			result = firstNumberDouble + secondNumberDouble;
			System.out.println(result);
			break;
		}
		case ('-') : {
			result = firstNumberDouble - secondNumberDouble;
			break;
		}
		case ('×') : {
			result = firstNumberDouble * secondNumberDouble;
			break;
		}
		case ('÷') : { 
			result = firstNumberDouble / secondNumberDouble;
			break;
		}
		case ('=') : { // 0 = 0
			result = firstNumberDouble;
			break;
		}
		}
		
		String resultString = Double.toString(result);
		if (resultString.substring(resultString.length() - 1).equals("0")) {
			resultString = Integer.toString((int)result);
		}
		System.out.println(resultString);

		return resultString;
	}
	
	public CalculationDTO CalculateAgain() {
		CalculationDTO calculationDTO = new CalculationDTO("", "", "");
		double result = 0.0;
		double firstNumberDouble = Double.parseDouble(firstNumber);
		double secondNumberDouble = Double.parseDouble(secondNumber);
		double inputTextNumber = Double.parseDouble(inputTextAll);
		firstNumberDouble = inputTextNumber;
		
		switch(operator.charAt(0)) {
		case ('+') : {
			result = firstNumberDouble + secondNumberDouble;
			break;
		}
		case ('-') : {
			result = firstNumberDouble - secondNumberDouble;
			break;
		}
		case ('×') : {
			result = firstNumberDouble * secondNumberDouble;
			break;
		}
		case ('÷') : { 
			result = firstNumberDouble / secondNumberDouble;
			break;
		}
		}
		
		String resultString = Double.toString(result);
		if (resultString.substring(resultString.length() - 1).equals("0")) {
			resultString = Integer.toString((int)result);
		}
		System.out.println(resultString);
		
		beforeInputTextAll = inputTextAll;
		beforeInputTextAll += operator;
		beforeInputTextAll += secondNumber;
		beforeInputTextAll += "=";
		
		calculationDTO.setInput(resultString);
		calculationDTO.setFirstNumber(Double.toString(firstNumberDouble));
		calculationDTO.setBeforeInput(beforeInputTextAll);
	
		return calculationDTO;
	}
	
}
