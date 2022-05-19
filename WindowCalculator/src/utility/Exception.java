package utility;
import model.*;
import java.text.*;
import java.math.*;

public class Exception {
	private NumberFormat format;
	
	public Exception() {
		format = NumberFormat.getInstance();
	}
	
	public CalculationDTO DivideByZero(BigDecimal firstNumber, BigDecimal secondNumber) {
		String resultString = "";
		BigDecimal result = new BigDecimal("0");
		CalculationDTO calculationDTO = new CalculationDTO(new BigDecimal("0"),"");
		
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
}
