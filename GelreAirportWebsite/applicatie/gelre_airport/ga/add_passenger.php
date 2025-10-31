<?php
session_start();
require_once "../support/db_connection.php";
require_once "../support/prepare_and_execute_query.php";
require_once "../support/form_builder.php";
require_once "../support/process_get_and_post_data.php";
require_once "../support/validate_input.php";
require_once "../support/flight_and_seat_combination.php";
require_once "../support/sanitize.php";
require_once "../support/enough_room_on_plane.php";

$form = '';
$notification = '';
$warnings = [];


$naam = processPostData('naam', true);
$vluchtnummer = processPostData('vluchtnummer', true);
$geslacht = processPostData('geslacht', false);
$stoel = processPostData('stoel', true);
$inchecktijdstip = 'now';

//Sanitize
$naam = sanitize($naam);
$vluchtnummer = sanitize($vluchtnummer);
$geslacht = sanitize($geslacht);
$stoel = sanitize($stoel);
$inchecktijdstip = sanitize($inchecktijdstip);

//General validation tests
validateTextInput($naam, 0, 35);
validateTextInput($geslacht, 1, 1);
validateDatetimeInput($inchecktijdstip, 0, 30, true);

//Specific validation tests
validateStoelInput($stoel, 3, 3);
validateVluchtnummerInput($vluchtnummer, 1, 6, 0);



function createHtmlForm(){
    $data = NULL;
    $form = '<nav><form action="" method="post">';
    $form .= '<table>';
    $form .= '<tr><td>';

    //Naam
    $form .= addTextInputToForm('naam');
    $form .= '</td></tr><tr><td>';
    
    //Geslacht
    $data = executeQueryWithoutExecuteArguments('SELECT DISTINCT Geslacht FROM Passagier', true)
            ->fetchAll(PDO::FETCH_ASSOC);
    $form .= addSelectToForm($data, 'geslacht');
    $form .= '</td></tr><tr><td>';

    //Vluchtnummer
    $form .= addNumberInputToForm('vluchtnummer');
    $form .= '</td></tr><tr><td>';
    
    //Stoel
    $form .= addTextInputToForm('stoel');
    $form .= '</td></tr><tr><td>';

    //Submit
    $form .= '<input type="submit" value="Passagier Toevoegen">';
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
    if(empty($geslacht)){
        $geslacht = 'x';
    }

    $inchecktijdstip = sanitizeDateTime($inchecktijdstip);
    $stoel = sanitizeStoel($stoel);


    $sql = 'INSERT INTO Passagier(Passagiernummer, Naam, Vluchtnummer, Geslacht, Balienummer, Stoel, Inchecktijdstip)
    VALUES((SELECT ISNULL(MAX(Passagiernummer)+1,1) FROM Passagier), :naam, :vluchtnummer, :geslacht, :balienummer, :stoel, :inchecktijdstip)';
    $executeArray = [
        ':naam' => $naam,
        ':vluchtnummer' => $vluchtnummer,
        ':geslacht' => $geslacht,
        ':balienummer' => $_SESSION['balienummer'],
        ':stoel' => $stoel,
        ':inchecktijdstip' => $inchecktijdstip
    ];

    executeQueryWithExecuteArguments($sql, $executeArray, false);
    $notification = 'Passagier toegevoegd!';
}

?>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Add Passenger</title>
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

    <h2>Passagier toevoegen</h2>
    <?php  
        echo '<b>' . $notification . '</b></br></br>';
        echo $form;
    ?>
</body>
</html>