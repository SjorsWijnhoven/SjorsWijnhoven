<?php
session_start();
require_once "../support/table_builder.php";
require_once "../support/prepare_and_execute_query.php";

$flightTable = '';
$luggageTable = '';


function showFlight(){
    $sql = 'SELECT P.Passagiernummer, P.Naam, P.Vluchtnummer, P.Stoel, V.Bestemming, V.Vertrektijd, V.Gatecode, V.Max_gewicht_pp as [Maximaal Persoonlijk Bagagegewicht (kg)]
            FROM Passagier P INNER JOIN Vlucht V
                ON P.Vluchtnummer = V.Vluchtnummer
            WHERE P.Passagiernummer = :passagiernummer';
    $executeArray = [':passagiernummer' => $_SESSION['passagiernummer']];
    $data = executeQueryWithExecuteArguments($sql, $executeArray, true)
            ->fetchAll(PDO::FETCH_ASSOC);

    return $data;
}

function showLuggage(){
        $sql = 'SELECT MAX(Objectvolgnummer) as [Aantal_Koffers], SUM(Gewicht) as [Totaalgewicht (kg)]
        FROM Bagageobject
        WHERE Passagiernummer = :passagiernummer';
        $executeArray = [':passagiernummer' => $_SESSION['passagiernummer']];
        $data = executeQueryWithExecuteArguments($sql, $executeArray, true)
                ->fetchAll(PDO::FETCH_ASSOC);
        
        if(empty($data[0]['Aantal_Koffers'])){
            $data = NULL;
        }

        return $data;
}





$flightTable = buildHtmlTable(showFlight());

$luggageData = showLuggage();
if(!empty($luggageData)){
    $luggageTable = buildHtmlTable($luggageData);
} else {
    $luggageTable = 'U hebt geen koffers ingecheckt.';
}

?>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Personal Flight Information</title>
</head>
<body>
    <header>
        <nav>
            <ul>
                <li><a href="add_luggage.php">Bagage toevoegen</a></li>
                <li><a href="flights.php">Alle Vluchten</a></li>
                <li><a href="../login/logout.php">Uitloggen</a></li>
            </ul>
        </nav>
    </header>

    <h1>Vluchten</h1>
        <?=$flightTable?>
    <h1>Bagage</h1>
        <?=$luggageTable?>

</body>
</html>