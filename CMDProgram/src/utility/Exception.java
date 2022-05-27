package utility;
import java.util.regex.Pattern;

public class Exception {
	public Exception() {
		
	}
	
	public Boolean isCommand(String command, String standardCommand) {
		if (command.matches(standardCommand)) {
			return true;
		}
		return false;
	}
	
	public Boolean isCdCommand(String command, String pattern) {
		if (Pattern.matches(pattern, command)) {
			return true;
		}
		return false;
	}

}
