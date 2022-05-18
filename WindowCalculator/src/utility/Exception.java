package utility;
import java.text.*;
import java.math.*;

public class Exception {
	private NumberFormat format;
	
	public Exception() {
		format = NumberFormat.getInstance();
	}
	
	public String DivideByZero(BigDecimal firstNumber, BigDecimal secondNumber) {
		String resultString = "";
		BigDecimal result = new BigDecimal("0");
		String firstString = format.format(firstNumber);
		String secondString = format.format(secondNumber);
		
		try {
			result = firstNumber.divide(secondNumber, MathContext.DECIMAL128);
			System.out.println("DIVIDE SUCCESS");
			format.setMaximumFractionDigits(16);
			format.setRoundingMode(RoundingMode.HALF_EVEN);
			resultString = format.format(result);
			
		}catch(ArithmeticException e) {
			resultString = "0으로 나눌 수 없습니다";
			System.out.println("hi");
		}
		
		return resultString;
	}
}
