<?php

session_start();
if(!isset($_SESSION['username'])) {
    header('location:/login.php');
}
?>

<html>
<!-- Side navigation -->
<head>
    <title>StarSync - Save Upload</title>
    <link href="https://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet">
    <link href="https://fonts.googleapis.com/css2?family=Baloo+Thambi+2:wght@400;500;600;700;800&display=swap" rel="stylesheet">
    <link rel="stylesheet" type="text/css" href="/css/bootstrap-dark.min.css">
    <link rel="stylesheet" type="text/css" href="/css/dashboard.css">
    <link href="https://fonts.googleapis.com/css2?family=Roboto&display=swap" rel="stylesheet">
</head>

<body>
<script type="text/javascript" src="../utils.js"></script>

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
    <div class="container-fluid">
        <form action="/upload.php" method="post" enctype="multipart/form-data">
            <h3 class="uplHeader">Select A Save File To Upload.</h3>
            <!-- <input type="file" name="fileToUpload" id="fileToUpload" required><br> -->
            <div class="custom-file overflow-hidden mb-3 ulCont">
                    <input id="customFile" name="fileToUpload" type="file" class="custom-file-input">
                    <label for="customFile" class="custom-file-label">Choose file</label>
            </div>
            <div class="input-group mb-3" id="dateBox">
                <div class="input-group-prepend">
                    <span class="input-group-text" id="basic-addon3">Date Modified</span>
                </div>
                <input type="text" class="form-control" id="dateModified" name="dateModified" aria-describedby="basic-addon3" required>
            </div>
            <div class="input-group mb-3" id="uploadDateBox">
                <div class="input-group-prepend">
                    <span class="input-group-text" id="basic-addon3">Current Date</span>
                </div>
                <input type="text" class="form-control" id="uploadDate" name="uploadDate" aria-describedby="basic-addon3" required>
            </div>
            <button type="submit" class="ulButtons"> Upload Progress </button>
            <button type="button" class="ulButtons" onclick="showFileModified()"> Get Modified Date </button>
        <button type="button" class="ulButtons" onclick="showUploadDate()"> Get Current Date </button>
        </form>
    </div>
</div>

<!--
</body>

</html>