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
		if (exception.isCdCommand(command, Constant.CD_PATTERN)) { // cd�� �Է�
			screenBase.printOnlyRoute(route);
			screenBase.showNextRoute(route);
		}
		
		else if (exception.isCdCommand(command, Constant.CD_GO_FIRST_PATTERN)) { // ó������
			route = route.substring(0,3);
			screenBase.showNextRoute(route);
		}
		
		else if (exception.isCdCommand(command, Constant.CD_GO_BACK_ONCE_PATTERN)) { // 1�ܰ� ��
			route = route.substring(0, route.lastIndexOf("\\"));
			screenBase.showNextRoute(route);
		}
		
		else if (exception.isCdCommand(command, Constant.CD_GO_BACK_TWICE_PATTERN)) { // 2�ܰ� ��
			route = route.substring(0, route.lastIndexOf("\\"));
			route = route.substring(0, route.lastIndexOf("\\"));
			screenBase.showNextRoute(route);
		}
		
		return route;
	}
}
