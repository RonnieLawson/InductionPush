<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">

<% 
	dim message
	dim notificationType
	notificationType = Request.Form("NotificationType")
	select case notificationType
		case "MessageReceived"
			HandleIncomingMessage()
		case "MessageEvent"
			HandleMessageEvent()
		case "MessageError"
			HandleMessageError()
	end select
	
	sub HandleIncomingMessage
		message = "<p>Received message</p>"
		message = message & "<p>ID: " & Request.Form("id") & "</p>"
		message = message & "<p>Originator: " & Request.Form("originator") & "</p>"
		message = message & "<p>Recipient: " & Request.Form("recipient") & "</p>"
		message = message & "<p>Body: " & Request.Form("body") & "</p>"
		message = message & "<p>Type: " & Request.Form("type") & "</p>"
		message = message & "<p>Received At: " & Request.Form("receivedAt") & "</p>"
	end sub
	
	sub HandleMessageEvent()
		message = "<p>Received message event</p>"
		message = message & "<p>ID: " & Request.Form("id") & "</p>"
		message = message & "<p>Event Type: " & Request.Form("eventType") & "</p>"
		message = message & "<p>Occurred At: " & Request.Form("occurredAt") & "</p>"
	end sub
	
	sub HandleMessageError()
		message = "<p>Received message error</p>"
		message = message & "<p>ID: " & Request.Form("id") & "</p>"
		message = message & "<p>Error Type: " & Request.Form("errorType") & "</p>"
		message = message & "<p>Occurred At: " & Request.Form("occurredAt") & "</p>"
		message = message & "<p>Detail: " & Request.Form("detail") & "</p>"
	end sub
%>


<html>
	<head>
		<title>Esendex Account Event Handler Example</title></head>
	<body>
		<h3>Esendex Account Event Handler Example</h3>
		<%Response.Write(message)%>
	</body>
</html>
