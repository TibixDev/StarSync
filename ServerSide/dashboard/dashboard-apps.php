<?php

session_start();
if(!isset($_SESSION['username'])) {
    header('location:/login.php');
}
?>

<html>
<!-- Side navigation -->
<head>
    <title>StarSync - Apps</title>
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
        <li><a href="dashboard-profile.php"><span class="material-icons">account_circle</span>Profile</a></li>
        <li><a href="dashboard-apps.php"><span class="material-icons">apps</span>Applications</a></li>
        <li><a href="dashboard-about.php"><span class="material-icons">info</span>About</a></li>
        <li class="logout"><a href="/logout.php"><span class="material-icons">exit_to_app</span>Logout</a></li>
      </ul>
</div>
  
  <!-- Page content -->
<div class="main">
    <div class="container-fluid">
        <h1 class="pt-3 pb-5">StarSync Application Downloads</h1>
        <row class="pb-3 pr-1 my-auto d-inline-block">
            <img class="appImg" alt="Windows Icon" src="../assets/ss_win_ico.png">
            <h2><a href="#">Windows Download</a> (v0.2 Alpha)</h2>
        </row>
        <row class="pb-3 pr-1 my-auto d-inline-block">
            <img class="appImg" alt="Android Icon" src="../assets/ss_android_ico.png">
            <h2><a href="#">Android Download</a> (v0.1 Alpha)</h2>
        </row>
        <row class="pb-3 pr-1 my-auto d-inline-block">
            <img class="appImg" alt="Ubuntu Icon" src="../assets/ss_ubuntu_ico.png">
            <h2><a href="#">Ubuntu Download</a> (TBD)</h2>
        </row>
        <row class="pb-3 pr-1 my-auto d-inline-block">
            <img class="appImg" alt="OS X Icon" src="../assets/ss_osx_ico.png">
            <h2><a href="#">OS X Download</a> (TBD)</h2>
        </row>
    </div>
</div>
<!--
</body>

</html>