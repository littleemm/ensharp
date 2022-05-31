package controller;
import utility.Exception;
import java.io.*;
import utility.Constant;
import view.ScreenBase;
import view.ScreenException;

public class CommandCd {
	private Exception exception;
	private ScreenBase screenBase;
	private ScreenException screenException;
	
	public CommandCd(Exception exception, ScreenBase screenBase, ScreenException screenException) {
		this.exception = exception;
		this.screenBase = screenBase;
		this.screenException = screenException;
	}
	
	public String analyzeCd(String command, String route) {
		if (exception.isCdCommand(command, Constant.CD_PATTERN)) { // cd만 입력
			screenBase.printOnlyRoute(route);
		}
		
		else if (exception.isCdCommand(command, Constant.CD_GO_FIRST_PATTERN)) { // 처음으로
			route = route.substring(0,3);
		}
		
		else if (exception.isCdCommand(command, Constant.CD_GO_BACK_ONCE_PATTERN)) { // 1단계 위
			route = route.substring(0, route.lastIndexOf("\\"));
		}
		
		else if (exception.isCdCommand(command, Constant.CD_GO_BACK_TWICE_PATTERN)) { // 2단계 위
			route = route.substring(0, route.lastIndexOf("\\"));
			route = route.substring(0, route.lastIndexOf("\\"));
		}
		else if (exception.isCdCommand(command, Constant.CD_ROUTE_PATTERN)) {
			route = getRouteFromCommand(command, route);
		}
		else {
			screenException.printTypoWarning(command);
		}
		
		screenBase.showNextRoute(route);
		return route;
	}
	
	private String getRouteFromCommand (String command, String route) {
		File directory = new File(command.replaceAll(Constant.CD_ROUTE_PATTERN, "$1"));
		if (directory.isDirectory()) {
			return directory.getPath();
		}
		else {
			screenException.informWarningRoute();
			return route;
		}
	}
}
