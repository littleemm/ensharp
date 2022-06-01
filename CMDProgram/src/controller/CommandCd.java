package controller;
import java.util.regex.Pattern;
import java.util.*;
import utility.Exception;
import java.io.*;
import utility.Constant;
import view.ScreenBase;
import view.ScreenException;
import java.lang.String;

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
			if (!exception.isDriveString(command)) {
				route = route.substring(0, route.lastIndexOf("\\"));
			}
		}
		
		else if (exception.isCdCommand(command, Constant.CD_GO_BACK_TWICE_PATTERN)) { // 2단계 위
			if (!exception.isDriveString(command)) {
				route = route.substring(0, route.lastIndexOf("\\")+1);
				if (route.lastIndexOf("\\") > 2) {
					route = route.substring(0, route.lastIndexOf("\\"));
				}
				//route = route.substring(0, route.lastIndexOf("\\"));
			}
		}
		
		else if (exception.isCdCommand(command, Constant.CD_CANONICALROUTE_PATTERN)) {
			route = getRouteFromCanonicalRoute(command, route);
		}
		
		else if (exception.isCdCommand(command, Constant.CD_ROUTE_PATTERN)) {
			route = getRouteFromCommand(command, route);
		}
		
		else if (exception.isCdCommand(command, Constant.CD_ROUTE_PATTERN_FROM_CURRENT)) {
			route = getRouteFromCurrentDirectory(command, route);
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
			return directory.getAbsolutePath();
		}
		
		screenException.informWarningRoute();
		return route;
	}
	
	private String getRouteFromCurrentDirectory (String command, String route) {
		String directoryBefore = route + "\\" + command.replaceAll(Constant.CD_ROUTE_PATTERN_FROM_CURRENT, "$1");
		File directory = new File(directoryBefore);
		if (directory.isDirectory()) {
			return directory.getAbsolutePath();
		}
		
		screenException.informWarningRoute();
		return route;
	}
	
	private String getRouteFromCanonicalRoute (String command, String route) {
		String directoryBefore = command.replaceAll(Constant.CD_CANONICALROUTE_PATTERN, "$1");
		File directory = new File(directoryBefore);
		int startPoint = 0;
		
	
		try {
			directory.getCanonicalPath();
			
			while (directoryBefore.indexOf(Constant.CANONICAL_ROUTE, startPoint) >= 0) {
				startPoint = directoryBefore.indexOf(Constant.CANONICAL_ROUTE, startPoint) + 2;
				route = route.substring(0, route.lastIndexOf("\\"));
				
				if (route.length() == 2) {
					route += "\\";
					break;
				}
			} 
			
		}
		catch(IOException e) {
			
			System.out.println("오류");
		
		}
		
		return route;
	}
}
