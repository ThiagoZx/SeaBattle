<?php
    $hostname = 'mysql.hostinger.com.br';
    $username = 'u667006922_zx';
    $password = 'aL9atefFtlSjpgevSQ';
   
    $con = mysqli_connect($hostname, $username, $password, 'u667006922_shots') or die ("no DB Connection");
   
    $query = "SELECT * FROM u872502990_tris.highscores ORDER by Score DESC LIMIT 50;";
    $result = mysqli_query($con, $query);
    $num_results = mysqli_num_rows($result);  
    for($i = 0; $i < $num_results; $i++) {
         $row = mysqli_fetch_array($result);
         echo $row['Name'] . "|" . $row['Score'] . "|";
    }
    mysqli_close($con);
?>