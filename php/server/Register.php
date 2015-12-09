<?php
    $hostname = 'mysql.hostinger.com.br';
    $db_username = 'u667006922_zx';
    $db_password = 'aL9atefFtlSjpgevSQ';

    $con = mysqli_connect($hostname, $db_username, $db_password, 'u667006922_shots') or die ("no DB Connection");
    $del = "DELETE FROM `u667006922_shots`.`login` WHERE `login`.`username` = '' AND `login`.`password` = '' LIMIT 1;";

    $username = $_POST['username'];
    $password = $_POST['password'];

    $register_query = "INSERT INTO `u667006922_shots`.`login` (userID, username, `password`) VALUES (NULL, '$username', '$password');";
    $username_query = " SELECT * FROM `login` WHERE username = '$username'; ";

    $check = mysqli_query($con, $username_query);
   
    if(mysqli_num_rows($check)){
        echo "user taken";
    } else {
        mysqli_query($con, $register_query);
    }
    
    mysqli_query($con, $del);

    mysqli_close($con);

    # Yes, I realise that I could put everything in only 2 scripts (1 .cs and 1 .php), but it's my first time on php so let's take it easy, shall we? - Zx

 ?>