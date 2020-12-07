<?php
$conn = new mysqli('localhost', 'id12642094_starsync_admin', 'n0p3', 'id12642094_starsync_members');
$uplUrl = "http://yourwebserver.example/api/api_upload.php";

function redirect($msgID) {
    echo '<script language="javascript">setTimeout(function(){ window.location.href ="/redirect.php?messageID='. $msgID .'"; }, 0)</script>';
}

function escape($string) {
    $conn = new mysqli('localhost', 'id12642094_starsync_admin', 'n0p3', 'id12642094_starsync_members');
    $final = mysqli_real_escape_string($conn, $string);
    return $final;
}

function sortTime($time1, $time2) {
    return strtotime($time1) - strtotime($time2);
}

function incrementSaveCount($user, $increment) {
    $conn = new mysqli('localhost', 'id12642094_starsync_admin', 'n0p3', 'id12642094_starsync_members');
    if ($increment) {
        $query = "UPDATE starsync_db SET saveCount=saveCount+1 WHERE userAccount='$user'";
        mysqli_query($conn, $query);
    } else {
        $query = "UPDATE starsync_db SET saveCount=saveCount-1 WHERE userAccount='$user'";
        mysqli_query($conn, $query);
    }
}

function incrementSyncCount($user) {
    $conn = new mysqli('localhost', 'id12642094_starsync_admin', 'n0p3', 'id12642094_starsync_members');
    $query = "UPDATE starsync_db SET syncCount=syncCount+1 WHERE userAccount='$user'";
    mysqli_query($conn, $query);
}
?>
