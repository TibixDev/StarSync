<?php
session_start();

include_once 'constants.php';
$user = $_SESSION['username'];
$saveQuery = "SELECT * FROM starsync_filedata WHERE fileOwner = '$user'";
$result = mysqli_query($conn, $saveQuery);
//$row = mysqli_fetch_array($result);
//header('location:'.$row[2]);

echo "<table>";

while ($row = mysqli_fetch_array($result)) {
    echo "<tr><td>" . $row['fileName'] . "</td><td>" . $row['fileUploadDate'] . "</td><td>" . $row['fileModifyDate'] . "</td><td>" . $row['fileOwner'] . "</td></tr>";
}

echo "</table>";

?>