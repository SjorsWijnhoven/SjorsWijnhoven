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

$vertrektijd = processGetData('vertrektijd', false);
$vertrektijdPlus1 = NULL;
$bestemming = processGetData('bestemming', false);
$vluchtnummer = processGetData('vluchtnummer', false);

//Sanitize
$vertrektijd = sanitize($vertrektijd);
$bestemming = sanitize($bestemming);
$vluchtnummer = sanitize($vluchtnummer);

//General validation
validateDateInput($vertrektijd, 0, 30, true);
validateTextInput($bestemming, 3, 3);
validateNumberInput($vluchtnummer, 1, 9, 0);


function createHtmlForm(){
    $data = NULL;
    $form = '<nav><form action="" method="get">';
    $form .= '<table>';
    $form .= '<tr><td>';
    
    $form .= '<p>Filter:</p>';

    //Time of Departure
    $form .= addDateToForm('vertrektijd');
    $form .= '</td></tr><tr><td>';

    //Destination Filter
    $data = executeQueryWithoutExecuteArguments('SELECT Luchthavencode FROM Luchthaven ORDER BY Luchthavencode', true)
            ->fetchAll(PDO::FETCH_ASSOC);
    $form .= addSelectToForm($data, 'bestemming');
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


function showFlights() {
    global $bestemming;
    global $vertrektijd;
    global $vluchtnummer;

    if(empty($vertrektijd)){
        //Date of departure is always between 188-01-01 and 3000-01-01
        $vertrektijd = '18000101';
        $vertrektijdPlus1 = '30000101';
    } else {
        $vertrektijd = sanitizeDate($vertrektijd);
        $vertrektijd = intval($vertrektijd);
        $vertrektijdPlus1 = $vertrektijd + 1;
        
        //Both vertrektijd variables must be a string for the query to work
        $vertrektijd = strval($vertrektijd);
        $vertrektijdPlus1 = strval($vertrektijdPlus1);
    }
    
    if(empty($bestemming)){
        $bestemming = '%%';
    } else {
        $bestemming = "%$bestemming%";
    }
    
    if(empty($vluchtnummer)){
        $vluchtnummer = '%%';
    } else {
        $vluchtnummer = "%$vluchtnummer%";
    }
    
    $sql = 'SELECT * FROM Vlucht
    WHERE :vertrektijd <= Vertrektijd and Vertrektijd < :vertrektijdPlus1
        AND Bestemming LIKE :bestemming
        AND Vluchtnummer LIKE :vluchtnummer';
    $executeArray = [
        ':vertrektijd' => $vertrektijd,
        ':vertrektijdPlus1' => $vertrektijdPlus1,
        ':bestemming' => $bestemming,
        ':vluchtnummer' => $vluchtnummer
    ];
    $data = executeQueryWithExecuteArguments($sql, $executeArray, true)
            ->fetchAll(PDO::FETCH_ASSOC);

    return $data;
}

$form .= createHtmlForm();
$table .= buildHtmlTable(showFlights());
?>






<!DOCTYPE html>
<html lang="nl">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Flights</title>
</head>
<body>
    <header>
        <nav>
            <ul>
                <li><a href="add_flight.php">Vlucht toevoegen</a></li>
                <li><a href="passengers.php">Passagierslijst</a></li>
                <li><a href="../login/logout.php">Uitloggen</a></li>
            </ul>
        </nav>
    </header>

    <h1>Vluchten</h1>
    <?php
        echo $form . '</br></br>';
        echo $table;
    ?>

</body>
</html>