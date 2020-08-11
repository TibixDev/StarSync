<?php
session_start();
session_destroy();

include_once("constants.php");
redirect("logoutSuccess");
?>