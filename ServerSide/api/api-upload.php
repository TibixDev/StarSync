<?php
session_start();
include_once("../constants.php");

function apiUpload($user, $file, $uploadDate, $modifiedDate, $conn) {
    $target_directory = "../saveData" . "/" . $user . "/";
    $orig_name = escape($file['name']);
    $target_file = $target_directory . $orig_name;
    $uploadOk = 0;
    $fileType = strtolower(pathinfo($target_file, PATHINFO_EXTENSION));
    $file_tmp = $file['tmp_name'];
    $upload_date = escape($uploadDate);
    $date_modified = escape($modifiedDate);
    $saveQuery = " INSERT INTO starsync_filedata(fileName, fileUploadDate, fileModifyDate, fileOwner) VALUES ('$orig_name' , '$upload_date', '$date_modified', '$user')";
    $apiResponse = new stdClass();

    if ($fileType !== 'zip') {
        $apiResponse->response = "File was not in ZIP format.";
        $apiResponse->status = "error";
        $uploadOk = 0;
    } else {
        $uploadOk = 1;
    }

    if ($_FILES["fileToUpload"]["size"] > 5000000) {
        $apiResponse->response = "File exceeded the 50MB limit.";
        $apiResponse->status = "error";
        $uploadOk = 0;
    }

    if (!file_exists($target_directory)) {
        mkdir($target_directory, 0777, true);
    }

    if (!isset($date_modified) || !isset($upload_date)) {
        $apiResponse->response = "An upload / modify date was not supplied.";
        $apiResponse->status = "error";
        $uploadOk = 0;
    }

    if ($uploadOk == 1) {
        if (move_uploaded_file($file_tmp, $target_file)) {
            mysqli_query($conn, $saveQuery) or die(mysqli_error($conn));
            incrementSaveCount($user, true);
            $apiResponse->response = "The file " . $orig_name . " has been uploaded.";
            $apiResponse->status = "success";
            $finalResp = json_encode($apiResponse);
            echo $finalResp;
        }
    }

    else {
        $finalResp = json_encode($apiResponse);
        echo $finalResp;
    }
}
?>