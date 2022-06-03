package controller;
import javax.swing.*;
import java.net.*;
import java.io.*;
import java.awt.*;
import java.awt.event.*;
import view.SignUpScreen;
import view.MainScreen;
import model.MemberDTO;

public class SignUpAdministrator {
	private SignUpScreen signUpScreen;
	private MainScreen mainScreen;
	private MemberDTO memberDTO;
	private DatabaseConnection connection;
	
	public SignUpAdministrator(MainScreen mainScreen, MemberDTO memberDTO, DatabaseConnection connection) {
		this.mainScreen = mainScreen;
		this.memberDTO = memberDTO;
		this.connection = connection;
		
		signUpScreen = new SignUpScreen();
	}
	
	public void showSignUpPage(JFrame mainFrame, JPanel mainStartingPanel, JButton signupButton) { // 실제 회원가입 페이지 
		signupButton.addActionListener(new ActionListener() { // 메인 페이지에서 signUp 버튼 누를 때 
			public void actionPerformed(ActionEvent e) {
				changeMainToSignUpPage(mainFrame, mainStartingPanel);
			}
		});
		
		signUpScreen.backButton.addActionListener(new ActionListener() { // 회원가입 페이지에서 back 버튼 누를 때 
			public void actionPerformed(ActionEvent e) {
				changeSignUpPageToMain(mainFrame, mainStartingPanel);
			}
		});
		
	}
	
	private String convertPasswordToString() { // password 값 받아오기 
		String password = "";
		char[] secret = signUpScreen.passwordField.getPassword(); 

		for(char sign : secret){         
	         Character.toString(sign);   
	         password += (password.equals("")) ? ""+sign+"" : ""+sign+"";   
		}
		
		return password;
	}
	
	private void setInformationFromTextField() { // DTO 세팅 
		memberDTO.setName(signUpScreen.informationField[0].getText());
		memberDTO.setId(signUpScreen.informationField[1].getText());
		memberDTO.setPassword(convertPasswordToString());
		memberDTO.setBirth(signUpScreen.informationField[2].getText());
		memberDTO.setEmail(signUpScreen.informationField[3].getText() + "@" + signUpScreen.informationField[4].getText());
		memberDTO.setPhoneNumber(signUpScreen.informationField[5].getText()+signUpScreen.informationField[6].getText()+signUpScreen.informationField[7].getText());
		memberDTO.setZipCode(signUpScreen.informationField[8].getText());
		memberDTO.setAddress(signUpScreen.informationField[9].getText());
		memberDTO.setDetailAddress(signUpScreen.informationField[10].getText());
	}
	
	private Boolean isBlank() { // 필수항목이 빈칸인지 체크 
		if (memberDTO.getName().length() == 0) {
			signUpScreen.popFrame("아이디를 입력해주세요!");
			return true;
		}
		return false;
	}
	
	private void openAddressSite() { // 우편번호 칸 옆 버튼 누르면 주소 찾는 사이트 
		signUpScreen.addressSearchButton.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				Desktop desktop = Desktop.getDesktop();
				try {
					URI uri = new URI("https://juso.go.kr/");
	                desktop.browse(uri);
				}catch(IOException ex) {
					ex.printStackTrace();
				}
				catch(URISyntaxException ex){
					ex.printStackTrace();
				}
			}
		});
	}
	
	private void clickSignUpButton(JFrame mainFrame, JPanel mainStartingPanel) { // 회원가입 버튼이 눌리면 일어나는 일 
		signUpScreen.signupButton.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				setInformationFromTextField();
				
				if(!isBlank()) {
					System.out.println(memberDTO.getDetailAddress());
					connection.succeedSignUp(memberDTO);
					changeSignUpPageToMain(mainFrame, mainStartingPanel);
					signUpScreen.popFrame("회원가입 성공!");
				}
			}
		});
	}
	
	private void changeMainToSignUpPage(JFrame mainFrame, JPanel mainStartingPanel) { // 처음 페이지 -> 회원가입 페이지 
		mainScreen.initializeTextField();
		mainStartingPanel.setVisible(false);
		signUpScreen.showSignUpScreen();
		
		mainFrame.add(signUpScreen.signUpPagePanel);
		mainFrame.repaint();
		mainFrame.revalidate();
		mainFrame.setVisible(true);
		
		openAddressSite();
		clickSignUpButton(mainFrame, mainStartingPanel);
	}
	
	private void changeSignUpPageToMain(JFrame mainFrame, JPanel mainStartingPanel) { // 회원가입 페이지 -> 처음 페이지 
		signUpScreen.initializeTextField();
		signUpScreen.signUpPagePanel.setVisible(false);
	
		mainStartingPanel.setVisible(true);
		mainFrame.repaint();
		mainFrame.revalidate();
		mainFrame.setVisible(true);
	}
	
	
}
