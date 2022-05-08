package Controller;
import javax.swing.*;

import java.awt.BorderLayout;
import java.awt.event.*;
import View.*;

public class Search extends JFrame{
	private View.Basic basic;
	private JFrame mainFrame;
	
	public Search() 
	{
		mainFrame = new JFrame();
		basic = new View.Basic();
	}
	
	public void SearchImage() {	
		mainFrame.setTitle("Image Search Program");
		mainFrame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		mainFrame.setSize(1000, 600);
		mainFrame.setLocation(220,100);
		mainFrame.setLayout(null);
		basic.PrintSearchPage();
		
		mainFrame.add(basic.searchPanel);
		basic.searchButton.addActionListener(new ButtonActionListener());
		basic.logButton.addActionListener(new ButtonActionListener());
		
		mainFrame.setVisible(true);
	}
	
	private class ButtonActionListener implements ActionListener {
		public void actionPerformed(ActionEvent e) {
			JButton button = (JButton)e.getSource();
			if(button.getText().equals(" 검색 ")) {
				
			}
			else if(button.getText().equals(" 당신의 모든 기록 ")) {
				
			}
		}
	}
	
}
