<?php
require_once "../support/db_connection.php";
require_once "../support/form_builder.php";
require_once "../support/process_get_and_post_data.php";
require_once "../support/validate_input.php";
require_once "../support/sanitize.php";

$form = '';
$notification = '';
$warnings = [];

$passagiernummer = processPostData('passagiernummer', true);

//Sanitize
$passagiernummer = sanitize($passagiernummer);

//validateExitence() instead of 3x the same function (Passagiernummer, Stoel, Balienummer)
validatePassagiernummerInput($passagiernummer, 5, 6, 0);

function createHtmlForm(){
    $form = '<nav><form action="" method="post">';
    $form .= '<table>';
    $form .= '<tr><td>';  

    $form .= '<h3>Passagier login:</h3>';

    //Passagiernummer
    $form .= addNumberInputToForm('passagiernummer');
    $form .= '</td></tr><tr><td>';

    $form .= '<input type="submit" value="Inloggen">';
    $form .= '</td></tr>';
    $form .= '</table>';
    $form .= '</form></nav>';

    return $form;
}




$form = createHtmlForm();


if((count($warnings) > 0)) {
    $notification = '<ul>';
    foreach($warnings as $warning){
        $notification .= "<li>$warning</li>";
    }
    $notification .= '</ul>';
} else {
    session_start();
    $_SESSION['passagiernummer'] = $passagiernummer;
    header('location: ../pa/personal_flight.php');
}

?>





<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Document</title>
</head>
<body>
    <?php
       echo '<b>' . $notification . '</b></br></br>';
       echo $form;
    ?>
</body>
</html>