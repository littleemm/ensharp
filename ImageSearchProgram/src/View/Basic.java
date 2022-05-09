package View;
import javax.swing.*;

public class Basic extends JFrame {
	public JTextField searchField;
	public JButton searchButton; 
	public JButton logButton;
	public JButton backButton;
	public JPanel searchPanel;
	public JPanel logPanel;
	public JPanel resultPanel;
	public JComboBox comboBox;
	
	public Basic() {
		searchField = new JTextField();
		searchButton = new JButton(" 검색 ");
		logButton = new JButton(" 당신의 모든 기록 ");
		backButton = new JButton(" 뒤로가기 ");
		searchPanel = new JPanel();
		logPanel = new JPanel();
		resultPanel = new JPanel();
		comboBox = new JComboBox();
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
		resultPanel.setSize(800, 100);
		
		searchField.setSize(480, 50);
		searchField.setLocation(0, 0);
		resultPanel.add(searchField);
		
		searchButton.setSize(80, 40);
		searchButton.setLocation(490, 5);
		resultPanel.add(searchButton);
		
		backButton.setSize(80, 40);
		backButton.setLocation(570, 5);
		resultPanel.add(backButton);
		
		comboBox.setSize(80, 40);
		comboBox.setLocation(650, 5);
		resultPanel.add(comboBox);
		
		resultPanel.setLayout(null);
		resultPanel.setLocation(100, 50);
		resultPanel.setVisible(true);
	}
}
