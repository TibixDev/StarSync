<?php
session_start();

if(!isset($_SESSION['username'])) {
    header('location:/login.php');
}

include_once '../constants.php';
$user = $_SESSION['username'];
$query = "SELECT * FROM starsync_filedata WHERE fileOwner = '$user' ORDER BY fileUploadDate DESC";
?>

<html>
<!-- Side navigation -->
<head>
    <title>StarSync - Save Managment</title>
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
        <li><a href="dashboard-profile.php"><span class="material-icons">account_circle</span>Profile</a></li>
        <li><a href="dashboard-apps.php"><span class="material-icons">apps</span>Applications</a></li>
        <li><a href="dashboard-about.php"><span class="material-icons">info</span>About</a></li>
        <li class="logout"><a href="/logout.php"><span class="material-icons">exit_to_app</span>Logout</a></li>
      </ul>
</div>
  
  <!-- Page content -->
<div class="main">
    <div class="container-fluid">
        <h1 class="saveTextHeader">Save Data</h1>
        <?php
            $result = mysqli_query($conn, $query);
            echo '<table class="table saveDataTable"><thead class="coloredTableHead"><tr><th>File Name</th><th>Upload Date</th><th>Modify Date</th><th>File Owner</th></tr></thead>';
            while($row = mysqli_fetch_array($result)) 
            {
                echo "<tr><td class='tableLink'>" . "<a href=http://starsync.000webhostapp.com/saveData/$user/" . $row['fileName'] . ">". $row['fileName'] . "</td><td>" . $row['fileUploadDate'] . "</td><td>" . $row['fileModifyDate'] . "</td><td>" . $row['fileOwner'] . "</td></th>";
            }
            echo "</table>";
        ?>
    </div>
</div>

<!--
</body>

</html>