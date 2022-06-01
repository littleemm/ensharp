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
	public static String CANONICAL_ROUTE = "..\\";
	
	/////////////////////////////////////////////////////
	public static String CD_PATTERN = "^(?i)cd[;,=\s]*$";
	public static String CD_PATTERN_DRIVE = "^(?i)cd[;,=\s]+(?i)c:$";
	public static String CD_GO_FIRST_PATTERN = "^(?i)cd[;,=\s]*\\\\$";
	public static String CD_GO_BACK_TWICE_PATTERN = "^(?i)cd[;,=\s]*..\\\\..$";
	public static String CD_GO_BACK_ONCE_PATTERN = "^(?i)cd[;,=\s]*..$";
	public static String CD_ROUTE_PATTERN = "^(?i)cd[;,=\s]+([a-zA-Z]{1}:[^:\\*\\?\"<>\\|]+)[;,=\s]*$";
	public static String CD_ROUTE_PATTERN_FROM_CURRENT = "^(?i)cd[;,=\s]+([^/:\\*\\?\"<>\\|]+)$";
	public static String CD_CANONICALROUTE_PATTERN = "^(?i)cd[;,=\s]+([/\\.\\\\]+)$";
	
	public static String DIR_PATTERN = "^(?i)dir[;,=\s]*(\\.|\\.\\\\)*[;,=\\s]*$";
	public static String DIR_ROUTE_PATTERN = "^(?i)dir[;,=\s]+([a-zA-Z]{1}:[^:\\*\\?\"<>\\|]+)[;,=\s]*$";
	public static String DIR_ADDITIONAL_PATTERN = "^(?i)dir[;,=\s]*$";
	
	public static String COPY_CURRENT_PATTERN = "^(?i)copy[\\s;=]+(([a-zA-Z]{1}:)*[^:\\*\\?\"<>\\|]+[\\\\]{1})?([^/:\\*\\?\"<>\\|\\\\]*\\.(?i)(txt|ini))[\\s;,=]+(([a-zA-Z]{1}:)*[^:\\*\\?\"<>\\|]+[\\\\]{1})?([^/:\\*\\?\"<>\\|\\\\]*\\.(?i)(txt|ini))[\\s;=]*$";
	public static String COPY_SPECIAL_CURRENT_PATTERN = "^(?i)copy(\\.(?i)(txt|ini))[\s;,=]+([a-zA-Z]{1}:[^:\\*\\?\"<>\\|]+[\\\\]{1})?([^/:\\*\\?\"<>\\|\\\\]*\\.(?i)(txt|ini))$";
	public static String COPY_ONE_FILE_PATTERN = "^(?i)copy[\\s;=]+([a-zA-Z]{1}:[^:\\*\\?\"<>\\|]+[\\\\]{1})?([^/:\\*\\?\"<>\\|\\\\]*\\.(?i)(txt|ini))[\\s;=]*$";
	
	public static String MOVE_CURRENT_PATTERN = "^(?i)move[\\s;=]+([a-zA-Z]{1}:[^:\\*\\?\"<>\\|]+[\\\\]{1})?([^/:\\*\\?\"<>\\|\\\\]*\\.(?i)(txt|ini))[\\s;,=]+([a-zA-Z]{1}:[^:\\*\\?\"<>\\|]+[\\\\]{1})?([^/:\\*\\?\"<>\\|\\\\]*\\.(?i)(txt|ini))[\\s;=]*$";
	public static String MOVE_SPECIAL_CURRENT_PATTERN = "^(?i)move(\\.(?i)(txt|ini))[\s;,=]+([a-zA-Z]{1}:[^:\\*\\?\"<>\\|]+[\\\\]{1})?([^/:\\*\\?\"<>\\|\\\\]*\\.(?i)(txt|ini))$";
	public static String MOVE_ONE_FILE_PATTERN = "^(?i)move[\\s;=]+([a-zA-Z]{1}:[^:\\*\\?\"<>\\|]+[\\\\]{1})?([^/:\\*\\?\"<>\\|\\\\]*\\.(?i)(txt|ini))[\\s;=]*$";
	public static String MOVE_FILE_TO_FOLDER_ABSOLUTE = "^(?i)move[\\s;=]+([a-zA-Z]{1}:[^:\\*\\?\"<>\\|]+[\\\\]{1})?([^/:\\*\\?\"<>\\|\\\\]*\\.(?i)(txt|ini))[\\s;,=]+([a-zA-Z]{1}:[^:\\*\\?\"<>\\|]+)$";
	public static String MOVE_FILE_TO_FOLDER = "^(?i)move[\\s;=]+([a-zA-Z]{1}:[^:\\*\\?\"<>\\|]+[\\\\]{1})?([^/:\\*\\?\"<>\\|\\\\]*\\.(?i)(txt|ini))[\s;,=]+(([/\\.\\\\]*)([^:\\*\\?\"<>\\|]*))$";
	///////////////////////////////////////////////////////
	
	public static String EXCEPTION_COMMAND_PATTERN_TWO = "(.*)[>]{1,2}(.*)";
	public static String EXCEPTION_COMMAND_PATTERN_THREE = "(.*)[>]{3,}(.*)";
	public static String EXCEPTION_COMMAND_PATTERN_ONE_OTHER = "(.*)[<]{1}(.*)";
	public static String EXCEPTION_COMMAND_PATTERN_TWO_OTHER = "(.*)[<]{2,}(.*)";
	
	public static String COLONS_EXCEPTION_PATTERN = "(.*)[:]{2,}(.*)";
	
	public static String ANSWER_POSITIVE = "(?i)(yes|y|ye)+";
	public static String ANSWER_NEGATIVE = "(?i)(no|n)+";
	public static String ANSWER_ALL = "(?i)(all|al|a)+";
	
	public static String DRIVE_PATTERN = "([a-zA-Z]{1}:\\\\)";
	
	public static Boolean UNTIL_CONSOLE_EXIT = true;

}
