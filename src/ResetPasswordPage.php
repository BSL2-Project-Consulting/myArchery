<!DOCTYPE html>
<html>
  <head>
    <title>Reset-Password Page</title>
    <link rel="stylesheet" href="Styles/styles_for_resetpassword.css" />
  </head>
  <body>
    <div class="container">
      <img src="Bilder/logo.png" alt="logo.png" class="logo"/>
      <form action="ResetPasswordServer.php" method="post" >

          <div class="reset-text">
            We will replace your password with a random one and send it to you by email. 
            After that you have 20 minutes to log-in and change your password by yourself. 
            If you don't change your password within the 20 minutes, we will re-enter your old password.
            (in case you are not who you pretend to be)
          </div>
          
          <br>

          <!-- Email -->
          <div class="form-input">
            <p class="email-paragraph">E-Mail:</p>
            <input type="text" name="email" placeholder="Enter your E-Mail" required/>	
          </div>

          <button type="submit" name="reset_password" class="btn-reset">Reset Password</button>

          <p class="login-paragraph">Password remembered? <a href="archery-loginForm.html">Login</a> instead!</p>
        
      </form>
    </div>
  </body>
</html>