<?php

    $to_email = $_SESSION['to_email'];
    $subject = $_SESSION['subject'];
    $emailbody = $_SESSION['emailbody'];
    $headers = "From: myarchery.bslinz2@gmail.com";

    if (mail($to_email, $subject, $emailbody, $headers)) {
        array_push($_SESSION['outputmsg'], "Email successfully sent to $to_email!<br>");
    } else {
        array_push($_SESSION['outputmsg'], "Email sending failed!<br>");
    }

    if(count($_SESSION['outputmsg']) > 0) {
        include('Message.php');
        die();
    }


?>