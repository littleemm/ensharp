package View;
import javax.swing.*;

public class Basic extends JFrame {
	private JTextField searchField;
	private JButton searchButton;
	private JPanel searchPanel;
	
	public Basic() {
		searchField = new JTextField();
		searchButton = new JButton(" 검색 ");
		PrintSearchPage();
	}
	
	public void PrintSearchPage() {
		getContentPane().setLayout(null);
		searchPanel = new JPanel();
		searchField.setSize(400, 50);
		searchField.setLocation(400, 250);
		searchPanel.add(searchField);
		
		searchButton.setSize(50,50);
		searchButton.setLocation(810, 250);
		searchPanel.add(searchButton);
		
		getContentPane().add(searchPanel);
		setSize(1200, 600);
		setVisible(true);
	}
}
