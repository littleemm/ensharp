package utility;

public class Constant {
	public Constant() {
		
	}
	
	public static String ID_PATTERN = "^((?=.*[a-z])(?=.*[0-9]).{5,20})|([a-z]{5,20})$";
	public static String PASSWORD_PATTERN = "^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[\\W]).{8,16}$";
	public static String NAME_PATTERN = "^([가-힣]{2,4})|([a-zA-Z]{2,10})$";
	public static String BIRTH_PATTERN = "^[0-9]{2}((0[1-9]{1})|(1[1-2]{1}))((0[1-9]{1})|(1[0-9]{1})|(2[0-9]{1})|(3[0-1]{1}))$";
	public static String EMAIL_PATTERN = "^\\w+@\\w+\\.\\w+(\\.\\w+)?$";
	public static String PHONE_PATTERN = "(010[0-9]{8})|(0[1-9]{2}[0-9]{7})|(02[0-9]{7,8})";
	
	public static String INSERT_QUERY = "INSERT INTO member (name, id, password, birth, email, phone, zipcode, address, detailAddress) VALUE ('%s', '%s', '%s', '%s', '%s', '%s', '%s', '%s', '%s');";
	public static String SELECT_PASSWORD_QUERY = "SELECT password FROM member WHERE id = '%s'";
	public static String SELECT_NAME_QUERY = "SELECT name FROM member WHERE id = '%s'";
	
}
