package utility;
import java.util.regex.Pattern;
import java.util.regex.Matcher;

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
	
	public Boolean isDirBasicCommand(String command) {
		if (Pattern.matches(Constant.DIR_PATTERN, command)) {
			return true;
		}
		return false;
	}
	
	public Boolean isDirBeforeRouteCommand(String command) {
		Pattern pattern = Pattern.compile(Constant.DIR_ADDITIONAL_PATTERN);
		Matcher matcher = pattern.matcher(command);
		if(matcher.groupCount() == 1) {
			return true;
		}
		return false;
	}
	

	public Boolean isCopyCurrentCommand(String command, String pattern) {
		if(Pattern.matches(pattern, command)) {
			return true;
		}
		return false;
	}
	
	public Boolean isMoveCurrentCommand(String command, String pattern) {
		if(Pattern.matches(pattern, command)) {
			return true;
		}
		return false;
	}
	
	public Boolean isDirCommand(String command, String pattern) {
		if (Pattern.matches(pattern,  command)) {
			return true;
		}
		return false;
	}
		
	public void getEndFileIndex(String command, int sequence) {
		String result = command.replaceAll(Constant.COPY_CURRENT_PATTERN, "$1, $2, $3, $4, $5, $6");
		System.out.println(result);
	}
}
