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
		if (exception.isCopyCurrentCommand(command, Constant.COPY_CURRENT_PATTERN) || exception.isCopyCurrentCommand(command, Constant.COPY_SPECIAL_CURRENT_PATTERN)) { 
			fileCopy(command, route);
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
		String directory = route; // 복사할 파일의 파일 위치
		String destinationDirectory = route; // 붙여넣어질 파일의 파일 위치
		
		int sourceFileLength = exception.getEndFileIndex(command, 0) - exception.getBeginFileIndex(command) + 1;
		System.out.println(exception.getEndFileIndex(command, 0));
		String sourceFileName = command.substring(exception.getBeginFileIndex(command), sourceFileLength); // 디렉토리 부분 잘라낸 순수 파일 이름
		
		if (exception.getBeginRouteIndex(sourceFileName, 0) >= 0) {
			int directoryLength = exception.getEndRouteIndex(sourceFileName, 0) - exception.getBeginRouteIndex(sourceFileName, 0) + 1;
			directory = sourceFileName.substring(exception.getBeginRouteIndex(sourceFileName, 0), directoryLength);
		}
		
		command = command.substring(exception.getEndFileIndex(command, 0) + 1);
		int destinationFileLength = exception.getEndFileIndex(command, 0) - exception.getBeginCutFileIndex(command, 0) + 1;
		String destinationFileName = command.substring(exception.getBeginCutFileIndex(command, 0), destinationFileLength);
		
		if (exception.getBeginRouteIndex(destinationFileName, 0) >= 0) {
			int directoryLength = exception.getEndRouteIndex(destinationFileName, 0) - exception.getBeginRouteIndex(destinationFileName, 0) + 1;
			destinationDirectory = sourceFileName.substring(exception.getBeginRouteIndex(destinationFileName, 0), directoryLength);
		}
		
		
		File source = new File(String.format("%s%s", directory, command));
		File destination = new File(String.format("%s%s", destinationDirectory, command));
	}
}
