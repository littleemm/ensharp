package Controller;
import javax.imageio.ImageIO;
import javax.swing.*;

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
	private JButton [] imageButton;
	private JPanel buttonPanel;
	private ImageIcon mainImage;
	private JLabel imageLabel; 

	public ImageSearching() 
	{
		mainFrame = new JFrame();
		basic = new Basic();
		kakaoApi = new KakaoAPI();
		buttonPanel = new JPanel();
		imageButton = new JButton[30];
		imageLabel = new JLabel();
		mainImage = new ImageIcon("src/Image/applemain.png");
	}
	
	public void SearchImage() {	
		mainFrame.setTitle("Image Search Program");
		mainFrame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		mainFrame.setSize(1000, 600);
		mainFrame.setLocation(220,100);
		mainFrame.setLayout(null);
		imageLabel.setLayout(null);
		imageLabel.setSize(600, 200);
		imageLabel.setLocation(430, 70);
		imageLabel.setIcon(mainImage);
		mainFrame.add(imageLabel);
		basic.PrintSearchPage();
		
		
		mainFrame.add(basic.searchPanel);
		basic.searchButton.addActionListener(new ButtonActionListener());
		basic.logButton.addActionListener(new ButtonActionListener());
		
		mainFrame.setVisible(true);
	}
	
	private void ShowImageResult(String image) {
		basic.PrintResultPageOfTop();
		mainFrame.add(basic.resultPanel);
		buttonPanel.setLayout(null);
		buttonPanel.setSize(1000, 500);
		
		Vector<ImageIcon> images = kakaoApi.SearchImageIcon(image, "10"); // default는 10
		
		for (int i=0;i<images.size();i++) {
			imageButton[i] = new JButton();
			imageButton[i].setSize(100, 100);
			imageButton[i].setBorderPainted(true);
			//URL url = new URL(images.get(i).toString());
			//Image im = ImageIO.read(url);
			imageButton[i].setIcon(images.get(i));
		}
		for (int i=0;i<images.size()/2;i++) {
			imageButton[i].setLocation(10 + i*100, 0);
			imageButton[i + images.size()/2].setLocation(10 + i*100, 110);
			buttonPanel.add(imageButton[i]);
			buttonPanel.add(imageButton[i + images.size()/2]);
		}
		basic.backButton.addActionListener(new ButtonActionListener());
		buttonPanel.setLocation(220, 150);
		buttonPanel.setVisible(true);
		mainFrame.add(buttonPanel);
		mainFrame.setVisible(true);
	}
	
	
	private class ButtonActionListener implements ActionListener {
		public void actionPerformed(ActionEvent e) {
			JButton button = (JButton)e.getSource();
			if(button.getText().equals(" 검색 ")) {
				String image = basic.searchField.getText();
				basic.searchPanel.setVisible(false);
				ShowImageResult(image);
			}
			else if(button.getText().equals(" 당신의 모든 기록 ")) {
				
			}
			else if(button.getText().equals(" 뒤로가기 ")) {
				basic.resultPanel.setVisible(false);
				buttonPanel.setVisible(false);
				SearchImage();
			}
		}
	}
	
	private class comboBoxActionListener implements ActionListener {
		public void actionPerformed(ActionEvent e) {
			JComboBox<String> box = (JComboBox<String>)e.getSource();
			
			int index = box.getSelectedIndex();
			
			
		}
	}
}
