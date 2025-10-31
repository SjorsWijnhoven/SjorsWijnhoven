<?php

function checkSeatAvailability($vluchtnummer, $stoel){
    global $warnings;

    if(empty($warnings) && !empty($vluchtnummer) && !empty($stoel)){
        $sql = 'SELECT * FROM Passagier
                WHERE Vluchtnummer = :vluchtnummer AND Stoel = :stoel';
        $executeArray = [
            ':vluchtnummer' => $vluchtnummer,
            ':stoel' => $stoel
        ];

        $data = executeQueryWithExecuteArguments($sql, $executeArray, true)
                ->fetchAll(PDO::FETCH_ASSOC);

        if(!empty($data)){
            $warnings[] = 'De gekozen stoel is al bezet.';
        }
    }
}

?>