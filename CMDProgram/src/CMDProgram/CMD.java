package CMDProgram;
import controller.*;
import java.io.*;
import java.util.concurrent.Executors;
import java.util.function.Consumer;

public class CMD { // CMD ���� Ŭ����
	public static void main(String[] args) throws IOException, InterruptedException {
		MainCMD mainCMD = new MainCMD();
		mainCMD.startCMD();
	}

}
