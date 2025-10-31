<?php
session_start();
require_once "../support/prepare_and_execute_query.php";
require_once "../support/form_builder.php";
require_once "../support/process_get_and_post_data.php";
require_once "../support/validate_input.php";
require_once "../support/sanitize.php";

$form = '';
$notification = '';
$warnings = [];


$passagiernummer = processPostData('passagiernummer', true);
$gewicht = processPostData('gewicht', true);

//Sanitize
$passagiernummer = sanitize($passagiernummer);
$gewicht = sanitize($gewicht);

//Specific validation tests
validateBagageGewichtInput($passagiernummer, 5, 6, 0, $gewicht, 0, 6, 2);



function createHtmlForm(){
    $data = NULL;
    $form = '<nav><form action="" method="post">';
    $form .= '<table>';
    $form .= '<tr><td>';

    //Passagiernummer
    $form .= addTextInputToForm('passagiernummer');
    $form .= '</td></tr><tr><td>';

    //Gewicht
    $form .= addNumberInputToForm('gewicht');
    $form .= '</td></tr><tr><td>';

    //Submit
    $form .= '<input type="submit" value="Bagage Toevoegen">';
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

    $sql = 'INSERT INTO Bagageobject(Passagiernummer, Objectvolgnummer, Gewicht)
    VALUES(:passagiernummer_1, (SELECT ISNULL(MAX(Objectvolgnummer)+1,0)FROM Bagageobject WHERE Passagiernummer = :passagiernummer_2), :gewicht)
    ';
    $executeArray = [
        ':passagiernummer_1' => $passagiernummer,
        ':passagiernummer_2' => $passagiernummer,
        ':gewicht' => $gewicht
    ];

    executeQueryWithExecuteArguments($sql, $executeArray, false);
    $notification = 'Bagage toegevoegd!';
}

?>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Add Luggage</title>
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

    <h2>Bagage toevoegen</h2>
    <?php  
        echo '<b>' . $notification . '</b></br></br>';
        echo $form;
    ?>
</body>
</html>