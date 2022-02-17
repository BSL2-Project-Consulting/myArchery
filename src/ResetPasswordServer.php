<?php

    session_start();

    //variables
    $tmpemail = "";
    $tmppassword = "";
    $tmpuserid = "";
    //for random PW
    $randomencryptpassword = "";
    $randompassword = "";
    $characters = '.-0123456789abc.-defghijklm.-nopqrstuvwx.-yzABCDEFGHIJKLM.-NOPQRSTUVWXYZ.-';
    $charactersLength = strlen($characters);

    $errors = array();

    //connect to dbs
    $db = mysqli_connect('localhost', 'root', 'test1234', 'myarchery') or die("could't connect to database");

    //Reset Password  --------------------------------------------------------------------------------------------------------
    //get inserted value
    $tmpemail = $_POST["email"];
    
    //check if we get some
    if(empty($tmpemail)) {array_push($errors, "E-Mail is required!");}

    //random Password
    for ($i = 0; $i < 10; $i++) {
        $randompassword .= $characters[rand(0, $charactersLength - 1)];
    }

    $randomencryptpassword = hash('sha256', $randompassword);
    
    //get use_id
    $user_check_query = "SELECT use_id FROM user WHERE email = '$tmpemail';";
    $results = mysqli_query($db, $user_check_query);
    $db_output = mysqli_fetch_assoc($results);
    
    $tmpuserid = $db_output['use_id'];

    //update untildate into password_history
    $update_password_history = "UPDATE password_history SET Untildate = NOW() WHERE use_id = '$tmpuserid' AND untildate is NULL;";
    mysqli_query($db, $update_password_history);

    //insert new entry for user in password_history
    $insertquery_password_history = "INSERT INTO password_history (password, fromdate, untildate, use_id) VALUES ('$randomencryptpassword', NOW(), DATE_ADD(NOW(), INTERVAL 20 MINUTE), '$tmpuserid');";
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
        echo "Email successfully sent to $to_email...";
    } else {
        echo "Email sending failed!";
    }
    




    //check every min if password is expired
    //get fromdate
    /*
    $user_check_query = "SELECT use_id FROM user WHERE email = '$tmpemail';";
    $results = mysqli_query($db, $user_check_query);
    $db_output = mysqli_fetch_assoc($results);
    
    $tmpuserid = $db_output['use_id'];
    */

?>