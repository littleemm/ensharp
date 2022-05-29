package CMDProgram;
import controller.*;
import java.io.*;
import java.util.concurrent.Executors;
import java.util.function.Consumer;

public class CMD { // CMD 메인 클래스
	public static void main(String[] args) throws IOException, InterruptedException {
		MainCMD mainCMD = new MainCMD();
		mainCMD.startCMD();
	}

}
