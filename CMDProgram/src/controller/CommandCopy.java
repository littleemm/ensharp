package controller;
import view.ScreenException;
import utility.Constant;
import utility.Exception;
import view.ScreenBase;
import view.ScreenException;

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
	
	private void copyFile(String command, String route) {
		String sourceFile = command.replaceAll(Constant.COPY_CURRENT_PATTERN, "$2");
		String destinationFile = command.replaceAll(Constant.COPY_CURRENT_PATTERN, "$5");
		
		String directory = getDirectory(command, route, Constant.COPY_CURRENT_PATTERN, "$1"); // ������ ������ ���� ��ġ
		String destinationDirectory = getDirectory(command, route, Constant.COPY_CURRENT_PATTERN, "$4"); // �ٿ��־��� ������ ���� ��ġ
		
		File source = new File(String.format("%s%s", directory, sourceFile));
		File destination = new File(String.format("%s%s", destinationDirectory, destinationFile));
		copyFileBasic(source, destination);
	}
	
	private void copyEmptyNameFile(String command, String route) {
		String sourceFile = command.replaceAll(Constant.COPY_SPECIAL_CURRENT_PATTERN, "$1");
		String destinationFile = command.replaceAll(Constant.COPY_SPECIAL_CURRENT_PATTERN, "$4");
		
		String destinationDirectory = getDirectory(command, route, Constant.COPY_SPECIAL_CURRENT_PATTERN, "$3");
		File source = new File(String.format("%s\\%s", route, sourceFile));
		File destination = new File(String.format("%s%s", destinationDirectory, destinationFile));
		copyFileBasic(source, destination);
	}
	
	private void copyFileSimply(String command, String route) {
		String directory = command.replaceAll(Constant.COPY_ONE_FILE_PATTERN, "$1");
		String file = command.replaceAll(Constant.COPY_ONE_FILE_PATTERN, "$2");
		
		File source = new File(String.format("%s%s", directory, file));
		File destination = new File(String.format("%s\\%s", route, file));
		copyFileBasic(source, destination);
	}
	
	private void copyFileBasic(File source, File destination) {
		try {
			FileInputStream fileInput = new FileInputStream(source);
			FileOutputStream fileOutput = new FileOutputStream(destination);
			byte [] buffer = new byte[1024*10];
			while(true) {
				int size = fileInput.read(buffer);
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
