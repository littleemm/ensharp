package utility;

public class Constant {
	public Constant() {
		
	}
	
	public static String HELP_COMMAND = "(?i)help";
	public static String CLS_COMMAND = "(?i)cls";
	public static String CD_COMMAND = "(?i)cd";
	public static String DIR_COMMAND = "(?i)dir";
	public static String COPY_COMMAND = "(?i)copy";
	public static String MOVE_COMMAND = "(?i)move";
	public static String CD_GO_FIRST_COMMAND = "(?i)cd\\";
	public static String CD_GO_BACK_ONCE_COMMAND = "(?i)cd..";
	public static String CD_GO_BACK_TWICE_COMMNAD = "(?i)cd..\\..";
	
	public static String ALL_DIVISION_PATTERN = "[;,=\s]+";
	public static String DIVISION_SPECIAL_PATTERN = "[;=\s]+";
	
	public static String CD_PATTERN = "^(?i)cd[;,=\s]*$";
	public static String CD_PATTERN_DRIVE = "^(?i)cd[;,=\s]+(?i)c:$";
	public static String CD_GO_FIRST_PATTERN = "^(?i)cd[;,=\s]*\\\\$";
	public static String CD_GO_BACK_TWICE_PATTERN = "^(?i)cd[;,=\s]*..\\\\..$";
	public static String CD_GO_BACK_ONCE_PATTERN = "^(?i)cd[;,=\s]*..$";
	
	public static String DIR_PATTERN = "^(?i)dir[;,=\s]*[.]?$";
	public static String DIR_ADDITIONAL_PATTERN = "^(?i)dir[;,=\s]*$";
	
	public static String COPY_CURRENT_PATTERN = "^(?i)copy[\\s;=]+([a-zA-Z]{1}:[^/:\\*\\?\"<>\\|]+)*[^/:\\*\\?\"<>\\|\\\\]*\\.(?i)(txt|ini)[\\s;,=]+([a-zA-Z]{1}:[^/:\\*\\?\"<>\\|]+)*[^/:\\*\\?\"<>\\|\\\\]*\\.(?i)(txt|ini)[\\\\s;=]*$";
	public static String COPY_SPECIAL_CURRENT_PATTERN = "^(?i)copy\\.(?i)(txt|ini)[\\s;,=]+[^/:\\*\\?\"<>\\|\\\\]*\\.(?i)(txt|ini)$";
	public static String COPY_BEGIN_PATTERN = "(?i)copy[\\s;=]*";
	public static String COPY_END_PATTERN = ".(?i)(txt|ini)";
	
	public static String ROUTE_PATTERN = "[a-zA-Z]{1}:";
	public static String ROUTE_END_PATTERN = "\\";
	
	public static Boolean UNTIL_CONSOLE_EXIT = true;

}
