package view;

public class ScreenException {
	public void informWarningRoute() {
		System.out.println("������ ��θ� ã�� �� �����ϴ�.");
	}
	
	public void printTypoWarning(String command) {
		System.out.println
		(String.format("'%s'��(��) ���� �Ǵ� �ܺ� ���, ������ �� �ִ� ���α׷�, �Ǵ�\r\n"
				+ "��ġ ������ �ƴմϴ�.", command));
	}
}
