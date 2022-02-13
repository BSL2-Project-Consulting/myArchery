

<!DOCTYPE html>
<html>
  <head>
    <title>Registration Page</title>
    <link rel="stylesheet" href="Styles/styles_for_register.css" />
  </head>
  <body>
    <div class="container">
      <img src="Bilder/logo.png" alt="logo.png" class="logo"/>
      <form name="form" action="RegistServer.php" method="post" >

        <!-- First Name -->
        <div class="form-input">
          <p class="firstname-paragraph">First Name:</p>
          <input type="text" name="firstname" id="firstname" placeholder="Enter your First Name" required/>	
        </div>

        <!-- Last Name -->
        <div class="form-input">
          <p class="lastname-paragraph">Last Name:</p>
          <input type="text" name="lastname" id="lastname" placeholder="Enter your Last Name" required/>	
        </div>

        <!-- Email -->
        <div class="form-input">
          <p class="email-paragraph">E-Mail:</p>
          <input type="email" name="email" id="email" placeholder="Enter your E-Mail" required/>	
        </div>

        <!-- Username -->
        <div class="form-input">
            <p class="username-paragraph">Username:</p>
            <input type="text" name="username" id="username" placeholder="Enter a Username" required/>	
        </div>

        <!-- Password -->
        <div class="form-input">
          <p class="password-paragraph">Password:</p>
            <input type="password" name="password" id="password" placeholder="Enter a Password" required/>
        </div>

        <button type="submit" name="reg_user" class="btn-login">Register</button>

        <p class="login-paragraph">Already a User? <a href="LoginPage.php">Log-In</a> instead!</p>
        
      </form>
    </div>
  </body>
</html>

