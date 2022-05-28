package controller;
import utility.Exception;
import utility.Constant;
import view.ScreenBase;

public class CommandCd {
	private Exception exception;
	private ScreenBase screenBase;
	
	public CommandCd(Exception exception, ScreenBase screenBase) {
		this.exception = exception;
		this.screenBase = screenBase;
	}
	
	public String analyzeCd(String command, String route) {
		if (exception.isCdCommand(command, Constant.CD_PATTERN)) { // cd만 입력
			screenBase.printOnlyRoute(route);
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
}
