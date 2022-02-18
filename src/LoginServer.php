<?php

    session_start();

    //variables
    $tmpusername = "";
    $tmppassword = "";

    $errors = array();

    //connect to dbs
    $db = mysqli_connect('localhost', 'root', 'test1234', 'myarchery') or die("could't connect to database");

    //Log-In Users --------------------------------------------------------------------------------------------------------
    //get inserted values
    $tmpusername = $_POST["username"];
    $tmppassword = $_POST["password"]; 
    
    //check if we get some
    if(empty($tmpusername)) {array_push($errors, "Username is required!");}
    if(empty($tmppassword)) {array_push($errors, "Password is required!");}

    //encrypt password
    // $encryptpassword = "";
    $encryptpassword = hash('sha256', $tmppassword);

    //check db for inserted Username and Password and get the data 
    $user_check_query = "SELECT password FROM user WHERE username = '$tmpusername';";
    $results = mysqli_query($db, $user_check_query);
    $user = mysqli_fetch_assoc($results);

    //compare inserted with db
    if(!IS_NULL($user)) {
        if($user['password'] == $encryptpassword){
            //Log-In User
            $_SESSION['username'] = $tmpusername;
            $_SESSION['success'] = "Your Log-In was successfully!";

            header('location: index.php');
        } else {
            array_push($errors, "Password incorrect! Please try again!");
            include('Errors.php');
            die();
        }
    } else {
        array_push($errors, "Username unknown! Please register first!");
        include('Errors.php');
        die();
    }

?>