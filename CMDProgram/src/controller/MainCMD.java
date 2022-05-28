package controller;
import view.ScreenBase;
import java.io.*;
import java.util.Scanner;
import utility.Constant;
import utility.Exception;

public class MainCMD {
	private ScreenBase screenBase;
	private Scanner scanner;
	private Exception exception;
	private CommandCd commandCd;
	private CommandDir commandDir;
	
	public MainCMD() {
		screenBase = new ScreenBase();
		scanner = new Scanner(System.in);
		exception = new Exception();
		commandCd = new CommandCd(exception, screenBase);
		commandDir = new CommandDir(exception, screenBase);
	}
	
	public void startCMD() throws IOException, InterruptedException {
		startFirst();	
	}
	
	private void startFirst() throws IOException, InterruptedException {
		screenBase.showCMDSign();
		screenBase.showFirstRoute();
		String route = System.getProperty("user.home");
		while(Constant.UNTIL_CONSOLE_EXIT) {
			route = readCommand(scanCommand(), route);
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
			screenBase.showNextRoute(route);
		}
		else if (exception.isCommand(command, Constant.CLS_COMMAND)) {
			screenBase.showClsResult();
			screenBase.showNextRoute(route);
		}
		else if (command.length() >= 2 && exception.isCommand(command.substring(0,2), Constant.CD_COMMAND)) {
			return commandCd.analyzeCd(command, route);
		}
		else if (command.length() >= 3 && exception.isCommand(command.substring(0,3), Constant.DIR_COMMAND)) {
			
		}
		else if (command.length() >= 4 && exception.isCommand(command.substring(0,4), Constant.COPY_COMMAND)) {
			
		}
		else if (command.length() >= 4 && exception.isCommand(command.substring(0,4), Constant.MOVE_COMMAND)) {
			
		}
		else {
			
		}
		
		return route;
	}
	

	
}
