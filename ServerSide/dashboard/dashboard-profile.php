<?php
session_start();

if(!isset($_SESSION['username'])) {
    header('location:/login.php');
}
?>

<html>
<!-- Side navigation -->
<head>
    <title>StarSync - Profile</title>
    <link href="https://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet">
    <link href="https://fonts.googleapis.com/css2?family=Baloo+Thambi+2:wght@400;500;600;700;800&display=swap" rel="stylesheet">
    <link rel="stylesheet" type="text/css" href="/css/bootstrap-dark.min.css">
    <link rel="stylesheet" type="text/css" href="/css/dashboard.css">
    <link href="https://fonts.googleapis.com/css2?family=Roboto&display=swap" rel="stylesheet">
    <script>
        function copyAPIKey() {
            var key = "<?php echo $_SESSION['apiKey'];?>";
            var tempBox = document.createElement("textarea");
            document.body.appendChild(tempBox);
            tempBox.value = key;
            tempBox.select();
            document.execCommand("copy");
            document.body.removeChild(tempBox);
        }
    </script>
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
        <div class="profileContainer">
            <div class="profileHeader pt-5 text-center">
                <img src="../assets/ss_profile_ico.png" id="pic" class="pt-2" alt="User Icon"></img>
                <h1 class="pt-2"><?php echo $_SESSION['username'];?></h1>
            </div>
            <div class="row pt-3">
                <div class="col text-right">
                    <h2 class="text-right">Registered On: 2020/8/20</h2>
                    <h2 class="text-right">Saves Upload: 14</h2>
                    <h2 class="text-right">Times Synced: 200</h2>
                </div>
                <div id="sep" class="mx-1">
                </div>
                <div class="col text-left">
                    <h2 class="text-left">API Key: <button type="button" class="ulButtons" style="font-size: 20px; margin: 0; padding-left: 5px; padding-right: 5px;" onclick="copyAPIKey();">Copy</button><h2>
                    <h2 class="text-left">QR: <img class="ml-2" src="../api/api-qrgen.php?input=<?php echo $_SESSION['apiKey'];?>"></h2>
                </div>
            </div>
        </div>
    </div>
</div>
<!--
</body>

</html>