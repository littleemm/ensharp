package controller;
import view.*;
import javax.swing.*;
import java.awt.*;
import java.awt.event.*;

public class Calculation extends JFrame{
	
	private JFrame mainFrame;
	private JLabel miniLabel;
	private Font font;
	private Font beforeFont;
	private String beforeInputTextAll;
	private String inputTextAll;
	private String inputText;
	private String inputOperation;
	public CalculatorButton calculatorButton;
	public CalculatorScreen calculatorScreen;
	
	public Calculation() {
		mainFrame = new JFrame("계산기");
		miniLabel = new JLabel();
		beforeFont = new Font("맑은 고딕 Bold", Font.BOLD, 10);
		font = new Font("맑은 고딕 Bold", Font.BOLD, 40);
		beforeInputTextAll = "";
		inputTextAll = "";
		inputText = "";
		inputOperation = "";
		calculatorButton = new CalculatorButton();
		calculatorScreen = new CalculatorScreen();
	}
	
	public void ShowCalculatorMain() {
		mainFrame.setBounds(10, 10, 430, 510);
		mainFrame.setLayout(null);
		mainFrame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		//mainFrame.setUndecorated(true);
		//mainFrame.setBackground(new Color(0,0,0,230));
		calculatorButton.PrintMainPanel();
		calculatorButton.PrintLogButtonPanel();
		calculatorScreen.PrintCalculatorScreen();
		
		mainFrame.add(calculatorButton.logButtonPanel);
		mainFrame.add(calculatorScreen.inputPanel);
		mainFrame.add(calculatorButton.buttonPanel);
		
		for (int i=0;i<12;i++) {
			calculatorButton.valueButton[i].addActionListener(new numberButtonListener());
			calculatorButton.valueButton[i].addMouseListener(new MouseButtonListener());
		}
		
		for (int i=0;i<4;i++) {
			calculatorButton.operationButton[i].addActionListener(new operationButtonListener());
		}
		
		mainFrame.setVisible(true);
	}
	
	private class numberButtonListener implements ActionListener {
		public void actionPerformed(ActionEvent e) {
			JButton button = (JButton)e.getSource();
			for (int j=0;j<12;j++) {
				if(button.getText().equals(calculatorButton.screenValue[j])) {
					inputText = calculatorButton.screenValue[j]; // 현재 눌린 숫자 
					inputTextAll += inputText; // 연산 기호가 입력되기 전까지는 숫자를 연속적으로 표현해야한다.
					calculatorScreen.currentInput.setText(inputTextAll); // label에 입력된 숫자 넣기 
					calculatorScreen.currentInput.setFont(font); 
				}
			calculatorScreen.currentInput.setHorizontalAlignment(JLabel.RIGHT); // 오른쪽에서부터 숫자 시작 
			calculatorScreen.inputPanel.add(calculatorScreen.currentInput);
			}
		}

	}
	
	private class operationButtonListener implements ActionListener {
		public void actionPerformed(ActionEvent e) {
			JButton button = (JButton)e.getSource();
			for (int j=0;j<4;j++) {
				if(button.getText().equals(calculatorButton.operationValue[j])) {
					beforeInputTextAll = inputTextAll;
					inputOperation = calculatorButton.operationValue[j];
					beforeInputTextAll += inputOperation;
					calculatorScreen.beforeInput.setText(beforeInputTextAll);
					calculatorScreen.beforeInput.setFont(beforeFont);
				}
				calculatorScreen.beforeInput.setHorizontalAlignment(JLabel.RIGHT);
				calculatorScreen.inputPanel.add(calculatorScreen.beforeInput);
			}
		}
		
	}
	
	private class MouseButtonListener implements MouseListener {
		public void mouseEntered(MouseEvent e) {
			JButton button = (JButton)e.getSource();
			for (int j=0;j<20;j++)
			if(button.getText().equals(calculatorButton.calculatorValue[j])) {
				button.setOpaque(true);
				button.setBackground(Color.GRAY);
			}
		}
		public void mouseExited(MouseEvent e) {
			JButton button = (JButton)e.getSource();
			for (int j=0;j<20;j++)
				if(button.getText().equals(calculatorButton.calculatorValue[j])) {
					calculatorButton.PaintColor();
					
				}
		}
		public void mousePressed(MouseEvent e) {
			
		}
		public void mouseReleased(MouseEvent e) {
			
		}
		public void mouseClicked(MouseEvent e) {
			
		}

	}
	
}
