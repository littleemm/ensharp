package model;
import java.math.*;
import java.text.*;

public class CalculationDTO {
	private String inputTextAll;
	private String beforeInputTextAll;
	private String firstNumber;
	private BigDecimal resultBig;
	private String warningMessage;
	
	public CalculationDTO(BigDecimal resultBig, String warningMessage) {
		this.resultBig = resultBig;
		this.warningMessage = warningMessage;
		
	}
	
	public CalculationDTO(String inputTextAll, String beforeInputTextAll, String firstNumber) {
		this.inputTextAll = inputTextAll;
		this.beforeInputTextAll = beforeInputTextAll;
		this.firstNumber = firstNumber;
	}
	
	public BigDecimal getResultBig() {
		return resultBig;
	}
	
	public void setResultBig(BigDecimal resultBig) {
		this.resultBig = resultBig;
	}
	
	public String getWarningMessage() {
		return warningMessage;
	}
	
	public void setWarningMessage(String warningMessage) {
		this.warningMessage = warningMessage;
	}
	
	public String getInput() {
		return inputTextAll;
	}
	
	public void setInput(String inputTextAll) {
		this.inputTextAll = inputTextAll;
	}
	
	public String getBeforeInput() {
		return beforeInputTextAll;
	}
	
	public void setBeforeInput(String beforeInputTextAll) {
		this.beforeInputTextAll = beforeInputTextAll;
	}
	
	public String getFirstNumber() {
		return firstNumber;
	}
	
	public void setFirstNumber(String firstNumber) {
		this.firstNumber = firstNumber;
	}
}
