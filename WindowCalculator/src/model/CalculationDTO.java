package model;

public class CalculationDTO {
	private String inputTextAll;
	private String beforeInputTextAll;
	private String firstNumber;
	
	public CalculationDTO(String inputTextAll, String beforeInputTextAll, String firstNumber) {
		this.inputTextAll = inputTextAll;
		this.beforeInputTextAll = beforeInputTextAll;
		this.firstNumber = firstNumber;
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
