<?php
    $hostname = 'mysql.hostinger.com.br';
    $username = 'u667006922_zx';
    $password = 'aL9atefFtlSjpgevSQ';
   
    $con = mysqli_connect($hostname, $username, $password, 'u667006922_shots') or die ("no DB Connection");
   
    $name = $_POST['name'];
    $score = $_POST['score'];
    $godmode = intval($_POST['godmode']);

    if($godmode == 0) {
    	$query = "INSERT INTO u872502990_tris.highscores (ID, Name, Score) VALUES (NULL, '$name', $score);";
    } else {
    	$query = "DELETE FROM u872502990_tris.highscores WHERE Name = '$name';";
    }    
    mysqli_query($con, $query);
?>