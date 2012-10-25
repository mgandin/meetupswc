import java.util.Date;

public class TimeServices {

	public static boolean isPastDue(Date date) {
		
		return date.before(date);
	}
	
	public static boolean isWorkDay(Date date) {
		return false;
	}
	
	public static boolean isHoliday(Date date) {
		return false;
	}
}
