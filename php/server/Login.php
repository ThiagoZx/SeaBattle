<?php
    $hostname = 'mysql.hostinger.com.br';
    $db_username = 'u667006922_zx';
    $db_password = 'aL9atefFtlSjpgevSQ';

    $con = mysqli_connect($hostname, $db_username, $db_password, 'u667006922_shots') or die ("no DB Connection");

    $username = $_POST['username'];
    $password = $_POST['password'];

    $query = " SELECT userID FROM `u667006922_shots`.`login` WHERE username = '$username' AND password = '$password'; ";
    $validade_query = mysqli_query($con, $query);

    if (mysqli_num_rows($validade_query)) {
        echo '$validade_query';
    } else {
        echo "wrong";
    }

    mysqli_close($con);

    # Yes, I realise that I could put everything in only 2 scripts (1 .cs and 1 .php), but it's my first time on php so let's take it easy, shall we? - Zx

 ?>