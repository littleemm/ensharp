package controller;
import model.*;

public class Calculation {
	private String inputTextAll;
	private String beforeInputTextAll;
	
	public Calculation(String inputTextAll, String beforeInputTextAll) {
		this.inputTextAll = inputTextAll;
		this.beforeInputTextAll = beforeInputTextAll;
	}
	
	public CalculationDTO CalculateWithOperator(String equalSign) { // 사칙연산 
		CalculationDTO calculationDTO = new CalculationDTO("", "");
		
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

		calculationDTO.setInput(resultString);
		calculationDTO.setBeforeInput(beforeInputTextAll);
		
		return calculationDTO;
	}
}
