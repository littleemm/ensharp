package model;

public class CalculationDTO {
	private String expression;
	private String result;
	
	public CalculationDTO(String expression, String result) {
		this.expression = expression;
		this.result = result;
	}
	
	public String getExpression() {
		return expression;
	}
	
	public void setExpression(String expression) {
		this.expression = expression;
	}
	
	public String getResult() {
		return result;
	}
	
	public void setResult(String result) {
		this.result = result;
	}
}
