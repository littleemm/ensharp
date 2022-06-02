package view;
import javax.swing.*;
import java.awt.*;
import model.*;
import java.util.*;

public class LogPage {
	public JPanel logPanel;
	public JButton deleteButton;
	public JButton [] logListButton;
	private JLabel signLabel;
	private ScrollPane scroll;
	private Color color;
	private JLabel expressionLabel;
	private JLabel resultLabel;
	
	private CalculationLogDTO [] DTOList;
	private Font bigFont;
	private Font smallFont;
	
	public LogPage() {
		scroll = new ScrollPane();
		color = new Color(250, 249, 250);
		DTOList = new CalculationLogDTO[20];
		
		smallFont = new Font("맑은 고딕", Font.PLAIN, 10);
		bigFont = new Font("맑은 고딕 Bold", Font.BOLD, 15);
		logPanel = new JPanel();
		expressionLabel = new JLabel();
		resultLabel = new JLabel();
		logListButton = new JButton[20];
		signLabel = new JLabel("");
	}
	
	public void PrintLogList() {
		logPanel.setPreferredSize(new Dimension(300, 600));
		logPanel.setLayout(new GridLayout(21, 1));
		
		signLabel.setPreferredSize(new Dimension(300, 10));
		signLabel.setFont(bigFont);
		signLabel.setHorizontalAlignment(JLabel.LEFT);
		logPanel.add(signLabel);
		
		
		scroll.add(logPanel);
	}
	
	public void insertLog(String inputTextAll, String beforeInputTextAll) {
		JButton logDataButton = new JButton(String.format("<html><body style=text-align:right;><p>%s <br/> %s </p></body></html>", beforeInputTextAll, inputTextAll));
		JPanel panel = new JPanel();
		panel.setLayout(new BorderLayout());
		logDataButton.setPreferredSize(new Dimension(430, 100));
		
		logDataButton.setOpaque(true);
		logDataButton.setBackground(color);
		logDataButton.setBorderPainted(false);
		logDataButton.setFocusPainted(false);
		logDataButton.setFont(smallFont);
		logPanel.add(logDataButton);
	}
	
	public void insertData(CalculationLogDTO calculationLogDTO) {
		 ArrayList<CalculationLogDTO> list = new ArrayList<>(Arrays.asList(DTOList));       
		 list.add(calculationLogDTO);
		 DTOList = list.toArray(DTOList);
	}
	public void PaintColor() {
		for (int i=0;;i++) {
			logListButton[i].setOpaque(true);
			logListButton[i].setBackground(color);
			logListButton[i].setBorderPainted(false);
			logListButton[i].setFocusPainted(false);
		}
	}
}
