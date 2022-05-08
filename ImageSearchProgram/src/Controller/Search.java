package Controller;
import java.awt.*;
import java.awt.event.*;
import javax.swing.*;
import View.*;

public class Search extends JFrame{
	private View.Basic basic;
	public Search() 
	{
		basic = new View.Basic();
	}
	
	public void SearchImage() {
		setTitle("ImageSearchProgram");
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		
		basic.PrintSearchPage();
		
		setSize(1200, 600);
		setVisible(true);
		
	}
	
	
	

	
	
}
