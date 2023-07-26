<?php

$host="localhost";
$user="fypuser";
$password="root";
$db="mydb";

$conn = new mysqli(hostname: $host, username: $user, password: $password, database: $db);

if ($conn->connect_error) {
  die("Connection error: " . $conn->connect_error);
}
  
return $conn;

?>