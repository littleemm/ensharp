package model;

public class MemberDTO {
	private String name;
	private String id;
	private String password;
	private String birth;
	private String email;
	private String phoneNumber;
	private String zipCode;
	private String address;
	private String detailAddress;
	
	public MemberDTO(String name, String id, String password, String birth, String email, String phoneNumber, String zipCode, String address, String detailAddress) {
		this.name = name;
		this.id = id;
		this.password = password;
		this.birth = birth;
		this.email = email;
		this.phoneNumber = phoneNumber;
		this.zipCode = zipCode;
		this.address = address;
		this.detailAddress = detailAddress;
	}
	
	public String getName() {
		return name;
	}
	
	public void setName(String name) {
		this.name = name;
	}
	
	public String getId() {
		return id;
	}
	
	public void setId(String id) {
		this.id = id;
	}
	
	public String getPassword() {
		return password;
	}
	
	public void setPassword(String password) {
		this.password = password;
	}
	
	public String getBirth() {
		return birth;
	}
	
	public void setBirth(String birth) {
		this.birth = birth;
	}
	
	public String getEmail() {
		return email;
	}
	
	public void setEmail(String email) {
		this.email = email;
	}
	
	public String getPhoneNumber() {
		return phoneNumber;
	}
	
	public void setPhoneNumber(String phoneNumber) {
		this.phoneNumber = phoneNumber;
	}
	
	public String getZipCode() {
		return zipCode;
	}
	
	public void setZipCode(String zipCode) {
		this.zipCode = zipCode;
	}
	
	public String getAddress() {
		return address;
	}
	
	public void setAddress(String address) {
		this.address = address;
	}
	
	public String getDetailAddress() {
		return detailAddress;
	}
	
	public void setDetailAddress(String detailAddress) {
		this.detailAddress = detailAddress;
	}
	
}
