package View;
import javax.imageio.ImageIO;
import javax.swing.*;
import java.awt.Color;
import java.awt.GridBagLayout;
import java.awt.Image;
import java.net.URL;
import java.util.Vector;

public class Basic extends JFrame {
	public JTextField searchField;
	public JButton searchButton; 
	public JButton logButton;
	public JButton backButton;
	public JPanel buttonPanel;
	public JPanel searchPanel;
	public JPanel logPanel;
	public JPanel resultPanel;
	public JComboBox<String> comboBox;
	public JButton logBackButton;
	public JButton logDeleteButton;
	private JButton [] imageButton;
	private JLabel topLabel;
	String [] size = {"10", "20", "30"};
	
	public Basic() {
		searchField = new JTextField();
		searchButton = new JButton(" 검색 ");
		logButton = new JButton(" 당신의 모든 기록 ");
		backButton = new JButton(" 뒤로가기 ");
		searchPanel = new JPanel();
		logPanel = new JPanel();
		resultPanel = new JPanel();
		buttonPanel = new JPanel();
		logBackButton = new JButton(" 뒤로가기 ");
		logDeleteButton = new JButton(" 기록삭제 ");
		comboBox = new JComboBox(size);
		topLabel = new JLabel(" 당신의 모든 기록 ");
		imageButton = new JButton[30];
	}
	
	public void PrintSearchPage() {
		searchPanel.setSize(570, 100);

		searchField.setSize(420, 50);
		searchField.setLocation(60, 0);
		searchPanel.add(searchField);
		
		searchButton.setSize(80, 40);
		searchButton.setLocation(490, 5);
		searchPanel.add(searchButton);
		
		logButton.setSize(150, 35);
		logButton.setLocation(200, 60);
		searchPanel.add(logButton);

		searchPanel.setLayout(null);
		searchPanel.setLocation(230, 300);
		searchPanel.setBackground(Color.WHITE);
		searchPanel.setVisible(true);
	}
	
	public void PrintLogPage() {
		logPanel.setSize(800, 100);
		
		topLabel.setSize(10, 10);
		topLabel.setLayout(null);
		topLabel.setLocation(20, 20);
		logPanel.add(topLabel);
		
		logBackButton.setSize(80, 40);
		logBackButton.setLocation(490, 10);
		logPanel.add(logBackButton);
		
		logDeleteButton.setSize(80, 40);
		logDeleteButton.setLocation(570, 10);
		logPanel.add(logDeleteButton);
		
		logPanel.setLayout(null);
		logPanel.setLocation(10, 300);
		logPanel.setBackground(Color.WHITE);
		logPanel.setVisible(true);
		
	}
	
	public void PrintResultPageOfTop() {
		resultPanel.setSize(800, 100);
		
		searchField.setSize(400, 50);
		searchField.setLocation(90, 0);
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
		resultPanel.setBackground(Color.WHITE);
		resultPanel.setVisible(true);
	}
	
	public void PrintResultPageOfResult(Vector<ImageIcon> images) {
		buttonPanel.setLayout(new GridBagLayout());
		buttonPanel.setSize(5000, 300);
		

		for (int i=0;i<images.size();i++) {
			
			try {
				URL url = new URL(images.get(i).toString());
				Image ButtonIcon = ImageIO.read(url).getScaledInstance(100, 100, Image.SCALE_SMOOTH);
				imageButton[i] = new JButton(new ImageIcon(ButtonIcon));
				imageButton[i].setSize(100, 100);
				imageButton[i].setBorderPainted(false);
				imageButton[i].setFocusPainted(false);
				imageButton[i].setContentAreaFilled(false);
				
			} catch(Exception e) {
				
			}
			
		}
		for (int i=0;i<images.size();i++) {
			imageButton[i].setLocation(15 + i*100, 15);
			//imageButton[i + images.size()/2].setLocation(15 + i*100, 130);
			buttonPanel.add(imageButton[i]);
			//buttonPanel.add(imageButton[i + images.size()/2]);
		}
	}
}
