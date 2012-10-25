using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SchedulerDotNet
{
    public class Scheduler {
	    private String owner = "";
	    private MailService mailService;
	    private SchedulerDisplay display;
	    private List<Event> evts = new List<Event>();
	
	    public Scheduler(String owner) {
		    this.owner = owner;
		
		    mailService = MailService.GetInstance();
		    display = new SchedulerDisplay();		
	    }
	
	    public void AddEvent(Event evt) {
		    evt.Added();
		    evts.Add(evt);
		    mailService.SendMail("jacques@spg1.com", "Event Notification", evt.ToString());
		    display.ShowEvent(evt);		
	    }
	
	    public bool HasEvents(DateTime date) {
		    foreach(Event evt in evts) {
			    if (evt.GetDate().Equals(date))
				    return true;
		    }
		    return false;    
	    }
	
	    public void PerformConsistencyCheck(StringBuilder message) {
		
	    }
	
	    public void Update() {
		    foreach(Event evt in evts) {
			    if (!(evt is Meeting)) {
				    continue;
			    }

			    Meeting meeting = (Meeting)evt;

			    String note = NoteRetriever.GetNote(meeting.GetDate());
			    if (note.Length == 0)
				    continue;
		
			    meeting.AppendToText(note);
		    }
	    }
	
	    public Meeting GetMeeting(DateTime date, int slot) {
		    foreach(Event evt in evts) {
			    if (!(evt is Meeting))
				    continue;
			    Meeting meeting = (Meeting)evt;
			    if (meeting.GetDate().Equals(date) && meeting.GetSlot() == slot
				    && !TimeServices.IsHoliday(meeting.GetDate()))
				    return meeting;
				
		    }
		    return null;
	    }
    }
}
