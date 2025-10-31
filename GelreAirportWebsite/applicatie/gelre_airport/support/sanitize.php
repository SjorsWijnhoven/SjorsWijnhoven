<?php

function sanitize($input) {
    if(!empty($input)) {
        $input = trim(htmlspecialchars(strip_tags($input)));
    }
    return $input;
}

function sanitizeDate($input){
    $input = date_create($input);
    $input = $input->format('Y-m-d');
    $input = strval($input);
    $input = substr($input, 0, 10);
    $input = str_replace('-', '', $input);

    return $input;
}

function sanitizeDatetime($input){
    $input = date_create($input);
    $input = $input->format('Y-m-d H:i:s');
    $input = strval($input);

    return $input;
}

function sanitizeStoel($input){
    ucfirst($input);

    return $input;
}

?>