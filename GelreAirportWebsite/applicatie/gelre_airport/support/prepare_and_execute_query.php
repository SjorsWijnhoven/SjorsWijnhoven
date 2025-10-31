<?php

require_once "db_connection.php";

function executeQueryWithoutExecuteArguments(String $sql, bool $return){
    $connection = maakVerbinding();

    $query = $connection->prepare($sql);
    $query->execute();

    if($return){
        return $query;
    }
}


function executeQueryWithExecuteArguments(String $sql, Array $executeArray, bool $return){
    $connection = maakVerbinding();

    $query = $connection->prepare($sql);
    $query->execute($executeArray);

    if($return){
        return $query;
    }
}
?>