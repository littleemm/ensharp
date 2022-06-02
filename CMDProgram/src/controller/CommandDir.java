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
import java.math.*;

public class CommandDir {
	private Exception exception;
	private ScreenBase screenBase;
	private ScreenException screenException;
	private BigDecimal decimal;
	private NumberFormat format;
	
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
	
	private void getResult(String route) throws IOException, InterruptedException {
		File directory= new File(route);
		int directoryCount = 2;
		int fileCount = 0;
		int sizeCount = 0;
		File[] files = directory.listFiles();
		SimpleDateFormat dateFormat = new SimpleDateFormat("yyyy-MM-dd  a 0H:mm");
		
		executeDirCommand(route);
		System.out.println("\n " + route + " 디렉터리\n");
		
		System.out.printf("%s    %3s %6s\t%s \n",dateFormat.format(new Date(directory.lastModified())),"<DIR>","",".");
		System.out.printf("%s    %3s %6s\t%s \n",dateFormat.format(new Date(directory.lastModified())),"<DIR>","","..");
		 for(int index = 0;index<files.length;index++){
			  File file = files[index];
			  String name = file.getName(); 
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
			   //attribute += file.isHidden() ? "H" : " ";
			   
			   if(file.isHidden()) {
				   attribute += "H";
			   }
			   else {
				   sizeCount += file.length();
			   }
			   
		   }
		   if (size.length() > 0) {
		   decimal = new BigDecimal(size);
		   format = NumberFormat.getInstance();
		   size = format.format(decimal);
		   }
		   if (!attribute.contains("H")) { 
			   if (size.length() > 0) {
				   fileCount++;
			   }
			   else {
				   directoryCount++;
			   }
			   System.out.printf("%s    %3s %6s\t%s \n",dateFormat.format(new Date(file.lastModified())),attribute,size,name);
		   }
		  }
		 String sizeCountString = Integer.toString(sizeCount);
		 sizeCountString = format.format(new BigDecimal(sizeCountString));
		 long total = Runtime.getRuntime().maxMemory();
		 String freeMemory = Integer.toString((int)total - sizeCount);
		 freeMemory = format.format(new BigDecimal(freeMemory));
		 System.out.print("\t\t" + fileCount + "개 파일");
		 System.out.printf("\t %13s %s\n", sizeCountString, " 바이트");
		 System.out.print("\t\t" + directoryCount + "개 디렉터리");
		 System.out.printf("\t %13s %s\n", freeMemory, " 바이트 남음");
	 }
	
	private void executeDirCommand(String route) {
		 ProcessBuilder processBuilder = new ProcessBuilder();

	        processBuilder.command("cmd.exe", "/c", "dir");

	        try {

	            Process process = processBuilder.start();

	            BufferedReader reader =
	                    new BufferedReader(new InputStreamReader(process.getInputStream()));

	            String line;
	            while ((line = reader.readLine()) != null) {
	            	System.out.println(line);
	            	if (line.contains("볼륨 일련 번호:")) {
	            		break;
	            	}
	            }

	        } catch (IOException e) {
	            e.printStackTrace();
	        }

	    
	}
	


	
	
}
