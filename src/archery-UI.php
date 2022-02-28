<?php 
    session_start();
    
    if(!isset($_SESSION['username'])){
        header('location: LoginPage.php');
    }

?>

<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="utf-8">
    <meta content="width=device-width, initial-scale=1.0" name="viewport">

    <title>Startseite - Archery </title>
    <meta content="" name="description">
    <meta content="" name="keywords">

    <!-- Favicons -->
    <link href="assets/img/logo/logo_archery.png" rel="icon">

    <!-- Google Fonts -->
    <link
        href="https://fonts.googleapis.com/css?family=Open+Sans:300,300i,400,400i,600,600i,700,700i|Krub:300,300i,400,400i,500,500i,600,600i,700,700i|Poppins:300,300i,400,400i,500,500i,600,600i,700,700i"
        rel="stylesheet">

    <!-- Vendor CSS Files -->
    <link href="assets/vendor/aos/aos.css" rel="stylesheet">
    <link href="assets/vendor/bootstrap/css/bootstrap.min.css" rel="stylesheet">
    <link href="assets/vendor/bootstrap-icons/bootstrap-icons.css" rel="stylesheet">
    <link href="assets/vendor/boxicons/css/boxicons.min.css " rel="stylesheet">
    <link href="assets/vendor/glightbox/css/glightbox.min.css" rel="stylesheet">
    <link href="assets/vendor/swiper/swiper-bundle.min.css" rel="stylesheet">

    <!-- Template Main CSS File -->
    <link href="assets/css/style.css" rel="stylesheet">

    <!-- Navbar Login Form Input -->
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.0/css/bootstrap.min.css">
    <script src="https://code.jquery.com/jquery-3.5.1.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/popper.js@1.16.0/dist/umd/popper.min.js"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.0/js/bootstrap.min.js"></script>
</head>

<body>

    <!-- ========= Header =========== -->
    <header id="header" class="fixed-top">
        <div class="container d-flex align-items-center justify-content-between">
            <h1 class="logo">ARCHERY<a href="archery-UI.html" class="logo"><img src="assets/img/logo/firmen_logo.jfif"
                        alt="" class="img-fluid"></a></h1>
            <nav id="navbar" class="navbar navbar-expand-lg ">
                <ul>
                    <li><a class="nav-link scrollto active" href="#">Home</a></li>
                    <li><a class="nav-link scrollto" href="#">About</a></li>
                    <li><a class="nav-link scrollto" href="#">All Events</a></li>
                    <li><a class="nav-link scrollto" href="#">Create Events</a></li>
                    <div class="navbar-nav" style="padding-left: 1rem;">
                        <a href="#" data-toggle="dropdown" class="nav-item nav-link dropdown-toggle ">Login</a>
                        <div class="dropdown-menu login-form">
                            <form action="LoginServer.php" method="post">
                                <div class="form-group">
                                    <label>Username</label>
                                    <input type="text" name="username" class="form-control" required="required">
                                </div>
                                <div class="form-group">
                                    <div class="clearfix">
                                        <label>Password</label>
                                        <a href="ResetPasswordPage.php" class="float-right text-muted"><small>Forgot?</small></a>
                                    </div>
                                    <input type="password" name="password" class="form-control" required="required">
                                </div>
                                <input type="submit" class="btn btn-primary btn-block" value="Login">
                            </form>
                        </div>
                    </div>
                    <img src="assets/img/icons/login_icon.png"
                        style="max-width: 20px; max-height: 20px; margin-left: 5px; margin-bottom: 1px;">
                </ul>
            </nav>
        </div>
    </header>
    <section id="hero" class="d-flex align-items-center">

        <div class="container d-flex flex-column align-items-center justify-content-center" data-aos="fade-up">
            <h1>Archery</h1>
            <h2>Our Software to bring your archery club to a new level.</h2>
            <a href="archery-eventCreate.html" class="btn-get-started scrollto">Get Started</a>
            <img src="assets/img/logo/logo_archery.png" class="img-fluid" data-aos="zoom-in" data-aos-delay="150">
        </div>
    </section>

    <main id="main">

    </main>

    <script src="assets/vendor/aos/aos.js"></script>
    <script src="assets/vendor/bootstrap/js/bootstrap.bundle.min.js"></script>
    <script src="assets/vendor/glightbox/js/glightbox.min.js"></script>
    <script src="assets/vendor/isotope-layout/isotope.pkgd.min.js"></script>
    <script src="assets/vendor/swiper/swiper-bundle.min.js"></script>
    <script src="assets/vendor/php-email-form/validate.js"></script>
    <script src="assets/js/archery.js"></script>
</body>

</html>