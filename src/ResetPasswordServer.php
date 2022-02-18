<?php

    session_start();

    //variables
    $tmpemail = "";
    $tmppassword = "";
    $tmpuserid = "";
    $tmpuntildate = "";
    $tmpactualdate = "";
    //for random PW
    $tmpoldpassword = "";
    $randomencryptpassword = "";
    $randompassword = "";
    $characters = '.-0123456789abc.-defghijklm.-nopqrstuvwx.-yzABCDEFGHIJKLM.-NOPQRSTUVWXYZ.-';
    $charactersLength = strlen($characters);

    $message = array();


    //connect to dbs
    $db = mysqli_connect('localhost', 'root', 'test1234', 'myarchery') or die("could't connect to database");


    //start---------------------------------------------------------------------------------------------------------------------------------------------------------------
    //get inserted value
    $tmpemail = $_POST["email"];

    //check if we get some
    if(empty($tmpemail)) {array_push($message, "E-Mail is required!");}


    //random Password
    for ($i = 0; $i < 10; $i++) {
        $randompassword .= $characters[rand(0, $charactersLength - 1)];
    }
    //encrypt
    $randomencryptpassword = hash('sha256', $randompassword);

    
    //get use_id
    $user_check_query = "SELECT use_id FROM user WHERE email = '$tmpemail';";
    $results = mysqli_query($db, $user_check_query);
    $db_output = mysqli_fetch_assoc($results);
    
    $tmpuserid = $db_output['use_id'];


    //update tables
    //update untildate into password_history
    $update_password_history = "UPDATE password_history SET untildate = NOW(), is_active = 0 WHERE use_id = '$tmpuserid' AND is_active = 1;";
    mysqli_query($db, $update_password_history);
    //insert new entry for user in password_history
    $insertquery_password_history = "INSERT INTO password_history (password, fromdate, use_id) VALUES ('$randomencryptpassword', NOW(), '$tmpuserid');";
    mysqli_query($db, $insertquery_password_history);
    //insert new pw in user
    $insertquery_user = "UPDATE user SET password = '$randomencryptpassword' WHERE use_id = '$tmpuserid';";
    mysqli_query($db, $insertquery_user);


    //send mail
    $to_email = "julian.pichler4@gmail.com";
    $subject = "New MyArchery password!";
    $body = "Hi, This is your new password: \"$randompassword\" !";
    $headers = "From: myarchery.bslinz2@gmail.com";

    if (mail($to_email, $subject, $body, $headers)) {
        echo "Email successfully sent to $to_email..." . '<br>';
    } else {
        echo "Email sending failed!" . '<br>';
    }

    $i = 0;
    while ($i == 0) {
        //get untildate
        $get_untildate_query = "SELECT untildate FROM password_history WHERE use_id = '$tmpuserid' AND is_active = 1;";
        $results = mysqli_query($db, $get_untildate_query);
        $db_output = mysqli_fetch_assoc($results);

        $tmpuntildate = $db_output['untildate'];

        //get actual date
        date_default_timezone_set("Europe/Vienna");
        $tmpactualdate = date("Y-m-d") . " " . date("H:i:s");

        //is untildate over?
        if ($tmpuntildate > $tmpactualdate) {
            sleep(60);
        } else {
            $i++;
        }
    }

    $_SESSION['to_email'] = "julian.pichler4@gmail.com";
    $_SESSION['subject'] = "New MyArchery password!";
    $_SESSION['emailbody'] = "Hi, This is your new password: \"$randompassword\" !";

    //get last pw from password_history
    $get_untildate_query = "SELECT password FROM password_history WHERE use_id = '$tmpuserid' AND is_temp = 0 AND is_active = 0 ORDER BY phy_id DESC LIMIT 1;";
    $results = mysqli_query($db, $get_untildate_query);
    $db_output = mysqli_fetch_assoc($results);

    $tmpoldpassword = $db_output['password'];


    //update tables (now he inserts the previous password)
    //update untildate into password_history
    $update_password_history = "UPDATE password_history SET untildate = NOW(), is_active = 0 WHERE use_id = '$tmpuserid' AND is_active = 1;";
    mysqli_query($db, $update_password_history);
    //insert new entry for user in password_history
    $insertquery_password_history = "INSERT INTO password_history (password, fromdate, is_temp, is_active, use_id) VALUES ('$tmpoldpassword', NOW(), '0', '1', '$tmpuserid');";
    mysqli_query($db, $insertquery_password_history);
    //insert old pw in user
    $insertquery_user = "UPDATE user SET password = '$tmpoldpassword' WHERE use_id = '$tmpuserid';";
    mysqli_query($db, $insertquery_user);
    include('SendMail.php');


    //send mail for test
    $to_email = "julian.pichler4@gmail.com";
    $subject = "We changed you pw back!";
    $body = "Sheeeh wieder altes pw in DB!";
    $headers = "From: myarchery.bslinz2@gmail.com";

    if (mail($to_email, $subject, $body, $headers)) {
        echo "Email successfully sent to $to_email..." . '<br>';
    //pushin errors/msg's
    if(count($message) == 0 ) {

    } else {
        echo "Email sending failed!" . '<br>';
        include('Message.php');
        die();
    }


?>