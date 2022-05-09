package Controller;
import javax.swing.*;
import java.awt.event.*;
import View.*;

public class ImageSearching extends JFrame{
	private View.Basic basic;
	private JFrame mainFrame;
	private KakaoAPI kakaoApi;
	private JLabel jlabel;
	
	public ImageSearching() 
	{
		mainFrame = new JFrame();
		basic = new View.Basic();
		kakaoApi = new KakaoAPI();
		jlabel = new JLabel();
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
	
	private void ShowImageResult(String image) {
		basic.PrintResultPageOfTop();
		mainFrame.add(basic.resultPanel);
		
		JList<ImageIcon> imageList = kakaoApi.SearchImageIcon(image, "10"); // default는 10
		imageList.setSize(400, 400);
		imageList.setLocation(20, 20);
		mainFrame.add(new JScrollPane(imageList));
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
		}
	}
}
