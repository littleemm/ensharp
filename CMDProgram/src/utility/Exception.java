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
			(String.format("'%s'��(��) ���� �Ǵ� �ܺ� ���, ������ �� �ִ� ���α׷�, �Ǵ�\r\n"
					+ "��ġ ������ �ƴմϴ�.", command.substring(0, command.indexOf(" "))));
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
			System.out.println(">��(��) ������� �ʾҽ��ϴ�.");
			return true;
		}
		else if (command.matches(Constant.EXCEPTION_COMMAND_PATTERN_TWO_OTHER)) {
			System.out.println("<<��(��) ������� �ʾҽ��ϴ�.");
			return true;
		}
		else if (command.matches(Constant.EXCEPTION_COMMAND_PATTERN_TWO) 
				|| command.matches(Constant.EXCEPTION_COMMAND_PATTERN_ONE_OTHER)) {
			System.out.println("��� ������ �ùٸ��� �ʽ��ϴ�.");
			return true;
		}
		return false;
	}
	
	public Boolean isColons(String command) {
		if (command.length() >= 3 && 
				command.substring(0,3).matches(Constant.DIR_COMMAND) && command.matches(Constant.COLONS_EXCEPTION_PATTERN)) {
			System.out.println("������ ��θ� ã�� �� �����ϴ�.");
			return true;
		}
		else if (command.matches(Constant.COLONS_EXCEPTION_PATTERN)) {
			System.out.println("�ý����� ������ ����̺긦 ã�� �� �����ϴ�.");
			return true;
		}
		
		return false;
	}
	
	private void compareSequence(String command) {
		if (command.indexOf('>') < command.indexOf('<')) {
			System.out.println(">��(��) ������� �ʾҽ��ϴ�.");
		}
		else {
			System.out.println("<<��(��) ������� �ʾҽ��ϴ�.");
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
