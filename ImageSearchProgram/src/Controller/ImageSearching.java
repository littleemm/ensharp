package Controller;
import javax.imageio.ImageIO;
import javax.swing.*;
import java.awt.*; 
import java.awt.Color;
import java.awt.Graphics;
import java.awt.Image;
import javax.swing.ImageIcon;
import java.awt.event.*;
import View.*;
import java.util.*;
import java.net.URL;
import java.net.URLEncoder;

public class ImageSearching extends JFrame{
	private Basic basic;
	private JFrame mainFrame;
	private KakaoAPI kakaoApi;
	private ImageIcon mainImage;
	private JLabel imageLabel; 
	private JScrollPane scrollPane;
	private String image;

	public ImageSearching() 
	{
		mainFrame = new JFrame();
		basic = new Basic();
		kakaoApi = new KakaoAPI();
		imageLabel = new JLabel();
		mainImage = new ImageIcon("src/Image/applemain.png");
	}
	
	public void SearchImage() {	 // 메인 페이지 (메인 검색 페이지) 
		mainFrame.setTitle("Image Search Program");
		mainFrame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		mainFrame.setSize(1000, 600);
		mainFrame.setLocation(220,100);
		mainFrame.setLayout(null);
		
		imageLabel.setLayout(null);
		imageLabel.setSize(600, 200);
		imageLabel.setLocation(430, 70);
		imageLabel.setIcon(mainImage);
		
		basic.PrintSearchPage();
		
		mainFrame.add(imageLabel);
		mainFrame.add(basic.searchPanel);
		basic.searchButton.addActionListener(new ButtonActionListener());
		basic.logButton.addActionListener(new ButtonActionListener());
		mainFrame.getContentPane().setBackground(Color.WHITE);
		mainFrame.setVisible(true);
	}
	
	private void ShowImageResult(String image, String size) { // 메인 페이지 
		basic.PrintResultPageOfTop();
		mainFrame.add(basic.resultPanel);
		
		Vector<ImageIcon> images = kakaoApi.SearchImageIcon(image, size); // default는 10
		
		basic.PrintResultPageOfResult(images);
	
		basic.backButton.addActionListener(new ButtonActionListener());
		basic.searchButton.addActionListener(new ButtonActionListener());
		basic.comboBox.addActionListener(new comboBoxActionListener());
		
		scrollPane = new JScrollPane(basic.buttonPanel);
		scrollPane.setBounds(220, 150, 520, 300);
		
		//buttonPanel.setLocation(220, 150);
		basic.buttonPanel.setVisible(true);
		mainFrame.add(scrollPane);
		mainFrame.setVisible(true);
	}
	
	private void ShowLogPage() { // 로그 기록 페이지 
		basic.PrintLogPage();
		mainFrame.add(basic.logPanel);
		basic.logBackButton.addActionListener(new ButtonActionListenerForLog());
		
		
		mainFrame.setVisible(true);
	}
	
	private class ButtonActionListener implements ActionListener { 
		public void actionPerformed(ActionEvent e) {
			JButton button = (JButton)e.getSource();
			if(button.getText().equals(" 검색 ")) {
				image = basic.searchField.getText();
				basic.searchPanel.setVisible(false);
				imageLabel.setVisible(false);	
				basic.buttonPanel.setVisible(false);
				setVisible(false);
				ShowImageResult(image, "10");
			}
			else if(button.getText().equals(" 당신의 모든 기록 ")) {
				basic.searchPanel.setVisible(false);
				imageLabel.setVisible(false);
				ShowLogPage();
			}
			else if(button.getText().equals(" 뒤로가기 ")) {
				basic.resultPanel.setVisible(false);
				basic.buttonPanel.setVisible(false);
				scrollPane.setVisible(false);
				setVisible(false);
				SearchImage();
				imageLabel.setVisible(true);
			}
		}
	}
	
	private class ButtonActionListenerForLog implements ActionListener {
		public void actionPerformed(ActionEvent e) {
			JButton button = (JButton)e.getSource();
			if(button.getText().equals(" 기록삭제 ")) {
				
			}
			else if(button.getText().equals(" 뒤로가기 ")) {
				basic.logPanel.setVisible(false);
				SearchImage();
				imageLabel.setVisible(true);
			}
		}
	}
	
	private class comboBoxActionListener implements ActionListener {
		public void actionPerformed(ActionEvent e) {
			JComboBox<String> box = (JComboBox<String>)e.getSource();
			
			int index = box.getSelectedIndex();
			setVisible(false);
			switch(index) {
			case (0): {
				ShowImageResult(image, "10");
			}
			case (1): {
				ShowImageResult(image, "20");
			}
			case (2): {
				ShowImageResult(image, "30");
			}
			}
			
		}
	}
}
