<?php

// function addSortingToForm(Array $data, String $name){
//     $form = "<label for=\"$name\">" . ucfirst($name) . "</label>";
//     $form .= "<select name=\"$name\" id=\"$name\">";

//         foreach($data as $option){
//             $form .= '<option value="' . $option . '">' . ucfirst($option) . '</option>';
//         }

//     $form .= '</select>';

//     return $form;
// }

function addSelectToForm(Array $data, String $name){
    $form = "<label for=\"$name\">" . ucfirst($name) . "</label>";
    $form .= "<select id=\"$name\" name=\"$name\">";
    $form .= '<option value="">Geen</option>';

    foreach($data as $row){
        foreach($row as $option){
            $form .= '<option value="' . $option . '">' . ucfirst($option) . '</option>';
        }
    }

    $form .= '</select>';

    return $form;
}

function addTextInputToForm(String $name){
    $form = "<label for=\"$name\">" . ucfirst($name) . "</label>";
    $form .= "<input type=\"text\" id=\"$name\" name=\"$name\">";

    return $form;
}

function addPasswordInputToForm(String $name){
    $form = "<label for=\"$name\">" . ucfirst($name) . "</label>";
    $form .= "<input type=\"password\" id=\"$name\" name=\"$name\">";

    return $form;
}

function addNumberInputToForm(String $name) {
    $form = "<label for=\"$name\">" . ucfirst($name) . "</label>";
    $form .= "<input type=\"number\" id=\"$name\" name=\"$name\" step=\"0.01\">";

    return $form;
}

function addDateTimeToForm(String $name) {
    $form = "<label for=\"$name\">" . ucfirst($name) . "</label>";
    $form .= "<input type=\"datetime-local\" id=\"$name\" name=\"$name\">";

    return $form;
}

function addDateToForm(String $name) {
    $form = "<label for=\"$name\">" . ucfirst($name) . "</label>";
    $form .= "<input type=\"date\" id=\"$name\" name=\"$name\">";

    return $form;
}

?>