<?php
session_start();

include_once 'constants.php';
$url = "/login.php";
$name = escape($_POST['user']);
$pass = escape($_POST['pass']);
$passHash = password_hash($pass, PASSWORD_DEFAULT);
$apiKey = bin2hex(random_bytes(32));
$regDate = date('Y-m-d H:i:s', time());

$s = " SELECT * FROM starsync_db WHERE userAccount = '$name'";
$result = mysqli_query($conn, $s);
$num = mysqli_num_rows($result);

if ($num == 1) {
    redirect("regUserTakenErr");
} else { 
    $registerquery = " INSERT INTO starsync_db(userAccount , userPwd, apiKey, regDate, saveCount, syncCount) VALUES ('$name' , '$passHash' , '$apiKey', '$regDate', '0', '0')";
    mysqli_query($conn, $registerquery) or die(mysqli_error($conn));
    redirect("regSuccess");
}

?>