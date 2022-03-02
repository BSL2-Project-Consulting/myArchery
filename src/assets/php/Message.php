
<!DOCTYPE html>
<html>
  <head>
    <title>Message Page</title>
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

      <a href="login.html" class="button">Log-In or Regist</a>

    </div>
  </body>
</html>