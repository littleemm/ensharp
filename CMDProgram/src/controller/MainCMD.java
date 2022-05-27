package controller;
import view.ScreenBase;
import java.util.Scanner;
import utility.Constant;
import utility.Exception;

public class MainCMD {
	private ScreenBase screenBase;
	private Scanner scanner;
	private Exception exception;
	private CommandCd commandCd;
	
	public MainCMD() {
		screenBase = new ScreenBase();
		scanner = new Scanner(System.in);
		exception = new Exception();
		commandCd = new CommandCd(exception);
	}
	
	public void startCMD() {
		startFirst();	
	}
	
	private void startFirst() {
		screenBase.showCMDSign();
		screenBase.showFirstRoute();
		String route = "\nC:\\Users\\ASUS>";
		while(Constant.UNTIL_CONSOLE_EXIT) {
			route = readCommand(scanCommand(), route);
			screenBase.showNextRoute(route);
		}
		scanner.close();
	}
	
	private String scanCommand() {
		String command = scanner.next();
		return command;
	}
	
	private String readCommand(String command, String route) {
		if (exception.isCommand(command, Constant.HELP_COMMAND)) {
			screenBase.showHelpResult();
		}
		else if (exception.isCommand(command, Constant.CLS_COMMAND)) {
			
		}
		else if (exception.isCommand(command.substring(0,2), Constant.CD_COMMAND)) {
			return commandCd.analyzeCd(command, route);
		}
		else if (exception.isCommand(command.substring(0,3), Constant.DIR_COMMAND)) {
			
		}
		else if (exception.isCommand(command.substring(0,4), Constant.COPY_COMMAND)) {
			
		}
		else if (exception.isCommand(command.substring(0,4), Constant.MOVE_COMMAND)) {
			
		}
		
		return route;
	}
	

	
}
