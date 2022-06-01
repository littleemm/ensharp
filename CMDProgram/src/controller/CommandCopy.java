package controller;
import view.ScreenException;
import utility.Constant;
import utility.Exception;
import view.ScreenBase;
import view.ScreenException;

import java.io.*;
import java.util.Scanner;
import java.io.*;
public class CommandCopy {
	private Exception exception;
	private ScreenBase screenBase;
	private ScreenException screenException;
	
	public CommandCopy(Exception exception, ScreenBase screenBase, ScreenException screenException) {
		this.exception = exception;
		this.screenBase = screenBase;
		this.screenException = screenException;
	}
	
	public String analyzeCopy(String command, String route) {
		if (exception.isCopyCurrentCommand(command, Constant.COPY_CURRENT_PATTERN)) { 
			copyFile(command, route);
		}
		
		else if (exception.isCopyCurrentCommand(command, Constant.COPY_SPECIAL_CURRENT_PATTERN)) {
			copyEmptyNameFile(command, route);
		}
		
		else if (exception.isCopyCurrentCommand(command, Constant.COPY_ONE_FILE_PATTERN)) { // 처음으로
			copyFileSimply(command, route);
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
	
	private String getCanonicalDirectory(String directory, String route) {
		if (!directory.contains(":")) {
			directory = route + "\\" + directory;
			return directory;
		}
		
		return directory;
	}
	
	private void copyFile(String command, String route) { //////
		String sourceFile = command.replaceAll(Constant.COPY_CURRENT_PATTERN, "$3");
		String destinationFile = command.replaceAll(Constant.COPY_CURRENT_PATTERN, "$7");
		
		String directory = getDirectory(command, route, Constant.COPY_CURRENT_PATTERN, "$1"); // 복사할 파일의 파일 위치
		String destinationDirectory = getDirectory(command, route, Constant.COPY_CURRENT_PATTERN, "$5"); // 붙여넣어질 파일의 파일 위치
		
		directory = getCanonicalDirectory(directory, route);
		destinationDirectory = getCanonicalDirectory(destinationDirectory, route);
		
		File source = new File(String.format("%s%s", directory, sourceFile));
		File destination = new File(String.format("%s%s", destinationDirectory, destinationFile));
		checkSameFileInDestination(source, destination);
	}
	
	private void copyEmptyNameFile(String command, String route) {
		String sourceFile = command.replaceAll(Constant.COPY_SPECIAL_CURRENT_PATTERN, "$1");
		String destinationFile = command.replaceAll(Constant.COPY_SPECIAL_CURRENT_PATTERN, "$4");
		
		String destinationDirectory = getDirectory(command, route, Constant.COPY_SPECIAL_CURRENT_PATTERN, "$3");
		File source = new File(String.format("%s\\%s", route, sourceFile));
		File destination = new File(String.format("%s%s", destinationDirectory, destinationFile));
		checkSameFileInDestination(source, destination);
	}
	
	private void copyFileSimply(String command, String route) {
		String directory = command.replaceAll(Constant.COPY_ONE_FILE_PATTERN, "$1");
		String file = command.replaceAll(Constant.COPY_ONE_FILE_PATTERN, "$2");
		
		File source = new File(String.format("%s%s", directory, file));
		File destination = new File(String.format("%s\\%s", route, file));
		checkSameFileInDestination(source, destination);
	}
	
	private void checkSameFileInDestination(File source, File destination) {
		String directory = destination.getParentFile().toString();
		File destinationDirectory = new File(directory);
		
		if (source.toString().equals(destination.toString())) {
			System.out.println("같은 파일로 복사할 수 없습니다.");
			System.out.println("        0개 파일이 복사되었습니다.");
			return;
		}

		String[] filenames = destinationDirectory.list();
		for (String filename : filenames) {
			if (filename.equals(destination.getName())) {
				askCopyFile(source, destination);
				return;
			}
		}
		copyFileBasic(source, destination);
	}
	
	private void askCopyFile(File source, File destination) {
		Scanner scanner = new Scanner(System.in);
		while (true) {
			System.out.print(String.format("%s을(를) 덮어쓰시겠습니까? (Yes/No/All): ", destination));
			String answer = scanner.nextLine();
			
			if (exception.isAnswer(answer, Constant.ANSWER_POSITIVE)) {
				copyFileBasic(source, destination);
				return;
			}
			else if (exception.isAnswer(answer, Constant.ANSWER_NEGATIVE)){
				System.out.println("        0개 파일이 복사되었습니다.");
			
				return;
			}
			else if (exception.isAnswer(answer, Constant.ANSWER_ALL)) {
				copyFileBasic(source, destination);
			
				return;
			}
		}
	}
	
	
	private void copyFileBasic(File source, File destination) {
		try {
			FileInputStream fileInput = new FileInputStream(source);
			FileOutputStream fileOutput = new FileOutputStream(destination);
			byte [] buffer = new byte[1024*10];
			while(true) {
				int size = fileInput.read(buffer);
				if (size < 0) { // 급한 오류 해결.. 파일에 대한 오류 해결방법을 못찾음
					size = 0;
				}
				fileOutput.write(buffer, 0, size);
				if(size < buffer.length) {
					break;
				}
			}
			fileOutput.close();
			fileInput.close();
			System.out.println("        1개 파일이 복사되었습니다.");
		} catch(IOException e) {
			System.out.println("파일 복사 오류");
		}
	}
}
