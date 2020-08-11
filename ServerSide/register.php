<?php
session_start();

include_once 'constants.php';
$url = "/login.php";
$name = escape($_POST['user']);
$pass = escape($_POST['pass']);
$passHash = password_hash($pass, PASSWORD_DEFAULT);
$apiKey = bin2hex(random_bytes(32));

$s = " SELECT * FROM starsync_db WHERE userAccount = '$name'";
$result = mysqli_query($conn, $s);
$num = mysqli_num_rows($result);

if ($num == 1) {
    redirect("regUserTakenErr");
} else { 
    $registerquery = " INSERT INTO starsync_db(userAccount , userPwd, apiKey) VALUES ('$name' , '$passHash' , '$apiKey')";
    mysqli_query($conn, $registerquery) or die(mysqli_error($conn));
    redirect("regSuccess");
}

?>