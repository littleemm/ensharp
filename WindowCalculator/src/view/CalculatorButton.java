package view;
import java.awt.*;
import javax.swing.*;


public class CalculatorButton extends JPanel {
	public String [] calculatorValue = {"CE", "C", "⌫", "÷", "7", "8", "9", "×", "4", "5", "6", "-", "1", "2", "3", "+", "+/-", "0", ".","="};
	public String [] screenValue = {"7", "8", "9", "4", "5", "6", "1", "2", "3", "+/-", "0", "."};
	public String [] operationValue = {"÷", "×", "-", "+"};
	public String [] clearValue = {"CE", "C", "⌫"};
	public JPanel buttonPanel;
	public JPanel logButtonPanel;
	public JButton [] clearButton;
	public JButton [] operationButton;
	public JButton [] valueButton;
	public JButton logButton;
	private JLabel imageLabel;
	private JLabel guideLabel;
	
	private Color numberColor;
	private Color color;
	private ImageIcon logButtonImage;
	private ImageIcon logoImage;
	private Font guideFont;
	
	public CalculatorButton() {
		buttonPanel = new JPanel();
		logButtonPanel = new JPanel();
		clearButton = new JButton[3];
		operationButton = new JButton[5];
		valueButton = new JButton[12];
		imageLabel = new JLabel();
		guideLabel = new JLabel("  표준");
		logButton = new JButton(".");
		numberColor = new Color(200, 199, 252);
		color = new Color(250, 249, 250);
		logoImage = new ImageIcon("src/image/logo.png");
		logButtonImage = new ImageIcon("src/image/logButton.png");
		guideFont = new Font("맑은 고딕", Font.BOLD, 20);
	}
	
	public void PrintMainPanel() {
		buttonPanel.setSize(340, 300);
		buttonPanel.setLayout(new GridLayout(5, 4, 1, 1));
		
		for (int i=0;i<3;i++) {
			clearButton[i] = new JButton(calculatorValue[i]);
			buttonPanel.add(clearButton[i]);
		}
		
		operationButton[0] = new JButton(calculatorValue[3]);
		buttonPanel.add(operationButton[0]);
		
		for (int i=4;i<7;i++) {
			valueButton[i-4] = new JButton(calculatorValue[i]);
			buttonPanel.add(valueButton[i-4]);
		}
		
		operationButton[1] = new JButton(calculatorValue[7]);
		buttonPanel.add(operationButton[1]);
		
		for (int i=8;i<11;i++) {
			valueButton[i+3-8] = new JButton(calculatorValue[i]);
			buttonPanel.add(valueButton[i+3-8]);
		}
		
		operationButton[2] = new JButton(calculatorValue[11]);
		buttonPanel.add(operationButton[2]);
		
		for (int i=12;i<15;i++) {
			valueButton[i+6-12] = new JButton(calculatorValue[i]);
			buttonPanel.add(valueButton[i+6-12]);
		}
		
		operationButton[3] = new JButton(calculatorValue[15]);
		buttonPanel.add(operationButton[3]);
		
		for (int i=16;i<19;i++) {
			valueButton[i+9-16] = new JButton(calculatorValue[i]);
			buttonPanel.add(valueButton[i+9-16]);
		}
		
		operationButton[4] = new JButton(calculatorValue[19]);
		buttonPanel.add(operationButton[4]);
		
		PaintColor();
		
		//buttonPanel.setLocation(0, 180);
		buttonPanel.setVisible(true);
	}
	
	public void PaintColor() {
		for (int i=0;i<3;i++) {
			clearButton[i].setOpaque(true);
			clearButton[i].setBackground(color);
			clearButton[i].setBorderPainted(false);
			clearButton[i].setFocusPainted(false);
		}
		for (int i=0;i<5;i++) {
			operationButton[i].setOpaque(true);
			operationButton[i].setBackground(color);
			operationButton[i].setBorderPainted(false);
			operationButton[i].setFocusPainted(false);
		}
		for (int i=0;i<12;i++) {
			valueButton[i].setOpaque(true);
			valueButton[i].setBackground(Color.WHITE);
			valueButton[i].setBorderPainted(false);
			valueButton[i].setFocusPainted(false);
		}
		logButton.setOpaque(false);
		logButton.setBackground(Color.WHITE);
		operationButton[4].setOpaque(true);
		operationButton[4].setBackground(numberColor);
		
	}
	
	public void PrintLogButtonPanel() {
		logButtonPanel.setSize(340, 30);
		logButtonPanel.setLayout(new BorderLayout());
		

		guideLabel.setSize(210, 35);
		guideLabel.setLayout(null);
		//guideLabel.setLocation(10, 0);
		guideLabel.setFont(guideFont);
		//guideLabel.setHorizontalAlignment(JLabel.LEFT); 
		logButtonPanel.add(guideLabel, BorderLayout.NORTH);
	
		//imageLabel.setSize(200, 50);
		//imageLabel.setLayout(null);
		//imageLabel.setLocation(10, 0);
		//imageLabel.setIcon(logoImage);
		//logButtonPanel.add(imageLabel);
		
		//logButton.setLocation(395,17);
		logButton.setSize(20,20);
		logButton.setIcon(logButtonImage);
		logButton.setHorizontalAlignment(JButton.RIGHT);
		logButton.setBorderPainted(false);
		logButton.setFocusPainted(false);
		logButtonPanel.add(logButton, BorderLayout.NORTH);
		
		//logButtonPanel.setLocation(0, 1);
		logButtonPanel.setVisible(true);
	}
}
