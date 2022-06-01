package utility;
import java.util.regex.Pattern;
import java.util.regex.Matcher;
import view.ScreenException;

public class Exception {
	private ScreenException screenException;
	
	public Exception(ScreenException screenException) {
		this.screenException = screenException;
	}
	
	public Boolean isSignWithBlank(String command) {
		if (command.indexOf(" ") == -1) {
			return false;
		}
		if (Pattern.matches(Constant.EXCEPTION_COMMAND_FRONT, command.substring(0, command.indexOf(" ")))) {
			System.out.println
			(String.format("'%s'은(는) 내부 또는 외부 명령, 실행할 수 있는 프로그램, 또는\r\n"
					+ "배치 파일이 아닙니다.", command.substring(0, command.indexOf(" "))));
			return true;
		}
		return false;
	}
	
	public Boolean isDriveString(String command) {
		if (Pattern.matches(Constant.DRIVE_PATTERN, command)) {
			return true;
		}
		return false;
	}
	
	public Boolean isTwinSign(String command) {
		if(command.matches(Constant.EXCEPTION_COMMAND_PATTERN_THREE) 
				&& command.matches(Constant.EXCEPTION_COMMAND_PATTERN_TWO_OTHER)) {
			compareSequence(command);
			return true;
		}
		else if (command.matches(Constant.EXCEPTION_COMMAND_PATTERN_THREE)) {
			System.out.println(">은(는) 예상되지 않았습니다.");
			return true;
		}
		else if (command.matches(Constant.EXCEPTION_COMMAND_PATTERN_TWO_OTHER)) {
			System.out.println("<<은(는) 예상되지 않았습니다.");
			return true;
		}
		else if (command.matches(Constant.EXCEPTION_COMMAND_PATTERN_TWO) 
				|| command.matches(Constant.EXCEPTION_COMMAND_PATTERN_ONE_OTHER)) {
			System.out.println("명령 구문이 올바르지 않습니다.");
			return true;
		}
		return false;
	}
	
	public Boolean isColons(String command) {
		if (command.length() >= 3 && 
				command.substring(0,3).matches(Constant.DIR_COMMAND) && command.matches(Constant.COLONS_EXCEPTION_PATTERN)) {
			System.out.println("지정된 경로를 찾을 수 없습니다.");
			return true;
		}
		else if (command.matches(Constant.COLONS_EXCEPTION_PATTERN)) {
			System.out.println("시스템이 지정된 드라이브를 찾을 수 없습니다.");
			return true;
		}
		
		return false;
	}
	
	private void compareSequence(String command) {
		if (command.indexOf('>') < command.indexOf('<')) {
			System.out.println(">은(는) 예상되지 않았습니다.");
		}
		else {
			System.out.println("<<은(는) 예상되지 않았습니다.");
		}
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
	
	public Boolean isAnswer(String command, String pattern) {
		if (Pattern.matches(pattern, command)) {
			return true;
		}
		return false;
	}
		
	public void getEndFileIndex(String command, int sequence) {
		String result = command.replaceAll(Constant.COPY_CURRENT_PATTERN, "$1, $2, $3, $4, $5, $6");
		System.out.println(result);
	}
}
