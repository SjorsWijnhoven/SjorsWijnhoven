<?php

function getVariableName($var) {
    foreach($GLOBALS as $key => $value) {
        if ($var === $value) {
            return ucfirst($key);
        }
    }
    return;
} 

?>