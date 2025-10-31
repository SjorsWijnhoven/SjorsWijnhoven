<?php

function checkIfEnoughRoomOnPlane($vluchtnummer){
    global $warnings;

    if(empty($warnings)){
        //Determine amount of taken seats in plane
        $sql = 'SELECT COUNT(P.Passagiernummer) AS [Aantal Passagiers]
               FROM Vlucht V INNER JOIN Passagier P
                   ON V.Vluchtnummer = P.Vluchtnummer
                   WHERE V.Vluchtnummer = :vluchtnummer
               GROUP BY V.Vluchtnummer';
        $executeArray = ['vluchtnummer' => $vluchtnummer];
        $data = executeQueryWithExecuteArguments($sql, $executeArray, true)
                ->fetchAll(PDO::FETCH_ASSOC);
        
        foreach($data as $row){
            foreach($row as $takenSeats){
                $takenSeats = $takenSeats;
            }
        }
        
        //Determine amount of total seats in plane
        $sql = 'SELECT Max_aantal FROM Vlucht
                WHERE Vluchtnummer = :vluchtnummer';
        $executeArray = ['vluchtnummer' => $vluchtnummer];
        $data = executeQueryWithExecuteArguments($sql, $executeArray, true)
                ->fetchAll(PDO::FETCH_ASSOC);
        
        foreach($data as $row){
            foreach($row as $totalSeats){
                $totalSeats = $totalSeats;
            }
        }
        
        //Check if there are free seats left
        if(!empty($vluchtnummer)){
            if($takenSeats >= $totalSeats) {
                $warnings[] = 'Dit vliegtuig is al volgeboekt.';
            }
        }
    }
}

?>