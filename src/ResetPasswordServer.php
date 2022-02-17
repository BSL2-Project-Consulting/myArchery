<?php

    session_start();

    //variables
    $tmpemail = "";
    $tmppassword = "";
    $

    $errors = array();

    //connect to dbs
    $db = mysqli_connect('localhost', 'root', 'test1234', 'myarchery') or die("could't connect to database");

    //Reset Password  --------------------------------------------------------------------------------------------------------
    //get inserted value
    $tmpemail = $_POST["email"];
    
    //check if we get some
    if(empty($tmpemail)) {array_push($errors, "E-Mail is required!");}

    

?>