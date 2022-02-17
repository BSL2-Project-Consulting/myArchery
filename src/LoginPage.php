<!DOCTYPE html>
<html>
  <head>
    <title>Log-In Page</title>
    <link rel="stylesheet" href="Styles/styles_for_login.css" />
  </head>
  <body>
    <div class="container">
      <img src="Bilder/logo.png" alt="logo.png" class="logo"/>
      <form action="LoginServer.php" method="post" >

          <!-- Username -->
          <div class="form-input">
            <p class="username-paragraph">Username:</p>
            <input type="text" name="username" placeholder="Enter your Username" required/>	
          </div>

          <!-- Password -->
          <div class="form-input">
            <p class="password-paragraph">Password:</p>
            <input type="password" name="password" placeholder="Enter your Password" required/>
            <br>
            <a class="reset-password" href="ResetPasswordPage.php">Forgot password?</a>
          </div>
          
          <button type="submit" name="login_user" class="btn-login">Log-In</button>
          <a href="SendMail.php">Send Mail to julian</a>

          <p class="register-paragraph">Not a User? <a href="RegistPage.php">Register</a> instead!</p>
        
      </form>
    </div>
  </body>
</html>



