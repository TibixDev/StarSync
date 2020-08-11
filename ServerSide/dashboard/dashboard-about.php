<?php

session_start();
if(!isset($_SESSION['username'])) {
    header('location:/login.php');
}
?>

<html>
<!-- Side navigation -->
<head>
    <title>StarSync - About</title>
    <link href="https://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet">
    <link href="https://fonts.googleapis.com/css2?family=Baloo+Thambi+2:wght@400;500;600;700;800&display=swap" rel="stylesheet">
    <link rel="stylesheet" type="text/css" href="/css/bootstrap-dark.min.css">
    <link rel="stylesheet" type="text/css" href="/css/dashboard.css">
    <link href="https://fonts.googleapis.com/css2?family=Roboto&display=swap" rel="stylesheet">
</head>

<body>
<div class="sidenav">
    <ul>
        <h1 class="sbTitle">StarSync</h1>
        <h3 class="welcomeUser">Welcome, <?php echo $_SESSION['username'];?>!</h3>
        <li><a href="dashboard-upload.php"><span class="material-icons">backup</span>Upload Saves</a></li>
        <li><a href="dashboard-history.php"><span class="material-icons">save</span>Save History</a></li>
        <li><a href="dashboard-apps.php"><span class="material-icons">apps</span>Applications</a></li>
        <li><a href="dashboard-about.php"><span class="material-icons">info</span>About</a></li>
        <li class="logout"><a href="/logout.php"><span class="material-icons">exit_to_app</span>Logout</a></li>
      </ul>
</div>
  
  <!-- Page content -->
<div class="main">
    <h1 class="pl-2 pt-4"><strong>StarSync</strong> - Created with ❤️ by Tibix</h1>
    <br>
    <h2 class="pl-2">StarSync is a cross-platform cloud save management app created for Stardew Valley.</h2>
    <br>
    <h2 class="pl-2">StarSync is free, and it will always be free. I do not earn any revenue from this project. Hosting is covered by me, and any donations are welcome.</h2>
    <br>
    <br>
    <h2 class="pl-2">Credits:</h2>
    <h2 class="pl-2"><strong>ConcernedApe</strong> - For creating Stardew Valley</h2>
    <h2 class="pl-2"><strong>StackOverflow</strong> - For everything else</h2>
</div>
<!--
</body>

</html>