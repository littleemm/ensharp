package controller;
import view.ScreenException;
import java.util.ArrayList;
import view.ScreenBase;
import utility.Constant;
import utility.Exception;
import java.util.concurrent.Executors;
import java.util.function.Consumer;
import java.io.*;
import java.nio.file.*;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.nio.file.attribute.FileTime;
import java.nio.file.attribute.BasicFileAttributes;
import java.text.*;
import java.util.*;
import java.io.File;


public class CommandDir {
	private Exception exception;
	private ScreenBase screenBase;
	private ScreenException screenException;
	
	public CommandDir(Exception exception, ScreenBase screenBase, ScreenException screenException) {
		this.exception = exception;
		this.screenBase = screenBase;
		this.screenException = screenException;
	}
	
	///////////////
	public String analyzeDir(String command, String route) throws IOException, InterruptedException {
		if (exception.isDirCommand(command, Constant.DIR_PATTERN)) { // dir
			getResult(route);
		}
		
		else if (exception.isDirCommand(command, Constant.DIR_ROUTE_PATTERN)) { // dir + 경로
			showRouteDirResult(command);
		}
		else {
			screenException.printTypoWarning(command);
		}
		
		screenBase.showNextRoute(route);
		return route;
	}
	
	
	private void showRouteDirResult (String command) throws IOException, InterruptedException {
		String route = command.replaceAll(Constant.DIR_ROUTE_PATTERN, "$1");
		getResult(route);
	}
	
	private void getResult(String route)  {
		File directory= new File(route);
		int directoryCount = 0;
		int fileCount = 0;
		File[] files = directory.listFiles();
		System.out.println("\n " + route + " 디렉터리\n");
		 for(int index = 0;index<files.length;index++){
			  File file = files[index];
			  String name = file.getName(); 
			  SimpleDateFormat df = new SimpleDateFormat("yyyy-MM-dd  a HH:mm");
			  String attribute = "";
			  String size = "";
		   
		   if(files[index].isDirectory()){
			   if (file.isHidden()) {
				   attribute = "H";
			   }
			   else {
				   attribute = "<DIR>";
			   }
		   }
		   
		   else{
			   size = file.length() + "";
			   attribute += file.isHidden() ? "H" : " ";
		   }
		   
		   if (!attribute.equals("H")) { 
			   if (size.length() > 0) {
				   fileCount++;
			   }
			   else {
				   directoryCount++;
			   }
			   System.out.printf("%s    %3s %6s\t%s \n",df.format(new Date(file.lastModified())),attribute,size,name);
		   }
		  }
		 
		 System.out.println("\t\t" + fileCount + "개 파일");
		 System.out.println("\t\t" + directoryCount + "개 디렉터리");
	 }

	
	
}
