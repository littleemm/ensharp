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
	

	public Boolean isCopyCurrentCommand(String command, String pattern) {
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
	
	public int getBeginFileIndex(String command) {
		Pattern pattern = Pattern.compile(Constant.COPY_BEGIN_PATTERN);
		Matcher matcher = pattern.matcher(command);
		return matcher.end();
	}
	
	public int getBeginCutFileIndex(String command, int sequence) {
		Pattern pattern = Pattern.compile(Constant.ALL_DIVISION_PATTERN);
		Matcher matcher = pattern.matcher(command);
		return matcher.end(sequence);
	}
	
	public int getEndFileIndex(String command, int sequence) {
		Pattern pattern = Pattern.compile(Constant.COPY_END_PATTERN);
		Matcher matcher = pattern.matcher(command);
		String result = command.replaceAll(Constant.COPY_CURRENT_PATTERN, "$1, $2, $3, $4, $5, $6");
		System.out.println(result);
		return matcher.end(sequence) - 1;
	}
	
	public int getBeginRouteIndex(String file, int sequence) {
		Pattern pattern = Pattern.compile(Constant.ROUTE_PATTERN);
		Matcher matcher = pattern.matcher(file);
		return matcher.start(sequence);
	}
	
	public int getEndRouteIndex(String file, int sequence) {
		Pattern pattern = Pattern.compile(Constant.ROUTE_END_PATTERN);
		Matcher matcher = pattern.matcher(file);
		return matcher.end(sequence) - 1;
	}

}
