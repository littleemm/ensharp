package controller;
import view.ScreenBase;
import java.util.Scanner;
import utility.Exception;

public class MainCMD {
	private ScreenBase screenBase;
	private Scanner scanner;
	private Exception exception;
	
	public MainCMD() {
		screenBase = new ScreenBase();
		scanner = new Scanner(System.in);
		exception = new Exception();
	}
	
	public void startCMD() {
		startFirst();	
	}
	
	private void startFirst() {
		screenBase.showCMDSign();
		screenBase.showFirstRoute();
		String command = scanner.next();
		readCommand(command);
		scanner.close();
	}
	
	private void readCommand(String command) {
		if (exception.isHelpCommand(command)) {
			screenBase.showHelpResult();
			return;
		}
		
	}
	

	
}
