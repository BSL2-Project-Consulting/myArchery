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

    $_SESSION['outputmsg'] = array();


    //connect to dbs
    $db = mysqli_connect('localhost', 'root', 'test1234', 'myarchery') or die("could't connect to database");


    //start---------------------------------------------------------------------------------------------------------------------------------------------------------------
    //get inserted value
    $tmpemail = $_POST["email"];

    //check if we get some
    if(empty($tmpemail)) {array_push($_SESSION['outputmsg'], "E-Mail is required!");}

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
    $insertquery_password_history = "INSERT INTO password_history (password, fromdate, is_active, use_id) VALUES ('$randomencryptpassword', NOW(), '1', '$tmpuserid');";
    mysqli_query($db, $insertquery_password_history);
    //insert new pw in user
    $insertquery_user = "UPDATE user SET password = '$randomencryptpassword' WHERE use_id = '$tmpuserid';";
    mysqli_query($db, $insertquery_user);


    //send mail  
    $_SESSION['to_email'] = "julian.pichler4@gmail.com";
    $_SESSION['subject'] = "New MyArchery password!";
    $_SESSION['emailbody'] = "Hi, This is your new password: \"$randompassword\" !";

    include('SendMail.php');

?>