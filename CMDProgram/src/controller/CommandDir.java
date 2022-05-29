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
	private String command;
	
	public CommandDir(Exception exception, ScreenBase screenBase) {
		this.exception = exception;
		this.screenBase = screenBase;
		command = "";
	}
	
	public String analyzeDir(String command, String route) throws IOException, InterruptedException {
		this.command = command;
		
		if (exception.isDirBasicCommand(command)) { // dir
			showBasicDirResult(route);
			screenBase.showNextRoute(route);
		}
		
		else if (exception.isDirBeforeRouteCommand(command)) { // dir + 경로
			
			screenBase.showNextRoute(route);
		}
		
		else if (exception.isDirCommand(command, Constant.CD_GO_BACK_ONCE_PATTERN)) { // 1단계 위
			route = route.substring(0, route.lastIndexOf("\\"));
			screenBase.showNextRoute(route);
		}
		
		else if (exception.isDirCommand(command, Constant.CD_GO_BACK_TWICE_PATTERN)) { // 2단계 위
			route = route.substring(0, route.lastIndexOf("\\"));
			route = route.substring(0, route.lastIndexOf("\\"));
			screenBase.showNextRoute(route);
		}
		
		return route;
	}
	
	public void getDirRoute(String command) {
		
	}
	
	
	private void showBasicDirResult (String route) throws IOException, InterruptedException {
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
