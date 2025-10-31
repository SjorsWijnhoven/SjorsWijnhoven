<?php
require_once "variable_name.php";
require_once "db_connection.php";
require_once "prepare_and_execute_query.php";

//GENERAL VALIDATION TESTS
function validateBasic($var, int $minLength, int $maxLength){
    global $warnings;

    if(!empty($var)){

        if(strlen($var) < $minLength){
            $warnings[] = getVariableName($var) . ' moet minimaal ' . $minLength . ' tekens bevatten.';
        }
    
        if(strlen($var) > $maxLength){
            $warnings[] = getVariableName($var) . ' mag maximaal ' . $maxLength . ' tekens bevatten.';
        }
    }
}


function validateTextInput($var, int $minLength, int $maxLength){
    global $warnings;

    if(!empty($var)){
        validateBasic($var, $minLength, $maxLength);
    }
}


function validateNumberInput($var, int $minLength, int $maxLength, int $maxDecimals){
    global $warnings;

    if(!empty($var)){
        if(is_numeric($var)){

            $strvar = strval($var);
            validateBasic($strvar, $minLength, $maxLength);
            $strvar = str_replace(',', '.', $strvar);

            if(strpos($strvar, '.')){
                if(strlen(substr(strrchr($strvar, "."), 1)) > $maxDecimals){
                    $warnings[] = getVariableName($var) . ' mag maximaal ' . $maxDecimals . ' decimalen bevatten.';
                }
            }
        } else {
            $warnings[] = getVariableName($var) . ' moet een getal zijn.';
        }
    }
}


function validateDateInput($input, int $minLength, int $maxLength, bool $canBePreviousDate){
    global $warnings;

    if(!empty($input)){
        validateBasic($input, $minLength, $maxLength);
        
        if(!$canBePreviousDate){
            $current = date_create('now');
            $inputDate = date_create($input);

            if($inputDate < $currentDate){
                $warnings[] = getVariableName($input) . ' mag niet in het verleden zijn.';
            }
        }
    }
}


function validateDatetimeInput($input, int $minLength, int $maxLength, bool $canBePreviousDate){
    global $warnings;

    if(!empty($input)){
        validateBasic($input, $minLength, $maxLength);

        if(!$canBePreviousDate){
            $currentDatetime = date_create('now');
            $inputDatetime = date_create($input);

            if($inputDatetime < $currentDatetime){
                $warnings[] = getVariableName($input) . ' mag niet in het verleden zijn.';
            }
        }
    }
}







//CASE SPECIFIC VALIDATION TESTS
//ONLY USED FOR CREATING INSERT FORMS
function validatePassagiernummerInput($passagiernummer, int $minLength, int $maxLength, int $maxDecimals){
    global $warnings;

    validateNumberInput($passagiernummer, $minLength, $maxLength, $maxDecimals);

    //Determine if given passagiernummer exists
    $sql = 'SELECT Passagiernummer FROM Passagier WHERE Passagiernummer = :passagiernummer';
    $executeArray = [':passagiernummer' => $passagiernummer];
    $data = executeQueryWithExecuteArguments($sql, $executeArray, true)
            ->fetchAll(PDO::FETCH_ASSOC);
    
    if(empty($data) && !empty($passagiernummer)){
        $warnings[] = 'Ingevoerd passagiernummer bestaat niet.';
    }
}


function validateVluchtnummerInput($vluchtnummer, int $minLength, int $maxLength, int $maxDecimals){
    global $warnings;

    validateNumberInput($vluchtnummer, $minLength, $maxLength, $maxDecimals);
 
    //Determine if given vluchtnummer exists
    if(is_numeric($vluchtnummer)){
        $sql = 'SELECT Vluchtnummer FROM Vlucht WHERE Vluchtnummer LIKE :vluchtnummer';
        $executeArray = [':vluchtnummer' => $vluchtnummer];
        $data = executeQueryWithExecuteArguments($sql, $executeArray, true)
        ->fetchAll(PDO::FETCH_ASSOC);
    }
    if(empty($data) && !empty($vluchtnummer)){
        $warnings[] = 'Ingevoerd vluchtnummer bestaat niet.';
    }
}


function validateBalienummerInput($balienummer, int $minLength, int $maxLength, int $maxDecimals){
    global $warnings;

    validateNumberInput($balienummer, $minLength, $maxLength, $maxDecimals);

    //Determine if given balienummer exists
    $sql = 'SELECT Balienummer FROM Balie Where Balienummer = :balienummer';
    $executeArray = [':balienummer' => $balienummer];
    $data = executeQueryWithExecuteArguments($sql, $executeArray, true)
            ->fetchAll(PDO::FETCH_ASSOC);
    
    if(empty($data) && !empty($balienummer)){
        $warnings[] = 'Het ingevoerde balienummer bestaat niet.';
    }
}


function validateStoelInput($stoel, int $minLength, int $maxLength){
    global $warnings;

    validateTextInput($stoel, $minLength, $maxLength);

    if(!empty($stoel)){
    
        $stoelArray = str_split($stoel);
        if(is_numeric($stoelArray[0])){
            $warnings[] = 'Stoel moet bestaan uit [letter, cijfer, cijfer]. Voorbeeld: A01';
        } else {
            if(!is_numeric($stoelArray[1])){
                $warnings[] = 'Stoel moet bestaan uit [letter, cijfer, cijfer]. Voorbeeld: A01';
            } else {
                if(!is_numeric($stoelArray[2])){
                    $warnings[] = 'Stoel moet bestaan uit [letter, cijfer, cijfer]. Voorbeeld: A01';
                }
            }
        }
    }
}


function validateBagageGewichtInput($passagiernummer, int $PminLength, int $PmaxLength, int $PmaxDecimals, $gewicht, int $GminLength, int $GmaxLength, int $GmaxDecimals){
    global $warnings;
    
    validatePassagiernummerInput($passagiernummer, $PminLength, $PmaxLength, $PmaxDecimals);
    validateNumberInput($gewicht, $GminLength, $GmaxLength, $GmaxDecimals);
    
    //Determine current personal luggage weight
    if(!empty($gewicht) && empty($warnings)){
        $sql = 'SELECT SUM(Gewicht)
                FROM BagageObject
                WHERE Passagiernummer = :passagiernummer';
        $executeArray = [':passagiernummer' => $passagiernummer];
        $data = executeQueryWithExecuteArguments($sql, $executeArray, true)
        ->fetchAll(PDO::FETCH_ASSOC);
        
        foreach($data as $row){
            foreach($row as $currentPersonalWeight){
                $currentPersonalWeight = $currentPersonalWeight;
            }
        }
        
        //Determine current total plane luggage weight
        $sql = 'SELECT SUM(Gewicht)
                FROM BagageObject B INNER JOIN Passagier P
                    ON B.Passagiernummer = P.Passagiernummer
                WHERE P.Vluchtnummer IN
                                (SELECT Vluchtnummer
                                FROM Passagier
                                WHERE Passagiernummer = :passagiernummer)';
        $executeArray = [':passagiernummer' => $passagiernummer];
        $data = executeQueryWithExecuteArguments($sql, $executeArray, true)
                ->fetchAll(PDO::FETCH_ASSOC);

        foreach($data as $row){
            foreach($row as $currentTotalWeight){
                $currentTotalWeight = $currentTotalWeight;
            }
        }

        //Determine Max allowed personal luggage weight AND Max allowed total luggage weight
        $sql = 'SELECT V.Max_gewicht_pp, V.Max_totaalgewicht
                FROM Passagier P INNER JOIN Vlucht V
                    ON P.Vluchtnummer = V.Vluchtnummer
                WHERE P.Passagiernummer = :passagiernummer';
        $executeArray = [':passagiernummer' => $passagiernummer];
        $data = executeQueryWithExecuteArguments($sql, $executeArray, true)
                ->fetchAll(PDO::FETCH_ASSOC);

        foreach($data as $row){
            $maxPersonalWeight = $row['Max_gewicht_pp'];
            $maxTotalWeight = $row['Max_totaalgewicht'];
        }


        //Compare weights
        $addedPersonalWeight = $currentPersonalWeight + $gewicht;
        $addedTotalWeight = $currentTotalWeight + $gewicht;

        if($addedPersonalWeight > $maxPersonalWeight){
            $excessPersonalWeight = $addedPersonalWeight - $maxPersonalWeight;
            $warnings[] = "Deze koffer weegt $excessPersonalWeight kg te veel voor de persoonlijke bagagelimiet.";
        }

        if($addedTotalWeight > $maxTotalWeight){
            $excessTotalWeight = $addedTotalWeight - $maxTotalWeight;
            $warnings[] = "Deze koffer weegt $excessTotalWeight kg te veel voor de totale bagagelimiet.";
        }
    }
}


function validatePasswordInput($wachtwoord, int $minLength, int $maxLength){
    global $warnings;

    validateTextInput($wachtwoord, $minLength, $maxLength);

    $wachtwoordArray = '';
    $integers = 0;

    if(!empty($wachtwoord)){
        $wachtwoordArray = str_split($wachtwoord);

        foreach($wachtwoordArray as $char) {
            if(is_numeric($char)){
                $integers++;
            }
        }
        if($integers == 0){
            $warnings[] = 'Wachtwoord moet minimaal 1 cijfer bevatten.';
        }
    }
}



?>