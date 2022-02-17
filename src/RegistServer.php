<?php 

    session_start();

    //variables
    $tmpfirstname = " ";
    $tmplastname = " ";
    $tmpemail = " ";
    $tmpusername = " ";
    $tmppassword = " ";

    $errors = array();

    //connect to db
    $db = mysqli_connect('localhost', 'root', 'test1234', 'myarchery') or die("could't connect to database");

    //Register Users -----------------------------------------------------------------------------
    //get inserted values
    $tmpfirstname = $_POST["firstname"];
    $tmplastname = $_POST["lastname"];
    $tmpemail = $_POST["email"];
    $tmpusername = $_POST["username"];
    $tmppassword = $_POST["password"];

    //check if we get some
    if(empty($tmpfirstname)) {array_push($errors, "First name is required!");}
    if(empty($tmplastname)) {array_push($errors, "Last name is required!");}
    if(empty($tmpemail)) {array_push($errors, "Email is required!");}
    if(empty($tmpusername)) {array_push($errors, "Username is required!");}
    if(empty($tmppassword)) {array_push($errors, "Password is required!");}

    //check db for existing Username
    $user_check_query = "SELECT username, email FROM user WHERE username = '$tmpusername' OR email = '$tmpemail' LIMIT 1;";
    $results = mysqli_query($db, $user_check_query);
    $db_output = mysqli_fetch_assoc($results);

    if($db_output) {
        if($db_output['username'] === $tmpusername){array_push($errors, "Username already exists!");}
        if($db_output['email'] === $tmpemail){array_push($errors, "E-Mail already registered!");}
    }

    //register user if no error
    if(count($errors) == 0 ) {
        //password encrypt
        $encryptpassword = hash('sha256', $tmppassword);

        //insert into user query
        $insertquery_user = "INSERT INTO user (username, password, vname, nname, email) VALUES ('$tmpusername', '$encryptpassword', '$tmpfirstname', '$tmplastname', '$tmpemail');";
        //run query
        mysqli_query($db, $insertquery_user);

        $user_check_query = "SELECT use_id FROM user WHERE username = '$tmpusername';";
        $results = mysqli_query($db, $user_check_query);
        $db_output = mysqli_fetch_assoc($results);
        
        $tmpuserid = $db_output['use_id'];
        
        //insert into user query
        $insertquery_password_history = "INSERT INTO password_history (password, fromdate, use_id) VALUES ('$encryptpassword', NOW(), '$tmpuserid');";
        //run query
        mysqli_query($db, $insertquery_password_history);

        $_SESSION['username'] = $tmpusername;
        $_SESSION['success'] = "You are now part of the community!";

        header('location: index.php');
    } else {
        include('Errors.php');
        die();
    }

?>

