<?php
session_start();
include_once("constants.php");
?>

<!DOCTYPE html>
<html>
<head>
    <title>StarSync - Redirect</title>
    <link href="https://fonts.googleapis.com/css2?family=Nunito&display=swap" rel="stylesheet">
    <style>
    body {
        background-color: #2b2b2b;
    }

    .redirBox{
        background-color: #474747;
        margin: auto;
        height: 25%;
        width: 50%;
        border: 10px solid #474747;
        border-radius: 20px;
        padding-top: 1%;
        padding-bottom: 1%;
    }

    h1 {
        color: white;
        margin: auto;
        font-family: Nunito;
        font-size: 20pt;
        text-align: center;
    }

    .titleHeader {
        font-size: 35pt;
        margin: auto;
        text-align: center;
        padding-bottom: 2%;
    }
    </style>
</head>
<body>
<h1 class="titleHeader">StarSync Redirect</h1>

<?php

$msgID = 'default';

if (isset($_GET['messageID'])) {
    $msgID = escape($_GET['messageID']);
}

$finalMsg = null;
$redirectUrl = null;
$timeInMilis = 3000;

switch($msgID) {
    default:
        $finalMsg = "Unknown redirect reason. Redirecting to home...";
        $redirectUrl = "/";
    break;

    case "uplSuccess":
        $finalMsg = "Upload successful! Redirecting to dashboard...";
        $redirectUrl = "/dashboard/dashboard-upload.php";
    break;

    case "uplFailed":
        $finalMsg = "Upload failed! Please try again later. Redirecting to dashboard...";
        $redirectUrl = "/dashboard/dashboard-upload.php";
    break;

    case "uplNoFileErr":
        $finalMsg = "Upload failed! There was no file provided to be uploaded. Redirecting to dashboard...";
        $redirectUrl = "/dashboard/dashboard-upload.php";
    break;

    case "uplNotZipErr":
        $finalMsg = "Upload failed! Your file was not in a .zip format. Redirecting to dashboard...";
        $redirectUrl = "/dashboard/dashboard-upload.php";
    break;

    case "uplFileSizeErr":
        $finalMsg = "Upload failed! File size surpassed 50MB. Redirecting to dashboard...";
        $redirectUrl = "/dashboard/dashboard-upload.php";
    break;

    case "uplNoDateErr":
        $finalMsg = "Upload failed! An upload / modified date was not set. Redirecting to dashboard...";
        $redirectUrl = "/dashboard/dashboard-upload.php";
    break;

    case "loginSuccess":
        $finalMsg = "Login successful! Redirecting to dashboard...";
        $redirectUrl = "/dashboard/dashboard-upload.php";
    break;

    case "logoutSuccess":
        $finalMsg = "Log out successful! Redirecting to login...";
        $redirectUrl = "/login.php";
    break;

    case "loginFailed":
        $finalMsg = "Login failed! Make sure your password is correct, and that the username supplied is a valid user. Redirecting to login...";
        $redirectUrl = "/login.php";
        $timeInMilis = 5000;
    break;

    case "regUserTakenErr":
        $finalMsg = "Registration failed! The specified username already is taken. Redirecting to registration...";
        $redirectUrl = "/login.php";
    break;

    case "regSuccess":
        $finalMsg = "Registration successful! Welcome to StarSync. Redirecting to login...";
        $redirectUrl = "/login.php";
    break;
}

echo '<div class="redirBox">';
echo '<h1>' . $finalMsg . '</h1>';
echo '</div>';
echo '<script language="javascript">setTimeout(function(){ window.location.href ="'. $redirectUrl .'"; }, ' . $timeInMilis . ')</script>';
?>

</body>
</html>