import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.Statement;
import java.text.SimpleDateFormat;
import java.util.Date;

public class NoteRetriever {

	
	public static String get_note(Date date) throws Exception {
    	
    	Class.forName("org.hsqldb.jdbcDriver").newInstance();
//    	Connection connection =  DriverManager.getConnection("jdbc:hsqldb:file:src/db/dbtva",
//				"sa", "");
    	
    	SimpleDateFormat dateFormat = new SimpleDateFormat("dd/MM/yyyy");

    	Connection connection =  DriverManager.getConnection("jdbc:hsqldb:mem:test",
				"sa", "");
    	
    	// ####
    	// To Remove !!
    	
    	Statement createStatement = connection.createStatement();
    	createStatement.executeUpdate("create table event (note varchar(30), date varchar(30))");
    	
    	createStatement.execute("insert into event (note,date) values ('toto','" + dateFormat.format(date) + "')");
    	createStatement.close();
    	
    	PreparedStatement preparedStatement = connection.prepareStatement("Select note from event where date=?");
    	preparedStatement.setString(1, dateFormat.format(date));
    	
    	ResultSet resultSet = preparedStatement.executeQuery();
    	
    	resultSet.next();
    	
    	return resultSet.getString("note");
    }
}
