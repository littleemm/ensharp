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
	
	public String modifyResult(String resultString) {
		resultString = resultString.replaceAll(",", "");
		BigDecimal resultBig;
		
		if (resultString.length() > 16 && !isDecimalPoint(resultString)) {
			resultBig = new BigDecimal(resultString);
			String point = Double.toString(Math.pow(0.1, resultString.length() - 1));
			System.out.println(point);
			resultBig = resultBig.multiply(new BigDecimal(point));
			
			resultString = format.format(resultBig) + "e+" + Double.toString(resultString.length()-1);
			System.out.println(resultString);
		}
		else if (isDecimalPoint(resultString)) {
			
		}
		return resultString;
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
