package Model;


public class LogDTO {
	
	private String history;
	private String time;
	
	public LogDTO(String history, String time) {
		this.history = history;
		this.time = time;
	}
	
	public String getHistory() {
		return history;
	}
	
	public void setHistory(String history) {
		this.history = history;
	}
	
	public String getTime() {
		return time;
	}
	
	public void setTime(String time) {
		this.time = time;
	}
}
