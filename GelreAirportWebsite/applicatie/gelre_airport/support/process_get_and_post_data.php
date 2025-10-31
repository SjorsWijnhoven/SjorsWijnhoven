<?php

function processGetData($getKey, bool $required) {
    global $warnings;
    $value = NULL;

    if(!empty($_GET[$getKey])) {
        $value = $_GET[$getKey];
    } else {
        if($required) {
             $warnings[] = "Het veld: '$getKey' is verplicht.";
        } else {
            $value = NULL;
        }
    }
    return $value;
}


function processPostData($postKey, bool $required) {
    global $warnings;
    $value = NULL;

    if(!empty($_POST[$postKey])) {
        $value = $_POST[$postKey];
    } else {
        if($required) {
            $warnings[] = "Het veld: '$postKey' is verplicht.";
        } else {
            $value = NULL;
        }
    }
    return $value;
}
?>