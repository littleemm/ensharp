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
	private DecimalFormat basicFormat;
	
	private Exception exception;
	
	public Calculation(String firstNumber, String secondNumber, String operator, String inputTextAll, String beforeInputTextAll) {
		this.operator = operator;
		this.firstNumber = firstNumber;
		this.secondNumber = secondNumber;
		this.inputTextAll = inputTextAll;
		this.beforeInputTextAll = beforeInputTextAll;
		
		exception = new Exception();
		format = NumberFormat.getInstance();
		basicFormat = new DecimalFormat("################.################");
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
		
		if(resultString == Constant.WARNING_DIVIDE_0 || resultString == Constant.WARNING_DIVIDE_EMPTY) {
			calculationDTO.setInput(resultString);
			calculationDTO.setFirstNumber(resultString);
			return calculationDTO;
		}
		
		resultBig = eraseDecimalPoint(resultBig);
		if (resultBig.toPlainString().length() - resultBig.toPlainString().replace(String.valueOf('.'), "").length() == 1) {
			resultString = resultBig.toPlainString();
		}
		else {
		resultString = format.format(resultBig);
		}
		
		resultString = exception.modifyResult(resultString, firstNumber);
		
		System.out.println(resultString);
		calculationDTO.setInput(resultString);
		if (resultBig.toPlainString().length() - resultBig.toPlainString().replace(String.valueOf('.'), "").length() == 1 && resultBig.toPlainString().length() > 16) {
		calculationDTO.setFirstNumber(resultBig.toPlainString());
		}
		else {
		calculationDTO.setFirstNumber(basicFormat.format(resultBig));
		}
		return calculationDTO;
	}
	
	private void calculateEmptyMore() {
		String operatorBefore = beforeInputTextAll.substring(beforeInputTextAll.length() - 1); 
		if (operatorBefore == "+" || operatorBefore == "-" || operatorBefore == "×" || operatorBefore == "÷") {
			secondNumber = firstNumber;
			beforeInputTextAll = firstNumber;
			beforeInputTextAll += operatorBefore;
			inputTextAll = firstNumber;
		}
	}
	
	public CalculationDTO CalculateAgain() {
		CalculationDTO calculationDTO = new CalculationDTO("", "", "");
		System.out.println(inputTextAll);
		resultBig = new BigDecimal("0");
		firstBig = new BigDecimal(firstNumber);
		if (secondNumber.length() > 0) {
		secondBig = new BigDecimal(secondNumber);
		}
		if (inputTextAll.length() - inputTextAll.replace(String.valueOf('e'), "").length() == 1) {
			inputTextAllBig = new BigDecimal(firstNumber);
		}
		else {
			inputTextAllBig = new BigDecimal(inputTextAll);
		}
		System.out.println("inputTextAllBig" + inputTextAllBig.toPlainString());
		if (inputTextAll.substring(inputTextAll.indexOf("e") + 1).equals("9999")) {
			calculationDTO.setInput(Constant.WARNING_OVERFLOW);
			calculationDTO.setFirstNumber(Constant.WARNING_OVERFLOW);
			calculationDTO.setBeforeInput("");
		
			return calculationDTO;
		}
		
		firstBig = inputTextAllBig;
		
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
		case ('=') : {
			resultBig = firstBig;
		}
		}
		
		resultBig = eraseDecimalPoint(resultBig);
		String resultString = format.format(resultBig);
		if (inputTextAll.length() - inputTextAll.replace(String.valueOf('.'), "").length() == 1) {
			resultString = resultBig.toPlainString();
		}
		
		resultString = exception.modifyResult(resultString, firstNumber);
		
		if(resultString == Constant.WARNING_OVERFLOW) {
			calculationDTO.setInput(resultString);
			calculationDTO.setFirstNumber(resultString);
			calculationDTO.setBeforeInput("");
			return calculationDTO;
		}
		
		System.out.println(resultString + "hi");
		if (inputTextAll.length() - inputTextAll.replace(String.valueOf('e'), "").length() == 1) {
			firstBig = resultBig;
		}
		beforeInputTextAll = inputTextAll;
		beforeInputTextAll += operator;
		beforeInputTextAll += secondNumber;
		if(!operator.equals("=")) {
		beforeInputTextAll += "=";
		}
		System.out.println(firstBig.toString());
		calculationDTO.setInput(resultString);
		
		if (inputTextAll.length() - inputTextAll.replace(String.valueOf('.'), "").length() == 1 && inputTextAll.length() - inputTextAll.replace(String.valueOf('e'), "").length() == 1) {
			calculationDTO.setFirstNumber(firstBig.toPlainString());
		}
		else {
			calculationDTO.setFirstNumber(basicFormat.format(firstBig));
		}
		calculationDTO.setBeforeInput(beforeInputTextAll);
	
		return calculationDTO;
	}
	
	private BigDecimal eraseDecimalPoint(BigDecimal resultBig) {
		resultBig = resultBig.stripTrailingZeros();
		return resultBig;
	}
}
