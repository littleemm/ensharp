package utility;
import java.util.regex.Pattern;

public class Exception {
	
    public Boolean isMemberId(String id) // 아이디
    {
        if (Pattern.matches(Constant.ID_PATTERN, id))
        {
            return true;
        }
        
        return false;
    }
    
    public Boolean isPassword(String password) // 비밀번호 예외처리
    {
        if(Pattern.matches(Constant.PASSWORD_PATTERN, password))
        {
            return true;
        }

        return false;
    }
    
    public Boolean isMemberName(String name) // 이름 예외처리
    {
        if (Pattern.matches(Constant.NAME_PATTERN, name))
        {
            return true;
        }

        return false;
    }
    
    public Boolean isPhoneNumber(String phoneNumber) // 휴대전화 예외처리
    {
        if (Pattern.matches(Constant.PHONE_PATTERN, phoneNumber))
        {
            return true;
        }

        return false;
    }
    
    public Boolean isEmail(String email) // 휴대전화 예외처리
    {
        if (Pattern.matches(Constant.EMAIL_PATTERN, email))
        {
            return true;
        }

        return false;
    }
}
