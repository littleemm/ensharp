package controller;
import view.ScreenBase;
import utility.Constant;
import utility.Exception;
import java.util.concurrent.Executors;
import java.util.function.Consumer;
import java.io.*;

public class CommandDir {
	private Exception exception;
	private ScreenBase screenBase;
	
	public CommandDir(Exception exception, ScreenBase screenBase) {
		this.exception = exception;
		this.screenBase = screenBase;
	}
	
	public String analyzeDir(String command, String route) throws IOException, InterruptedException {
		if (exception.isDirCommand(command, Constant.DIR_PATTERN)) { // dir
			executeDirCommand(route);
		}
		
		else if (exception.isDirCommand(command, Constant.DIR_ROUTE_PATTERN)) { // dir + °æ·Î
			showRouteDirResult(command);
		}
		
		screenBase.showNextRoute(route);
		return route;
	}
	
	
	private void showRouteDirResult (String command) throws IOException, InterruptedException {
		String route = command.replaceAll(Constant.DIR_ROUTE_PATTERN, "$1");
		System.out.println(route);
		executeDirCommand(route);
	}
	
	private void executeDirCommand (String route) throws IOException, InterruptedException {
		 boolean isWindows = System.getProperty("os.name").toLowerCase().startsWith("windows");
		  ProcessBuilder builder = new ProcessBuilder();
		    if (isWindows) {
	            builder.command("cmd.exe", "/c", "dir");
	        } else {
	            builder.command("sh", "-c", "ls");
	        }
		    builder.directory(new File(route));
	        Process process = builder.start();
	        StreamGobbler streamGobbler =
	                new StreamGobbler(process.getInputStream(), System.out::println);
	        Executors.newSingleThreadExecutor().submit(streamGobbler);
	        int exitCode = process.waitFor();
	        assert exitCode == 0;
	}
	
	private static class StreamGobbler implements Runnable {
        private InputStream inputStream;
        private Consumer<String> consumer;

        public StreamGobbler(InputStream inputStream, Consumer<String> consumer) {
            this.inputStream = inputStream;
            this.consumer = consumer;
        }

        
        public void run() {
            try {
                new BufferedReader(new InputStreamReader(inputStream, "euc-kr")).lines()
                        .forEach(consumer);
            } catch (UnsupportedEncodingException e) {
                e.printStackTrace();
            }
        }
    }
}
