package controller;
import model.*;
import java.math.*;
import java.text.*;
import utility.Constant;
import utility.Exception;

public class Calculation {
	String operator;
	String firstNumber;
	String secondNumber;
	String inputTextAll;
	String beforeInputTextAll;
	
	private BigDecimal resultBig;
	private BigDecimal firstBig;
	private BigDecimal secondBig;
	private BigDecimal inputTextAllBig;
	private BigDecimal beforeInputTextAllBig;
	private NumberFormat format;
	//private DecimalFormat format;
	
	private Exception exception;
	
	public Calculation(String firstNumber, String secondNumber, String operator, String inputTextAll, String beforeInputTextAll) {
		this.operator = operator;
		this.firstNumber = firstNumber;
		this.secondNumber = secondNumber;
		this.inputTextAll = inputTextAll;
		this.beforeInputTextAll = beforeInputTextAll;
		
		exception = new Exception();
		format = NumberFormat.getInstance();
		//format = new DecimalFormat("#,###,###,###,###,###.################");
	}
	
	public CalculationDTO StartCalculatingBasic() {
		CalculationDTO calculationDTO = new CalculationDTO("", "", "");
		resultBig = new BigDecimal("0");
		firstBig = new BigDecimal(firstNumber);
		secondBig = new BigDecimal(secondNumber);
		String resultString = "";
		
		switch(operator.charAt(0)) {
		case ('+') : {
			resultBig = firstBig.add(secondBig);
			break;
		}
		case ('-') : {
			resultBig = firstBig.subtract(secondBig);
			break;
		}
		case ('×') : {
			resultBig = firstBig.multiply(secondBig, MathContext.DECIMAL128);
			format.setMaximumFractionDigits(15);
			format.setRoundingMode(RoundingMode.HALF_EVEN);
			break;
		}
		case ('÷') : { 
			CalculationDTO exceptionDTO = exception.DivideByZero(firstBig, secondBig);
			format.setMaximumFractionDigits(16);
			format.setRoundingMode(RoundingMode.HALF_EVEN);
			
			resultBig = exceptionDTO.getResultBig();
			resultString = exceptionDTO.getWarningMessage();
			break;
		}
		case ('=') : { // 0 = 0
			resultBig = firstBig;
			resultString = format.format(resultBig);
			break;
		}
		}
		
		if(resultString == Constant.WARNING_DIVIDE_0) {
			calculationDTO.setInput(resultString);
			calculationDTO.setFirstNumber(resultString);
			return calculationDTO;
		}
		
		resultString = eraseDecimalPoint(resultBig);

		calculationDTO.setInput(resultString);
		calculationDTO.setFirstNumber(resultString);
		
		return calculationDTO;
	}
	
	public CalculationDTO CalculateAgain() {
		CalculationDTO calculationDTO = new CalculationDTO("", "", "");
		resultBig = new BigDecimal("0");
		firstBig = new BigDecimal(firstNumber);
		secondBig = new BigDecimal(secondNumber);
		inputTextAllBig = new BigDecimal(inputTextAll);
		firstBig= inputTextAllBig;
		
		switch(operator.charAt(0)) {
		case ('+') : {
			resultBig = firstBig.add(secondBig);
			break;
		}
		case ('-') : {
			resultBig = firstBig.subtract(secondBig);
			break;
		}
		case ('×') : {
			resultBig = firstBig.multiply(secondBig);
			break;
		}
		case ('÷') : { 
			resultBig = firstBig.divide(secondBig);
			break;
		}
		}
		
		String resultString = eraseDecimalPoint(resultBig);
		System.out.println(resultString + "hi");
		
		beforeInputTextAll = inputTextAll;
		beforeInputTextAll += operator;
		beforeInputTextAll += secondNumber;
		beforeInputTextAll += "=";
		
		calculationDTO.setInput(resultString);
		calculationDTO.setFirstNumber(format.format(firstBig));
		calculationDTO.setBeforeInput(beforeInputTextAll);
	
		return calculationDTO;
	}
	
	private String eraseDecimalPoint(BigDecimal resultBig) {
		String resultString = format.format(resultBig);
		resultBig = resultBig.stripTrailingZeros();
		resultString = format.format(resultBig);
		return resultString;
	}
}
