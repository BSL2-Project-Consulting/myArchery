
<!DOCTYPE html>
<html>
  <head>
    <title>Error Page</title>
    <link rel="stylesheet" href="Styles/styles_for_message.css" />
  </head>
  <body>
    <div class="container">

      <img src="Bilder/logo.png" alt="logo.png" class="logo"/>
                    
      <?php if(count($_SESSION['outputmsg']) > 0 ) : ?>
          
          <div class="error_msg">

              <?php foreach($_SESSION['outputmsg'] as $msg) : ?>

                  <p><?php echo $msg ?></p>

              <?php endforeach ?>

          </div>

      <?php endif ?>
      
      <br>

      <a href="RegistPage.php" class="button">Go to Registration</a>
      <a href="LoginPage.php" class="button">Go to Log-In</a>

    </div>
  </body>
</html>