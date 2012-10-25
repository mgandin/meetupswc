
public class SchedulerDisplay {
	public void showEvent(Event event) {
		for(int n = 0; n < 100; n++) {
			try {
				Thread.sleep(1000);
			} catch (InterruptedException e) {
				throw new RuntimeException(e);
			}
			System.out.println("[" + event.getDate() + "]");	
		}
	}
}
