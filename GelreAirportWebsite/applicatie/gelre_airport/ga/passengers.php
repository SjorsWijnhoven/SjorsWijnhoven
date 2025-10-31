<?php
session_start();
require_once "../support/prepare_and_execute_query.php";
require_once "../support/process_get_and_post_data.php";
require_once "../support/table_builder.php";
require_once "../support/form_builder.php";
require_once "../support/validate_input.php";
require_once "../support/sanitize.php";

$form = '';
$table = '';

$naam = processGetData('naam', false);
$passagiernummer = processGetData('passagiernummer', false);
$vluchtnummer = processGetData('vluchtnummer', false);

//Sanitize
$naam = sanitize($naam);
$passagiernummer = sanitize($passagiernummer);
$vluchtnummer = sanitize($vluchtnummer);

//General validation
validateTextInput($naam, 0, 35);
validateNumberInput($passagiernummer, 1, 6, 0);
validateNumberInput($vluchtnummer, 1, 6, 0);


function createHtmlForm(){

    $data = NULL;
    $form = '<nav><form action="" method="get">';
    $form .= '<table>';
    $form .= '<tr><td>';

    $form .= '<p>Filter:</p>';

    //Passenger Name
    $form .= addTextInputToForm('naam');
    $form .= '</td></tr><tr><td>';

    //Passenger Number
    $form .= addNumberInputToForm('passagiernummer');
    $form .= '</td></tr><tr><td>';

    //Flight Number
    $form .= addNumberInputToForm('vluchtnummer');
    $form .= '</td></tr><tr><td>';


    
    $form .= '<input type="submit" value="Filter">';
    $form .= '</td></tr>';

    $form .= '</table>';
    $form .= '</form></nav>';

    return $form;
}


function showPassengers() {
    global $naam;
    global $passagiernummer;
    global $vluchtnummer;

    if(empty($naam)){
        $naam = '%%';
    } else {
        $naam = "%$naam%";
    }

    if(empty($passagiernummer)){
        $passagiernummer = '%%';
    } else {
        $passagiernummer = "%$passagiernummer%";
    }

    if(empty($vluchtnummer)){
        $vluchtnummer = '%%';
    } else {
        $vluchtnummer = "%$vluchtnummer%";
    }


    $sql = 'SELECT * FROM Passagier WHERE Passagiernummer LIKE :passagiernummer AND Naam LIKE :naam AND Vluchtnummer LIKE :vluchtnummer';
    $executeArray = [
        ':naam' => $naam,
        ':passagiernummer' => $passagiernummer,
        ':vluchtnummer' => $vluchtnummer
    ];
    $data = executeQueryWithExecuteArguments($sql, $executeArray, true)
            ->fetchAll(PDO::FETCH_ASSOC);

    return $data;
}

$form .= createHtmlForm();
$table .= buildHtmlTable(showPassengers());
?>






<!DOCTYPE html>
<html lang="nl">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Passengers</title>
</head>
<body>
    <header>
        <nav>
            <ul>
                <li><a href="add_passenger.php">Passagier toevoegen</a></li>
                <li><a href="add_luggage.php">Bagage toevoegen</a></li>
                <li><a href="rebook_passenger.php">Passagier omboeken</a></li>
                <li><a href="flights.php">Vluchtenlijst</a></li>
                <li><a href="../login/logout.php">Uitloggen</a></li>
            </ul>
        </nav>
    </header>

    <h1>Passagiers</h1>
    <?php
        echo $form . '</br></br>';
        echo $table;
    ?>

</body>
</html>