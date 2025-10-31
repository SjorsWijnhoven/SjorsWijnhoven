<?php
require_once "../support/db_connection.php";
require_once "../support/form_builder.php";
require_once "../support/process_get_and_post_data.php";
require_once "../support/validate_input.php";
require_once "../support/sanitize.php";

$form = '';
$notification = '';
$warnings = [];

$balienummer = processPostData('balienummer', true);
$wachtwoord = ProcessPostData('wachtwoord', true);

//Sanitize
$balienummer = sanitize($balienummer);
$wachtwoord = sanitize($wachtwoord);

//Specific validation tests
validateBalienummerInput($balienummer, 1, 2, 0);
validatePasswordInput($wachtwoord, 5, 50);


function createHtmlForm(){
    $form = '<nav><form action="" method="post">';
    $form .= '<table>';
    $form .= '<tr><td>';  

    $form .= '<h3>Medewerker login:</h3>';

    //Balienummer
    $form .= addNumberInputToForm('balienummer');
    $form .= '</td></tr><tr><td>';

    //Wachtwoord
    $form .= addPasswordInputToForm('wachtwoord');
    $form .= '</td></tr><tr><td>';

    $form .= '<input type="submit" value="Inloggen">';
    $form .= '</td></tr>';
    $form .= '</table>';
    $form .= '</form></nav>';

    return $form;
}


function verifyWachtwoord(){
    global $notification;
    global $warnings;
    global $wachtwoord;
    global $balienummer;

    if((count($warnings) > 0)) {
        $notification = '<ul>';
        foreach($warnings as $warning){
            $notification .= "<li>$warning</li>";
        }
        $notification .= '</ul>';
    } else {
        
        $sql = 'SELECT Wachtwoord FROM Balie WHERE Balienummer = :balienummer';
        $executeArray = [':balienummer' => $balienummer];
        $data = executeQueryWithExecuteArguments($sql, $executeArray, true)
                ->fetchAll(PDO::FETCH_ASSOC);

        foreach($data as $row){
            foreach($row as $wachtwoordHash){
                $wachtwoordHash = $wachtwoordHash;
            }
        }


        if(password_verify($wachtwoord, $wachtwoordHash)){
            return true;
        } else {
            $warnings[] = 'Balienummer en wachtwoord komen niet overeen.';
            return false;
        }
    }
}




$form = createHtmlForm();

if(verifyWachtwoord()){
    session_start();
    $_SESSION['balienummer'] = $balienummer;
    header('location: ../ga/flights.php');
} else {
    if((count($warnings) > 0)) {
        $notification = '<ul>';
        foreach($warnings as $warning){
            $notification .= "<li>$warning</li>";
        }
        $notification .= '</ul>';
    }
}


?>





<!DOCTYPE html>
<html lang="nl">
    <head>
        <meta charset="UTF-8">
        <meta name="viewport" content="width=device-width, initial-scale=1.0">
        <title>Login</title>
    </head>
    <body>
        <?php
            echo '<b>' . $notification . '</b></br></br>';
            echo $form;
        ?>
    </body>
</html>