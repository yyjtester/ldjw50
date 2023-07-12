<?php

$host="localhost";
$user="root";
$password="J./HzjrZ4h90(wG3";
$db="mydb";

$con = mysqli_connect($host, $user, $password, $db);

if ($con == false) {
  die("Connection failed: " . $con->connect_error);
}
  
?>