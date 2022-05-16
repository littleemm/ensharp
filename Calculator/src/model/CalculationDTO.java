package model;

public class CalculationDTO {
	private String inputTextAll;
	private String beforeInputTextAll;
	
	public CalculationDTO(String inputTextAll, String beforeInputTextAll) {
		this.inputTextAll = inputTextAll;
		this.beforeInputTextAll = beforeInputTextAll;
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
}
