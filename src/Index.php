<?php 
    session_start();

    if(!isset($_SESSION['username'])){
        $_SESSION['msg'] = "You must log in first to view this page";
        header('location: LoginPage.php');
    }

?>

<!DOCTYPE html>
<html>
    <nav>
    <ul>
        <li><a href="Index.php">Home</a></li>
        <li><a href="Events.php">Events</a></li>
        <li><a href="Kontakt.php">Contact</a></li>
        <li><a href="LoginPage.php">Login</a></li>
    </ul>
    </nav>
  <head>
    <title>MyArchery</title>
    <link rel="stylesheet" href="Styles/styles_for_index.css" />
  </head>
  <body>
    <h1>This is the homepage!</h1>
    <?php if(isset($_SESSION['success'])) : ?>
        <div>
            <h3>
                <?php
                    echo $_SESSION['success'];
                    unset($_SESSION['success']);
                ?>
            </h3>
        </div>
    <?php endif ?>

    <?php if(isset($_SESSION['username'])) : ?>
        <h3>Welcome <strong><?php echo $_SESSION['username']; ?></strong></h3>
    <?php endif ?>

  </body>
</html>


