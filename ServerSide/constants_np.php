<?php
$conn = new mysqli('localhost', 'id12642094_starsync_admin', 'n0p3', 'id12642094_starsync_members');
$uplUrl = "http://starsync.000webhostapp.com/upload.php";

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
?>