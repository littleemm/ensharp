package view;
import javax.swing.*;
import java.awt.*;

public class CalculatorScreen {
	
	public JPanel inputPanel; 
	public JLabel beforeInput;
	public JLabel currentInput;
	private GridBagLayout layout;
	private GridBagConstraints constraint;
	
	public CalculatorScreen() {
		inputPanel = new JPanel();
		beforeInput = new JLabel();
		currentInput = new JLabel();
		layout = new GridBagLayout();
		constraint = new GridBagConstraints();
	}
	
	public void PrintCalculatorScreen() {
		inputPanel.setSize(420, 100);
		inputPanel.setLayout(layout);
		
		beforeInput.setSize(410, 10);
		//beforeInput.setLocation(0, 40);
		beforeInput.setHorizontalAlignment(JLabel.RIGHT);
		//inputPanel.add(beforeInput);
		gridBagInsert(beforeInput, 0, 0, 0, 1, 1);
		
		currentInput.setSize(410, 145);
		//currentInput.setLocation(0, 15);
		currentInput.setHorizontalAlignment(JLabel.RIGHT);
		//inputPanel.add(currentInput);
		gridBagInsert(currentInput, 0, 1, 0, 2, 3);

		//inputPanel.setLocation(0, 30);
		inputPanel.setVisible(true);
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
        inputPanel.add(component);

}
}
