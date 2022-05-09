package View;
import javax.swing.*;

public class Basic extends JFrame {
	public JTextField searchField;
	public JButton searchButton;
	public JFrame searchFrame; 
	public JButton logButton;
	public JPanel searchPanel;
	private JPanel logPanel;
	
	public Basic() {
		searchField = new JTextField();
		searchButton = new JButton(" 검색 ");
		logButton = new JButton(" 당신의 모든 기록 ");
		searchPanel = new JPanel();
		logPanel = new JPanel();
	}
	
	public void PrintSearchPage() {
		searchPanel.setSize(570, 100);

		searchField.setSize(480, 50);
		searchField.setLocation(0, 0);
		searchPanel.add(searchField);
		
		searchButton.setSize(80, 40);
		searchButton.setLocation(490, 5);
		searchPanel.add(searchButton);
		
		logButton.setSize(150, 35);
		logButton.setLocation(200, 60);
		searchPanel.add(logButton);

		searchPanel.setLayout(null);
		searchPanel.setLocation(230, 300);
		searchPanel.setVisible(true);
	}
	
	public void PrintLogPage() {
		
	}
	
	public void PrintResultPage() {
		
	}
}
