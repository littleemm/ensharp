package controller;
import view.*;
import javax.swing.*;
import java.awt.*;
import java.awt.event.*;

public class CalculatorMain extends JFrame{
	
	private JFrame mainFrame;
	private Font font;
	private Font beforeFont;
	private String beforeInputTextAll;
	private String inputTextAll;
	private String inputText;
	public CalculatorButton calculatorButton;
	public CalculatorScreen calculatorScreen;
	public LogPage logPage;
	private GridBagLayout layout;
	private GridBagConstraints constraint;
	private ButtonActionListener listener;
	private JPanel panel;
	private JPanel p;
	
	public CalculatorMain() {
		mainFrame = new JFrame("계산기");
		beforeFont = new Font("맑은 고딕 Bold", Font.BOLD, 10);
		font = new Font("맑은 고딕 Bold", Font.BOLD, 40);
		beforeInputTextAll = "";
		inputTextAll = "0";
		inputText = "";
		layout = new GridBagLayout();
		constraint = new GridBagConstraints();
		calculatorButton = new CalculatorButton();
		calculatorScreen = new CalculatorScreen();
		logPage = new LogPage();
		listener = new ButtonActionListener(inputText, inputTextAll, beforeInputTextAll, calculatorScreen, calculatorButton, logPage);
		panel = new JPanel();
		p = new JPanel();
	}
	
	public void ShowCalculatorMain() {
		mainFrame.setPreferredSize(new Dimension(430, 600));
		mainFrame.setMinimumSize(new Dimension(400, 550));
		mainFrame.setLocationRelativeTo(null);
		mainFrame.setLayout(new BorderLayout());
		mainFrame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		
		panel.setSize(340, 600);
		panel.setLayout(layout);
		
		calculatorButton.PrintMainPanel();
		calculatorButton.PrintLogButtonPanel();
		calculatorScreen.PrintCalculatorScreen();
		
		gridBagInsert(calculatorButton.logButtonPanel, 0, 0, 0, 1, 1);
		gridBagInsert(calculatorScreen.inputPanel, 0, 1, 0, 2, 3);
		gridBagInsert(calculatorButton.buttonPanel, 0, 5, 0, 5, 5);
		mainFrame.add(panel, BorderLayout.CENTER);
		listener.ListenButtonAction(mainFrame, panel);
		
		calculatorScreen.beforeInput.setText(beforeInputTextAll); // label에 입력된 숫자 넣기 
		calculatorScreen.beforeInput.setFont(beforeFont); 
		calculatorScreen.beforeInput.setHorizontalAlignment(JLabel.RIGHT); // 오른쪽에서부터 숫자 시작 
		calculatorScreen.inputPanel.add(calculatorScreen.beforeInput);
		
		calculatorScreen.currentInput.setText(inputTextAll); // label에 입력된 숫자 넣기 
		calculatorScreen.currentInput.setFont(font); 
		calculatorScreen.currentInput.setHorizontalAlignment(JLabel.RIGHT); // 오른쪽에서부터 숫자 시작 
		calculatorScreen.inputPanel.add(calculatorScreen.currentInput);
		
		
		mainFrame.addComponentListener(new Listener());
		
		mainFrame.setVisible(true);
	}
	
	private class Listener implements ComponentListener {
		public void componentResized(ComponentEvent e) {
			if (mainFrame.getWidth() > 500) {
				panel.setPreferredSize(new Dimension(400, 600));
				calculatorButton.buttonPanel.setMaximumSize(new Dimension(400, 300));
				calculatorScreen.inputPanel.setSize(400, 100);
				calculatorButton.logButtonPanel.setSize(400, 30);
				logPage.PrintLogList();
				//mainFrame.add(panel, BorderLayout.CENTER);
				logPage.logPanel.setVisible(true);
				//p.setSize(400, 600);
				mainFrame.add(logPage.logPanel, BorderLayout.EAST);
				
			}
			
			if (mainFrame.getWidth() <= 440) {
				panel.setSize(440, 600);
				mainFrame.add(panel, BorderLayout.CENTER);
				logPage.logPanel.setVisible(false);
				//p.setSize(400, 600);
			}
			mainFrame.repaint();
			mainFrame.revalidate();
		}
		public void componentHidden(ComponentEvent e) {
			
		}
		public void componentMoved(ComponentEvent e) {
			
		}
		public void componentShown(ComponentEvent e) {
			
		}
	}
	
	private void gridBagInsert(Component component, int x, int y, int width, int height, int y1) {
	        constraint.fill= GridBagConstraints.BOTH;
	        constraint.weightx=1;
		    constraint.weighty=y1;
	        constraint.gridx = x;
	        constraint.gridy = y;
	        constraint.gridwidth = width;
	        constraint.gridheight = height;
	        layout.setConstraints(component, constraint);
	        panel.add(component);
	}
	
}
