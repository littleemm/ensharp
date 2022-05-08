package Model;
import java.awt.*;
import java.awt.event.*;
import javax.swing.*;

public class Basic extends JFrame {
	private JTextField searchField;
	private JButton searchButton;
	
	public Basic() {
		searchField = new JTextField();
		searchButton = new JButton("🔍");
	
	}
	
	public void PrintSearchPage() {
		searchField.setSize(100, 20);
		searchField.setLocation(300, 200);
		add(searchField);
		
		searchButton.setSize(20,20);
		searchButton.setLocation(410, 200);
		add(searchButton);
	}
}
