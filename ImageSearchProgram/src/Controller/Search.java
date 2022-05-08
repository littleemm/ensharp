package Controller;
import java.awt.*;
import java.awt.event.*;
import javax.swing.*;

public class Search extends JFrame{
	public Search() 
	{
		JTextField searchField = new JTextField();
		JButton searchButton = new JButton("🔍");
		setTitle("ImageSearchProgram");
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		
		Container container = getContentPane();
		container.setLayout(null);
		
		searchField.setSize(400, 50);
		searchField.setLocation(400, 200);
		add(searchField);
		
		searchButton.setSize(50,50);
		searchButton.setLocation(810, 200);
		add(searchButton);
		
		setSize(1200, 600);
		setVisible(true);
	}
	

	
	
}
