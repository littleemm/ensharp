package controller;
import utility.Constant;
import utility.Exception;
import view.ScreenBase;
import java.io.*;

public class CommandCopy {
	private Exception exception;
	private ScreenBase screenBase;
	
	public CommandCopy(Exception exception, ScreenBase screenBase) {
		this.exception = exception;
		this.screenBase = screenBase;
	}
	
	public String analyzeCopy(String command, String route) {
		if (exception.isCopyCommand(command)) { 
			screenBase.showNextRoute(route);
		}
		
		else if (exception.isCdCommand(command, Constant.CD_GO_FIRST_PATTERN)) { // 처음으로
			route = route.substring(0,3);
			screenBase.showNextRoute(route);
		}
		
		else if (exception.isCdCommand(command, Constant.CD_GO_BACK_ONCE_PATTERN)) { // 1단계 위
			route = route.substring(0, route.lastIndexOf("\\"));
			screenBase.showNextRoute(route);
		}
		
		else if (exception.isCdCommand(command, Constant.CD_GO_BACK_TWICE_PATTERN)) { // 2단계 위
			route = route.substring(0, route.lastIndexOf("\\"));
			route = route.substring(0, route.lastIndexOf("\\"));
			screenBase.showNextRoute(route);
		}
		
		return route;
	}
	
	private void fileCopy(String command, String route) {
		
	}
}
