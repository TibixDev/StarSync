<?php
session_start();

include_once 'constants.php';
$target_directory = "saveData" . "/" . $_SESSION['username'] . "/";
$orig_name = escape(basename($_FILES['fileToUpload']['name']));
$target_file = $target_directory . $orig_name;
$uploadOk = 0;
$fileType = strtolower(pathinfo($target_file,PATHINFO_EXTENSION));
$file_tmp = $_FILES['fileToUpload']['tmp_name'];
$upload_date = escape($_POST['uploadDate']);
$date_modified = escape($_POST['dateModified']);
$username = $_SESSION['username'];
$saveQuery = " INSERT INTO starsync_filedata(fileName, fileUploadDate, fileModifyDate, fileOwner) VALUES ('$orig_name' , '$upload_date', '$date_modified', '$username')";
$messageID = null;
$isAPICall = false;

if ($fileType !== 'zip') {
    $messageID = "uplNotZipErr";
    $uploadOk = 0;
} else {
    $uploadOk = 1;
}

if ($_FILES["fileToUpload"]["size"] > 5000000) {
    $messageID = "uplFileSizeErr";
    $uploadOk = 0;
}

if (!file_exists($target_directory)) {
    mkdir($target_directory, 0777, true);
    echo $target_directory;
}

if (!isset($date_modified) || !isset($upload_date)) {
    $uploadOk = 0;
    $messageID = "uplNoDateErr";
}

if ($uploadOk == 0) {
    redirect($messageID);
} else { 
    if (move_uploaded_file($file_tmp, $target_file)) {
        mysqli_query($conn, $saveQuery) or die(mysqli_error($conn));
        $messageID = "uplSuccess";
        redirect($messageID);
    }
}
?>