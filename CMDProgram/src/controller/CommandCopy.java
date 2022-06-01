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
		
		else if (exception.isCopyCurrentCommand(command, Constant.COPY_ONE_FILE_PATTERN)) { // ó������
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
		
		String directory = getDirectory(command, route, Constant.COPY_CURRENT_PATTERN, "$1"); // ������ ������ ���� ��ġ
		String destinationDirectory = getDirectory(command, route, Constant.COPY_CURRENT_PATTERN, "$5"); // �ٿ��־��� ������ ���� ��ġ
		
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
			System.out.println("���� ���Ϸ� ������ �� �����ϴ�.");
			System.out.println("        0�� ������ ����Ǿ����ϴ�.");
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
			System.out.print(String.format("%s��(��) ����ðڽ��ϱ�? (Yes/No/All): ", destination));
			String answer = scanner.nextLine();
			
			if (exception.isAnswer(answer, Constant.ANSWER_POSITIVE)) {
				copyFileBasic(source, destination);
				return;
			}
			else if (exception.isAnswer(answer, Constant.ANSWER_NEGATIVE)){
				System.out.println("        0�� ������ ����Ǿ����ϴ�.");
			
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
				if (size < 0) { // ���� ���� �ذ�.. ���Ͽ� ���� ���� �ذ����� ��ã��
					size = 0;
				}
				fileOutput.write(buffer, 0, size);
				if(size < buffer.length) {
					break;
				}
			}
			fileOutput.close();
			fileInput.close();
			System.out.println("        1�� ������ ����Ǿ����ϴ�.");
		} catch(IOException e) {
			System.out.println("���� ���� ����");
		}
	}
}
