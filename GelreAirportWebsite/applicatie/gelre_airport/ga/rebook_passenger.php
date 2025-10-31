<?php
session_start();
require_once "../support/process_get_and_post_data.php";
require_once "../support/validate_input.php";
require_once "../support/form_builder.php";
require_once "../support/enough_room_on_plane.php";
require_once "../support/flight_and_seat_combination.php";
require_once "../support/sanitize.php";

$form = '';
$notification = '';
$warnings = [];

//$_SESSION['data_ingevuld'] = false; TOEVOEGEN!!!!!!
//BELNGRIJK
//DIT MOET EEN GROOT ZICHTBAAR BLOK ZIJN
//LALALALALALALALLALALAL
//NOG MEER ONZIN
//OKE HET IS WEL GOED GENOEG ZO
//DIT GA IK NIET MISSEN
// :)
//GEDAAN!

$passagiernummer = processGetData('passagiernummer',true);
$vluchtnummer = processGetData('vluchtnummer',true);
$stoel = processGetData('stoel', true);
$inchecktijdstip = 'now';

//Sanitize
$passagiernummer = sanitize($passagiernummer);
$vluchtnummer = sanitize($vluchtnummer);
$stoel = sanitize($stoel);
$inchecktijdstip = sanitize($inchecktijdstip);

//Specific validation
validatePassagiernummerInput($passagiernummer, 5, 6, 0);
validateVluchtnummerInput($vluchtnummer, 5, 6, 0);
validateStoelInput($stoel, 3, 3);
validateDatetimeInput($inchecktijdstip, 0, 30, true);



function createHtmlForm(){
    $form = '<nav><form action="" method="get">';
    $form .= '<table>';
    $form .= '<tr><td>';


    //Passenger Number
    $form .= addNumberInputToForm('passagiernummer');
    $form .= '</td></tr><tr><td>';

    //Flight Number
    $form .= addNumberInputToForm('vluchtnummer');
    $form .= '</td></tr><tr><td>';

    //Stoel
    $form .= addTextInputToForm('stoel');
    $form .= '</td></tr><tr><td>';

    
    $form .= '<input type="submit" value="Filter">';
    $form .= '</td></tr>';

    $form .= '</table>';
    $form .= '</form></nav>';

    return $form;
}




$form = createHtmlForm();
checkIfEnoughRoomOnPlane($vluchtnummer);
checkSeatAvailability($vluchtnummer, $stoel);


if((count($warnings) > 0)) {
    $notification = '<ul>';
    foreach($warnings as $warning){
        $notification .= "<li>$warning</li>";
    }
    $notification .= '</ul>';
} else {

    $inchecktijdstip = sanitizeDateTime($inchecktijdstip);
    $stoel = sanitizeStoel($stoel);


    $sql = 'UPDATE Passagier
    SET Vluchtnummer = :vluchtnummer, Balienummer = :balienummer, Stoel = :stoel, Inchecktijdstip = :inchecktijdstip
    WHERE Passagiernummer = :passagiernummer';
    $executeArray = [
        ':vluchtnummer' => $vluchtnummer,
        ':balienummer' => $_SESSION['balienummer'],
        ':stoel' => $stoel,
        ':inchecktijdstip' => $inchecktijdstip,
        ':passagiernummer' => $passagiernummer
    ];

    executeQueryWithExecuteArguments($sql, $executeArray, false);
    $notification = 'Vlucht omgeboekt!';
}

?>





<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Passagier Omboeken</title>
</head>
<body>
    <header>
        <nav>
            <ul>
                <li><a href="passengers.php">Passagierslijst</a></li>
                <li><a href="flights.php">Vluchtenlijst</a></li>
                <li><a href="../login/logout.php">Uitloggen</a></li>
            </ul>
        </nav>
    </header>

    <h2>Passagier Omboeken</h2>

    <?php
        echo '<b>' . $notification . '</b></br></br>';
        echo $form;
    ?>
</body>
</html>