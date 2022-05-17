package utility;

public class Exception {
	private String inputTextAll;
	
	
	public Exception(String inputTextAll) {
		this.inputTextAll = inputTextAll;
	}
	
	public String DivideByZero(String value) {
		if (value == "0") {
			inputTextAll = "0으로 나눌 수 없습니다";
		}
		return inputTextAll;
	}
}
