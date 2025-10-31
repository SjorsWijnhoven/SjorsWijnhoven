<?php

function buildHtmlTable($data){
    //table start
    $table = '<table>';

    //column names
    $table .= '<tr>';

    if(!empty($data)){
        $columnNames = array_keys($data[0]);

        foreach($columnNames as $name){
            $table .= "<th>{$name}</th>";
        }
        
        $table .= '</tr>';


        //rows
        foreach($data as $row){
            $column = '<tr>';

            foreach($row as $dataItem){
                $table .= "<td>{$dataItem}</td>";
            }

            $table .= '</tr>';
        }
    }

    //table end
    $table .= '</table>';

    return $table;
}

?>