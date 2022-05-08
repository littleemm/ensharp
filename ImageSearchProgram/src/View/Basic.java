package View;
import javax.swing.*;

public class Basic extends JFrame {
	public JTextField searchField;
	public JButton searchButton;
	public JFrame searchFrame; 
	public JButton logButton;
	private JPanel panel;
	
	public Basic() {
		searchField = new JTextField();
		searchButton = new JButton(" 검색 ");
		logButton = new JButton(" 당신의 모든 기록 ");
	}
	
	public void PrintSearchPage() {
		searchFrame = new JFrame();
		searchFrame.setTitle("Image Search Program");
		searchFrame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		searchFrame.setLocation(100,100);

		searchField.setSize(480, 50);
		searchField.setLocation(350, 250);
		searchFrame.add(searchField);
		
		searchButton.setSize(80, 40);
		searchButton.setLocation(835, 255);
		searchFrame.add(searchButton);
		
		logButton.setSize(150, 35);
		logButton.setLocation(530, 330);
		searchFrame.add(logButton);
		
		
		searchFrame.add(new JPanel());
		searchFrame.setSize(1200, 600);
		searchFrame.setVisible(true);
	}
	
	public void PrintLogPage() {
		
	}
	
	public void PrintResultPage() {
		
	}
}
