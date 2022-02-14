<?php

    $to_email = "von78042@mzico.com";
    $subject = "Test email to send from XAMPP";
    $body = "Hi, This is test mail to check how to send mail from Localhost Using Gmail ";
    $headers = "From: karin.bacher4456@gmail.com";
    $i = 0;
    
    while ($i < 100) {
        if (mail($to_email, $subject, $body, $headers))
        
        {
            echo "Email successfully sent to $to_email...";
            $i = $i + 1;
        }
        
        else
        
        {
            echo "Email sending failed!";
            $i = $i + 1;
        }
    }

?>