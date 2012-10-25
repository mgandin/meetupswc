using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SchedulerDotNet
{
    public class Meeting : Event {
	
	    private String description;
	
	    public Meeting(DateTime date, int slot, String description) : base(date, slot) {
		    this.description = description;
	    }

	    public String GetText() {
		    return description;
	    }

	    public bool IsPastDue() {
		    return TimeServices.IsPastDue(GetDate());
	    }

        public new String ToString()
        {
            StringBuilder buffer = new StringBuilder();
		    int n = 0;
		    buffer.Append(base.ToString());
		    String result = FormatText(description);
		    buffer.Append("[" + result.Length);
		    for(n = 0; n < result.Length; n++) {
			    buffer.Append("{");			
		    }
		    buffer.Append(FormatText(description));
		    for(n = 0; n < result.Length; n++) {
			    buffer.Append("}");			
		    }		
		    buffer.Append(result.Length + "]");
		    return result;
		
	    }

  

        public void AppendToText(String newText)
	    {
		    description += newText;
	    }


	    private String FormatText(String text) 
	    {
            StringBuilder result = new StringBuilder();
		    for (int n = 0; n < text.Length; ++n) {
			    int c = text[n];
			    if (c == '<') {
				    while(text[n] != '/' && text[n] != '>')
					    n++;
				    if (text[n] == '/')
					    n+=4;
				    else
					    n++;
			    }
			    if (n < text.Length)
				    result.Append(text[n]);
		    }
		    return result.ToString();
	    }

    }
}
