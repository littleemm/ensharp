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
	

}
