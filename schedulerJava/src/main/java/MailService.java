import java.util.Date;
import java.util.Properties;

import javax.mail.Message;
import javax.mail.MessagingException;
import javax.mail.Session;
import javax.mail.Transport;
import javax.mail.internet.MimeMessage;


public class MailService {
	private static MailService instance;
	private Properties props;
	
   private MailService() {
    	props = new Properties();
	    props.put("mail.smtp.host", "my-mail-server");
	    props.put("mail.from", "antoine.contal@orange-ftgroup.com");
    }
    
    public static MailService getInstance() {
        if (instance == null)
        	instance = new MailService();
        return instance;
    }
    
	/* (non-Javadoc)
	 * @see IMailService#sendMail(java.lang.String, java.lang.String, java.lang.String)
	 */
	public void sendMail(String address, String subject, String message) {
		
	    Session session = Session.getInstance(props, null);

	    try {
	        MimeMessage msg = new MimeMessage(session);
	        msg.setFrom();
	        msg.setRecipients(Message.RecipientType.TO,
	                          address);
	        msg.setSubject(subject);
	        msg.setSentDate(new Date());
	        msg.setText(message);
	        Transport.send(msg);
	    } catch (MessagingException mex) {
	        throw new RuntimeException("send failed, exception: " + mex);
	    }

	}
}
