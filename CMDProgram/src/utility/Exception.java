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
		
		else if (Pattern.matches(Constant.DIR_ADDITIONAL_PATTERN, command.substring(0, command.length()-2)) 
				&& command.substring(command.length() - 2).equals(".\\")) {
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
	
	public Boolean isCopyBeforeSourceFileCommand(String command) {
		Pattern pattern = Pattern.compile(Constant.COPY_FRONT_PATTERN);
		Matcher matcher = pattern.matcher(command);
		if(matcher.groupCount() == 1) {
			return true;
		}
		return false;
	}
	
	public Boolean isCopyCommand(String command) {
		if(Pattern.matches(Constant.COPY_FRONT_PATTERN, command)) {
			return true;
		}
		System.out.println("hi");
		return false;
	}
	
	public Boolean isDirCommand(String command, String pattern) {
		if (Pattern.matches(pattern,  command)) {
			return true;
		}
		return false;
	}

}
