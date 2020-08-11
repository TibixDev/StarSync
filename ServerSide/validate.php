<?php
session_start();

include_once 'constants.php';
$name = escape($_POST['user']);
$pass = escape($_POST['pass']);
$accSearch = " SELECT * FROM starsync_db WHERE userAccount = '$name'";
$result = mysqli_query($conn, $accSearch);
$totalAccs = mysqli_num_rows($result);

if ($totalAccs == 1) {
    $passHashQuery = "SELECT userPwd FROM starsync_db WHERE userAccount = '$name'";
    $phqResult = mysqli_query($conn, $passHashQuery);
    $row = mysqli_fetch_assoc($phqResult);
    $passHash = $row["userPwd"];
    if (password_verify($pass, $passHash)) 
    {
        $_SESSION['username'] = $name;
        redirect("loginSuccess");
        exit();
    }
    else {
        redirect("loginFailed");
        exit();
    }
} else { 
    redirect("loginFailed");
    exit();
}

?>