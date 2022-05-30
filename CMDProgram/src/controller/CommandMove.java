package controller;

import java.io.File;
import java.io.FileReader;
import java.io.FileWriter;
import java.io.IOException;

import utility.Constant;
import utility.Exception;
import view.ScreenBase;

public class CommandMove {
	private Exception exception;
	private ScreenBase screenBase;
	
	public CommandMove(Exception exception, ScreenBase screenBase) {
		this.exception = exception;
		this.screenBase = screenBase;
	}
	
	public String analyzeMove(String command, String route) {
		if (exception.isMoveCurrentCommand(command, Constant.MOVE_CURRENT_PATTERN)) { 
			moveFile(command, route);
		}
		
		else if (exception.isMoveCurrentCommand(command, Constant.MOVE_SPECIAL_CURRENT_PATTERN)) {
			moveEmptyNameFile(command, route);
		}
		
		else if (exception.isMoveCurrentCommand(command, Constant.MOVE_ONE_FILE_PATTERN)) { // 처음으로
			moveFileSimply(command, route);
		}
		
		screenBase.showNextRoute(route);
		return route;
	}
	
	private String getDirectory(String command, String route, String pattern, String sequence) {
		if(command.replaceAll(pattern, sequence).length() > 0) {
			return command.replaceAll(pattern, sequence);
		}
		return route + "\\";
	}
	
	private void moveFile(String command, String route) {
		String sourceFile = command.replaceAll(Constant.MOVE_CURRENT_PATTERN, "$2");
		String destinationFile = command.replaceAll(Constant.MOVE_CURRENT_PATTERN, "$5");
		
		String directory = getDirectory(command, route, Constant.MOVE_CURRENT_PATTERN, "$1"); // 복사할 파일의 파일 위치
		String destinationDirectory = getDirectory(command, route, Constant.MOVE_CURRENT_PATTERN, "$4"); // 붙여넣어질 파일의 파일 위치
		
		File source = new File(String.format("%s%s", directory, sourceFile));
		File destination = new File(String.format("%s%s", destinationDirectory, destinationFile));
		moveFileBasic(source, destination);
	}
	
	private void moveEmptyNameFile(String command, String route) {
		String sourceFile = command.replaceAll(Constant.MOVE_SPECIAL_CURRENT_PATTERN, "$1");
		String destinationFile = command.replaceAll(Constant.MOVE_SPECIAL_CURRENT_PATTERN, "$4");
		
		String destinationDirectory = getDirectory(command, route, Constant.MOVE_SPECIAL_CURRENT_PATTERN, "$3");
		
		File source = new File(String.format("%s\\%s", route, sourceFile));
		File destination = new File(String.format("%s%s", destinationDirectory, destinationFile));
		moveFileBasic(source, destination);
	}
	
	private void moveFileSimply(String command, String route) {
		String directory = command.replaceAll(Constant.MOVE_ONE_FILE_PATTERN, "$1");
		String file = command.replaceAll(Constant.MOVE_ONE_FILE_PATTERN, "$2");
		
		File source = new File(String.format("%s%s", directory, file));
		File destination = new File(String.format("%s\\%s", route, file));
		moveFileBasic(source, destination);
	}
	
	private void moveFileBasic(File source, File destination) {
		if(source.renameTo(destination)){
			System.out.println("        1개 파일을 이동했습니다.");
		}
		else{
			System.out.println("파일 이동 오류");
		}
	
	}
}
