<?php
require_once("conn.php");

$query = 'SELECT req.*, sh."Name" AS shelterName, con."Point" AS pointName FROM "Requests" AS req INNER JOIN "Shelters" AS sh ON req."DeclarantShelterId" = sh."Id" INNER JOIN "Contracts" AS con ON req."ContractId" = con."Id"';

$result = pg_query($link, $query) or die("Ошибка $.result, ". pg_last_error($link));
	if($result)
	{
		$rows = pg_num_rows($result);
		if($rows > 0){
			for ($i = 0 ; $i < $rows ; ++$i)
		    {
		    	$row = pg_fetch_row($result);
				echo "<div class = 'col col-7-lg  animal border'>";
				    	echo "<input type='hidden' name='id_animal' value='$row[0]'>";
				    	echo "<p>Заявка №$row[0]</p>";
				    	echo "<p>Номер контракта: $row[1]</p>";
				    	echo "<p>Задание: $row[5]</p>";
				    	echo "<p>Заявил: $row[4]</p>";
			    echo "</div>";
			}
		}
		else{
			echo "<h3>Пока никого нет...</h3>";
		}
		
	}
pg_free_result($result);
pg_close($link);
?>