import Controller.*;
import Model.*;


public class MainPage {

	public static void main(String[] args) {
		Controller.Search search = new Controller.Search();
		Model.Basic basic = new Model.Basic();
		
		basic.PrintSearchPage();
		
	}

}
