<?php
    session_start();
    include_once("../constants.php");
    $action = null;
    if (isset($_POST['action'])) {
        $action = escape($_POST['action']);
    }
    $apiResponse = null;
    $validAuth = false;
    $currentUser = null;


    /* API Key Verification Prep */
    
    if (isset($_POST["apiKey"])) {
        $apiKey = escape($_POST['apiKey']);
        $validationQuery = "SELECT userAccount FROM starsync_db WHERE apiKey = '$apiKey'";
        $validationResp = mysqli_query($conn, $validationQuery);
        $validationArray = mysqli_fetch_assoc($validationResp);

        if (mysqli_num_rows($validationResp) != 0) {
            $validAuth = true;
            $currentUser = $validationArray["userAccount"];
            $_SESSION["username"] = $currentUser;
        }
        else {
            $apiResponse->response = "invalidAPIKey";
            $apiResponse->status = "error";
            $validAuth = false;
        }
    }

    else {
        $apiResponse->response = "noAPIKey";
        $apiResponse->status = "error";
    }

    /* API Action Handler */

    switch ($action) {
        case "validateAuth":
            $validationQuery = "SELECT userAccount FROM starsync_db WHERE apiKey = '$apiKey'";
            $validationResp = mysqli_query($conn, $validationQuery);
            $validationArray = mysqli_fetch_assoc($validationResp);
            if (mysqli_num_rows($validationResp) != 0) {
                $validatedUser = $validationArray["userAccount"];
                $apiResponse->response = $validatedUser;
                $apiResponse->status = "success";
            }
            else {
                $apiResponse->response = "invalidAPIKey";
                $apiResponse->status = "error";
            }
        break;

        case "getLatest":
            if ($validAuth) {
                $latestURL = null;
                $fileListQuery = "SELECT * FROM starsync_filedata WHERE fileOwner = '$currentUser'";
                $fileListResult = mysqli_query($conn, $fileListQuery);
                if (mysqli_num_rows($fileListResult) == 0) {
                    $apiResponse->response = "noSaves";
                    $apiResponse->status = "error";
                    break;
                }
                $tempArray = [];
                while ($fileListRow = mysqli_fetch_assoc($fileListResult)) {
                    array_push($tempArray, $fileListRow["fileUploadDate"]);
                }
                usort($tempArray, "sortTime");
                $latestDate = end($tempArray);
                mysqli_data_seek($fileListResult, 0);
                while ($fileListRow = mysqli_fetch_assoc($fileListResult)) {
                    if ($fileListRow["fileUploadDate"] == $latestDate) {
                        $latestURL = $fileListRow["fileName"];
                        $latestUploadDate = $fileListRow["fileUploadDate"];
                        $latestModifyDate = $fileListRow["fileModifyDate"];
                        $apiResponse->response = $latestURL;
                        $apiResponse->uploadDate = $latestUploadDate;
                        $apiResponse->modifyDate = $latestModifyDate;
                        $apiResponse->status = "success";
                        break;
                    }
                }
            }
        break;

        case "retrieveLatest":
            if ($validAuth) {
                $latestURL = null;
                $fileListQuery = "SELECT * FROM starsync_filedata WHERE fileOwner = '$currentUser' ORDER BY fileUploadDate DESC";
                $fileListResult = mysqli_query($conn, $fileListQuery);
                if (mysqli_num_rows($fileListResult) == 0) {
                    $apiResponse->response = "The user hasn't uploaded any saves yet.";
                    $apiResponse->status = "info";
                    break;
                }
                $latestRow = mysqli_fetch_assoc($fileListResult);
                $latestFile = $latestRow["fileName"];
                $apiResponse->response = $latestFile;
                $apiResponse->status = "success";
            }
        break;

        case "uploadLatest":
            if ($validAuth) {
                if (!isset($_FILES["fileToUpload"])) {
                    $apiResponse->response = "No file was supplied.";
                    $apiResponse->status = "error";
                    break;
                }
                
                if (!isset($_POST["uploadDate"])) {
                    $apiResponse->response = "No upload date was supplied.";
                    $apiResponse->status = "error";
                    break;
                }

                if (!isset($_POST["modifiedDate"])) {
                    $apiResponse->response = "No modify date was supplied.";
                    $apiResponse->status = "error";
                    break;
                }

                $fileToUpload = $_FILES["fileToUpload"];
                $uploadDate = escape($_POST["uploadDate"]);
                $modifiedDate = escape($_POST["modifiedDate"]);

                include_once("api-upload.php");
                apiUpload($currentUser, $fileToUpload, $uploadDate, $modifiedDate, $conn);
            }
        break;

        default: 
            if ($validAuth) {
                $apiResponse->response = "No valid API action was specified.";
                $apiResponse->status = "error";
            }
        break;
    }

    if ($action != "uploadLatest") {
        $finalResp = json_encode($apiResponse);
        echo $finalResp;
    }
?>