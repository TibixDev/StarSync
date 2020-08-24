<?php
session_start();
include_once("../dependencies/qr/phpqrcode.php");
include_once("../constants.php");
$qrinput = escape("starsync-app://" . $_GET['input']);
QRcode::png($qrinput);
?>