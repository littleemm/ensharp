package view;
import javax.swing.*;
import java.awt.*;
import model.*;
import java.util.*;

public class LogPage {
	public JPanel logPanel;
	public JButton deleteButton;
	public JButton [] logListButton;
	private JList<CalculationLogDTO> logList;
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
		logList = new JList<CalculationLogDTO>(); 
		DTOList = new CalculationLogDTO[20];
		
		smallFont = new Font("맑은 고딕", Font.PLAIN, 10);
		bigFont = new Font("맑은 고딕 Bold", Font.BOLD, 15);
		logPanel = new JPanel();
		expressionLabel = new JLabel();
		resultLabel = new JLabel();
		logListButton = new JButton[20];
		logList = new JList();
	}
	
	public void PrintLogList() {
		logPanel.setPreferredSize(new Dimension(300, 600));
		logPanel.setLayout(new GridLayout(20, 1));
		
		//logList.add(logDTO);
		
		for (int i=19;i>=0;i--) {
			if (DTOList[i] != null) {
				expressionLabel.setSize(430, 10);
				expressionLabel.setFont(smallFont);
				expressionLabel.setText(DTOList[i].getExpression());
				resultLabel.setSize(430, 20);
				resultLabel.setFont(bigFont);
				resultLabel.setText(DTOList[i].getResult());
				logListButton[i] = new JButton();
				logListButton[i].setSize(430, 30);
				logListButton[i].add(expressionLabel);
				logListButton[i].add(resultLabel);
				logPanel.add(logListButton[i]);
			}
		}

		//logListButton[logList.getModel().getSize()].add(expressionLabel);
		//logListButton[logList.getModel().getSize()].add(resultLabel);
		scroll.add(logPanel);
		logPanel.setBackground(color.pink);
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
