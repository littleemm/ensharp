package utility;
import model.*;
import java.text.*;
import java.math.*;

public class Exception {
	private NumberFormat format;
	private DecimalFormat decimalFormat;
	
	public Exception() {
		format = NumberFormat.getInstance();
		decimalFormat = new DecimalFormat("#.################");
	}
	
	public CalculationDTO DivideByZero(BigDecimal firstNumber, BigDecimal secondNumber) {
		String resultString = "";
		BigDecimal result = new BigDecimal("0");
		CalculationDTO calculationDTO = new CalculationDTO(new BigDecimal("0"),"");
		
		if(isEmpty(firstNumber)) {
			resultString = "정의되지 않은 결과입니다.";
			calculationDTO.setWarningMessage(resultString);
			return calculationDTO;
		}
		
		try {
			result = firstNumber.divide(secondNumber, MathContext.DECIMAL128);
			System.out.println("DIVIDE SUCCESS");
			format.setMaximumFractionDigits(16);
			format.setRoundingMode(RoundingMode.HALF_EVEN);
			calculationDTO.setResultBig(result);
			
		}catch(ArithmeticException e) {
			resultString = "0으로 나눌 수 없습니다";
			calculationDTO.setWarningMessage(resultString);
		}
		
		return calculationDTO;
	}
	
	private Boolean isEmpty(BigDecimal firstNumber) {
		int firstInteger = Integer.parseInt(firstNumber.toString());
		System.out.println("firstInteger" + firstInteger);
		if (firstInteger == 0) {
			return true;
		}
		return false;
	}
	
	public String modifyResult(String resultString, String firstNumber) {
		resultString = resultString.replaceAll(",", "");
		BigDecimal resultBig;
		System.out.println(resultString + "string");
		if(resultString.length()-1 >= 10000) {
			return "오버플로";
		}
		
		if (resultString.length() > 16 && !isDecimalPoint(resultString)) {
			resultBig = new BigDecimal(resultString);
			System.out.println(resultBig.toString());
			String point = squareDecimal(resultString);
			System.out.println(point);
			System.out.println(new BigDecimal(point));
			resultBig = resultBig.multiply(new BigDecimal(point), MathContext.DECIMAL64);
			int resultInteger = (int)(resultString.length()-1);
			
			resultString = resultBig.toString() + "e+" + Integer.toString(resultInteger);
			System.out.println(resultString);
		}
		else if (firstNumber.indexOf("0.") >= 0 && resultString.substring(resultString.indexOf(".") + 1).length() > 16 && isDecimalPoint(resultString)) {
			resultBig = new BigDecimal(resultString);
			System.out.println(resultBig.toString());
			String point = squareTen(resultString);
			System.out.println(point);
			System.out.println(new BigDecimal(point));
			resultBig = resultBig.multiply(new BigDecimal(point), MathContext.DECIMAL64);
			int resultInteger = (int)(resultString.length()-2);
			
			resultString = resultBig.stripTrailingZeros().toString() + "e-" + Integer.toString(resultInteger);
			if (resultBig.toString().indexOf(".") != -1 && resultString.indexOf(".") == -1) {
				resultString = resultBig.stripTrailingZeros().toString() + "." + "e-" + Integer.toString(resultInteger);
			}
			System.out.println(resultString);
		}
		
		return resultString;
	}
	private String squareTen(String resultString) {
		BigDecimal result = new BigDecimal("10");
		BigDecimal decimal = new BigDecimal("10");
		for (int i=0;i < resultString.substring(resultString.indexOf(".") + 1).length() - 1;i++) {
			result = decimal.multiply(result, MathContext.DECIMAL64); 
		}
		return result.toString();
	}
	
	private String squareDecimal(String resultString) {
		BigDecimal result = new BigDecimal("0.1");
		BigDecimal decimal = new BigDecimal("0.1");
		for (int i=0;i < resultString.length() - 2;i++) {
			result = decimal.multiply(result, MathContext.DECIMAL64); 
		}
		return result.toString();
	}
	
	private Boolean isDecimalPoint(String resultString) {
		for (int i=0;i<resultString.length();i++) {
			if (resultString.charAt(i) == '.') {
				return true;
			}
		}
		return false;
	}
}
