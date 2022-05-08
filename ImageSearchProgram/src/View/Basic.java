package View;
import javax.swing.*;

public class Basic extends JFrame {
	private JTextField searchField;
	private JButton searchButton;
	private JFrame searchFrame; 
	private JPanel searchPanel;
	
	public Basic() {
		searchField = new JTextField();
		searchButton = new JButton(" 검색 ");
		searchPanel = new JPanel();
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
		searchButton.setLocation(840, 255);
		searchFrame.add(searchButton);
		
		searchFrame.add(searchPanel);
		searchFrame.setSize(1200, 600);
		searchFrame.setVisible(true);
	}
}
