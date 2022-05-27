package controller;
import utility.Exception;
import utility.Constant;

public class CommandCd {
	private Exception exception;
	
	public CommandCd(Exception exception) {
		this.exception = exception;
	}
	
	public String analyzeCd(String command, String route) {
		if (exception.isCdCommand(command)) { // cd¸¸ ÀÔ·Â

		}
		
		else if (command.substring(2,1).equals("\\")) {
			
		}
		
		else if (command.substring(2,5).equals("..\\..")) {
			
		}
		
		else if (command.substring(2,2).equals("..")) {
			
		}
		
		return route;
	}
}
