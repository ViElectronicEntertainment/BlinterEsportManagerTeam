<?php
    require( '../Alpha/wp-load.php' );
    $login = $_GET['login'];
    $password = $_GET['password'];
    $user = get_user_by('login', $login);
    if ( wp_check_password( $password, $user->data->user_pass, $user->ID) )
    echo "1";
    else
    echo "0";
?>