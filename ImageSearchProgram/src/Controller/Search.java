package Controller;
import javax.swing.*;
import java.awt.event.*;
import View.*;

public class Search extends JFrame{
	private View.Basic basic;
	
	public Search() 
	{
		basic = new View.Basic();
	}
	
	public void SearchImage() {		
		basic.PrintSearchPage();
		JButton b = new JButton("Action");
		basic.searchButton.addActionListener(new ActionListener());
	}
	
	private class ActionListener implements ActionListener {
		
	}
	
}
