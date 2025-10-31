<?php
session_start();
require_once "../support/db_connection.php";
require_once "../support/prepare_and_execute_query.php";
require_once "../support/form_builder.php";
require_once "../support/process_get_and_post_data.php";
require_once "../support/validate_input.php";
require_once "../support/sanitize.php";

$form = '';
$notification = '';
$warnings = [];


$bestemming = processPostData('Bestemming', true);
$gatecode = processPostData('Gatecode', false);
$max_passagiers = processPostData('Max_passagiers', true);
$max_gewicht_pp = processPostData('Max_gewicht_pp', true);
$max_totaalgewicht = processPostData('Max_totaalgewicht', true);
$vertrekdatumtijd = processPostData('Vertrekdatumtijd', false);
$maatschappijcode = processPostData('Maatschappijcode', true);

//Sanitize
$bestemming = sanitize($bestemming);
$gatecode = sanitize($gatecode);
$max_passagiers = sanitize($max_passagiers);
$max_gewicht_pp = sanitize($max_gewicht_pp);
$max_totaalgewicht = sanitize($max_totaalgewicht);
$vertrekdatumtijd = sanitize($vertrekdatumtijd);
$vertrekdatumtijd = sanitize($vertrekdatumtijd);

//General validation
validateTextInput($bestemming, 3, 3);
validateTextInput($gatecode, 1, 1);
validateNumberInput($max_passagiers, 1, 3, 0);
validateNumberInput($max_gewicht_pp, 1, 6, 2);
validateNumberInput($max_totaalgewicht, 1, 6, 2);
validateDatetimeInput($vertrekdatumtijd, 0, 30, false);
validateTextInput($maatschappijcode, 2, 2);



function createHtmlForm(){
    $data = NULL;
    $form = '<nav><form action="" method="post">';
    $form .= '<table>';
    $form .= '<tr><td>';

    //Bestemming
    $data = executeQueryWithoutExecuteArguments('SELECT Luchthavencode FROM Luchthaven ORDER BY Luchthavencode', 'bestemming', true)
            ->fetchAll(PDO::FETCH_ASSOC);
    $form .= addSelectToForm($data, 'Bestemming');
    $form .= '</td></tr><tr><td>';

    //Gatecode
    $data = executeQueryWithoutExecuteArguments('SELECT Gatecode FROM Gate ORDER BY Gatecode', true)
            ->fetchAll(PDO::FETCH_ASSOC);
    $form .= addSelectToForm($data, 'Gatecode');
    $form .= '</td></tr><tr><td>';
    
    //Maatschappijcode
    $data = executeQueryWithoutExecuteArguments('SELECT Maatschappijcode FROM Maatschappij ORDER BY Maatschappijcode', true)
            ->fetchAll(PDO::FETCH_ASSOC);
    $form .= addSelectToForm($data, 'Maatschappijcode');
    $form .= '</td></tr><tr><td>';
    
    //Max aantal (passagiers)
    $form .= addNumberInputToForm('Max_passagiers');
    $form .= '</td></tr><tr><td>';
    
    //Max gewicht pp
    $form .= addNumberInputToForm('Max_gewicht_pp');
    $form .= '</td></tr><tr><td>';
    
    //Max totaalgewicht
    $form .= addNumberInputToForm('Max_totaalgewicht');
    $form .= '</td></tr><tr><td>';
    
    //Vertrekdatumtijd
    $form .= addDateTimeToForm('Vertrekdatumtijd');
    $form .= '</td></tr><tr><td>';

    //Submit
    $form .= '<input type="submit" value="Vlucht Toevoegen">';
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

    $vertrekdatumtijd = sanitizeDatetime($vertrekdatumtijd);

    $sql = 'INSERT INTO Vlucht(Vluchtnummer, Bestemming, Gatecode, Max_aantal, Max_gewicht_pp, Max_totaalgewicht, Vertrektijd, Maatschappijcode)
    VALUES((SELECT ISNULL(MAX(Vluchtnummer)+1,1) FROM Vlucht), :Bestemming, :Gatecode, :Max_passagiers, :Max_gewicht_pp, :Max_totaalgewicht, :Vertrekdatumtijd, :Maatschappijcode)';
    $executeArray = [
        ':Bestemming' => $bestemming,
        ':Gatecode' => $gatecode,
        ':Max_passagiers' => $max_passagiers,
        ':Max_gewicht_pp' => $max_gewicht_pp,
        ':Max_totaalgewicht' => $max_totaalgewicht,
        ':Vertrekdatumtijd' => $vertrekdatumtijd,
        ':Maatschappijcode' => $maatschappijcode
    ];

    executeQueryWithExecuteArguments($sql, $executeArray, false);
    $notification = 'Vlucht toegevoegd!';
}

?>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Add Flight</title>
</head>
<body>
    <header>
        <nav>
            <ul>
                <li><a href="flights.php">Vluchtenlijst</a></li>
                <li><a href="passengers.php">Passagierslijst</a></li>
                <li><a href="../login/logout.php">Uitloggen</a></li>
            </ul>
        </nav>
    </header>

    <h2>Vlucht toevoegen</h2>
    <?php  
        echo '<b>' . $notification . '</b></br></br>';
        echo $form;
    ?>
</body>
</html>