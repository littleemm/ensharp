package controller;
import view.ScreenBase;
import view.ScreenException;
import java.io.*;
import java.util.Scanner;
import utility.Constant;
import utility.Exception;
import java.util.concurrent.Executors;
import java.util.function.Consumer;

public class MainCMD {
	private ScreenBase screenBase;
	private ScreenException screenException;
	private Scanner scanner;
	private Exception exception;
	private CommandCd commandCd;
	private CommandDir commandDir;
	private CommandCopy commandCopy;
	private CommandMove commandMove;
	
	public MainCMD() {
		screenBase = new ScreenBase();
		screenException = new ScreenException();
		scanner = new Scanner(System.in);
		exception = new Exception(screenException);
		commandCd = new CommandCd(exception, screenBase, screenException);
		commandDir = new CommandDir(exception, screenBase, screenException);
		commandCopy = new CommandCopy(exception, screenBase, screenException);
		commandMove = new CommandMove(exception, screenBase, screenException);
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
		String command = scanner.nextLine();
		return command;
	}
	
	private String readCommand(String command, String route) throws IOException, InterruptedException {
		if (exception.isTwinSign(command)) {
			screenBase.showNextRoute(route);
			return route;
		}
		
		if (exception.isColons(command)) {
			screenBase.showNextRoute(route);
			return route;
		}
		
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
			return commandDir.analyzeDir(command, route);
		}
		else if (command.length() >= 4 && exception.isCommand(command.substring(0,4), Constant.COPY_COMMAND)) {
			return commandCopy.analyzeCopy(command, route);
		}
		else if (command.length() >= 4 && exception.isCommand(command.substring(0,4), Constant.MOVE_COMMAND)) {
			return commandMove.analyzeMove(command, route);
		}
		else {
			screenException.printTypoWarning(command);
			screenBase.showNextRoute(route);
		}
		
		return route;
	}
	

	
}
