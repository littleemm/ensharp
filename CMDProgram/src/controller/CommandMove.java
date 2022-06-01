package controller;
import view.ScreenException;
import java.io.File;
import java.io.FileReader;
import java.io.FileWriter;
import java.io.IOException;
import java.util.Scanner;
import utility.Constant;
import utility.Exception;
import view.ScreenBase;
import view.ScreenException;

public class CommandMove {
	private Exception exception;
	private ScreenBase screenBase;
	private ScreenException screenException;
	
	public CommandMove(Exception exception, ScreenBase screenBase, ScreenException screenException) {
		this.exception = exception;
		this.screenBase = screenBase;
		this.screenException = screenException;
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
		
		else if (exception.isMoveCurrentCommand(command, Constant.MOVE_FILE_TO_FOLDER_ABSOLUTE)) {
			moveFileToFolder(command, route);
		}
		
		else if (exception.isMoveCurrentCommand(command, Constant.MOVE_FILE_TO_FOLDER)) {
			moveFileToFolderCanonical(command, route);
		}
		
		else {
			screenException.printTypoWarning(command);
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
		checkSameFileInDestination(source, destination);
	}
	
	private void moveEmptyNameFile(String command, String route) {
		String sourceFile = command.replaceAll(Constant.MOVE_SPECIAL_CURRENT_PATTERN, "$1");
		String destinationFile = command.replaceAll(Constant.MOVE_SPECIAL_CURRENT_PATTERN, "$4");
		
		String destinationDirectory = getDirectory(command, route, Constant.MOVE_SPECIAL_CURRENT_PATTERN, "$3");
		
		File source = new File(String.format("%s\\%s", route, sourceFile));
		File destination = new File(String.format("%s%s", destinationDirectory, destinationFile));
		checkSameFileInDestination(source, destination);
	}
	
	private void moveFileSimply(String command, String route) {
		String directory = command.replaceAll(Constant.MOVE_ONE_FILE_PATTERN, "$1");
		String file = command.replaceAll(Constant.MOVE_ONE_FILE_PATTERN, "$2");
		
		File source = new File(String.format("%s%s", directory, file));
		File destination = new File(String.format("%s\\%s", route, file));
		checkSameFileInDestination(source, destination);
	}
	
	private void moveFileToFolder(String command, String route) {
		String destinationDirectory = getDirectory(command, route, Constant.MOVE_FILE_TO_FOLDER_ABSOLUTE, "$4");
		if (destinationDirectory.substring(destinationDirectory.length() - 2, destinationDirectory.length() - 1).equals("\\")) {
			destinationDirectory = destinationDirectory.substring(0, destinationDirectory.length()-2);
		}
		
		String fileDirectory = getDirectory(command, route, Constant.MOVE_FILE_TO_FOLDER_ABSOLUTE, "$1");
		String file = command.replaceAll(Constant.MOVE_FILE_TO_FOLDER_ABSOLUTE, "$2");
		
		if (destinationDirectory.substring(0, destinationDirectory.length() - 1) != "\\") {
			destinationDirectory += "\\";
		}
		
		File source = new File(String.format("%s%s", fileDirectory, file));
		File destination = new File(String.format("%s%s", destinationDirectory, file));
		System.out.println(source);
		System.out.println(destination);
		checkSameFileInDestination(source, destination);
	}
	
	private void moveFileToFolderCanonical(String command, String route) {
		String directory = getDirectory(command, route, Constant.MOVE_FILE_TO_FOLDER, "$1"); // 복사할 파일의 파일 위치
		String destinationDirectory = getCanonicalRouteFromCommand(command, route);
		
		String sourceFile = command.replaceAll(Constant.MOVE_FILE_TO_FOLDER, "$2");
		String destinationFile = sourceFile;
		
		String directoryNext = command.replaceAll(Constant.MOVE_FILE_TO_FOLDER, "$6");
		if (directoryNext.indexOf(".txt") >= 0 || directoryNext.indexOf(".ini") >= 0) {
			destinationFile = directoryNext;
		}
		

		File source = new File(String.format("%s%s", directory, sourceFile));
		File destination = new File(String.format("%s%s", destinationDirectory, destinationFile));
		System.out.println(source);
		System.out.println(destination);
		checkSameFileInDestination(source, destination);
	}
	
	private String getCanonicalRouteFromCommand (String command, String route) {
		String directoryBefore = command.replaceAll(Constant.MOVE_FILE_TO_FOLDER, "$5");
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
		
		if (route.substring(0, route.length() - 1) != ("\\")) {
			route += "\\";
		}
		
		String directoryNext = command.replaceAll(Constant.MOVE_FILE_TO_FOLDER, "$6");
		if (directoryNext.indexOf(".txt") < 0 && directoryNext.indexOf(".ini") < 0) {
			route += directoryNext;
			route += "\\";
		}

		System.out.println(route);
		
		return route;
			
	}
	
	private void checkSameFileInDestination(File source, File destination) {
		String directory = destination.getParentFile().toString();
		File destinationDirectory = new File(directory);

		String[] filenames = destinationDirectory.list();
		for (String filename : filenames) {
			if (filename.equals(destination.getName())) {
				askMoveFile(source, destination);
				return;
			}
		
		}
		moveFileBasic(source, destination);
	}
	
	private void askMoveFile(File source, File destination) {
		Scanner scanner = new Scanner(System.in);
		while (true) {
			System.out.println(String.format("%s을(를) 덮어쓰시겠습니까? (Yes/No/All): ", destination));
			String answer = scanner.nextLine();
			
			if (exception.isAnswer(answer, Constant.ANSWER_POSITIVE)) {
				moveFileBasic(source, destination);
				return;
			}
			else if (exception.isAnswer(answer, Constant.ANSWER_NEGATIVE)){
				System.out.println("        0개 파일을 이동했습니다.");
				return;
			}
			else if (exception.isAnswer(answer, Constant.ANSWER_ALL)) {
				moveFileBasic(source, destination);
				return;
			}
		}
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
