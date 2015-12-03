<?php
    $hostname = "mysql.hostinger.com.br";
    $db_username = "u667006922_zx";
    $db_password = "aL9atefFtlSjpgevSQ";

    $con = mysqli_connect($hostname, $db_username, $db_password, "u667006922_shots") or die ("no DB Connection");

    $userID = $_POST["userID"];
    $username = $_POST["username"];
    $password = $_POST["password"];

    $username_check = "SELECT count(1) FROM u667006922_shots.login WHERE username = $username;";
    
    if(mysqli_query($con, $query)){
        echo "username already taken!";
    } else {
        $query = "INSERT INTO u667006922_shots.login (userID, username, password) VALUES ($userID, $username, $password);";
        mysqli_query($con, $query);
    }    
 ?>