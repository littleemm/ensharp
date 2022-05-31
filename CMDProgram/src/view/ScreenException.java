package view;

public class ScreenException {
	public void informWarningRoute() {
		System.out.println("지정된 경로를 찾을 수 없습니다.");
	}
	
	public void printTypoWarning(String command) {
		System.out.println
		(String.format("'%s'은(는) 내부 또는 외부 명령, 실행할 수 있는 프로그램, 또는\r\n"
				+ "배치 파일이 아닙니다.", command));
	}
}
