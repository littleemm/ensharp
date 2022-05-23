package view;
import javax.swing.*;
import java.awt.*;
import model.*;

public class LogPage {
	public JPanel logPanel;
	public JButton deleteButton;
	public JButton [] logListButton;
	private JList<CalculationLogDTO> logList;
	private ScrollPane scroll;
	private Color color;
	private JLabel expressionLabel;
	private JLabel resultLabel;
	
	private Font bigFont;
	private Font smallFont;
	
	public LogPage() {
		scroll = new ScrollPane();
		color = new Color(250, 249, 250);
		logList = new JList<CalculationLogDTO>(); 
		
		smallFont = new Font("맑은 고딕", Font.PLAIN, 10);
		bigFont = new Font("맑은 고딕 Bold", Font.BOLD, 15);
		logPanel = new JPanel();
		expressionLabel = new JLabel();
		resultLabel = new JLabel();
		logListButton = new JButton[30];
		logList = new JList();
	}
	
	public void PrintLogList(CalculationLogDTO logDTO) {
		logPanel.setSize(430, 300);
		logPanel.setLayout(new BorderLayout());
		
		//logList.add(logDTO);
		expressionLabel.setSize(430, 300);
		expressionLabel.setText(logDTO.getExpression());
		expressionLabel.setFont(smallFont);
		resultLabel.setSize(430, 20);
		resultLabel.setText(logDTO.getResult());
		resultLabel.setFont(bigFont);
		logListButton[logList.getModel().getSize()] = new JButton();
		logListButton[logList.getModel().getSize()].add(expressionLabel);
		logListButton[logList.getModel().getSize()].add(resultLabel);
		logPanel.add(logListButton[logList.getModel().getSize()]);
		
		scroll.add(logPanel);
		logPanel.setBackground(color.pink);
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
