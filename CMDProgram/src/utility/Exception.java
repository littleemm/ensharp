package utility;
import java.util.regex.Pattern;

public class Exception {
	public Exception() {
		
	}
	
	public Boolean isHelpCommand(String command) {
		if (command.matches(Constant.HELP_COMMAND)) {
			return true;
		}
		return false;
	}

}
