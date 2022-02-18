<?php
    //send E-Mail
    $to_email = $_SESSION['to_email'];
    $subject = $_SESSION['subject'];
    $emailbody = $_SESSION['emailbody'];
    $headers = "From: myarchery.bslinz2@gmail.com";

    if (mail($to_email, $subject, $emailbody, $headers)) {
        array_push($message, "Email successfully sent to $to_email!<br>");
    } else {
        array_push($message, "Email sending failed!<br>");
    }


    //Print msg
    if(count($message) == 0 ) {
        
    } else {
        include('Message.php');
        die();
    }

?>